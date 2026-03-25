using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class CatalogFormAdmin : Form
    {
        private int currentUserId;
        public CatalogFormAdmin(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm();
            editForm.Show();
            this.Hide();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            FiltrationForm filterForm = new FiltrationForm();
            filterForm.Show();
            this.Hide();
        }
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            HistoryChangeForm historyForm = new HistoryChangeForm(currentUserId);
            historyForm.Show();
            this.Hide();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
