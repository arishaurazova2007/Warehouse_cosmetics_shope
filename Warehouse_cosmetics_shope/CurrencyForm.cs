using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope
{
    /// <summary>
    /// Форма управления валютными курсами.
    /// Позволяет просматривать, обновлять курсы через API и выбирать рабочую валюту.
    /// </summary>
    public partial class CurrencyForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;
        private readonly IWarehouseContext _db;

        public CurrencyForm(Guid userId, string userLogin, IWarehouseContext db)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;
            _db = db;
            LoadCurrencies();
            SetupComboBox();
        }

        /// <summary>
        /// Загружает таблицу курсов валют из базы данных и отображает в DataGridView.
        /// </summary>
        private void LoadCurrencies()
        {
            try
            {
                var rates = _db.CurrencyRates.ToList();
                currencyGridView.DataSource = rates.Select(r => new
                {
                    Валюта = r.CurrencyCode,
                    Курс = r.Rate,
                    Обновлено = r.LastUpdated.ToString("dd.MM.yyyy")
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки курсов: " + ex.Message);
            }
        }

        /// <summary>
        /// Заполняет выпадающий список доступными валютами (RUB, USD, EUR, CNY)
        /// и устанавливает текущую выбранную валюту.
        /// </summary>
        private void SetupComboBox()
        {
            currencyComboBox.Items.Clear();
            currencyComboBox.Items.Add("RUB");
            currencyComboBox.Items.Add("USD");
            currencyComboBox.Items.Add("EUR");
            currencyComboBox.Items.Add("CNY");
            currencyComboBox.SelectedItem = CurrencySettings.CurrentCurrency;
        }

        /// <summary>
        /// Извлекает числовое значение курса указанной валюты из JSON-строки ответа API.
        /// </summary>
        /// <param name="json">JSON-строка с курсами валют</param>
        /// <param name="currency">Код валюты </param>
        /// <returns>Курс валюты или 0, если валюта не найдена или произошла ошибка</returns>
        private decimal GetRateFromJson(string json, string currency)
        {
            try
            {
                string search = $"\"{currency}\":";
                int index = json.IndexOf(search);
                if (index < 0) return 0;
                int start = index + search.Length;
                int end = json.IndexOfAny(new char[] { ',', '}' }, start);
                string value = json.Substring(start, end - start).Trim();
                return decimal.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch { return 0; }
        }


        /// <summary>
        /// Обработчик кнопки "Назад". Закрывает текущую форму и открывает каталог администратора.
        /// </summary>
        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin, _db);
            catalogForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик кнопки "Сохранить". Применяет выбранную валюту и её курс
        /// </summary>
        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            if (currencyComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите валюту", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selected = currencyComboBox.SelectedItem.ToString();


            var rate = _db.CurrencyRates.Find(selected);
            if (rate != null)
            {
                CurrencySettings.CurrentCurrency = selected;
                CurrencySettings.CurrentRate = rate.Rate;
            }


            MessageBox.Show($"Валюта изменена на {selected}", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Обработчик кнопки "Обновить курс". Запрашивает актуальные курсы USD, EUR и CNY
        /// через внешний API, пересчитывает их относительно RUB и сохраняет в базу данных.
        /// </summary>
        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                {
                    string response = client.DownloadString("https://api.exchangerate-api.com/v4/latest/RUB");
                    decimal usdRate = GetRateFromJson(response, "USD");
                    decimal eurRate = GetRateFromJson(response, "EUR");
                    decimal cnyRate = GetRateFromJson(response, "CNY");

                    if (usdRate > 0 && eurRate > 0 && cnyRate>0)
                    {
                        usdRate = Math.Round(1 / usdRate, 2);
                        eurRate = Math.Round(1 / eurRate, 2);
                        cnyRate = Math.Round(1 / cnyRate, 2);


                        var usd = _db.CurrencyRates.Find("USD");
                        var eur = _db.CurrencyRates.Find("EUR");
                        var cny = _db.CurrencyRates.Find("CNY");
                        if (usd != null) { usd.Rate = usdRate; usd.LastUpdated = DateTime.Now; }
                        if (eur != null) { eur.Rate = eurRate; eur.LastUpdated = DateTime.Now; }
                        if (cny != null) { cny.Rate = cnyRate; cny.LastUpdated = DateTime.Now; }
                        _db.SaveChanges();

                        LoadCurrencies();
                        MessageBox.Show($"Курсы обновлены!\nUSD: {usdRate}\nEUR: {eurRate}\nCNY:{cnyRate}","Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении курса: " + ex.Message);
            }
        }
    }
}