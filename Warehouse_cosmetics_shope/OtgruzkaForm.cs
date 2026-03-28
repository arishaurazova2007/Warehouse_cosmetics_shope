using System;
using System.Data.Entity;       
using System.Linq;              
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Properties;
using System.Collections.Generic;
namespace Warehouse_cosmetics_shope
{
    public partial class OtgruzkaForm : Form
    {
        private Guid currentUserId;
        public OtgruzkaForm()
        {
            InitializeComponent();
        }
        public OtgruzkaForm(Guid userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            AddProductToOtgruzka(); // Метод для БД
            LoadOtgruzkaTable();    // для обновления таблицы
        }
        private void buttonGenerateList_Click(object sender, EventArgs e)
        {
            GenerateShipmentList(); // Метод для БД
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormKlad(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
        private void AddProductToOtgruzka()
        {
            // Валидация
            if (comboBoxName.SelectedItem == null)
            {
                MessageBox.Show(Resources.SelectProduct, Resources.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxUnits.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show(Resources.InvalidQuantity, Resources.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxType.SelectedItem == null)
            {
                MessageBox.Show(Resources.SelectClient, Resources.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxType.Focus();
                return;
            }
            using (var db = new WarehouseContext())
            {
                try
                {
                    var selectedProduct = comboBoxName.SelectedItem as Item;
                    var selectedClientType = (comboBoxType.SelectedItem as dynamic)?.Value;

                    if (selectedProduct == null)
                    {
                        MessageBox.Show(Resources.ProductNotFound, Resources.Error,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Находим актуальный товар в БД
                    var product = db.Items
                        .Include("Category")
                        .FirstOrDefault(p => p.ProductID == selectedProduct.ProductID);

                    if (product == null)
                    {
                        MessageBox.Show(Resources.ProductNotFound, Resources.Error,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Проверяем остаток
                    if (product.Quantity < quantity)
                    {
                        MessageBox.Show(string.Format(Resources.InsufficientStock, product.Quantity),
                            Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Списываем товар
                    product.Quantity -= quantity;
                    // Добавляем строку в таблиц
                    var selectedClient = comboBoxType.SelectedItem as Client;
                    string clientName = selectedClient?.ClientName ?? "Не указан";

                    dataGridView1.Rows.Add(
                        product.ProductName,
                        product.Category?.CategoryName ?? "Не указана",
                        product.ProductID.ToString(),
                        quantity,
                        clientName
                    );
                    db.SaveChanges();
                    MessageBox.Show(Resources.ProductAddedToShipment, Resources.Success,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Очищаем поля
                    textBoxUnits.Clear();
                    textBoxClient.Clear();
                    comboBoxName.Focus();
                    // Обновляем список товаров (остатки изменились)
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(Resources.ErrorAddingProduct, ex.Message),
                        Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void GenerateShipmentList()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show(Resources.NoProductsInShipment, Resources.Warning,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                using (var db = new WarehouseContext())
                {
                    // Получаем выбранного клиента
                    var selectedClient = comboBoxType.SelectedItem as Client;
                    if (selectedClient == null)
                    {
                        MessageBox.Show(Resources.SelectClient, Resources.Error,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Создаём новую отгрузку
                    var shipment = new Shipment
                    {
                        ShipmentID = Guid.NewGuid(),
                        ClientID = selectedClient.ClientID,
                        UserID = currentUserId,
                        Date = DateTime.Now,
                        ShipmentCompositions = new List<ShipmentComposition>()
                    };
                    db.Shipments.Add(shipment);
                    // Добавляем состав отгрузки
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var articul = row.Cells["Articul"].Value?.ToString();
                        if (Guid.TryParse(articul, out Guid productId))
                        {
                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                            var composition = new ShipmentComposition
                            {
                                ShipmentID = shipment.ShipmentID,
                                ProductID = productId,
                                Quantity = quantity
                            };
                            shipment.ShipmentCompositions.Add(composition);
                        }
                    }
                    db.SaveChanges();
                }
                MessageBox.Show(Resources.ShipmentListGenerated, Resources.Success,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Возврат в каталог
                var catalogForm = new CatalogFormKlad(currentUserId);
                catalogForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Resources.ErrorGeneratingShipment, ex.Message),
                    Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadProducts()
        {
            using (var db = new WarehouseContext())
            {
                var products = db.Items
                    .Include("Category")
                    .Where(p => p.Quantity > 0)
                    .ToList();

                comboBoxName.DataSource = products;
                comboBoxName.DisplayMember = "ProductName";
                comboBoxName.ValueMember = "ProductID";
            }
        }
        private void LoadClientTypes()
        {
            using (var db = new WarehouseContext())
            {
                var clients = db.Clients.ToList();
                if (clients.Count == 0)
                {
                    var testClient = new Client
                    {
                        ClientID = Guid.NewGuid(),
                        ClientName = "Тестовый клиент",
                        ClientType = ClientTypes.Физ_лицо
                    };
                    db.Clients.Add(testClient);
                    db.SaveChanges();
                    clients.Add(testClient);
                }
                comboBoxType.DataSource = clients;
                comboBoxType.DisplayMember = "ClientName";
                comboBoxType.ValueMember = "ClientID";
            }
        }
        private void LoadOtgruzkaTable()
        {
            // Пока просто очищаем таблицу
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            // Настраиваем колонки
            dataGridView1.Columns.Add("ProductName", "Название");
            dataGridView1.Columns.Add("Category", "Категория");
            dataGridView1.Columns.Add("Articul", "Артикул");
            dataGridView1.Columns.Add("Quantity", "Кол-во");
            dataGridView1.Columns.Add("Client", "Клиент");
        }
        private void OtgruzkaForm_Load(object sender, EventArgs e)
        {
            LoadProducts();      // Загрузить товары
            LoadClientTypes();   // Загрузить типы клиентов
            LoadOtgruzkaTable(); // Загрузить таблицу
        }
    }
}
