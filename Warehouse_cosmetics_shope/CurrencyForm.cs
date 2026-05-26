using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope
{
    public partial class CurrencyForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;

        public CurrencyForm(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;
            LoadCurrencies();
            SetupComboBox();
        }

        // Загружает таблицу курсов из БД
        private void LoadCurrencies()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var rates = db.CurrencyRates.ToList();
                    currencyGridView.DataSource = rates.Select(r => new
                    {
                        Валюта = r.CurrencyCode,
                        Курс = r.Rate,
                        Обновлено = r.LastUpdated.ToString("dd.MM.yyyy")
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки курсов: " + ex.Message);
            }
        }

        // Заполняет выпадающий список валют
        private void SetupComboBox()
        {
            currencyComboBox.Items.Clear();
            currencyComboBox.Items.Add("RUB");
            currencyComboBox.Items.Add("USD");
            currencyComboBox.Items.Add("EUR");
            currencyComboBox.Items.Add("CNY");
            currencyComboBox.SelectedItem = CurrencySettings.CurrentCurrency;
        }

      
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

    
        // Кнопка "Назад"
        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }

        // Кнопка "Сохранить" - применяет выбранную валюту
        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            if (currencyComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите валюту", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selected = currencyComboBox.SelectedItem.ToString();

            using (var db = new WarehouseContext())
            {
                var rate = db.CurrencyRates.Find(selected);
                if (rate != null)
                {
                    CurrencySettings.CurrentCurrency = selected;
                    CurrencySettings.CurrentRate = rate.Rate;
                }
            }

            MessageBox.Show($"Валюта изменена на {selected}", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Кнопка "Обновить курс" - получает курс через API
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
                        
                        using (var db = new WarehouseContext())
                        {
                            var usd = db.CurrencyRates.Find("USD");
                            var eur = db.CurrencyRates.Find("EUR");
                            var cny = db.CurrencyRates.Find("CNY");
                            if (usd != null) { usd.Rate = usdRate; usd.LastUpdated = DateTime.Now; }
                            if (eur != null) { eur.Rate = eurRate; eur.LastUpdated = DateTime.Now; }
                            if (cny != null) { cny.Rate = cnyRate; cny.LastUpdated = DateTime.Now; }
                            db.SaveChanges();
                        }
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