using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope
{
    public partial class LossForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;

        public LossForm(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;

            LoadLossItems();
        }

        private void LoadLossItems()
        {
            using (var db = new WarehouseContext())
            {
                var today = DateTime.Now.Date;

                var lossItems = db.Items
                    .Where(i => i.ExpDate < today && i.Quantity > 0)
                    .ToList();

                var displayList = lossItems.Select(i => new
                {
                    i.ProductNumber,
                    i.ProductName,
                    i.Quantity,
                    i.PurPrice,
                    LossAmount = i.PurPrice * i.Quantity,
                    ExpDate = i.ExpDate.ToShortDateString()
                }).ToList();

                lossDataDridView.DataSource = displayList;

                lossDataDridView.Columns["ProductNumber"].HeaderText = "Артикул";
                lossDataDridView.Columns["ProductName"].HeaderText = "Название";
                lossDataDridView.Columns["Quantity"].HeaderText = "Количество";
                lossDataDridView.Columns["PurPrice"].HeaderText = "Закупочная цена";
                lossDataDridView.Columns["LossAmount"].HeaderText = "Сумма убытка";
                lossDataDridView.Columns["ExpDate"].HeaderText = "Годен до";

                lossDataDridView.Columns["PurPrice"].DefaultCellStyle.Format = "C2";
                lossDataDridView.Columns["LossAmount"].DefaultCellStyle.Format = "C2";
                lossDataDridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //общая сумма убытка
                decimal totalLoss = lossItems.Sum(i => i.PurPrice * i.Quantity);
                lessMoneyNumeric.Value = totalLoss;
                lessMoneyNumeric.Enabled = false;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }
    }
}