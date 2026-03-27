using System;
using System.Windows.Forms;
using System.Linq;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    public partial class EditForm : Form
    {
        private Guid productId;
        private Guid currentUserId;
        public EditForm()
        {
            InitializeComponent();
            productId = Guid.Empty;
        }
        public EditForm(Guid productId, Guid userId)
        {
            InitializeComponent();
            this.productId = productId;
            this.currentUserId = userId;
            if (productId != Guid.Empty)
            {
                LoadProductData();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveProduct(); // Метод для БД
            var catalogForm = new CatalogFormAdmin(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId);
            catalogForm.Show();
            this.Hide();
        }
        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            var editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
            this.Hide();
        }
        private void LoadProductData()
        {
            using (var db = new WarehouseContext())
            {
                var product = db.Items.Include("Category").FirstOrDefault(p => p.ProductID == productId);
                if (product != null)
                {
                    textBoxProductName.Text = product.ProductName;
                    textBoxPrice.Text = product.Price.ToString();
                    textBoxExpDate.Text = product.ExpDate.ToString();

                    // Безопасная установка значений для ComboBox
                    if (comboBoxCategory != null)
                    {
                        comboBoxCategory.SelectedValue = product.CategoryID;
                    }
                    if (comboBoxType != null)
                    {
                        comboBoxType.SelectedItem = product.Units;
                    }
                    if (textBoxUnits != null)
                    {
                        textBoxUnits.Text = product.Units.ToString();
                    }
                }
            }
        }
        private void SaveProduct()
        {
            using (var db = new WarehouseContext())
            {
                Item product;
                if (productId == Guid.Empty)
                {
                    product = new Item { ProductID = Guid.NewGuid() };
                    db.Items.Add(product);
                }
                else
                {
                    product = db.Items.Find(productId);
                }
                product.ProductName = textBoxProductName.Text;
                decimal price;
                if (decimal.TryParse(textBoxPrice.Text, out price))
                {
                    product.Price = price;
                }
                else
                {
                    MessageBox.Show("Неверный формат цены", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int quantity;
                if (int.TryParse(textBoxPrice.Text, out quantity))
                {
                    product.Quantity = quantity;
                }
                else
                {
                    product.Quantity = 0;
                }

                DateTime expDate;
                if (DateTime.TryParse(textBoxExpDate.Text, out expDate))
                {
                    product.ExpDate = expDate;
                }
                else
                {
                    product.ExpDate = DateTime.Now.AddYears(3);
                }

                MeasurementUnits units;
                if (textBoxUnits != null && Enum.TryParse(textBoxUnits.Text, out units))
                {
                    product.Units = units;
                }
                else
                {
                    product.Units = MeasurementUnits.Шт;
                }

                db.SaveChanges();
            }
        }
        private void LoadCategories()
        {
            using (var db = new WarehouseContext())
            {
                var categories = db.Categories.Where(c => c.ParentID == null).ToList();
                comboBoxCategory.DataSource = categories;
                comboBoxCategory.DisplayMember = "CategoryName";
                comboBoxCategory.ValueMember = "CategoryID";
            }
        }
        private void LoadTypes()
        {
            if (comboBoxType != null)
            {
                var units = Enum.GetValues(typeof(MeasurementUnits)).Cast<MeasurementUnits>().ToList();
                comboBoxType.DataSource = units;
            }
            if (textBoxUnits != null)
            {
                textBoxUnits.Text = MeasurementUnits.Шт.ToString(); // Значение по умолчанию
            }
        }
        private void EditForm_Load(object sender, EventArgs e)
        {
            LoadCategories(); //  БД
            LoadTypes();      //  БД
        }
        private void Deletebutton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                Resources.ConfirmDelete,
                Resources.ConfirmDeleteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                DeleteProductFromCatalog();
                LogDeletionToHistory();
                var catalogForm = new CatalogFormAdmin(currentUserId);
                catalogForm.Show();
                this.Hide();
            }
        }
        private void DeleteProductFromCatalog()
        {
            using (var db = new WarehouseContext())
            {
                var product = db.Items.Find(productId);
                if (product != null)
                {
                    db.Items.Remove(product);
                    db.SaveChanges();
                }
            }
        }
        private void LogDeletionToHistory()
        {
            // TODO: Добавить запись в таблицу истории
            // Пример:
            // db.HistoryChanges.Add(new HistoryChange {
            //     ProductId = productId,
            //     UserId = currentUserId,
            //     ActionType = "Delete",
            //     ActionDate = DateTime.Now
            // });
        }
    }
}