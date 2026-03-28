using System;
using System.Windows.Forms;
using System.Linq;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Properties;
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
            var editCategoryForm = new EditCategoryForm(Guid.Empty, currentUserId);  // ✅ С параметрами!
            editCategoryForm.Show();
            this.Hide();
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

                if (product == null) return;

                product.ProductName = textBoxProductName.Text;
                if (comboBoxCategory.SelectedValue != null)
                    product.CategoryID = (Guid)comboBoxCategory.SelectedValue;
                if (decimal.TryParse(textBoxPrice.Text, out decimal price))
                    product.Price = price;
                if (int.TryParse(textBoxUnits.Text, out int qty))
                    product.Quantity = qty;
                if (DateTime.TryParse(textBoxExpDate.Text, out DateTime exp))
                    product.ExpDate = exp;
                if (comboBoxType.SelectedItem != null)
                    product.Units = (MeasurementUnits)comboBoxType.SelectedItem;
                db.SaveChanges();
                // Логирование создания/обновления
                db.HistoryChanges.Add(new HistoryChange
                {
                    HistoryID = Guid.NewGuid(),
                    ProductID = product.ProductID,
                    UserID = currentUserId,
                    ActionType = (productId == Guid.Empty) ? "Create" : "Update",
                    Details = (productId == Guid.Empty) ? "Создан новый товар" : "Обновлены данные товара",
                    ActionDate = DateTime.Now
                });
                db.SaveChanges();
                MessageBox.Show(Resources.ProductSaved, Resources.Success,
    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (productId != Guid.Empty)
            {
                LoadProductData();
            }
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
        private void LoadProductData()
        {
            using (var db = new WarehouseContext())
            {
                var product = db.Items.Include("Category").FirstOrDefault(p => p.ProductID == productId);
                if (product != null)
                {
                    textBoxProductName.Text = product.ProductName;
                    textBoxPrice.Text = product.Price.ToString();
                    textBoxExpDate.Text = product.ExpDate.ToString("dd.MM.yyyy");
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
        private void LogDeletionToHistory()
        {
            using (var db = new WarehouseContext())
            {
                db.HistoryChanges.Add(new HistoryChange
                {
                    HistoryID = Guid.NewGuid(),
                    ProductID = productId,
                    UserID = currentUserId,
                    ActionType = "Delete",
                    Details = "Товар удалён из каталога",
                    ActionDate = DateTime.Now
                });
                db.SaveChanges();
            }
        }
    }
}