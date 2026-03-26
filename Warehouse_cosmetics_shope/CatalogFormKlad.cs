using System;
using System.Windows.Forms;
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
            //здесь будет код загрузки товаров из БД
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
    }
}