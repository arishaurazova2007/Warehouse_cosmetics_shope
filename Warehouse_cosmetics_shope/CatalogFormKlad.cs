using System;
using System.Windows.Forms;
using Warehouse;

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
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            this.Hide();
            FiltrationForm filterForm = new FiltrationForm();
            filterForm.Show();
            this.Close();
        }
        private void buttonOtgruzka_Click(object sender, EventArgs e)
        {
            this.Hide();
            OtgruzkaForm otgruzkaForm = new OtgruzkaForm();
            otgruzkaForm.Show();
            this.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

    }
}
