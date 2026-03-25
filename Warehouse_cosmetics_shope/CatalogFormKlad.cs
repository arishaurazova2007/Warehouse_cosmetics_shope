using System;
using System.Windows.Forms;

namespace Warehouse_cosmetics_shope
{
    public partial class CatalogFormKlad : Form
    {
        private int currentUserId;
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
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        { 
            FiltrationForm filterForm = new FiltrationForm();
            filterForm.Show();
            this.Hide();
        }
        private void buttonOtgruzka_Click(object sender, EventArgs e)
        {
            OtgruzkaForm otgruzkaForm = new OtgruzkaForm();
            otgruzkaForm.Show();
            this.Hide();
        }

    }
}
