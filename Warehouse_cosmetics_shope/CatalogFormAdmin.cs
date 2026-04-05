using System.Linq;
using System;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using System.Data.Entity;
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
                dataGridViewCatalog.Columns["ChildCategoryName"].HeaderText = "Вид";
                dataGridViewCatalog.Columns["Units"].HeaderText = "Ед. изм.";
                dataGridViewCatalog.Columns["ExpDate"].HeaderText = "Срок годности";
                dataGridViewCatalog.Columns["PurPrice"].HeaderText = "Цена закупки";
                dataGridViewCatalog.Columns["SellPrice"].HeaderText = "Цена продажи";
                dataGridViewCatalog.Columns["Quantity"].HeaderText = "Остаток";

                // Форматирование
                dataGridViewCatalog.Columns["PurPrice"].DefaultCellStyle.Format = "C2";
                dataGridViewCatalog.Columns["SellPrice"].DefaultCellStyle.Format = "C2";
                dataGridViewCatalog.Columns["ExpDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}