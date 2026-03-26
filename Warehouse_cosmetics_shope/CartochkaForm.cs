using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class CartochkaForm : Form
    {
        public CartochkaForm()
        {
            InitializeComponent();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            CatalogFormKlad catalogForm = new CatalogFormKlad();
            catalogForm.Show();
            this.Hide();
        }
    }
}
