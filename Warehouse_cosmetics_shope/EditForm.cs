using System;
using System.Windows.Forms;
using System.Linq;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    public partial class EditForm : Form
    {
        private Guid productId;
        private Guid currentUserId;
        public EditForm()
        {
            InitializeComponent();
            productId = Guid.Empty;
        }
        public EditForm(Guid productId, Guid userId)
        {
            InitializeComponent();
            this.productId = productId;
            this.currentUserId = userId;
            if (productId != Guid.Empty)
            {
                LoadProductData();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveProduct(); // Метод для БД
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
        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            var editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
            this.Hide();
        }
        private void LoadProductData()
        {
            using (var db = new WarehouseContext())
            {
                var product = db.Items.Include("Category").FirstOrDefault(p => p.ProductID == productId);
                if (product != null)
                {
                    textBoxProductName.Text = product.ProductName;
                    textBoxPrice.Text = product.Price.ToString();
                    textBoxQuantity.Text = product.Quantity.ToString();
                    //ExpDate.Value = product.ExpDate;
                    
                }
            }
        }
        private void SaveProduct()
        {
            using (var db = new WarehouseContext())
            {
                Item product;
                if (productId == Guid.Empty)
                {
                    product = new Item { ProductID = Guid.NewGuid() };
                    db.Items.Add(product);
                }
                else
                {
                    product = db.Items.Find(productId);
                }
                product.ProductName = textBoxProductName.Text;
                product.Price = decimal.Parse(textBoxPrice.Text);
                product.Quantity = int.Parse(textBoxQuantity.Text);
                //product.ExpDate = ExpDate.Value;
                db.SaveChanges();
            }
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
            var confirmResult = MessageBox.Show(
                Resources.ConfirmDelete,
                Resources.ConfirmDeleteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                DeleteProductFromCatalog();
                LogDeletionToHistory();
                var catalogForm = new CatalogFormAdmin(currentUserId);
                catalogForm.Show();
                this.Hide();
            }
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