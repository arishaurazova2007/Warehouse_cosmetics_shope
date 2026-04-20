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
        public EditCategoryForm()
        {
            InitializeComponent();
            categoryId = Guid.Empty;
            LoadCategories();
        }
        public EditCategoryForm(Guid categoryId, Guid userId)
        {
            InitializeComponent();
            this.categoryId = categoryId;
            this.currentUserId = userId;
            LoadCategories();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveCategory();
            this.Hide();
        }
        private void buttonNewCategory_Click(object sender, EventArgs e)
        {
            var newCategoryForm = new NewCategoryForm();
            newCategoryForm.Show();
            this.Hide();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteCategory();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void LoadCategories()
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
            }
        }

        /// <summary>
        /// Получение полного пути категории (рекурсивно)
        /// </summary>
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
        private void SaveCategory()
        {
            //проверяем, выбрана ли категория
            if (categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию для редактирования", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //проверяем, введено ли новое название
            if (string.IsNullOrWhiteSpace(categoryNameInput.Text))
            {
                MessageBox.Show("Введите новое название категории", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoryNameInput.Focus();
                return;
            }

            Guid selectedCategoryId = (Guid)categoryComboBox.SelectedValue;
            string newName = categoryNameInput.Text.Trim();

            using (var db = new WarehouseContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.CategoryID == selectedCategoryId);
                if (category != null)
                {
                    category.CategoryName = newName;
                    db.SaveChanges();

                    MessageBox.Show($"Категория успешно переименована в \"{newName}\"!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Категория не найдена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadCategories();
        }

        private void DeleteCategory()
        {
            using (var db = new WarehouseContext())
            {
                if (categoryComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите категорию для удаления", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Guid selectedCategoryId = (Guid)categoryComboBox.SelectedValue;
                var checkResult = MessageBox.Show($"Вы уверены, что хотите удалить данную категорию?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (checkResult != DialogResult.Yes) return;
                
                var hasItems = db.Items.Any(i => i.CategoryID == selectedCategoryId);
                if (hasItems)
                {
                    MessageBox.Show("Нельзя удалить категорию, в которой есть товары. Сначала удалите или переместите товары.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
                var category = db.Categories.FirstOrDefault(c => c.CategoryID == selectedCategoryId);
                if (category != null)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();

                    MessageBox.Show("Категория удалена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("Категория не найдена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}