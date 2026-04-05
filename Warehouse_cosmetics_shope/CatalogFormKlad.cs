using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class CatalogFormKlad : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;
        public CatalogFormKlad(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;
            LoadCatalogData();
            ShowUserLogin();
        }
        private void LoadCatalogData()
        {
            //здесь будет код загрузки товаров из БД
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