using System;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    public partial class CatalogFormKlad : Form
    {
        private Guid currentUserId;
        public CatalogFormKlad()
        {
            InitializeComponent();
            LoadCatalogData();
        }
        private void LoadCatalogData()
        {
            using (var db = new WarehouseContext())
            {
                var products = db.Items.Include("Category").ToList();
                dataGridViewProducts.DataSource = products.Select(p => new
                {
                    p.ProductID,
                    p.ProductName,
                    Категория = p.Category.CategoryName,
                    p.Price,
                    p.Quantity,
                    p.Units,
                    p.ExpDate
                }).ToList();
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            var filterForm = new FiltrationForm();
            filterForm.Show();
            this.Hide();
        }
        private void buttonOtgruzka_Click(object sender, EventArgs e)
        {
            var otgruzkaForm = new OtgruzkaForm();
            otgruzkaForm.Show();
            this.Hide();
        }
        private void CatalogFormKlad_Load(object sender, EventArgs e)
        {
            LoadCatalogData();
        }
    }

}