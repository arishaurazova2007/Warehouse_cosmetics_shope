using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class HistoryChangeForm : Form
    {
        private Guid currentUserId;
        public HistoryChangeForm(Guid userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }
        // Загрузка истории изменений
        private void LoadHistoryData()
        {
            //загрузка из БД
        }
        private void HistoryChangeForm_Load(object sender, EventArgs e)
        {
            LoadHistoryData();
        }
        private void buttonBackToCatalog_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
    }
}