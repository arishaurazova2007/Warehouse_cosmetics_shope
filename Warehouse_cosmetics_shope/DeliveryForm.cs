using Newtonsoft.Json;
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

        public DeliveryForm(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;

            LoadCatalog();
            SetupCatalogGridView();
            SetupCatalogGridView();
        }

        private void LoadCatalog()
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
            }
        }

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

        private void DeliverySearchBox_Enter(object sender, EventArgs e)
        {
            if (deliverySearchBox.Text == "Поиск")
            {
                deliverySearchBox.Text = String.Empty;
                deliverySearchBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void DeliverySearchBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(deliverySearchBox.Text))
            {
                deliverySearchBox.Text = "Поиск";
                deliverySearchBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void DeliverySearchBox_TextChanged(object sender, EventArgs e)
        {
            if (deliverySearchBox.Text == "Поиск" || string.IsNullOrWhiteSpace(deliverySearchBox.Text))
            {
                LoadCatalog();
                return;
            }

            string searchText = deliverySearchBox.Text.Trim().ToLower();

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
            }
        }

        private void DeliverySearchButton_Click(object sender, EventArgs e)
        {
            DeliverySearchBox_TextChanged(sender, e);
        }

        private Guid selectedProductId = Guid.Empty;
        private string selectedProductName = String.Empty;
        private decimal selectedSellPrice = 0;

        private void CatalogInDeliveryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedProductId = (Guid)catalogInDeliveryGridView.Rows[e.RowIndex].Cells["ProductID"].Value;
                selectedProductName = catalogInDeliveryGridView.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                selectedSellPrice = (decimal)catalogInDeliveryGridView.Rows[e.RowIndex].Cells["SellPrice"].Value;
                deliverySearchBox.Text = selectedProductName;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            if (selectedProductId == Guid.Empty)
            {
                MessageBox.Show("Выберите товар из каталога", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (deliveryPurPriceNumeric.Value <= 0)
            {
                MessageBox.Show("Введите закупочную цену", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (deliveryQuantityNumeric.Value <= 0)
            {
                MessageBox.Show("Введите количество", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (expDatePicker.Value <= manufdatePicker.Value)
            {
                MessageBox.Show("Срок годности должен быть позже даты изготовления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //проверяем, не добавлен ли уже этот товар в текущую поставку
            var existingItem = deliveryItems.FirstOrDefault(i => i.ProductID == selectedProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += (int)deliveryQuantityNumeric.Value;
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
            }

            UpdateDeliveryTable();
            ClearForm();

            MessageBox.Show("Товар добавлен в поставку", "Оповещение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateDeliveryTable()
        {
            deliveryDataDridView.DataSource = null;
            deliveryDataDridView.DataSource = deliveryItems.Select(i => new
            {
                i.ProductName,
                Цена = i.PurPrice,
                Колво = i.Quantity,
                Изготовлен = i.ManufDate.ToShortDateString(),
                Годен = i.ExpDate.ToShortDateString()
            }).ToList();

            addFuulDeliveryButton.Text = $"Подтвердить поставку ({deliveryItems.Count})";
        }

        private void ClearForm()
        {
            deliveryPurPriceNumeric.Value = 1;
            deliveryQuantityNumeric.Value = 1;
            manufdatePicker.Value = DateTime.Now;
            expDatePicker.Value = DateTime.Now.AddYears(3);
            selectedProductId = Guid.Empty;
            selectedProductName = String.Empty;
        }

        private void addFuulDeliveryButton_Click(object sender, EventArgs e)
        {
            if (deliveryItems.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один товар в поставку", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new WarehouseContext())
            {
                foreach (var item in deliveryItems)
                {
                    var product = db.Items.FirstOrDefault(i => i.ProductID == item.ProductID);
                    if (product != null)
                    {
                        //увеличиваем остаток на складе
                        product.Quantity += item.Quantity;

                        //обновляем закупочную цену
                        product.PurPrice = item.PurPrice;

                        //Обновляем даты
                        product.ManufDate = item.ManufDate;
                        product.ExpDate = item.ExpDate;
                    }
                }
                db.SaveChanges();
            }

            MessageBox.Show($"Поставка оформлена!\nДобавлено {deliveryItems.Count} товаров",
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            deliveryItems.Clear();
            UpdateDeliveryTable();
            ClearForm();
            LoadCatalog();
        }

        private void cancelDeliveryButton_Click(object sender, EventArgs e)
        {
            deliveryItems.Clear();
            UpdateDeliveryTable();
            ClearForm();
            MessageBox.Show("Поставка отменена", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
                            MessageBox.Show("Неподдерживаемый формат файла", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при импорте: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ImportFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var importedItems = JsonConvert.DeserializeObject<List<ImportItem>>(json);

            foreach (var importItem in importedItems)
            {
                AddItem(importItem);
            }

            UpdateDeliveryTable();
            MessageBox.Show($"Импортировано {importedItems.Count} товаров", "Оповещение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImportFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportItem>));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                var importedItems = (List<ImportItem>)serializer.Deserialize(stream);

                foreach (var importItem in importedItems)
                {
                    AddItem(importItem);
                }

                UpdateDeliveryTable();
                MessageBox.Show($"Импортировано {importedItems.Count} товаров", "Оповещение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddItem(ImportItem importItem)
        {
            {
                using (var db = new WarehouseContext())
                {
                    var existingItem = db.Items.FirstOrDefault(i => i.ProductNumber == importItem.ProductNumber);

                    if (existingItem == null)
                    {
                        MessageBox.Show($"Товар с артикулом {importItem.ProductNumber} не найден в каталоге.\n" +
                            $"Импорт этого товара пропущен.",
                            "Товар не найден",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //товар найден
                    var existingDelivery = deliveryItems.FirstOrDefault(d => d.ProductID == existingItem.ProductID);
                    if (existingDelivery != null)
                    {
                        existingDelivery.Quantity += importItem.Quantity;
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
                    }
                }
            }
        }
    }
}