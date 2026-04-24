using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Helpers;

namespace Warehouse_cosmetics_shope
{
    public partial class FiltrationForm : Form
    {
        /// <summary>
        /// Событие, возникающее при применении фильтра. Передаёт выбранные категории и параметры фильтрации.
        /// </summary>
        public event Action<List<Guid>, decimal?, decimal?, bool?, bool?, bool?, bool?> FilterApplied;

        private List<CategoryInfo> _allCategories;

        /// <summary>
        /// Конструктор формы фильтрации
        /// </summary>
        public FiltrationForm()
        {
            InitializeComponent();
            LoadCategories();
            SetupCheckBoxes();
            Log.Information("Открыта форма фильтрации");
        }

        /// <summary>
        /// Настраивает взаимосвязь между чекбоксами (исключающий выбор)
        /// </summary>
        private void SetupCheckBoxes()
        {
            checkBoxInStock.CheckedChanged += (s, e) =>
            {
                if (checkBoxInStock.Checked) checkBoxNotInStock.Checked = false;
            };
            checkBoxNotInStock.CheckedChanged += (s, e) =>
            {
                if (checkBoxNotInStock.Checked) checkBoxInStock.Checked = false;
            };

            withDiscCheckBox.CheckedChanged += (s, e) =>
            {
                if (withDiscCheckBox.Checked) withoutDiscCheckBox.Checked = false;
            };
            withoutDiscCheckBox.CheckedChanged += (s, e) =>
            {
                if (withoutDiscCheckBox.Checked) withDiscCheckBox.Checked = false;
            };
        }

        /// <summary>
        /// Загружает категории в иерархическом виде с отступами
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var categories = db.Categories.ToList();
                    _allCategories = new List<CategoryInfo>();

                    foreach (var cat in categories.Where(c => c.ParentID == null).OrderBy(c => c.CategoryName))
                    {
                        AddCategoryWithChildren(cat, categories, 0);
                    }

                    categoriesCheckedListBox.DataSource = _allCategories;
                    categoriesCheckedListBox.DisplayMember = "DisplayName";
                    categoriesCheckedListBox.ValueMember = "CategoryID";

                    Log.Debug("Загружено {CategoryCount} категорий для фильтрации", _allCategories.Count);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке категорий для фильтрации");
                MessageBox.Show("Ошибка при загрузке категорий", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Рекурсивно добавляет категорию и всех её дочерних в список с отступами
        /// </summary>
        /// <param name="cat">Текущая категория</param>
        /// <param name="all">Список всех категорий</param>
        /// <param name="level">Уровень вложенности (для отступа)</param>
        private void AddCategoryWithChildren(Category cat, List<Category> all, int level)
        {
            _allCategories.Add(new CategoryInfo
            {
                CategoryID = cat.CategoryID,
                DisplayName = new string(' ', level * 4) + cat.CategoryName,
                ParentID = cat.ParentID
            });

            var children = all.Where(c => c.ParentID == cat.CategoryID).OrderBy(c => c.CategoryName);
            foreach (var child in children)
            {
                AddCategoryWithChildren(child, all, level + 1);
            }
        }

        /// <summary>
        /// Обработчик изменения состояния чекбокса категории (автоматически выбирает/снимает дочерние)
        /// </summary>
        private void categoriesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                var selected = _allCategories[e.Index];
                int startIndex = e.Index + 1;
                int endIndex = FindLastChildIndex(selected.CategoryID, startIndex);

                for (int i = startIndex; i <= endIndex; i++)
                {
                    categoriesCheckedListBox.SetItemChecked(i, e.NewValue == CheckState.Checked);
                }

                Log.Debug("Изменён выбор категории: {CategoryName} (новое состояние: {NewState})",
                    selected.DisplayName.Trim(), e.NewValue);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при обработке изменения выбора категории");
            }
        }

        /// <summary>
        /// Находит индекс последней дочерней категории для указанной родительской
        /// </summary>
        /// <param name="parentId">Идентификатор родительской категории</param>
        /// <param name="startIndex">Начальный индекс для поиска</param>
        /// <returns>Индекс последней дочерней категории</returns>
        private int FindLastChildIndex(Guid parentId, int startIndex)
        {
            int lastIndex = startIndex - 1;

            for (int i = startIndex; i < _allCategories.Count; i++)
            {
                if (IsDescendantOf(parentId, _allCategories[i].CategoryID))
                {
                    lastIndex = i;
                }
                else
                {
                    break;
                }
            }

            return lastIndex;
        }

        /// <summary>
        /// Проверяет, является ли категория потомком указанной родительской
        /// </summary>
        /// <param name="parentId">Идентификатор родительской категории</param>
        /// <param name="childId">Идентификатор проверяемой категории</param>
        /// <returns>true - если является потомком, false - иначе</returns>
        private bool IsDescendantOf(Guid parentId, Guid childId)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var current = db.Categories.FirstOrDefault(c => c.CategoryID == childId);
                    while (current != null)
                    {
                        if (current.ParentID == parentId) return true;
                        current = db.Categories.FirstOrDefault(c => c.CategoryID == current.ParentID);
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при проверке принадлежности категории {ChildId} к родителю {ParentId}", childId, parentId);
                return false;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Показать" (применяет фильтры)
        /// </summary>
        private void buttonShow_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCategoryIds = new List<Guid>();
                for (int i = 0; i < categoriesCheckedListBox.Items.Count; i++)
                {
                    if (categoriesCheckedListBox.GetItemChecked(i))
                    {
                        selectedCategoryIds.Add(_allCategories[i].CategoryID);
                    }
                }

                decimal? priceFrom = priceFromNumeric.Value > 0 ? priceFromNumeric.Value : (decimal?)null;
                decimal? priceTo = priceToNumeric.Value < 1000000 ? priceToNumeric.Value : (decimal?)null;

                bool? inStockOnly = checkBoxInStock.Checked ? true : (bool?)null;
                bool? notInStockOnly = checkBoxNotInStock.Checked ? true : (bool?)null;

                bool? withDiscount = withDiscCheckBox.Checked ? true : (bool?)null;
                bool? withoutDiscount = withoutDiscCheckBox.Checked ? true : (bool?)null;

                Log.Information("Применены фильтры: Категорий={CategoryCount}, Цена от={PriceFrom}, Цена до={PriceTo}, " +
                    "В наличии={InStock}, Нет в наличии={NotInStock}, Со скидкой={WithDiscount}, Без скидки={WithoutDiscount}",
                    selectedCategoryIds.Count, priceFrom, priceTo, inStockOnly, notInStockOnly, withDiscount, withoutDiscount);

                if (selectedCategoryIds.Count == 0)
                {
                    Log.Warning("Фильтр применён без выбора категорий");
                }

                FilterApplied?.Invoke(selectedCategoryIds, priceFrom, priceTo, inStockOnly, notInStockOnly, withDiscount, withoutDiscount);
                this.Close();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при применении фильтров");
                MessageBox.Show("Ошибка при применении фильтров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена"
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Log.Information("Фильтрация отменена пользователем");
            this.Close();
        }
    }
}