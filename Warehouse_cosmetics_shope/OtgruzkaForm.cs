using System;
using System.Windows.Forms;
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
            // Добавление товара в отгрузку
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
