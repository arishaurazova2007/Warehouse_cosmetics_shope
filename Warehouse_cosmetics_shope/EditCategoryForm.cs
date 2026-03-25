using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class EditCategoryForm : Form
    {
        private int categoryId;
        private int currentUserId;
        public EditCategoryForm()
        {
            InitializeComponent();
            categoryId = 0;
        }
        public EditCategoryForm(int categoryId, int userId)
        {
            InitializeComponent();
            this.categoryId = categoryId;
            this.currentUserId = userId;
            LoadCategoryData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveCategory();
            EditForm editForm = new EditForm();
            editForm.Show();
            this.Hide();
        }
        private void buttonNewCategory_Click(object sender, EventArgs e)
        {
            NewCategoryForm newCategoryForm = new NewCategoryForm();
            newCategoryForm.Show();
            this.Hide();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteCategory(); // Метод для БД
            EditForm editForm = new EditForm();
            editForm.Show();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm();
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