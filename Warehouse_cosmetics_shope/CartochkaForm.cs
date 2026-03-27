using System;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity; 
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    public partial class CartochkaForm : Form
    {
        private Guid currentUserId;
        
        public CartochkaForm(Guid userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            CatalogFormKlad catalogForm = new CatalogFormKlad(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
    }
}
