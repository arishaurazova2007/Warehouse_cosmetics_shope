using System;
using System.Windows.Forms;
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
            var editForm = new EditForm();
            editForm.Show();
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
            DeleteCategory(); // Метод для БД
            var editForm = new EditForm();
            editForm.Show();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var editForm = new EditForm();
            editForm.Show();
            this.Hide();
        }
        private void LoadCategoryData()
        {
            // код для загрузки данных из БД
        }
        private void SaveCategory()
        {
            //код для сохранения в БД
        }
        private void DeleteCategory()
        {

        }
        private void EditCategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategoryData();
        }
    }
}