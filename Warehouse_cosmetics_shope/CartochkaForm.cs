using System;
using System.Windows.Forms;

namespace Warehouse_cosmetics_shope
{
    public partial class CartochkaForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;

        public CartochkaForm(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormKlad(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {

        }
    }
}