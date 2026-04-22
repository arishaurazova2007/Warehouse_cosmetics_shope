using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Serilog;

namespace Warehouse_cosmetics_shope
{
    public partial class LossForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;

        /// <summary>
        /// Конструктор формы учёта убытков
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="userLogin">Логин текущего пользователя</param>
        public LossForm(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;

            Log.Information("Пользователь {UserLogin} открыл форму убытков", currentUserLogin);

            LoadLossItems();
        }

        /// <summary>
        /// Загружает товары с истекшим сроком годности и отображает их в таблице
        /// </summary>
        private void LoadLossItems()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var today = DateTime.Now.Date;

                    var lossItems = db.Items
                        .Where(i => i.ExpDate < today && i.Quantity > 0)
                        .ToList();

                    if (lossItems.Count == 0)
                    {
                        Log.Information("Просроченные товары отсутствуют");
                    }
                    else
                    {
                        Log.Information("Найдено {ItemCount} просроченных товаров на сумму {TotalLoss:C}",
                            lossItems.Count, lossItems.Sum(i => i.PurPrice * i.Quantity));
                    }

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

                    Log.Debug("Загружено {ItemCount} товаров в таблицу убытков", displayList.Count);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке просроченных товаров");
                MessageBox.Show("Ошибка при загрузке просроченных товаров", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var catalogAdminForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogAdminForm.ShowDialog();
            this.Hide();
            Log.Information("Пользователь {UserLogin} закрыл форму убытков", currentUserLogin);
        }
    }
}