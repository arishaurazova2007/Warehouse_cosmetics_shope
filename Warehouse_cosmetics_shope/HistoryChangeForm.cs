using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    public partial class HistoryChangeForm : Form
    {
        private Guid currentUserId;
        public HistoryChangeForm(Guid userId)
        {
            InitializeComponent();
            currentUserId = userId;

            dataGridViewHistory.AutoGenerateColumns = true;
            dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        // Загрузка истории изменений
        private void LoadHistoryData()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var products = db.Items.Include("Category").ToList();

                    if (products.Count == 0) return;
                    dataGridViewHistory.DataSource = products.Select(p => new
                    {
                        ID = p.ProductID,
                        Наименование = p.ProductName,
                        Категория = p.Category,
                        Статус = "В наличии", // Просто текст для красоты
                        Последнее_обновление = DateTime.Now.ToShortDateString()
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void HistoryChangeForm_Load(object sender, EventArgs e)
        {
            LoadHistoryData();
        }
        private void buttonBackToCatalog_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId);
            catalogForm.Show();
            this.Close();
        }
    }
}