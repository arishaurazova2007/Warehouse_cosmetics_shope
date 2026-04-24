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

        /// <summary>
        /// Конструктор формы отгрузки
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="userLogin">Логин текущего пользователя</param>
        public ShipmentForm(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;

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
                using (var db = new WarehouseContext())
                {
                    var today = DateTime.Now.Date;

                    var items = db.Items
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
                using (var db = new WarehouseContext())
                {
                    var today = DateTime.Now.Date;

                    var items = db.Items
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

                MessageBox.Show("Товар добавлен в отгрузку", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                using (var db = new WarehouseContext())
                {
                    var client = db.Clients.FirstOrDefault(c => c.ClientName == clientNameTextBox.Text.Trim());
                    if (client == null)
                    {
                        client = new Client
                        {
                            ClientID = Guid.NewGuid(),
                            ClientName = clientNameTextBox.Text.Trim(),
                            CType = (ClientTypes)clientTypeComboBox.SelectedValue
                        };
                        db.Clients.Add(client);
                        db.SaveChanges();
                        Log.Information("Создан новый клиент: {ClientName}", client.ClientName);
                    }

                    var shipment = new Shipment
                    {
                        ShipmentID = Guid.NewGuid(),
                        ClientID = client.ClientID,
                        UserID = currentUserId,
                        Date = DateTime.Now
                    };
                    db.Shipments.Add(shipment);
                    db.SaveChanges();

                    Log.Information("Создана отгрузка #{ShipmentId} для клиента {ClientName}",
                        shipment.ShipmentID, client.ClientName);

                    foreach (var item in shipmentItems)
                    {
                        var product = db.Items.FirstOrDefault(i => i.ProductID == item.ProductID);
                        if (product != null)
                        {
                            var composition = new ShipmentComposition
                            {
                                ShipmentID = shipment.ShipmentID,
                                ProductID = item.ProductID,
                                Quantity = item.Quantity
                            };
                            db.ShipmentCompositions.Add(composition);
                            product.Quantity -= item.Quantity;

                            Log.Debug("Списано {Quantity} шт. товара {ProductName}, остаток {NewStock}",
                                item.Quantity, product.ProductName, product.Quantity);
                        }
                    }
                    db.SaveChanges();
                }

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
            var catalogForm = new CatalogFormKlad(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }
    }
}