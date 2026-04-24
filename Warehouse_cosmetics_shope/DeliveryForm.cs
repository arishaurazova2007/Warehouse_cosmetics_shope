using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Helpers;

namespace Warehouse_cosmetics_shope
{
    public partial class DeliveryForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;
        private List<DeliveryItem> deliveryItems = new List<DeliveryItem>();

        /// <summary>
        /// Конструктор формы поставки
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="userLogin">Логин текущего пользователя</param>
        public DeliveryForm(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;

            Log.Information("Пользователь {UserLogin} открыл форму поставки", currentUserLogin);

            LoadCatalog();
            SetupCatalogGridView();
            SetupEventHandlers();
            SetupSearchBox();
        }

        /// <summary>
        /// Настраивает обработчики событий для элементов управления
        /// </summary>
        private void SetupEventHandlers()
        {
            catalogInDeliveryGridView.CellClick += CatalogInDeliveryGridView_CellClick;
            deliverySearchButton.Click += DeliverySearchButton_Click;
            addItemButton.Click += addItemButton_Click;
            addFuulDeliveryButton.Click += addFuulDeliveryButton_Click;
            cancelDeliveryButton.Click += cancelDeliveryButton_Click;
            buttonBack.Click += buttonBack_Click;
            fileImportButton.Click += fileImportButton_Click;
        }

        /// <summary>
        /// Настраивает поле поиска (плейсхолдер "Поиск")
        /// </summary>
        private void SetupSearchBox()
        {
            deliverySearchBox.Text = "Поиск";
            deliverySearchBox.ForeColor = System.Drawing.Color.Gray;
            deliverySearchBox.Enter += DeliverySearchBox_Enter;
            deliverySearchBox.Leave += DeliverySearchBox_Leave;
        }

        /// <summary>
        /// Загружает каталог товаров для выбора в поставку
        /// </summary>
        private void LoadCatalog()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var items = db.Items
                        .Select(i => new
                        {
                            i.ProductID,
                            i.ProductNumber,
                            i.ProductName,
                            i.Category.CategoryName,
                            i.SellPrice,
                            i.Units
                        })
                        .ToList();

