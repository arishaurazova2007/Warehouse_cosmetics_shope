using Serilog;
using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Helpers;

namespace Warehouse_cosmetics_shope
{
    public partial class EditCategoryForm : Form
    {
        private Guid categoryId;
        private Guid currentUserId;

        /// <summary>
        /// Конструктор по умолчанию (для создания новой категории)
        /// </summary>
        public EditCategoryForm()
        {
            InitializeComponent();
            categoryId = Guid.Empty;
            LoadCategories();
        }

        /// <summary>
        /// Конструктор для редактирования существующей категории
        /// </summary>
        /// <param name="categoryId">Идентификатор редактируемой категории</param>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        public EditCategoryForm(Guid categoryId, Guid userId)
        {
            InitializeComponent();
            this.categoryId = categoryId;
            this.currentUserId = userId;
            Log.Information("Открыта форма редактирования категории с ID {CategoryId}", categoryId);
            LoadCategories();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveCategory();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Новая категория"
        /// </summary>
        private void buttonNewCategory_Click(object sender, EventArgs e)
        {
            Log.Information("Открыта форма создания новой категории");
            var newCategoryForm = new NewCategoryForm();
            newCategoryForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Удалить"
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteCategory();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Загружает список категорий с полными путями в выпадающий список
        /// </summary>
        private void LoadCategories()
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

                    categoryComboBox.DataSource = displayList;
                    categoryComboBox.DisplayMember = "FullPath";
                    categoryComboBox.ValueMember = "CategoryID";

                    categoryComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    categoryComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

                    Log.Debug("Загружено {CategoryCount} категорий", displayList.Count);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке категорий");
                MessageBox.Show("Ошибка при загрузке категорий", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получение полного пути категории
        /// </summary>
        /// <param name="categoryId">Идентификатор категории</param>
        /// <param name="allCategories">Список всех категорий</param>
        /// <returns>Полный путь категории в формате "Родитель → Дочерняя → Внучатая"</returns>
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
        /// Сохраняет изменения названия категории
        /// </summary>
        private void SaveCategory()
        {
            // Проверяем, выбрана ли категория
            if (categoryComboBox.SelectedItem == null)
            {
                Log.Warning("Попытка сохранить категорию без выбора");
                MessageBox.Show("Выберите категорию для редактирования", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, введено ли новое название
            if (string.IsNullOrWhiteSpace(categoryNameInput.Text))
            {
                Log.Warning("Попытка сохранить категорию с пустым названием");
                MessageBox.Show("Введите новое название категории", "Ошибka",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoryNameInput.Focus();
                return;
            }

            Guid selectedCategoryId = (Guid)categoryComboBox.SelectedValue;
            string newName = categoryNameInput.Text.Trim();

            try
            {
                using (var db = new WarehouseContext())
                {
                    var category = db.Categories.FirstOrDefault(c => c.CategoryID == selectedCategoryId);
                    if (category != null)
                    {
                        string oldName = category.CategoryName;
                        category.CategoryName = newName;
                        db.SaveChanges();

                        Log.Information("Категория переименована: '{OldName}' → '{NewName}' (ID: {CategoryId})",
                            oldName, newName, selectedCategoryId);

                        MessageBox.Show($"Категория успешно переименована в \"{newName}\"!", "Оповещение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Log.Warning("Категория с ID {CategoryId} не найдена при сохранении", selectedCategoryId);
                        MessageBox.Show("Категория не найдена", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при сохранении категории ID {CategoryId}", selectedCategoryId);
                MessageBox.Show("Ошибка при сохранении категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadCategories();
        }

        /// <summary>
        /// Удаляет выбранную категорию 
        /// </summary>
        private void DeleteCategory()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    if (categoryComboBox.SelectedItem == null)
                    {
                        Log.Warning("Попытка удалить категорию без выбора");
                        MessageBox.Show("Выберите категорию для удаления", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Guid selectedCategoryId = (Guid)categoryComboBox.SelectedValue;
                    string categoryName = categoryComboBox.Text;

                    var checkResult = MessageBox.Show($"Вы уверены, что хотите удалить категорию \"{categoryName}\"?",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (checkResult != DialogResult.Yes) return;

                    //проверяем, есть ли товары в этой категории
                    var hasItems = db.Items.Any(i => i.CategoryID == selectedCategoryId);
                    if (hasItems)
                    {
                        Log.Warning("Попытка удалить категорию '{CategoryName}' с товарами", categoryName);
                        MessageBox.Show("Нельзя удалить категорию, в которой есть товары. Сначала удалите или переместите товары.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var category = db.Categories.FirstOrDefault(c => c.CategoryID == selectedCategoryId);
                    if (category != null)
                    {
                        db.Categories.Remove(category);
                        db.SaveChanges();

                        Log.Information("Категория '{CategoryName}' (ID: {CategoryId}) удалена", categoryName, selectedCategoryId);

                        MessageBox.Show("Категория удалена!", "Оповещение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadCategories();
                    }
                    else
                    {
                        Log.Warning("Категория с ID {CategoryId} не найдена при удалении", selectedCategoryId);
                        MessageBox.Show("Категория не найдена", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при удалении категории");
                MessageBox.Show("Ошибка при удалении категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}