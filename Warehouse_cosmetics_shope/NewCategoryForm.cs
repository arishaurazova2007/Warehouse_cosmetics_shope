using System;
using System.Windows.Forms;
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
            AddCategory(); // Сохранение в БД
            var editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var editCategoryForm = new EditCategoryForm();
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