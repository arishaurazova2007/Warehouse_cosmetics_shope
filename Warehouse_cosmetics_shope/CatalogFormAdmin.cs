using System.Linq;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using System.Drawing.Text;
namespace Warehouse_cosmetics_shope
{
    public partial class CatalogFormAdmin : Form
    {
        private string currentUserLogin;
        private Guid currentUserId;
        public CatalogFormAdmin(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;

            LoadCatalog();
            ShowUserLogin();
            dataGridViewCatalog.CellClick += dataGridViewCatalog_CellClick;
            dataGridViewCatalog.CellFormatting += dataGridViewCatalog_CellFormatting;
        }
        private void LoadCatalog()
        {
            using (var db = new WarehouseContext())
            {
                var items = db.Items
                    .Include(i => i.Category)
                    .Include(i => i.Category.Parent)
                    .ToList();

                var displayList = items.Select(i => new
                {
                    i.ProductNumber,
                    i.ProductName,
                    ParentCategoryName = i.Category?.Parent?.CategoryName,
                    ChildCategoryName = i.Category?.CategoryName,
                    Units = GetUnitDisplayName(i.Units),
                    i.ManufDate,
                    i.ExpDate,
                    i.PurPrice,
                    i.SellPrice,
                    i.Quantity
                }).ToList();

                dataGridViewCatalog.DataSource = displayList;

                // Настройка заголовков
                dataGridViewCatalog.Columns["ProductNumber"].HeaderText = "Артикул";
                dataGridViewCatalog.Columns["ProductName"].HeaderText = "Название";
                dataGridViewCatalog.Columns["ParentCategoryName"].HeaderText = "Категория";
                dataGridViewCatalog.Columns["ParentCategoryName"].Visible = false;
                dataGridViewCatalog.Columns["ChildCategoryName"].HeaderText = "Категория";
                dataGridViewCatalog.Columns["Units"].HeaderText = "Ед. изм.";
                dataGridViewCatalog.Columns["ManufDate"].HeaderText = "Дата производства";
                dataGridViewCatalog.Columns["ManufDate"].Visible = false;
                dataGridViewCatalog.Columns["ExpDate"].HeaderText = "Годен до";
                dataGridViewCatalog.Columns["PurPrice"].HeaderText = "Цена закупки";
                dataGridViewCatalog.Columns["SellPrice"].HeaderText = "Цена продажи";
                dataGridViewCatalog.Columns["Quantity"].HeaderText = "Остаток";

                // Форматирование
                dataGridViewCatalog.Columns["PurPrice"].DefaultCellStyle.Format = "C2";
                dataGridViewCatalog.Columns["SellPrice"].DefaultCellStyle.Format = "C2";
                dataGridViewCatalog.Columns["ExpDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dataGridViewCatalog.Columns["ManufDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
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
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            var itemForm = new ItemForm(Guid.Empty, currentUserId, currentUserLogin);
            itemForm.Show();
            this.Hide();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            var filterForm = new FiltrationForm();  
            filterForm.Show();
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
        private void dataGridViewCatalog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Получаем выбранный товар
                var selectedRow = dataGridViewCatalog.Rows[e.RowIndex];
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
        private void dataGridViewCatalog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем, что это строка с данными (не заголовок)
            if (e.RowIndex < 0) return;

            // Получаем дату истечения срока годности из нужной колонки
            var expDateCell = dataGridViewCatalog.Rows[e.RowIndex].Cells["ExpDate"];
            var manufDateCell = dataGridViewCatalog.Rows[e.RowIndex].Cells["ManufDate"];
            
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
                //если нет даты изготовления, используем стандартный срок (например, 3 года)
                totalDays = 1095;
            }

            //вычисляем, сколько процентов срока осталось
            double daysRemaining = (expDate - today).TotalDays;
            double remainingPercent = daysRemaining / totalDays;

            if (remainingPercent < 0.33)
            {
                dataGridViewCatalog.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 196, 150);
            }

            else
            {
                dataGridViewCatalog.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "Поиск")
            {
                searchBox.Text = String.Empty;
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
            // Игнорируем, если текст равен "Поиск" или пустой
            if (searchBox.Text == "Поиск" || string.IsNullOrWhiteSpace(searchBox.Text))
            {
                // Если ничего не введено - показываем все товары
                LoadCatalog();
                return;
            }

            string searchText = searchBox.Text.Trim().ToLower();

            using (var db = new WarehouseContext())
            {
                var filteredItems = db.Items
                    .Where(i => i.ProductNumber.ToString().Contains(searchText) ||
                                i.ProductName.ToLower().Contains(searchText))
                    .ToList();

                // Формируем данные для отображения
                var displayList = filteredItems.Select(i => new
                {
                    i.ProductNumber,
                    i.ProductName,
                    ParentCategoryName = i.Category?.Parent?.CategoryName ?? String.Empty,
                    ChildCategoryName = i.Category?.CategoryName ?? String.Empty,
                    Units = GetUnitDisplayName(i.Units),
                    i.ManufDate,
                    i.ExpDate,
                    i.PurPrice,
                    i.SellPrice,
                    i.Quantity
                }).ToList();

                dataGridViewCatalog.DataSource = displayList;
            }
        }
    }
}