using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;
using Serilog;

namespace Warehouse_cosmetics_shope
{
    public partial class NewItemForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;

        /// <summary>
        /// Конструктор формы создания новой карточки товара
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="userLogin">Логин текущего пользователя</param>
        public NewItemForm(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;

            Log.Information("Пользователь {UserLogin} открыл форму создания нового товара", currentUserLogin);

            LoadCategories();
            LoadUnits();
        }

        /// <summary>
        /// Загружает категории товаров в выпадающий список
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var allCategories = db.Categories.ToList();
                    var displayList = allCategories.Select(cat => new
                    {
                        CategoryID = cat.CategoryID,
                        FullPath = GetCategoryPath(cat.CategoryID, allCategories)
                    }).OrderBy(c => c.FullPath).ToList();

                    categoryComboBox.DataSource = displayList;
                    categoryComboBox.DisplayMember = "FullPath";
                    categoryComboBox.ValueMember = "CategoryID";

                    Log.Debug("Загружено {CategoryCount} категорий", displayList.Count);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке категорий");
                MessageBox.Show("Ошибка при загрузке категорий", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получение полного пути категории (рекурсивно)
        /// </summary>
        /// <param name="categoryId">Идентификатор категории</param>
        /// <param name="allCategories">Список всех категорий</param>
        /// <returns>Полный путь категории в формате "Родитель → Дочерняя"</returns>
        private string GetCategoryPath(Guid categoryId, System.Collections.Generic.List<Category> allCategories)
        {
            var path = new System.Collections.Generic.List<string>();
            var current = allCategories.FirstOrDefault(c => c.CategoryID == categoryId);

            while (current != null)
            {
                path.Insert(0, current.CategoryName);
                current = allCategories.FirstOrDefault(c => c.CategoryID == current.ParentID);
            }

            return string.Join(" → ", path);
        }

        /// <summary>
        /// Загружает единицы измерения в выпадающий список
        /// </summary>
        private void LoadUnits()
        {
            try
            {
                var units = System.Enum.GetValues(typeof(MeasurementUnits))
                    .Cast<MeasurementUnits>()
                    .Select(u => new { Value = u, Display = GetUnitDisplayName(u) })
                    .ToList();

                unitComboBox.DataSource = units;
                unitComboBox.DisplayMember = "Display";
                unitComboBox.ValueMember = "Value";

                Log.Debug("Загружены единицы измерения");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке единиц измерения");
                MessageBox.Show("Ошибка при загрузке единиц измерения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Возвращает русское название единицы измерения
        /// </summary>
        /// <param name="unit">Единица измерения</param>
        /// <returns>Русское название единицы измерения</returns>
        private string GetUnitDisplayName(MeasurementUnits unit)
        {
            switch (unit)
            {
                case MeasurementUnits.Piece: return "Шт";
                case MeasurementUnits.Milliliter: return "Мл";
                case MeasurementUnits.Gram: return "Гр";
                default: return unit.ToString();
            }
        }

        /// <summary>
        /// Проверяет корректность заполнения формы
        /// </summary>
        /// <returns>true - если данные валидны, false - если есть ошибки</returns>
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(productNameTextBox.Text))
            {
                Log.Warning("Попытка создать товар без наименования");
                MessageBox.Show("Введите наименование товара", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                productNameTextBox.Focus();
                return false;
            }

            if (categoryComboBox.SelectedItem == null)
            {
                Log.Warning("Попытка создать товар без выбора категории");
                MessageBox.Show("Выберите категорию", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoryComboBox.Focus();
                return false;
            }

            if (unitComboBox.SelectedItem == null)
            {
                Log.Warning("Попытка создать товар без выбора единицы измерения");
                MessageBox.Show("Выберите единицу измерения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                unitComboBox.Focus();
                return false;
            }

            if (sellPriceNumeric.Value <= 0)
            {
                Log.Warning("Попытка создать товар с некорректной ценой продажи: {Price}", sellPriceNumeric.Value);
                MessageBox.Show("Цена продажи должна быть больше 0", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sellPriceNumeric.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                using (var db = new WarehouseContext())
                {
                    var newProduct = new Item
                    {
                        ProductID = Guid.NewGuid(),
                        ProductName = productNameTextBox.Text.Trim(),
                        CategoryID = (Guid)categoryComboBox.SelectedValue,
                        PurPrice = 0,
                        SellPrice = sellPriceNumeric.Value,
                        Quantity = 0,
                        Units = (MeasurementUnits)unitComboBox.SelectedValue,
                        ExpDate = DateTime.Now.AddYears(3),
                        ManufDate = DateTime.Now
                    };

                    db.Items.Add(newProduct);
                    db.SaveChanges();

                    Log.Information("Создана карточка товара: {ProductName}, артикул: {ProductNumber}",
                        newProduct.ProductName, newProduct.ProductNumber);

                    MessageBox.Show($"Карточка товара создана!\nАртикул: {newProduct.ProductNumber}\n\nДля добавления товара на склад оформите поставку.",
                        "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при создании карточки товара {ProductName}", productNameTextBox.Text);
                MessageBox.Show("Ошибка при создании карточки товара", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Log.Information("Пользователь {UserLogin} отменил создание товара", currentUserLogin);
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }
    }
}