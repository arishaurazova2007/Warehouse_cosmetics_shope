using System;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
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
            using (var db = new WarehouseContext())
            {
                try
                {
                    Guid selectedProdId = Guid.Parse(textBoxArtikul.Text.Trim());
                    int quantityToShip = int.Parse(textBoxUnits.Text);
                    var product = db.Items.Find(selectedProdId);

                    if (product != null)
                    {
                        //Проверяем остаток
                        if (product.Quantity >= quantityToShip)
                        {
                            product.Quantity -= quantityToShip;
                            db.SaveChanges(); // Фиксируем изменения в БД

                            MessageBox.Show("Успешно: товар списан со склада.");

                            // Очищаем поля для удобства
                            textBoxArtikul.Clear();
                            textBoxUnits.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка: Недостаточно товара на складе!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: Товар с таким артикулом не найден.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка: Проверьте правильность ввода артикула и количества.");
                }
            }
        }
        private void GenerateShipmentList()
        {
            // Формирование списка отгрузки
        }
        private void LoadProducts()
        {
            // Загрузка товаров в ComboBox
        }
        private void LoadClientTypes()
        {
            // Загрузка типов клиентов в ComboBox
        }
        private void LoadOtgruzkaTable()
        {
            // Загрузка таблицы отгрузки
        }
        private void OtgruzkaForm_Load(object sender, EventArgs e)
        {
            LoadProducts();      // Загрузить товары
            LoadClientTypes();   // Загрузить типы клиентов
            LoadOtgruzkaTable(); // Загрузить таблицу
        }
    }
}
