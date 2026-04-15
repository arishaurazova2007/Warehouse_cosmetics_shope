using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope
{
    public partial class ItemForm : Form
    {
        private Guid productId;
        private Guid currentUserId;
        private string currentUserLogin;

        public ItemForm()
        {
            InitializeComponent();
        }

        public ItemForm(Guid productId, Guid userId, string userLogin)
        {
            InitializeComponent();
            LoadCategories();
            LoadUnits();
            LoadProductData();
        }

        /// <summary>
        /// Загрузка категорий с полным путём
        /// </summary>
        private void LoadCategories()
        {
            using (var db = new WarehouseContext())
            {
                var allCategories = db.Categories.ToList();
                var displayList = allCategories.Select(cat => new CategoryPath
                {
                    CategoryID = cat.CategoryID,
                    FullPath = GetCategoryPath(cat.CategoryID, allCategories)
                }).OrderBy(c => c.FullPath).ToList();

                categoryComboBox.DataSource = displayList;
                categoryComboBox.DisplayMember = "FullPath";
                categoryComboBox.ValueMember = "CategoryID";

                categoryComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                categoryComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        /// <summary>
        /// Получение полного пути категории (рекурсивно)
        /// </summary>
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

        /// <summary>
        /// Загрузка единиц измерения
        /// </summary>
        private void LoadUnits()
        {
            measUnitsComboBox.DataSource = Enum.GetValues(typeof(MeasurementUnits))
                .Cast<MeasurementUnits>()
                .Select(u => new { Value = u, Display = GetUnitDisplayName(u) })
                .ToList();
            measUnitsComboBox.DisplayMember = "Display";
            measUnitsComboBox.ValueMember = "Value";
        }

        /// <summary>
        /// Получение отображаемого имени единицы измерения
        /// </summary>
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

        /// <summary>
        /// Загрузка данных товара (для редактирования)
        /// </summary>
        private void LoadProductData()
        {
            if (productId == Guid.Empty) return;

            using (var db = new WarehouseContext())
            {
                var product = db.Items.FirstOrDefault(i => i.ProductID == productId);
                if (product != null)
                {
                    productNameInput.Text = product.ProductName;
                    showProductNumberLabel.Text = product.ProductNumber.ToString();
                    purPriceNumeric.Value = product.PurPrice;
                    sellPriceNumeric.Value = product.SellPrice;
                    quantityPickOrShowNumeric.Value = product.Quantity;
                    expDatePicker.Value = product.ExpDate;
                    manufdatePicker.Value = product.ManufDate;
                    measUnitsComboBox.SelectedItem = product.Units;
                    categoryComboBox.SelectedValue = product.CategoryID;
                }
            }
        }

        /// <summary>
        /// Сохранение товара
        /// </summary>
        private void EditProduct()
        {
            using (var db = new WarehouseContext())
            {
                    var product = db.Items.FirstOrDefault(i => i.ProductID == productId);
                    if (product != null)
                    {
                        product.ProductName = productNameInput.Text.Trim();
                        product.CategoryID = (Guid)categoryComboBox.SelectedValue;
                        product.PurPrice = purPriceNumeric.Value;
                        product.SellPrice = sellPriceNumeric.Value;
                        product.Units = (MeasurementUnits)measUnitsComboBox.SelectedValue;
                        product.ExpDate = expDatePicker.Value;
                        product.ManufDate = manufdatePicker.Value;
                        db.SaveChanges();

                        MessageBox.Show("Товар успешно обновлён!", "Оповещение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
             
            }
           
        }

        /// <summary>
        /// Удаление товара
        /// </summary>
        private void DeleteProduct()
        {
            using (var db = new WarehouseContext())
            {
                var product = db.Items.FirstOrDefault(i => i.ProductID == productId);
                if (product != null)
                {
                    db.Items.Remove(product);
                    db.SaveChanges();
                    MessageBox.Show("Товар удалён!", "Оповещение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Проверка заполнения формы
        /// </summary>
        private bool ValidateForm()
        {
            //проверка наименования товара
            if (string.IsNullOrWhiteSpace(productNameInput.Text))
            {
                MessageBox.Show("Введите наименование товара", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                productNameInput.Focus();
                return false;
            }

            //проверка выбора категории
            if (categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию товара", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoryComboBox.Focus();
                return false;
            }

            //проверка выбора единиц измерения
            if (measUnitsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите единицу измерения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                measUnitsComboBox.Focus();
                return false;
            }

            //проверка цены продажи
            if (sellPriceNumeric.Value <= 0)
            {
                MessageBox.Show("Цена продажи должна быть больше 0", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sellPriceNumeric.Focus();
                return false;
            }

            // Проверка даты изготовления (не может быть в будущем)
            if (manufdatePicker.Value > DateTime.Now)
            {
                MessageBox.Show("Дата изготовления не может быть в будущем", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                manufdatePicker.Focus();
                return false;
            }

            //проверка срока годности (должен быть позже даты изготовления)
            if (expDatePicker.Value <= manufdatePicker.Value)
            {
                MessageBox.Show("Дата истечения срока годности должна быть позже даты изготовления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                expDatePicker.Focus();
                return false;
            }

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                EditProduct();
                var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
                catalogForm.Show();
                this.Hide();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
            catalogForm.Show();
            this.Hide();
        }

        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            var editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить этот товар?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteProduct();
                var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
                catalogForm.Show();
                this.Hide();
            }
        }
    }

    /// <summary>
    /// Вспомогательный класс для отображения категории с полным путём
    /// </summary>
    public class CategoryPath
    {
        public Guid CategoryID { get; set; }
        public string FullPath { get; set; }
    }
}