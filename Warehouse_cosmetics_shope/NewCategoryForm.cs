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
        public NewCategoryForm()
        {
            InitializeComponent();
            LoadParentCategories();
        }
        public NewCategoryForm(Guid userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
            LoadParentCategories();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddCategory();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void AddCategory()
        {
            if (string.IsNullOrWhiteSpace(categoryNameInput.Text))
            {
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
            using (var db = new WarehouseContext())
            {
                var existingCategory = db.Categories.FirstOrDefault(c => c.CategoryName == newCategoryName);
                if (existingCategory != null)
                {
                    MessageBox.Show($"Категория с названием \"{newCategoryName}\" уже существует!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    categoryNameInput.Focus();
                    return;
                }
                else
                {
                    var newCategory = new Category
                    {
                        CategoryID = Guid.NewGuid(),
                        CategoryName = newCategoryName,
                        ParentID = parentId
                    };

                    db.Categories.Add(newCategory);
                    db.SaveChanges();

                    MessageBox.Show($"Категория \"{newCategoryName}\" успешно добавлена в {parentName}!",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
        }
        private void LoadParentCategories()
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
            }
        }
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

        private void newCategoryFormLabel_Click(object sender, EventArgs e)
        {

        }
    }
}