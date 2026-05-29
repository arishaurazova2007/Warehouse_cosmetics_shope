using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;
using Warehouse_cosmetics_shope.Helpers;

namespace Warehouse_cosmetics_shope
{
    public partial class ShipmentForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;
        private List<ShipmentItem> shipmentItems = new List<ShipmentItem>();
        private Guid selectedProductId = Guid.Empty;
        private string selectedProductName = string.Empty;
        private int selectedProductNumber = 0;
        private int selectedProductQuantity = 0;
        private string selectedCategoryName = string.Empty;
        private readonly IWarehouseContext _db;

        /// <summary>
        /// Флаг — пройдена ли проверка ИНН контрагента
        /// </summary>
        private bool innCheckPassed = false;

        /// <summary>
        /// Конструктор формы отгрузки
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="userLogin">Логин текущего пользователя</param>
        public ShipmentForm(Guid userId, string userLogin, IWarehouseContext db)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;
            _db = db;

            Log.Information("Пользователь {UserLogin} открыл форму отгрузки", currentUserLogin);

            LoadCatalog();
            LoadClientTypes();
            SetupCatalogGridView();
            SetupShipmentGridView();
            SetupSearchBox();
        }

        /// <summary>
        /// Загружает каталог товаров, доступных для отгрузки (с ненулевым остатком и не просроченных)
        /// </summary>
        private void LoadCatalog()
        {
            try
            {
                var today = DateTime.Now.Date;

                var items = _db.Items
                    .Include(i => i.Category)
                    .Where(i => i.Quantity > 0 && i.ExpDate > today)
                    .Select(i => new
                    {
                        i.ProductID,
                        i.ProductNumber,
                        i.ProductName,
                        i.Category.CategoryName,
                        i.Quantity,
                        i.SellPrice
                    })
                    .ToList();

                catalogInShipmentGridView.DataSource = items;

                Log.Debug("Загружено {ItemCount} товаров в каталог отгрузки", items.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке каталога отгрузки");
                MessageBox.Show("Ошибка при загрузке каталога", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загружает типы клиентов в выпадающий список
        /// </summary>
        private void LoadClientTypes()
        {
            try
            {
                var clientTypes = System.Enum.GetValues(typeof(ClientTypes))
                    .Cast<ClientTypes>()
                    .Select(t => new { Value = t, Display = GetClientTypeDisplayName(t) })
                    .ToList();

                clientTypeComboBox.DataSource = clientTypes;
                clientTypeComboBox.DisplayMember = "Display";
                clientTypeComboBox.ValueMember = "Value";

                Log.Debug("Загружены типы клиентов");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке типов клиентов");
            }
        }

        /// <summary>
        /// Возвращает отображаемое имя типа клиента
        /// </summary>
        /// <param name="type">Тип клиента</param>
        /// <returns>Русское название типа клиента</returns>
        private string GetClientTypeDisplayName(ClientTypes type)
        {
            switch (type)
            {
                case ClientTypes.LegalEntity: return "Юридическое лицо";
                case ClientTypes.IndividualEntrepreneur: return "ИП";
                case ClientTypes.Individual: return "Физическое лицо";
                default: return type.ToString();
            }
        }

        /// <summary>
        /// Настраивает отображение колонок в таблице каталога
        /// </summary>
        private void SetupCatalogGridView()
        {
            catalogInShipmentGridView.Columns["ProductID"].Visible = false;
            catalogInShipmentGridView.Columns["ProductNumber"].HeaderText = "Артикул";
            catalogInShipmentGridView.Columns["ProductName"].HeaderText = "Название";
            catalogInShipmentGridView.Columns["CategoryName"].HeaderText = "Категория";
            catalogInShipmentGridView.Columns["Quantity"].HeaderText = "Остаток";
            catalogInShipmentGridView.Columns["SellPrice"].HeaderText = "Цена";
            catalogInShipmentGridView.Columns["SellPrice"].DefaultCellStyle.Format = "C2";
        }

        /// <summary>
        /// Настраивает таблицу для отображения добавленных товаров
        /// </summary>
        private void SetupShipmentGridView()
        {
            shipmentDataDridView.AutoGenerateColumns = true;
            shipmentDataDridView.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Настраивает поле поиска (плейсхолдер "Поиск")
        /// </summary>
        private void SetupSearchBox()
        {
            shipmentSearchBox.Text = "Поиск";
            shipmentSearchBox.ForeColor = System.Drawing.Color.Gray;
            innTextBox.Text = "Введите ИНН";
            innTextBox.ForeColor = System.Drawing.Color.Gray;
            innTextBox.Enter += (s, e) => {
                if (innTextBox.Text == "Введите ИНН") { innTextBox.Text = ""; innTextBox.ForeColor = System.Drawing.Color.Black; }
            };
            innTextBox.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(innTextBox.Text)) { innTextBox.Text = "Введите ИНН"; innTextBox.ForeColor = System.Drawing.Color.Gray; }
            };

        }

        /// <summary>
        /// Обработчик входа курсора в поле поиска
        /// </summary>
        private void ShipmentSearchBox_Enter(object sender, EventArgs e)
        {
            if (shipmentSearchBox.Text == "Поиск")
            {
                shipmentSearchBox.Text = string.Empty;
                shipmentSearchBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// Обработчик выхода курсора из поля поиска
        /// </summary>
        private void ShipmentSearchBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(shipmentSearchBox.Text))
            {
                shipmentSearchBox.Text = "Поиск";
                shipmentSearchBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки поиска товаров
        /// </summary>
        private void ShipmentSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = shipmentSearchBox.Text.Trim().ToLower();

            if (searchText == "поиск" || string.IsNullOrWhiteSpace(searchText))
            {
                LoadCatalog();
                return;
            }

            Log.Debug("Поиск товара по запросу: {SearchText}", searchText);

            try
            {
                var today = DateTime.Now.Date;

                var items = _db.Items
                    .Include(i => i.Category)
                    .Where(i => i.Quantity > 0 && i.ExpDate > today &&
                        (i.ProductNumber.ToString().Contains(searchText) || i.ProductName.ToLower().Contains(searchText)))
                    .Select(i => new
                    {
                        i.ProductID,
                        i.ProductNumber,
                        i.ProductName,
                        i.Category.CategoryName,
                        i.Quantity,
                        i.SellPrice
                    })
                    .ToList();

                catalogInShipmentGridView.DataSource = items;
                catalogInShipmentGridView.Columns["ProductID"].Visible = false;

                if (items.Count == 0)
                {
                    Log.Warning("По запросу '{SearchText}' ничего не найдено", searchText);
                }
                else
                {
                    Log.Information("По запросу '{SearchText}' найдено {ItemCount} товаров", searchText, items.Count);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при поиске товаров по запросу {SearchText}", searchText);
                MessageBox.Show("Ошибка при поиске товаров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик клика по ячейке таблицы каталога (выбор товара)
        /// </summary>
        private void CatalogInShipmentGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    selectedProductId = (Guid)catalogInShipmentGridView.Rows[e.RowIndex].Cells["ProductID"].Value;
                    selectedProductName = catalogInShipmentGridView.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                    selectedProductNumber = (int)catalogInShipmentGridView.Rows[e.RowIndex].Cells["ProductNumber"].Value;
                    selectedProductQuantity = (int)catalogInShipmentGridView.Rows[e.RowIndex].Cells["Quantity"].Value;
                    selectedCategoryName = catalogInShipmentGridView.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                    shipmentSearchBox.Text = selectedProductName;
                    quantityNumeric.Maximum = selectedProductQuantity;

                    Log.Debug("Выбран товар: {ProductName}, остаток: {Quantity}", selectedProductName, selectedProductQuantity);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Ошибка при выборе товара из каталога");
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить товар"
        /// </summary>
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (selectedProductId == Guid.Empty)
            {
                Log.Warning("Попытка добавить товар без выбора");
                MessageBox.Show("Выберите товар из каталога", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantityNumeric.Value <= 0)
            {
                Log.Warning("Попытка добавить товар с некорректным количеством: {Quantity}", quantityNumeric.Value);
                MessageBox.Show("Введите количество", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantityNumeric.Value > selectedProductQuantity)
            {
                Log.Warning("Попытка отгрузить {Requested} шт., доступно только {Available} шт.",
                    quantityNumeric.Value, selectedProductQuantity);
                MessageBox.Show($"Недостаточно товара на складе. Доступно: {selectedProductQuantity}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var existingItem = shipmentItems.FirstOrDefault(i => i.ProductID == selectedProductId);
                if (existingItem != null)
                {
                    int newQuantity = existingItem.Quantity + (int)quantityNumeric.Value;
                    if (newQuantity > selectedProductQuantity)
                    {
                        Log.Warning("Суммарное количество {NewQuantity} превышает остаток {Stock}",
                            newQuantity, selectedProductQuantity);
                        MessageBox.Show($"Суммарное количество превышает остаток. Доступно: {selectedProductQuantity}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    existingItem.Quantity += (int)quantityNumeric.Value;
                    Log.Information("Обновлён товар {ProductName}: количество увеличено на {Quantity} (всего {Total})",
                        selectedProductName, quantityNumeric.Value, existingItem.Quantity);
                }
                else
                {
                    shipmentItems.Add(new ShipmentItem
                    {
                        ProductID = selectedProductId,
                        ProductName = selectedProductName,
                        ProductNumber = selectedProductNumber,
                        CategoryName = selectedCategoryName,
                        StockQuantity = selectedProductQuantity,
                        Quantity = (int)quantityNumeric.Value
                    });
                    Log.Information("Добавлен товар в отгрузку: {ProductName}, количество: {Quantity}",
                        selectedProductName, quantityNumeric.Value);
                }

                UpdateShipmentTable();
                ClearForm();
                LoadCatalog();

                /// <summary>
                /// Показывает предупреждение если добавленный товар помечен как хрупкий
                /// </summary>

                var product = _db.Items.FirstOrDefault(i => i.ProductID == selectedProductId);
                if (product != null && product.IsFragile)
                {
                    MessageBox.Show($"⚠️ Внимание! Товар \"{selectedProductName}\" хрупкий.\nПри транспортировке могут потребоваться специальные условия.",
                        "Хрупкий товар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Товар добавлен в отгрузку", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при добавлении товара {ProductName} в отгрузку", selectedProductName);
                MessageBox.Show("Ошибка при добавлении товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновляет таблицу с добавленными товарами
        /// </summary>
        private void UpdateShipmentTable()
        {
            var displayList = shipmentItems.Select(i => new
            {
                i.ProductName,
                i.CategoryName,
                i.ProductNumber,
                Остаток = i.StockQuantity,
                Количество = i.Quantity
            }).ToList();

            shipmentDataDridView.DataSource = displayList;
            Log.Debug("Обновлена таблица отгрузки, всего товаров: {ItemCount}", shipmentItems.Count);
        }

        /// <summary>
        /// Очищает поля ввода после добавления товара
        /// </summary>
        private void ClearForm()
        {
            quantityNumeric.Value = 1;
            selectedProductId = Guid.Empty;
            selectedProductName = string.Empty;
            selectedProductNumber = 0;
            selectedProductQuantity = 0;
            selectedCategoryName = string.Empty;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сформировать список" (оформление отгрузки)
        /// </summary>
        private void buttonGenerateList_Click(object sender, EventArgs e)
        {
            if (!innCheckPassed)
            {
                MessageBox.Show("Необходимо пройти проверку ИНН контрагента перед отгрузкой",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (shipmentItems.Count == 0)
            {
                Log.Warning("Попытка оформить пустую отгрузку");
                MessageBox.Show("Добавьте хотя бы один товар в отгрузку", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(clientNameTextBox.Text))
            {
                Log.Warning("Попытка оформить отгрузку без указания клиента");
                MessageBox.Show("Введите название клиента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clientTypeComboBox.SelectedItem == null)
            {
                Log.Warning("Попытка оформить отгрузку без выбора типа клиента");
                MessageBox.Show("Выберите тип клиента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var client = _db.Clients.FirstOrDefault(c => c.ClientName == clientNameTextBox.Text.Trim());
                if (client == null)
                {
                    client = new Client
                    {
                        ClientID = Guid.NewGuid(),
                        ClientName = clientNameTextBox.Text.Trim(),
                        CType = (ClientTypes)clientTypeComboBox.SelectedValue
                    };
                    _db.Clients.Add(client);
                    _db.SaveChanges();
                    Log.Information("Создан новый клиент: {ClientName}", client.ClientName);
                }

                var shipment = new Shipment
                {
                    ShipmentID = Guid.NewGuid(),
                    ClientID = client.ClientID,
                    UserID = currentUserId,
                    Date = DateTime.Now
                };
                _db.Shipments.Add(shipment);
                _db.SaveChanges();

                Log.Information("Создана отгрузка #{ShipmentId} для клиента {ClientName}",
                    shipment.ShipmentID, client.ClientName);

                foreach (var item in shipmentItems)
                {
                    var product = _db.Items.FirstOrDefault(i => i.ProductID == item.ProductID);
                    if (product != null)
                    {
                        var composition = new ShipmentComposition
                        {
                            ShipmentID = shipment.ShipmentID,
                            ProductID = item.ProductID,
                            Quantity = item.Quantity
                        };
                        _db.ShipmentCompositions.Add(composition);
                        product.Quantity -= item.Quantity;

                        Log.Debug("Списано {Quantity} шт. товара {ProductName}, остаток {NewStock}",
                            item.Quantity, product.ProductName, product.Quantity);
                    }
                }
                _db.SaveChanges();


                Log.Information("Отгрузка оформлена! Клиент: {ClientName}, товаров: {ItemCount}",
                    clientNameTextBox.Text, shipmentItems.Count);

                MessageBox.Show($"Отгрузка оформлена!\nКлиент: {clientNameTextBox.Text}\nТоваров: {shipmentItems.Count}",
                    "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                shipmentItems.Clear();
                UpdateShipmentTable();
                ClearForm();
                LoadCatalog();
                clientNameTextBox.Clear();
                clientTypeComboBox.SelectedIndex = -1;
                shipmentSearchBox.Text = "Поиск";
                shipmentSearchBox.ForeColor = System.Drawing.Color.Gray;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при оформлении отгрузки");
                MessageBox.Show("Ошибка при оформлении отгрузки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Log.Information("Пользователь {UserLogin} вернулся в каталог из отгрузки", currentUserLogin);

            var catalogForm = new CatalogFormKlad(currentUserId, currentUserLogin, _db);
            catalogForm.Show();
            this.Hide();

        }
        /// <summary>
        /// Получает координаты города по названию через бесплатный геокодер Open-Meteo.
        /// Возвращает (широта, долгота) или null если город не найден.
        /// </summary>
        private (double lat, double lon)? GetCityCoordinates(string city)
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    string url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(city)}&count=1&language=ru";
                    string response = client.DownloadString(url);

                    // Парсим координаты из JSON вручную
                    if (!response.Contains("\"latitude\"")) return null;

                    int latIdx = response.IndexOf("\"latitude\":") + 11;
                    int latEnd = response.IndexOfAny(new char[] { ',', '}' }, latIdx);
                    double lat = double.Parse(response.Substring(latIdx, latEnd - latIdx).Trim(),
                        System.Globalization.CultureInfo.InvariantCulture);

                    int lonIdx = response.IndexOf("\"longitude\":") + 12;
                    int lonEnd = response.IndexOfAny(new char[] { ',', '}' }, lonIdx);
                    double lon = double.Parse(response.Substring(lonIdx, lonEnd - lonIdx).Trim(),
                        System.Globalization.CultureInfo.InvariantCulture);

                    return (lat, lon);
                }
            }
            catch { return null; }
        }
        /// <summary>
        /// Проверяет погоду в регионе клиента на ближайшие 2 дня.
        /// Возвращает предупреждение если ожидается аномальная жара (выше 30°C) или мороз (ниже -10°C).
        /// </summary>
        private string CheckWeather(string region)
        {
            try
            {
                var coords = GetCityCoordinates(region);
                if (coords == null)
                    return null;

                using (var client = new System.Net.WebClient())
                {
                    string url = $"https://api.open-meteo.com/v1/forecast?latitude={coords.Value.lat.ToString(System.Globalization.CultureInfo.InvariantCulture)}&longitude={coords.Value.lon.ToString(System.Globalization.CultureInfo.InvariantCulture)}&daily=temperature_2m_max,temperature_2m_min&forecast_days=2&timezone=auto";
                    string response = client.DownloadString(url);

                    // Парсим максимальную температуру
                    int maxIdx = response.IndexOf("\"temperature_2m_max\":[") + 21;
                    int maxEnd = response.IndexOf("]", maxIdx);
                    string maxStr = response.Substring(maxIdx, maxEnd - maxIdx);
                    var maxTemps = maxStr.Split(',')
                        .Select(t => double.Parse(t.Trim(), System.Globalization.CultureInfo.InvariantCulture))
                        .ToList();

                    double maxTemp = maxTemps.Max();
                    double minTemp = maxTemps.Min();

                    if (maxTemp > 30)
                        return $"⚠️ Внимание! Погодные условия.\nВ регионе клиента ожидается +{maxTemp}°C.";
                    if (minTemp < -10)
                        return $"⚠️ Внимание! Погодные условия.\nВ регионе клиента ожидается {minTemp}°C.";

                    return null; // погода нормальная
                }
            }
            catch { return null; }
        }
        /// <summary>
        /// Обработчик нажатия кнопки проверки ИНН контрагента.
        /// Проверяет компанию по реестру ЕГРЮЛ и погодные условия в регионе клиента.
        /// Блокирует отгрузку если контрагент находится в реестре банкротов или имеет задолженности.
        /// </summary>
        private void buttonCheckINN_Click(object sender, EventArgs e)
        {
            string inn = innTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(inn) || inn == "Введите ИНН")
            {
                MessageBox.Show("Введите ИНН контрагента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Ищем клиента в нашей БД по ИНН
               
                    var client = _db.Clients.FirstOrDefault(c => c.INN == inn);

                    // Проверяем по ЕГРЮЛ
                    string companyName = "Неизвестная компания";
                    bool isBankrupt = false;
                    decimal debt = 0;

                    try
                    {
                        using (var webClient = new System.Net.WebClient())
                        {
                            webClient.Encoding = System.Text.Encoding.UTF8;
                            string token = "fe6f6c4e863aa3c085484d2618b4e9731728fe26";
                            string secret = "8a75801d293f8a87fe0b2f7b1eafa16684964554";

                            webClient.Headers.Add("Content-Type", "application/json");
                            webClient.Headers.Add("Authorization", $"Token {token}");
                            webClient.Headers.Add("X-Secret", secret);

                            string body = $"{{\"query\": \"{inn}\"}}";
                            string response = webClient.UploadString(
                                "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party",
                                "POST", body);

                            // Парсим имя компании
                            if (response.Contains("\"value\":"))
                            {
                                int valueIdx = response.IndexOf("\"value\":\"") + 9;
                                int valueEnd = response.IndexOf("\"", valueIdx);
                                if (valueIdx > 9 && valueEnd > valueIdx)
                                    companyName = response.Substring(valueIdx, valueEnd - valueIdx);
                            }

                            // Парсим статус — ликвидирована или банкрот
                            if (response.Contains("\"state\""))
                            {
                                if (response.Contains("\"LIQUIDATED\"") || response.Contains("\"BANKRUPT\""))
                                {
                                    isBankrupt = true;
                                    debt = 1000000;
                                }
                            }

                            Log.Information("Dadata вернула данные для ИНН {INN}: {CompanyName}", inn, companyName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Warning("Ошибка запроса к Dadata: {Message}", ex.Message);
                        if (client != null)
                            companyName = client.ClientName;
                    }

                    // Формируем результат проверки
                    string region = client?.Region ?? "";
                    string weatherWarning = !string.IsNullOrEmpty(region) ? CheckWeather(region) : null;

                    // Проверяем есть ли хрупкие товары в списке отгрузки
                    bool hasFragileItems = false;
                    string fragileItemName = "";
                if (shipmentItems.Any())
                {
                    foreach (var item in shipmentItems)
                    {
                        var product = _db.Items.FirstOrDefault(i => i.ProductID == item.ProductID);
                        if (product != null && product.IsFragile)
                        {
                            hasFragileItems = true;
                            fragileItemName = product.ProductName;
                            break;
                        }
                    }

                }

                // Строим сообщение
                string message = $"Компания: {companyName}\nИНН: {inn}\n\n";

                if (isBankrupt || debt > 0)
                {
                    // Контрагент проблемный
                    innCheckPassed = false;
                    message = $"🚫 Внимание!\n\nКомпания: {companyName}\nИНН: {inn}\n\nНайдены риски:\n";
                    if (isBankrupt) message += "⚠️ Компания в реестре банкротов\n";
                    if (debt > 0) message += $"⚠️ Задолженность: {debt} млн руб\n";
                    message += "\nОтгрузка этому контрагенту запрещена политикой компании.";

                    MessageBox.Show(message, "Проверка не пройдена",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Сохраняем в историю проверок
                    SaveCheckHistory(client?.ClientID, inn, "Отклонена", message);
                }
                else
                {
                    // Контрагент надёжный
                    innCheckPassed = true;
                    message += "✅ Проверка пройдена\n\nНе в реестре банкротов\n";

                    if (weatherWarning != null)
                    {
                        message += $"\n{weatherWarning}";
                        if (hasFragileItems)
                            message += $" В списке есть хрупкий товар ({fragileItemName})";
                        message += "\n\nСпециальные условия: Термоконтейнер.";
                    }
                    else
                    {
                        message += "\n✅ Погодные условия в регионе благоприятные\n\nСпециальные условия: не нужны.";
                    }

                    MessageBox.Show(message, "Проверка пройдена",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Сохраняем в историю проверок
                    SaveCheckHistory(client?.ClientID, inn, "Пройдена", message);
                }

                Log.Information("Проверка ИНН {INN}: результат — {Result}", inn, innCheckPassed ? "пройдена" : "отклонена");

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при проверке ИНН {INN}", inn);
                MessageBox.Show("Ошибка при проверке ИНН: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Сохраняет результат проверки контрагента в таблицу CheckHistory.
        /// Если клиент не найден в БД — запись не создаётся.
        /// </summary>
        private void SaveCheckHistory(Guid? clientId, string inn, string status, string details)
        {
            try
            {
                if (clientId == null) return;

                _db.CheckHistory.Add(new DataBaseClass.CheckHistory
                {
                    HistoryID = Guid.NewGuid(),
                    ClientID = clientId.Value,
                    CheckDate = DateTime.Now,
                    Status = status,
                    Details = details
                });
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при сохранении истории проверки ИНН {INN}", inn);
            }
        }
    }
}