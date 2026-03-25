using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class NewCategoryForm : Form
    {
        private int currentUserId;
        public NewCategoryForm()
        {
            InitializeComponent();
        }
        public NewCategoryForm(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddCategory(); // Сохранение в БД
            EditCategoryForm editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            EditCategoryForm editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
            this.Hide();
        }
        private void AddCategory()
        {
        }
        private void LoadParentCategories()
        {
            // Загрузка родительских категорий в ComboBox
        }
        private void NewCategoryForm_Load(object sender, EventArgs e)
        {
            LoadParentCategories();
        }
    }
}