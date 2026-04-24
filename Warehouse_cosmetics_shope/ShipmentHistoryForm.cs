using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Helpers;

namespace Warehouse_cosmetics_shope
{
    public partial class ShipmentHistoryForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;

        /// <summary>
        /// Конструктор формы истории отгрузок
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="userLogin">Логин текущего пользователя</param>
        public ShipmentHistoryForm(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;

            lowDatePicker.Value = DateTime.Now.AddMonths(-1);
            upDatePicker.Value = DateTime.Now;

            lowDatePicker.ValueChanged += (s, e) => LoadShipmentHistory();
            upDatePicker.ValueChanged += (s, e) => LoadShipmentHistory();

            fileExportButton.Click += FileExportButton_Click;
            buttonBackToCatalog.Click += ButtonBackToCatalog_Click;

            Log.Information("Пользователь {UserLogin} открыл историю отгрузок", currentUserLogin);

            LoadShipmentHistory();
        }

        /// <summary>
        /// Загружает историю отгрузок за выбранный период
        /// </summary>
        private void LoadShipmentHistory()
        {
            try
            {
                DateTime fromDate = lowDatePicker.Value.Date;
                DateTime toDate = upDatePicker.Value.Date.AddDays(1).AddSeconds(-1);

                Log.Debug("Загрузка истории отгрузок за период с {FromDate} по {ToDate}", fromDate, toDate);

                using (var db = new WarehouseContext())
                {
                    var shipments = db.Shipments
                        .Include("Client")
                        .Include("User")
                        .Include("ShipmentCompositions")
                        .Include("ShipmentCompositions.Product")
                        .Where(s => s.Date >= fromDate && s.Date <= toDate)
                        .ToList();

                    Log.Information("Найдено {ShipmentCount} отгрузок за выбранный период", shipments.Count);

                    var historyList = new List<ShipmentHistoryItem>();

                    foreach (var shipment in shipments)
                    {
                        decimal totalAmount = 0;
                        decimal totalProfit = 0;
                        int totalQuantity = 0;

                        if (shipment.ShipmentCompositions != null)
                        {
                            foreach (var composition in shipment.ShipmentCompositions)
                            {
                                if (composition.Product != null)
                                {
                                    totalAmount += composition.Quantity * composition.Product.SellPrice;
                                    totalProfit += composition.Quantity * (composition.Product.SellPrice - composition.Product.PurPrice);
                                    totalQuantity += composition.Quantity;
                                }
                            }
                        }

                        historyList.Add(new ShipmentHistoryItem
                        {
                            Date = shipment.Date,
                            EmployeeName = $"{shipment.User?.Surname} {shipment.User?.Name}",
                            ClientName = shipment.Client?.ClientName ?? "Не указан",
                            TotalAmount = totalAmount,
                            Profit = totalProfit,
                            Quantity = totalQuantity
                        });
                    }

                    ShipHistoryDataGridView.DataSource = historyList;
                    ConfigureColumns();

                    if (historyList.Count == 0)
                    {
                        Log.Warning("За период с {FromDate} по {ToDate} отгрузок не найдено", fromDate, toDate);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке истории отгрузок");
                MessageBox.Show("Ошибка при загрузке истории отгрузок", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Настраивает отображение колонок в таблице истории отгрузок
        /// </summary>
        private void ConfigureColumns()
        {
            if (ShipHistoryDataGridView.Columns.Contains("Date"))
            {
                ShipHistoryDataGridView.Columns["Date"].HeaderText = "Дата и время";
                ShipHistoryDataGridView.Columns["Date"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
            if (ShipHistoryDataGridView.Columns.Contains("EmployeeName"))
                ShipHistoryDataGridView.Columns["EmployeeName"].HeaderText = "Сотрудник";
            if (ShipHistoryDataGridView.Columns.Contains("ClientName"))
                ShipHistoryDataGridView.Columns["ClientName"].HeaderText = "Покупатель";
            if (ShipHistoryDataGridView.Columns.Contains("TotalAmount"))
            {
                ShipHistoryDataGridView.Columns["TotalAmount"].HeaderText = "Сумма отгрузки";
                ShipHistoryDataGridView.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
            }
            if (ShipHistoryDataGridView.Columns.Contains("Profit"))
            {
                ShipHistoryDataGridView.Columns["Profit"].HeaderText = "Прибыль";
                ShipHistoryDataGridView.Columns["Profit"].DefaultCellStyle.Format = "C2";
            }
            if (ShipHistoryDataGridView.Columns.Contains("Quantity"))
                ShipHistoryDataGridView.Columns["Quantity"].HeaderText = "Кол-во товаров";

            ShipHistoryDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Экспортирует историю отгрузок в JSON файл
        /// </summary>
        private void FileExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = lowDatePicker.Value.Date;
                DateTime toDate = upDatePicker.Value.Date.AddDays(1).AddSeconds(-1);

                Log.Information("Экспорт истории отгрузок за период с {FromDate} по {ToDate}", fromDate, toDate);

                using (var db = new WarehouseContext())
                {
                    var shipments = db.Shipments
                        .Include("Client")
                        .Include("User")
                        .Include("ShipmentCompositions")
                        .Include("ShipmentCompositions.Product")
                        .Where(s => s.Date >= fromDate && s.Date <= toDate)
                        .ToList();

                    if (shipments.Count == 0)
                    {
                        Log.Warning("Нет данных для экспорта за период с {FromDate} по {ToDate}", fromDate, toDate);
                        MessageBox.Show("Нет данных для экспорта за выбранный период", "Оповещение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var exportList = new List<ExportShipmentItem>();

                    foreach (var shipment in shipments)
                    {
                        decimal totalAmount = 0;
                        decimal totalProfit = 0;
                        int totalQuantity = 0;

                        if (shipment.ShipmentCompositions != null)
                        {
                            foreach (var composition in shipment.ShipmentCompositions)
                            {
                                if (composition.Product != null)
                                {
                                    totalAmount += composition.Quantity * composition.Product.SellPrice;
                                    totalProfit += composition.Quantity * (composition.Product.SellPrice - composition.Product.PurPrice);
                                    totalQuantity += composition.Quantity;
                                }
                            }
                        }

                        exportList.Add(new ExportShipmentItem
                        {
                            Date = shipment.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                            EmployeeName = $"{shipment.User?.Surname} {shipment.User?.Name}",
                            ClientName = shipment.Client?.ClientName ?? "Не указан",
                            TotalAmount = totalAmount,
                            Profit = totalProfit,
                            Quantity = totalQuantity
                        });
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "JSON files (*.json)|*.json";
                    saveFileDialog.Title = "Сохранить историю отгрузок";
                    saveFileDialog.FileName = $"ShipmentHistory_{fromDate:yyyyMMdd}_{toDate:yyyyMMdd}.json";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string json = JsonConvert.SerializeObject(exportList, Formatting.Indented);
                        File.WriteAllText(saveFileDialog.FileName, json);
                        Log.Information("История отгрузок успешно экспортирована в файл: {FilePath}", saveFileDialog.FileName);
                        MessageBox.Show($"История отгрузок сохранена в файл:\n{saveFileDialog.FileName}", "Оповещение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при экспорте истории отгрузок");
                MessageBox.Show("Ошибка при экспорте истории отгрузок", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "В каталог"
        /// </summary>
        private void ButtonBackToCatalog_Click(object sender, EventArgs e)
        {
            Log.Information("Пользователь {UserLogin} вернулся в каталог из истории отгрузок", currentUserLogin);
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }
    }
}