using System;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.Properties;
namespace Warehouse_cosmetics_shope
{
    public partial class EditForm : Form
    {
        private Guid productId;
        private Guid currentUserId;
        private string currentUserLogin;
        public EditForm()
        {
            InitializeComponent();
        }
        public EditForm(Guid productId, Guid userId, string userLogin)
        {
            InitializeComponent();
            this.productId = productId;
            this.currentUserId = userId;
            this.currentUserLogin = userLogin;
            LoadProductData();
            LoadCategories();
            LoadTypes();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveProduct(); // Метод для БД
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }
        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            var editCategoryForm = new EditCategoryForm();
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
        private void Deletebutton_Click(object sender, EventArgs e)
        {
            //var confirmResult = MessageBox.Show(
            //    Resources.ConfirmDelete,
            //    Resources.ConfirmDeleteTitle,
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Warning);

            //if (confirmResult == DialogResult.Yes)
            //{
            //    DeleteProductFromCatalog();
            //    LogDeletionToHistory();
            //    var catalogForm = new CatalogFormAdmin(currentUserId);
            //    catalogForm.Show();
            //    this.Hide();
            //}
        }
        private void DeleteProductFromCatalog()
        {
            // удаление - установка флага IsDeleted = true
        }
        private void LogDeletionToHistory()
        {
            // Запись в историю изменений (удаление не удаляет историю)
            
        }
    }
}