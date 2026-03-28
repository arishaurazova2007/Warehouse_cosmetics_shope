using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Properties;
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
            filterForm.OnFilterApplied += ApplyFilterFromFiltrationForm;  // ← ДОБАВИТЬ
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
        private void ApplyFilterFromFiltrationForm(FilterCriteria criteria)
        {
            using (var db = new WarehouseContext())
            {
                var query = db.Items.Include("Category").AsQueryable();

                // Фильтр по категориям
                if (criteria.CategoryPerfumeMen || criteria.CategoryPerfumeWomen || criteria.CategoryCosmetics)
                {
                    var categoryIds = new List<Guid>();

                    if (criteria.CategoryPerfumeMen)
                    {
                        var catId = db.Categories.FirstOrDefault(c => c.CategoryName == "Мужская парфюмерия")?.CategoryID;
                        if (catId != null) categoryIds.Add(catId.Value);
                    }
                    if (criteria.CategoryPerfumeWomen)
                    {
                        var catId = db.Categories.FirstOrDefault(c => c.CategoryName == "Женская парфюмерия")?.CategoryID;
                        if (catId != null) categoryIds.Add(catId.Value);
                    }
                    if (criteria.CategoryCosmetics)
                    {
                        var catId = db.Categories.FirstOrDefault(c => c.CategoryName == "Косметика")?.CategoryID;
                        if (catId != null) categoryIds.Add(catId.Value);
                    }

                    if (categoryIds.Count > 0)
                    {
                        query = query.Where(p => categoryIds.Contains(p.CategoryID));
                    }
                }
                // Фильтр по видам
                if (criteria.TypePerfume || criteria.TypePerfumeWater || criteria.TypeToiletWater ||
                    criteria.TypeCare || criteria.TypeDecor)
                {
                    var typeIds = new List<Guid>();

                    if (criteria.TypePerfume)
                    {
                        var ids = db.Categories.Where(c => c.CategoryName.Contains("Духи")).Select(c => c.CategoryID).ToList();
                        typeIds.AddRange(ids);
                    }
                    if (criteria.TypePerfumeWater)
                    {
                        var ids = db.Categories.Where(c => c.CategoryName.Contains("Парфюмерная вода")).Select(c => c.CategoryID).ToList();
                        typeIds.AddRange(ids);
                    }
                    if (criteria.TypeToiletWater)
                    {
                        var ids = db.Categories.Where(c => c.CategoryName.Contains("Туалетная вода")).Select(c => c.CategoryID).ToList();
                        typeIds.AddRange(ids);
                    }
                    if (criteria.TypeCare)
                    {
                        var ids = db.Categories.Where(c => c.CategoryName.Contains("Уходовая")).Select(c => c.CategoryID).ToList();
                        typeIds.AddRange(ids);
                    }
                    if (criteria.TypeDecor)
                    {
                        var ids = db.Categories.Where(c => c.CategoryName.Contains("Декоративная")).Select(c => c.CategoryID).ToList();
                        typeIds.AddRange(ids);
                    }

                    if (typeIds.Count > 0)
                    {
                        query = query.Where(p => typeIds.Contains(p.CategoryID));
                    }
                }
                // Фильтр по цене
                if (!string.IsNullOrWhiteSpace(criteria.PriceFrom))
                {
                    if (decimal.TryParse(criteria.PriceFrom, out decimal priceFrom))
                    {
                        query = query.Where(p => p.Price >= priceFrom);
                    }
                }
                if (!string.IsNullOrWhiteSpace(criteria.PriceTo))
                {
                    if (decimal.TryParse(criteria.PriceTo, out decimal priceTo))
                    {
                        query = query.Where(p => p.Price <= priceTo);
                    }
                }
                // Фильтр по наличию
                if (criteria.InStock && !criteria.NotInStock)
                {
                    query = query.Where(p => p.Quantity > 0);
                }
                else if (criteria.NotInStock && !criteria.InStock)
                {
                    query = query.Where(p => p.Quantity == 0);
                }
                // применяю фильтр
                var products = query.ToList();

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
    }
}