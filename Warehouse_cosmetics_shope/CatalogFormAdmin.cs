using System;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Properties;
namespace Warehouse_cosmetics_shope
{
    public partial class CatalogFormAdmin : Form
    {
        private Guid currentUserId;
        public CatalogFormAdmin(Guid userId)
        {
            InitializeComponent();
            currentUserId = userId;
            ShowCurrentUserId();
            LoadCatalogData();
            searchBox.GotFocus += SearchBox_GotFocus;
            searchBox.LostFocus += SearchBox_LostFocus;
            searchButton.Click += SearchButton_Click;
            dataGridViewProducts.CellDoubleClick += DataGridViewProducts_CellDoubleClick;
        }
        private void ShowCurrentUserId()
        {
            label3.Text = currentUserId.ToString();
        }
        private void SearchProducts()
        {
            string searchText = searchBox.Text.Trim();

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
        private void SearchBox_GotFocus(object sender, EventArgs e)
        {
            if (searchBox.Text == "Поиск")
            {
                searchBox.Text = "";
                searchBox.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void SearchBox_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                searchBox.Text = "Поиск";
                searchBox.ForeColor = System.Drawing.Color.Gray;
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchProducts();
        }
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            var editForm = new EditForm(Guid.Empty, currentUserId);
            editForm.Show();
            this.Hide();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            var filterForm = new FiltrationForm(currentUserId);
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
            try
            {
                using (var db = new WarehouseContext())
                {
                    var products = db.Items.Include(p => p.Category).ToList();

                    if (products.Count == 0)
                    {
                        MessageBox.Show("В каталоге пока нет товаров. Нажмите '+', чтобы добавить первый товар.");
                        dataGridViewProducts.DataSource = null;
                        return;
                    }

                    dataGridViewProducts.DataSource = products.Select(p => new
                    {
                        p.ProductID,               
                        Название = p.ProductName,  
                        Категория = p.Category,
                        Вид = p.Units,             
                        Цена = p.Price,            
                        Остаток = p.Quantity,      
                        Срок_годности = p.ExpDate 
                    }).ToList();

                    dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая ошибка при загрузке базы данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CatalogFormAdmin_Load(object sender, EventArgs e)
        {
            LoadCatalogData();
        }

        private void DataGridViewProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var productId = (Guid)dataGridViewProducts.Rows[e.RowIndex].Cells["ProductID"].Value;
                var editForm = new EditForm(productId, currentUserId);
                editForm.Show();
                this.Hide();
            }
        }
    }    
}