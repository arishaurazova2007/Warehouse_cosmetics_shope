using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;  // ← ДОБАВИТЬ
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Properties;  // ← ДОБАВИТЬ

namespace Warehouse_cosmetics_shope
{
    public partial class NewCategoryForm : Form
    {
        private Guid currentUserId;

        public NewCategoryForm()
        {
            InitializeComponent();
        }
        public NewCategoryForm(Guid userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (AddCategory())  // ← ПРОВЕРКА: успешно ли сохранено
            {
                var editCategoryForm = new EditCategoryForm(Guid.Empty, currentUserId);  // ← ИСПРАВЛЕНО
                editCategoryForm.Show();
                this.Hide();
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var editCategoryForm = new EditCategoryForm(Guid.Empty, currentUserId);  // ← ИСПРАВЛЕНО
            editCategoryForm.Show();
            this.Hide();
        }
        private bool AddCategory()  
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(textBoxCategoryName.Text))
            {
                MessageBox.Show(Resources.EnterCategoryName, Resources.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCategoryName.Focus();
                return false;
            }
            try
            {
                using (var db = new WarehouseContext())
                {
                    // Проверяем, нет ли такой категории
                    var existingCategory = db.Categories
                        .FirstOrDefault(c => c.CategoryName == textBoxCategoryName.Text.Trim());
                    if (existingCategory != null)
                    {
                        MessageBox.Show(Resources.CategoryAlreadyExists, Resources.Error,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    // Создаём новую категорию
                    var newCategory = new Category
                    {
                        CategoryID = Guid.NewGuid(),
                        CategoryName = textBoxCategoryName.Text.Trim(),
                        ParentID = comboBoxParentCategory.SelectedValue as Guid?  // Может быть null
                    };
                    db.Categories.Add(newCategory);
                    db.SaveChanges();

                    MessageBox.Show(Resources.CategoryAdded, Resources.Success,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Resources.ErrorAddingCategory, ex.Message),
                    Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void LoadParentCategories()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var categories = db.Categories.ToList();
                    comboBoxParentCategory.DataSource = categories;
                    comboBoxParentCategory.DisplayMember = "CategoryName";
                    comboBoxParentCategory.ValueMember = "CategoryID";
                    comboBoxParentCategory.SelectedIndex = -1;  // Ничего не выбрано
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Resources.ErrorLoadingCategories, ex.Message),
                    Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NewCategoryForm_Load(object sender, EventArgs e)
        {
            LoadParentCategories();
        }
    }
}