using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope
{
    public partial class CatalogFormKlad : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;
        private List<Guid> currentFilterCategoryIds = null;

        public CatalogFormKlad(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;
            LoadCatalogData();
            ShowUserLogin();

            // Подписываемся на события
            kladCatalogGrid.CellClick += kladCatalogGrid_CellClick;
            kladCatalogGrid.CellFormatting += kladCatalogGrid_CellFormatting;
            searchBox.TextChanged += searchBox_TextChanged;
            searchBox.Enter += searchBox_Enter;
            searchBox.Leave += searchBox_Leave;
        }

        private void LoadCatalogData()
        {
            using (var db = new WarehouseContext())
            {
                var query = db.Items
                    .Include(i => i.Category)
                    .Include(i => i.Category.Parent)
                    .Where(i => i.Quantity > 0)
                    .AsQueryable();

                // Применение фильтра
                if (currentFilterCategoryIds != null && currentFilterCategoryIds.Any())
                {
                    query = query.Where(i => currentFilterCategoryIds.Contains(i.CategoryID));
                }

                var items = query.ToList();

                var displayList = items.Select(i => new
                {
                    i.ProductNumber,
                    i.ProductName,
                    ParentCategoryName = i.Category?.Parent?.CategoryName,
                    ChildCategoryName = i.Category?.CategoryName,
                    Units = GetUnitDisplayName(i.Units),
                    i.ManufDate,
                    i.ExpDate,
                    i.SellPrice,
                    i.Quantity
                }).ToList();

                kladCatalogGrid.DataSource = displayList;

                // Настройка заголовков
                kladCatalogGrid.Columns["ProductNumber"].HeaderText = "Артикул";
                kladCatalogGrid.Columns["ProductName"].HeaderText = "Название";
                kladCatalogGrid.Columns["ParentCategoryName"].HeaderText = "Категория";
                kladCatalogGrid.Columns["ParentCategoryName"].Visible = false;
                kladCatalogGrid.Columns["ChildCategoryName"].HeaderText = "Категория";
                kladCatalogGrid.Columns["Units"].HeaderText = "Ед. изм.";
                kladCatalogGrid.Columns["ManufDate"].HeaderText = "Дата производства";
                kladCatalogGrid.Columns["ManufDate"].Visible = false;
                kladCatalogGrid.Columns["ExpDate"].HeaderText = "Годен до";
                kladCatalogGrid.Columns["SellPrice"].HeaderText = "Цена продажи";
                kladCatalogGrid.Columns["Quantity"].HeaderText = "Остаток";

                // Форматирование
                kladCatalogGrid.Columns["SellPrice"].DefaultCellStyle.Format = "C2";
                kladCatalogGrid.Columns["ExpDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                kladCatalogGrid.Columns["ManufDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
        }

        private string GetUnitDisplayName(MeasurementUnits unit)
        {
            switch (unit)
            {
                case MeasurementUnits.Piece: return "Шт";
                case MeasurementUnits.Milliliter: return "Мл";
                case MeasurementUnits.Gram: return "Гр";
                default: return unit.ToString();
            }
        }

        private void ShowUserLogin()
        {
            if (labelShowLogin != null)
            {
                labelShowLogin.Text = $"Ваш логин: {currentUserLogin}";
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

            filterForm.FilterApplied += (selectedCategoryIds) =>
            {
                currentFilterCategoryIds = selectedCategoryIds;
                LoadCatalogData();
            };

            filterForm.ShowDialog();
        }

        private void buttonOtgruzka_Click(object sender, EventArgs e)
        {
            var otgruzkaForm = new OtgruzkaForm(currentUserId, currentUserLogin);
            otgruzkaForm.Show();
            this.Hide();
        }

        private void kladCatalogGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = kladCatalogGrid.Rows[e.RowIndex];
                int productNumber = (int)selectedRow.Cells["ProductNumber"].Value;

                using (var db = new WarehouseContext())
                {
                    var product = db.Items.FirstOrDefault(i => i.ProductNumber == productNumber);
                    if (product != null)
                    {
                        var itemForm = new ItemForm(product.ProductID, currentUserId, currentUserLogin);
                        itemForm.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void kladCatalogGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var expDateCell = kladCatalogGrid.Rows[e.RowIndex].Cells["ExpDate"];
            var manufDateCell = kladCatalogGrid.Rows[e.RowIndex].Cells["ManufDate"];

            if (expDateCell.Value == null) return;

            DateTime expDate = (DateTime)expDateCell.Value;
            DateTime today = DateTime.Now.Date;
            double totalDays;

            if (manufDateCell.Value != null)
            {
                DateTime manufDate = (DateTime)manufDateCell.Value;
                totalDays = (expDate - manufDate).TotalDays;
            }
            else
            {
                totalDays = 1095;
            }

            double daysRemaining = (expDate - today).TotalDays;
            double remainingPercent = daysRemaining / totalDays;

            if (remainingPercent < 0.33)
            {
                kladCatalogGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 157);

                if (kladCatalogGrid.Columns[e.ColumnIndex].Name == "SellPrice")
                {
                    decimal originalPrice = (decimal)kladCatalogGrid.Rows[e.RowIndex].Cells["SellPrice"].Value;
                    e.Value = originalPrice * 0.7m;
                    e.FormattingApplied = true;
                }
            }
            else
            {
                kladCatalogGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "Поиск")
            {
                searchBox.Text = string.Empty;
                searchBox.ForeColor = Color.Black;
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                searchBox.Text = "Поиск";
                searchBox.ForeColor = Color.Gray;
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text == "Поиск" || string.IsNullOrWhiteSpace(searchBox.Text))
            {
                LoadCatalogData();
                return;
            }

            string searchText = searchBox.Text.Trim().ToLower();

            using (var db = new WarehouseContext())
            {
                var query = db.Items
                    .Include(i => i.Category)
                    .Include(i => i.Category.Parent)
                    .AsQueryable();

                query = query.Where(i => i.ProductNumber.ToString().Contains(searchText) ||
                                         i.ProductName.ToLower().Contains(searchText));

                if (currentFilterCategoryIds != null && currentFilterCategoryIds.Any())
                {
                    query = query.Where(i => currentFilterCategoryIds.Contains(i.CategoryID));
                }

                var filteredItems = query.ToList();

                var displayList = filteredItems.Select(i => new
                {
                    i.ProductNumber,
                    i.ProductName,
                    ParentCategoryName = i.Category?.Parent?.CategoryName ?? string.Empty,
                    ChildCategoryName = i.Category?.CategoryName ?? string.Empty,
                    Units = GetUnitDisplayName(i.Units),
                    i.ManufDate,
                    i.ExpDate,
                    i.SellPrice,
                    i.Quantity
                }).ToList();

                kladCatalogGrid.DataSource = displayList;

                // Настройка заголовков после поиска
                kladCatalogGrid.Columns["ProductNumber"].HeaderText = "Артикул";
                kladCatalogGrid.Columns["ProductName"].HeaderText = "Название";
                kladCatalogGrid.Columns["ParentCategoryName"].HeaderText = "Категория";
                kladCatalogGrid.Columns["ParentCategoryName"].Visible = false;
                kladCatalogGrid.Columns["ChildCategoryName"].HeaderText = "Категория";
                kladCatalogGrid.Columns["Units"].HeaderText = "Ед. изм.";
                kladCatalogGrid.Columns["ManufDate"].Visible = false;
                kladCatalogGrid.Columns["ExpDate"].HeaderText = "Годен до";
                kladCatalogGrid.Columns["SellPrice"].HeaderText = "Цена продажи";
                kladCatalogGrid.Columns["Quantity"].HeaderText = "Остаток";

                kladCatalogGrid.Columns["SellPrice"].DefaultCellStyle.Format = "C2";
                kladCatalogGrid.Columns["ExpDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
        }
    }
}