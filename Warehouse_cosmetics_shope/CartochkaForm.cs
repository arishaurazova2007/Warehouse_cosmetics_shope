using System;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity; 
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    public partial class CartochkaForm : Form
    {
        private Guid currentUserId;
        private Guid productId;

        public CartochkaForm(Guid userId, Guid productId)
        {
            InitializeComponent();
            this.currentUserId = userId;
            this.productId = productId;
            LoadProductData();
        }
        private void LoadProductData()
        {
            using (var db = new WarehouseContext())
            {
                if (this.IsDisposed) return; // Если форма уже закрыта — ничего не делаем
                try
                {
                    // Ищем товар по ID, который передали в конструктор
                    var product = db.Items.Include("Category").FirstOrDefault(p => p.ProductID == productId);

                    if (product != null)
                    {
                        textBoxName.Text = product.ProductName;
                        textBoxArtikul.Text = product.ProductID.ToString();
                        textBoxCategory.Text = product.Category?.CategoryName;
                        textBoxUnits.Text = product.Units.ToString();
                        textBoxType.Text = product.Category?.CategoryName; 
                        textBoxExpDate.Text = product.ExpDate.ToString("dd.MM.yyyy");  
                        textBoxUnits.Text = product.Units.ToString();
                        textBoxPrise.Text = product.Price.ToString();
                        textBoxOstat.Text = product.Quantity.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Товар не найден в базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            CatalogFormKlad catalogForm = new CatalogFormKlad(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
    }
}
