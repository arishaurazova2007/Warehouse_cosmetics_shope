using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using System.Data.Entity;
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
        }
        public EditCategoryForm(Guid categoryId, Guid userId)
        {
            InitializeComponent();
            this.categoryId = categoryId;
            this.currentUserId = userId;
            LoadCategoryData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveCategory();
            var catalogForm = new CatalogFormAdmin(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
        private void buttonNewCategory_Click(object sender, EventArgs e)
        {
            var newCategoryForm = new NewCategoryForm(currentUserId);
            newCategoryForm.Show();
            this.Hide();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteCategory();
            var catalogForm = new CatalogFormAdmin(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
        private void LoadCategoryData()
        {
            if (categoryId == Guid.Empty) return;

            using (var db = new WarehouseContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.CategoryID == categoryId);
                if (category != null)
                {
                    textBoxCategoryName.Text = category.CategoryName;
                }
            }
        }
        private void SaveCategory()
        {
            string newName = textBoxCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Название не может быть пустым!");
                return;
            }

            using (var db = new WarehouseContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.CategoryID == categoryId);
                if (category != null)
                {
                    category.CategoryName = newName;
                    db.SaveChanges();
                    MessageBox.Show("Категория обновлена!");
                }
            }
        }
        private void DeleteCategory()
        {
            var result = MessageBox.Show("Вы уверены? Все товары этой категории останутся без привязки!", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var db = new WarehouseContext())
                {
                    var category = db.Categories.FirstOrDefault(c => c.CategoryID == categoryId);
                    if (category != null)
                    {
                        db.Categories.Remove(category);
                        db.SaveChanges();
                    }
                }
            }
        }
        private void EditCategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategoryData();
        }
    }
}