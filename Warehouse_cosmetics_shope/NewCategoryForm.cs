using Serilog;
using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Helpers;

namespace Warehouse_cosmetics_shope
{
    public partial class NewCategoryForm : Form
    {
        private Guid currentUserId;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public NewCategoryForm()
        {
            InitializeComponent();
            LoadParentCategories();
            Log.Information("Открыта форма создания новой категории");
        }

        /// <summary>
        /// Конструктор с идентификатором пользователя
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        public NewCategoryForm(Guid userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
            LoadParentCategories();
            Log.Information("Пользователь {UserId} открыл форму создания категории", userId);
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить"
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddCategory();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Log.Information("Создание категории отменено");
            this.Hide();
        }

        /// <summary>
        /// Добавляет новую категорию в базу данных
        /// </summary>
        private void AddCategory()
        {
            if (string.IsNullOrWhiteSpace(categoryNameInput.Text))
            {
                Log.Warning("Попытка добавить категорию без названия");
                MessageBox.Show("Введите название категории", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoryNameInput.Focus();
                return;
            }

            Guid? parentId = null;
            string parentName = "Корневая категория";
            string newCategoryName = categoryNameInput.Text.Trim();

            if (parentCategoryComboBox.SelectedItem != null)
            {
                var selected = (CategoryPath)parentCategoryComboBox.SelectedItem;
                parentId = selected.CategoryID;
                parentName = selected.FullPath;
            }

            try
            {
                using (var db = new WarehouseContext())
                {
                    var existingCategory = db.Categories.FirstOrDefault(c => c.CategoryName == newCategoryName);
                    if (existingCategory != null)
                    {
                        Log.Warning("Попытка добавить существующую категорию '{CategoryName}'", newCategoryName);
                        MessageBox.Show($"Категория с названием \"{newCategoryName}\" уже существует!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        categoryNameInput.Focus();
                        return;
                    }

                    var newCategory = new Category
                    {
                        CategoryID = Guid.NewGuid(),
                        CategoryName = newCategoryName,
                        ParentID = parentId
                    };

                    db.Categories.Add(newCategory);
                    db.SaveChanges();

                    Log.Information("Создана новая категория: '{CategoryName}' (ID: {CategoryId}), родитель: {ParentName}",
                        newCategoryName, newCategory.CategoryID, parentName);

                    MessageBox.Show($"Категория \"{newCategoryName}\" успешно добавлена в {parentName}!",
                        "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при создании категории '{CategoryName}'", newCategoryName);
                MessageBox.Show("Ошибка при создании категории", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загружает список родительских категорий для выбора
        /// </summary>
        private void LoadParentCategories()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var allCategories = db.Categories.ToList();
                    var displayList = allCategories.Select(cat => new CategoryPath
                    {
                        CategoryID = cat.CategoryID,
                        FullPath = GetCategoryPath(cat.CategoryID, allCategories)
                    }).OrderBy(c => c.FullPath).ToList();

                    parentCategoryComboBox.DataSource = displayList;
                    parentCategoryComboBox.DisplayMember = "FullPath";
                    parentCategoryComboBox.ValueMember = "CategoryID";

                    parentCategoryComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    parentCategoryComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

                    Log.Debug("Загружено {CategoryCount} категорий для выбора родителя", displayList.Count);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке списка родительских категорий");
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
    }
}