using System;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using BCrypt.Net;
using Warehouse_cosmetics_shope.Properties;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    public partial class CatalogFormKlad : Form
    {
      
        private Guid currentUserId;
        public CatalogFormKlad(Guid userId)
        {
            InitializeComponent();
            textBoxSearch.GotFocus += TextBox1_GotFocus;
            textBoxSearch.LostFocus += TextBox1_LostFocus;
            dataGridViewProducts.CellDoubleClick += DataGridViewProducts_CellDoubleClick;
            currentUserId = userId;
            ShowCurrentUserId();
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
            var filterForm = new FiltrationForm(currentUserId);
            filterForm.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SearchProducts();
        }
        private void SearchProducts()
        {
            string searchText = textBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText) || searchText == "Поиск")
            {
                LoadCatalogData();
                return;
            }

            using (var db = new WarehouseContext())
            {
                var products = db.Items.Include("Category")
                    .Where(p => p.ProductName.Contains(searchText) ||
                               p.ProductID.ToString().Contains(searchText))
                    .ToList();

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
        private void buttonOtgruzka_Click(object sender, EventArgs e)
        {
            var otgruzkaForm = new OtgruzkaForm(currentUserId);
            otgruzkaForm.Show();
            this.Hide();
        }
        private void CatalogFormKlad_Load(object sender, EventArgs e)
        {
            LoadCatalogData();
        }
        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "Поиск")
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                textBoxSearch.Text = "Поиск";
                textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            }
        }
        private void ShowCurrentUserId()
        {
            labelID.Text = currentUserId.ToString();
        }
        private void DataGridViewProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var productId = (Guid)dataGridViewProducts.Rows[e.RowIndex].Cells["ProductID"].Value;
                var cartochkaForm = new EditForm(productId, currentUserId);
                cartochkaForm.Show();
                this.Hide();
            }
        }
    }
}