using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class EditForm : Form
    {
        private int productId;
        private int currentUserId;
        public EditForm()
        {
            InitializeComponent();
            productId = 0;
        }
        public EditForm(int productId, int userId)
        {
            InitializeComponent();
            this.productId = productId;
            this.currentUserId = userId;
            LoadProductData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveProduct(); // Метод для БД
            CatalogFormAdmin catalogForm = new CatalogFormAdmin(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            CatalogFormAdmin catalogForm = new CatalogFormAdmin(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            EditCategoryForm editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
            this.Hide();
        }
        private void LoadProductData()
        {
            // Загрузка данных товара (БД)
        }
        private void SaveProduct()
        {
            // Сохранение товара (БД)
        }
        private void LoadCategories()
        {
            // Загрузка категорий в ComboBox (БД)
        }
        private void LoadTypes()
        {
            // Загрузка видов в ComboBox (БД)
        }
        private void EditForm_Load(object sender, EventArgs e)
        {
            LoadCategories(); //  БД
            LoadTypes();      //  БД
        }
    }
}