                    catalogInDeliveryGridView.DataSource = items;
                    Log.Information("Загружено {ItemCount} товаров в каталог поставки", items.Count);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке каталога поставки");
                MessageBox.Show("Ошибка при загрузке каталога", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Настраивает отображение колонок в таблице каталога поставки
        /// </summary>
        private void SetupCatalogGridView()
        {
            catalogInDeliveryGridView.Columns["ProductID"].Visible = false;
            catalogInDeliveryGridView.Columns["ProductNumber"].HeaderText = "Артикул";
            catalogInDeliveryGridView.Columns["ProductName"].HeaderText = "Название";
            catalogInDeliveryGridView.Columns["CategoryName"].HeaderText = "Категория";
            catalogInDeliveryGridView.Columns["SellPrice"].HeaderText = "Цена продажи";
            catalogInDeliveryGridView.Columns["Units"].HeaderText = "Ед. изм.";
            catalogInDeliveryGridView.Columns["SellPrice"].DefaultCellStyle.Format = "C2";
        }

        /// <summary>
        /// Обработчик входа курсора в поле поиска
        /// </summary>
        private void DeliverySearchBox_Enter(object sender, EventArgs e)
        {
            if (deliverySearchBox.Text == "Поиск")
            {
                deliverySearchBox.Text = string.Empty;
                deliverySearchBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// Обработчик выхода курсора из поля поиска
        /// </summary>
        private void DeliverySearchBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(deliverySearchBox.Text))
            {
                deliverySearchBox.Text = "Поиск";
                deliverySearchBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки поиска товаров
        /// </summary>
        private void DeliverySearchButton_Click(object sender, EventArgs e)
        {
            string searchText = deliverySearchBox.Text.Trim().ToLower();

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
                    var items = db.Items
                        .Where(i => i.ProductNumber.ToString().Contains(searchText) ||
                                    i.ProductName.ToLower().Contains(searchText))
                        .Select(i => new
                        {
                            i.ProductID,
                            i.ProductNumber,
                            i.ProductName,
                            i.Category.CategoryName,
                            i.SellPrice,
                            i.Units
                        })
                        .ToList();

                    catalogInDeliveryGridView.DataSource = items;
                    catalogInDeliveryGridView.Columns["ProductID"].Visible = false;

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
                Log.Error(ex, "Ошибка при поиске товара по запросу {SearchText}", searchText);
                MessageBox.Show("Ошибка при поиске товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Guid selectedProductId = Guid.Empty;
        private string selectedProductName = string.Empty;
        private decimal selectedSellPrice = 0;

        /// <summary>
        /// Обработчик клика по ячейке таблицы каталога (выбор товара)
        /// </summary>
        private void CatalogInDeliveryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    selectedProductId = (Guid)catalogInDeliveryGridView.Rows[e.RowIndex].Cells["ProductID"].Value;
                    selectedProductName = catalogInDeliveryGridView.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                    selectedSellPrice = (decimal)catalogInDeliveryGridView.Rows[e.RowIndex].Cells["SellPrice"].Value;
                    deliverySearchBox.Text = selectedProductName;

                    Log.Debug("Выбран товар: {ProductName} (ID: {ProductId})", selectedProductName, selectedProductId);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Ошибка при выборе товара из каталога поставки");
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Log.Information("Пользователь {UserLogin} вернулся в каталог из поставки", currentUserLogin);
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить в список" (добавление товара в поставку)
        /// </summary>
        private void addItemButton_Click(object sender, EventArgs e)
        {
            if (selectedProductId == Guid.Empty)
            {
                Log.Warning("Попытка добавить товар без выбора");
                MessageBox.Show("Выберите товар из каталога", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (deliveryPurPriceNumeric.Value <= 0)
            {
                Log.Warning("Попытка добавить товар с некорректной закупочной ценой: {Price}", deliveryPurPriceNumeric.Value);
                MessageBox.Show("Введите закупочную цену", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (deliveryQuantityNumeric.Value <= 0)
            {
                Log.Warning("Попытка добавить товар с некорректным количеством: {Quantity}", deliveryQuantityNumeric.Value);
                MessageBox.Show("Введите количество", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (expDatePicker.Value <= manufdatePicker.Value)
            {
                Log.Warning("Некорректные даты: изготовление {ManufDate} >= срок годности {ExpDate}",
                    manufdatePicker.Value, expDatePicker.Value);
                MessageBox.Show("Срок годности должен быть позже даты изготовления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var existingItem = deliveryItems.FirstOrDefault(i => i.ProductID == selectedProductId);
                if (existingItem != null)
                {
                    existingItem.Quantity += (int)deliveryQuantityNumeric.Value;
                    Log.Information("Обновлён товар {ProductName}: количество увеличено на {Quantity} (всего {Total})",
                        selectedProductName, deliveryQuantityNumeric.Value, existingItem.Quantity);
                }
                else
                {
                    deliveryItems.Add(new DeliveryItem
                    {
                        ProductID = selectedProductId,
                        ProductName = selectedProductName,
                        PurPrice = deliveryPurPriceNumeric.Value,
                        SellPrice = selectedSellPrice,
                        Quantity = (int)deliveryQuantityNumeric.Value,
                        ManufDate = manufdatePicker.Value,
                        ExpDate = expDatePicker.Value
                    });
                    Log.Information("Добавлен новый товар в поставку: {ProductName}, количество: {Quantity}, цена: {Price}",
                        selectedProductName, deliveryQuantityNumeric.Value, deliveryPurPriceNumeric.Value);
                }

                UpdateDeliveryTable();
                ClearForm();

                MessageBox.Show("Товар добавлен в поставку", "Оповещение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при добавлении товара {ProductName} в поставку", selectedProductName);
                MessageBox.Show("Ошибка при добавлении товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновляет таблицу с добавленными товарами в поставку
        /// </summary>
        private void UpdateDeliveryTable()
        {
            deliveryDataDridView.DataSource = null;
            deliveryDataDridView.DataSource = deliveryItems.Select(i => new
            {
                i.ProductName,
                Цена = i.PurPrice,
                Количество = i.Quantity,
                Изготовлен = i.ManufDate.ToShortDateString(),
                Годен = i.ExpDate.ToShortDateString()
            }).ToList();

            addFuulDeliveryButton.Text = $"Подтвердить поставку ({deliveryItems.Count})";
            Log.Debug("Обновлена таблица поставки, всего товаров: {ItemCount}", deliveryItems.Count);
        }

        /// <summary>
        /// Очищает поля ввода после добавления товара
        /// </summary>
        private void ClearForm()
        {
            deliveryPurPriceNumeric.Value = 1;
            deliveryQuantityNumeric.Value = 1;
            manufdatePicker.Value = DateTime.Now;
            expDatePicker.Value = DateTime.Now.AddYears(3);
            selectedProductId = Guid.Empty;
            selectedProductName = string.Empty;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Подтвердить поставку"
        /// </summary>
        private void addFuulDeliveryButton_Click(object sender, EventArgs e)
        {
            if (deliveryItems.Count == 0)
            {
                Log.Warning("Попытка подтвердить пустую поставку");
                MessageBox.Show("Добавьте хотя бы один товар в поставку", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new WarehouseContext())
                {
                    foreach (var item in deliveryItems)
                    {
                        var product = db.Items.FirstOrDefault(i => i.ProductID == item.ProductID);
                        if (product != null)
                        {
                            product.Quantity += item.Quantity;
                            product.PurPrice = item.PurPrice;
                            product.ManufDate = item.ManufDate;
                            product.ExpDate = item.ExpDate;
                            Log.Debug("Обновлён товар {ProductName}: остаток увеличен на {Quantity}, новая закупочная цена {Price}",
                                product.ProductName, item.Quantity, item.PurPrice);
                        }
                        else
                        {
                            Log.Warning("Товар с ID {ProductId} не найден в БД при подтверждении поставки", item.ProductID);
                        }
                    }
                    db.SaveChanges();
                }

                Log.Information("Поставка оформлена! Добавлено {ItemCount} товаров", deliveryItems.Count);
                MessageBox.Show($"Поставка оформлена!\nДобавлено {deliveryItems.Count} товаров",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                deliveryItems.Clear();
                UpdateDeliveryTable();
                ClearForm();
                LoadCatalog();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при подтверждении поставки");
                MessageBox.Show("Ошибка при оформлении поставки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отменить поставку"
        /// </summary>
        private void cancelDeliveryButton_Click(object sender, EventArgs e)
        {
            Log.Information("Поставка отменена пользователем {UserLogin}, {ItemCount} товаров удалено",
                currentUserLogin, deliveryItems.Count);
            deliveryItems.Clear();
            UpdateDeliveryTable();
            ClearForm();
            MessageBox.Show("Поставка отменена", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Импорт файла"
        /// </summary>
        private void fileImportButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл с товарами";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string extension = Path.GetExtension(filePath).ToLower();

                    Log.Information("Импорт файла поставки: {FilePath}", filePath);

                    try
                    {
                        if (extension == ".json")
                        {
                            ImportFromJson(filePath);
                        }
                        else if (extension == ".xml")
                        {
                            ImportFromXml(filePath);
                        }
                        else
                        {
                            Log.Warning("Неподдерживаемый формат файла: {Extension}", extension);
                            MessageBox.Show("Неподдерживаемый формат файла", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Ошибка при импорте файла {FilePath}", filePath);
                        MessageBox.Show($"Ошибка при импорте: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Импортирует товары из JSON файла
        /// </summary>
        /// <param name="filePath">Путь к JSON файлу</param>
        private void ImportFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var importedItems = JsonConvert.DeserializeObject<List<ImportItem>>(json);

            Log.Information("Найден {ItemCount} товаров в JSON файле", importedItems?.Count ?? 0);

            foreach (var importItem in importedItems)
            {
                AddItem(importItem);
            }

            UpdateDeliveryTable();
            MessageBox.Show($"Импортировано {importedItems.Count} товаров", "Оповещение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Импортирует товары из XML файла
        /// </summary>
        /// <param name="filePath">Путь к XML файлу</param>
        private void ImportFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportItem>));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                var importedItems = (List<ImportItem>)serializer.Deserialize(stream);

                Log.Information("Найден {ItemCount} товаров в XML файле", importedItems?.Count ?? 0);

                foreach (var importItem in importedItems)
                {
                    AddItem(importItem);
                }

                UpdateDeliveryTable();
                MessageBox.Show($"Импортировано {importedItems.Count} товаров", "Оповещение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Добавляет импортированный товар в список поставки
        /// </summary>
        /// <param name="importItem">Импортируемый товар</param>
        private void AddItem(ImportItem importItem)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var existingItem = db.Items.FirstOrDefault(i => i.ProductNumber == importItem.ProductNumber);

                    if (existingItem == null)
                    {
                        Log.Warning("Товар с артикулом {ProductNumber} не найден в каталоге", importItem.ProductNumber);
                        MessageBox.Show($"Товар с артикулом {importItem.ProductNumber} не найден в каталоге",
                            "Товар не найден", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var existingDelivery = deliveryItems.FirstOrDefault(d => d.ProductID == existingItem.ProductID);
                    if (existingDelivery != null)
                    {
                        existingDelivery.Quantity += importItem.Quantity;
                        Log.Debug("Обновлён импортированный товар {ProductName}: количество увеличено на {Quantity}",
                            existingItem.ProductName, importItem.Quantity);
                    }
                    else
                    {
                        deliveryItems.Add(new DeliveryItem
                        {
                            ProductID = existingItem.ProductID,
                            ProductName = existingItem.ProductName,
                            PurPrice = importItem.PurPrice,
                            SellPrice = existingItem.SellPrice,
                            Quantity = importItem.Quantity,
                            ManufDate = importItem.ManufDate,
                            ExpDate = importItem.ExpDate
                        });
                        Log.Information("Импортирован новый товар в поставку: {ProductName}, количество: {Quantity}",
                            existingItem.ProductName, importItem.Quantity);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при импорте товара с артикулом {ProductNumber}", importItem.ProductNumber);
            }
        }
    }
}