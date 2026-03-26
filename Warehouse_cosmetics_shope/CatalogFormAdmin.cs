using System;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    public partial class CatalogFormAdmin : Form
    {
        private Guid currentUserId;
        public CatalogFormAdmin(Guid userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            var editForm = new EditForm();
            editForm.Show();
            this.Hide();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            var filterForm = new FiltrationForm();
            filterForm.Show();
            this.Hide();
        }
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            var historyForm = new HistoryChangeForm(currentUserId);
            historyForm.Show();
            this.Hide();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
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
        private void CatalogFormAdmin_Load(object sender, EventArgs e)
        {
            LoadCatalogData();
        }


    }    





}