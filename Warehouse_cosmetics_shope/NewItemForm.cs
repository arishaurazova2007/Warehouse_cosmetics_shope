using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope
{
    public partial class NewItemForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;

        public NewItemForm(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;

            LoadCategories();
            LoadUnits();
        }

        private void LoadCategories()
        {
            using (var db = new WarehouseContext())
            {
                var allCategories = db.Categories.ToList();
                var displayList = allCategories.Select(cat => new
                {
                    CategoryID = cat.CategoryID,
                    FullPath = GetCategoryPath(cat.CategoryID, allCategories)
                }).OrderBy(c => c.FullPath).ToList();

                categoryComboBox.DataSource = displayList;
                categoryComboBox.DisplayMember = "FullPath";
                categoryComboBox.ValueMember = "CategoryID";
            }
        }

        private string GetCategoryPath(Guid categoryId, System.Collections.Generic.List<Category> allCategories)
        {
            var path = new System.Collections.Generic.List<string>();
            var current = allCategories.FirstOrDefault(c => c.CategoryID == categoryId);

            while (current != null)
            {
                path.Insert(0, current.CategoryName);
                current = allCategories.FirstOrDefault(c => c.CategoryID == current.ParentID);
            }

            return string.Join(" → ", path);
        }

        private void LoadUnits()
        {
            var units = Enum.GetValues(typeof(MeasurementUnits))
                .Cast<MeasurementUnits>()
                .Select(u => new { Value = u, Display = GetUnitDisplayName(u) })
                .ToList();

            unitComboBox.DataSource = units;
            unitComboBox.DisplayMember = "Display";
            unitComboBox.ValueMember = "Value";
        }

        private string GetUnitDisplayName(MeasurementUnits unit)
        {
            switch (unit)
            {
                case MeasurementUnits.Piece: return "Шт";
                case MeasurementUnits.Milliliter: return "Мл";
                case MeasurementUnits.Gram: return "Гр";
                default: return unit.ToString();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(productNameTextBox.Text))
            {
                MessageBox.Show("Введите наименование товара", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                productNameTextBox.Focus();
                return false;
            }

            if (categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoryComboBox.Focus();
                return false;
            }

            if (unitComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите единицу измерения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                unitComboBox.Focus();
                return false;
            }

            if (sellPriceNumeric.Value <= 0)
            {
                MessageBox.Show("Цена продажи должна быть больше 0", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sellPriceNumeric.Focus();
                return false;
            }

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            using (var db = new WarehouseContext())
            {
                var newProduct = new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = productNameTextBox.Text.Trim(),
                    CategoryID = (Guid)categoryComboBox.SelectedValue,
                    PurPrice = 0,  // пока не указана, заполнится в поставке
                    SellPrice = sellPriceNumeric.Value,
                    Quantity = 0,   // товара нет на складе
                    Units = (MeasurementUnits)unitComboBox.SelectedValue,
                    ExpDate = DateTime.Now.AddYears(3),
                    ManufDate = DateTime.Now
                };

                db.Items.Add(newProduct);
                db.SaveChanges();

                MessageBox.Show($"Карточка товара создана!\nАртикул: {newProduct.ProductNumber}\n\nДля добавления товара на склад оформите поставку.",
                    "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }
    }
}