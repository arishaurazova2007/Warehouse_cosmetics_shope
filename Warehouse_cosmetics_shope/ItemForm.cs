using Serilog;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;
using Warehouse_cosmetics_shope.Helpers;

namespace Warehouse_cosmetics_shope
{
    public partial class ItemForm : Form
    {
        private Guid productId;
        private Guid currentUserId;
        private string currentUserLogin;
        private Roles currentUserRole;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ItemForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для администратора (создание/редактирование товара)
        /// </summary>
        /// <param name="productId">Идентификатор товара (Guid.Empty для нового товара)</param>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="userLogin">Логин текущего пользователя</param>
        /// <param name="userRole">Роль текущего пользователя</param>
        public ItemForm(Guid productId, Guid userId, string userLogin, Roles userRole)
        {
            InitializeComponent();
            this.productId = productId;
            this.currentUserId = userId;
            this.currentUserLogin = userLogin;
            this.currentUserRole = userRole;

            Log.Information("Администратор {UserLogin} открыл форму товара (режим: {Mode})",
                userLogin, productId == Guid.Empty ? "создание" : "редактирование");

            if (productId == Guid.Empty)
            {
                itemFormTitleLabel.Text = "Добавление нового товара";

                productNameInput.ReadOnly = false;
                productNameInput.BackColor = Color.White;

                categoryComboBox.Enabled = true;
                categoryComboBox.BackColor = Color.White;

                measUnitsComboBox.Enabled = true;
                measUnitsComboBox.BackColor = Color.White;

                sellPriceNumeric.Enabled = true;
                sellPriceNumeric.BackColor = Color.White;

                manufdatePicker.Enabled = true;
                manufdatePicker.BackColor = Color.White;

                expDatePicker.Enabled = true;
                expDatePicker.BackColor = Color.White;

                purPriceNumeric.Enabled = false;
                purPriceNumeric.BackColor = SystemColors.Control;

                quantityPickOrShowNumeric.Enabled = false;
                quantityPickOrShowNumeric.BackColor = SystemColors.Control;

                showProductNumberLabel.Text = "Будет задан после добавления товара";
                showProductNumberLabel.ForeColor = Color.Gray;
                showProductNumberLabel.Font = new Font(showProductNumberLabel.Font, FontStyle.Regular);

                buttonSave.Visible = true;
                buttonSave.Enabled = true;

                Deletebutton.Visible = false;
                Deletebutton.Enabled = false;
            }
            else
            {
                itemFormTitleLabel.Text = "Редактирование товара";

                productNameInput.ReadOnly = false;
                productNameInput.BackColor = Color.White;

                categoryComboBox.Enabled = true;
                categoryComboBox.BackColor = Color.White;

                measUnitsComboBox.Enabled = true;
                measUnitsComboBox.BackColor = Color.White;

                sellPriceNumeric.Enabled = true;
                sellPriceNumeric.BackColor = Color.White;

                manufdatePicker.Enabled = true;
                manufdatePicker.BackColor = Color.White;

                expDatePicker.Enabled = true;
                expDatePicker.BackColor = Color.White;

                purPriceNumeric.Enabled = false;
                purPriceNumeric.BackColor = SystemColors.Control;

                quantityPickOrShowNumeric.Enabled = false;
                quantityPickOrShowNumeric.BackColor = SystemColors.Control;

                showProductNumberLabel.Text = string.Empty;

                buttonSave.Visible = true;
                buttonSave.Enabled = true;

                Deletebutton.Visible = true;
                Deletebutton.Enabled = true;
            }

            LoadCategories();
            LoadUnits();
            LoadProductData();
        }

        /// <summary>
        /// Конструктор для кладовщика (только просмотр)
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="userLogin">Логин текущего пользователя</param>
        /// <param name="userRole">Роль текущего пользователя</param>
        /// <param name="isReadOnly">Флаг режима только для чтения</param>
        public ItemForm(Guid productId, Guid userId, string userLogin, Roles userRole, bool isReadOnly)
        {
            InitializeComponent();
            this.productId = productId;
            this.currentUserId = userId;
            this.currentUserLogin = userLogin;
            this.currentUserRole = userRole;

            itemFormTitleLabel.Text = "Карточка товара";
            Log.Information("Кладовщик {UserLogin} открыл карточку товара (ID: {ProductId})", userLogin, productId);

            SetReadOnlyMode();
            HideEditButtons();

            LoadCategories();
            LoadUnits();
            LoadProductData();
        }

        /// <summary>
        /// Устанавливает режим только для чтения для всех полей ввода
        /// </summary>
        private void SetReadOnlyMode()
        {
            productNameInput.ReadOnly = true;
            productNameInput.BackColor = SystemColors.Control;

            categoryComboBox.Enabled = false;
            categoryComboBox.BackColor = SystemColors.Control;

            measUnitsComboBox.Enabled = false;
            measUnitsComboBox.BackColor = SystemColors.Control;

            purPriceNumeric.Enabled = false;
            purPriceNumeric.BackColor = SystemColors.Control;

            sellPriceNumeric.Enabled = false;
            sellPriceNumeric.BackColor = SystemColors.Control;

            quantityPickOrShowNumeric.Enabled = false;
            quantityPickOrShowNumeric.BackColor = SystemColors.Control;

            manufdatePicker.Enabled = false;
            manufdatePicker.BackColor = SystemColors.Control;

            expDatePicker.Enabled = false;
            expDatePicker.BackColor = SystemColors.Control;

            buttonSave.Visible = false;
            buttonSave.Enabled = false;
        }

        /// <summary>
        /// Скрывает кнопку удаления товара
        /// </summary>
        private void HideEditButtons()
        {
            Deletebutton.Visible = false;
            Deletebutton.Enabled = false;
        }

        /// <summary>
        /// Загрузка категорий с полным путём
        /// </summary>
        private void LoadCategories()
        {
            try
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

                    Log.Debug("Загружено {CategoryCount} категорий", displayList.Count);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке категорий");
                MessageBox.Show("Ошибка при загрузке категорий", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получение полного пути категории (рекурсивно)
        /// </summary>
        /// <param name="categoryId">Идентификатор категории</param>
        /// <param name="allCategories">Список всех категорий</param>
        /// <returns>Полный путь категории в формате "Родитель → Дочерняя → Внучатая"</returns>
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
        /// Загрузка единиц измерения в выпадающий список
        /// </summary>
        private void LoadUnits()
        {
            try
            {
                measUnitsComboBox.DataSource = System.Enum.GetValues(typeof(MeasurementUnits))
                    .Cast<MeasurementUnits>()
                    .Select(u => new { Value = u, Display = GetUnitDisplayName(u) })
                    .ToList();
                measUnitsComboBox.DisplayMember = "Display";
                measUnitsComboBox.ValueMember = "Value";

                Log.Debug("Загружены единицы измерения");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке единиц измерения");
                MessageBox.Show("Ошибка при загрузке единиц измерения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получение отображаемого имени единицы измерения
        /// </summary>
        /// <param name="unit">Единица измерения</param>
        /// <returns>Русское название единицы измерения</returns>
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
        /// Загрузка данных товара для редактирования
        /// </summary>
        private void LoadProductData()
        {
            if (productId == Guid.Empty) return;

            try
            {
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

                        Log.Debug("Загружены данные товара: {ProductName}, артикул: {ProductNumber}",
                            product.ProductName, product.ProductNumber);
                    }
                    else
                    {
                        Log.Warning("Товар с ID {ProductId} не найден в БД", productId);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке данных товара ID {ProductId}", productId);
                MessageBox.Show("Ошибка при загрузке данных товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавление нового товара (создание карточки)
        /// </summary>
        private void AddNewProduct()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var newProduct = new Item
                    {
                        ProductID = Guid.NewGuid(),
                        ProductName = productNameInput.Text.Trim(),
                        CategoryID = (Guid)categoryComboBox.SelectedValue,
                        PurPrice = 0,
                        SellPrice = sellPriceNumeric.Value,
                        Quantity = 0,
                        Units = (MeasurementUnits)measUnitsComboBox.SelectedValue,
                        ManufDate = manufdatePicker.Value,
                        ExpDate = expDatePicker.Value
                    };

                    db.Items.Add(newProduct);
                    db.SaveChanges();

                    Log.Information("Создана карточка товара: {ProductName}, артикул: {ProductNumber}",
                        newProduct.ProductName, newProduct.ProductNumber);

                    MessageBox.Show($"Карточка товара создана!\nАртикул: {newProduct.ProductNumber}\n\nДля добавления товара на склад оформите поставку.",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при создании карточки товара {ProductName}", productNameInput.Text);
                MessageBox.Show("Ошибка при создании карточки товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Редактирование существующего товара
        /// </summary>
        private void EditProduct()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var product = db.Items.FirstOrDefault(i => i.ProductID == productId);
                    if (product != null)
                    {
                        string oldName = product.ProductName;
                        product.ProductName = productNameInput.Text.Trim();
                        product.CategoryID = (Guid)categoryComboBox.SelectedValue;
                        product.SellPrice = sellPriceNumeric.Value;
                        product.Units = (MeasurementUnits)measUnitsComboBox.SelectedValue;
                        product.ExpDate = expDatePicker.Value;
                        product.ManufDate = manufdatePicker.Value;
                        db.SaveChanges();

                        Log.Information("Товар обновлён: '{OldName}' → '{NewName}' (ID: {ProductId})",
                            oldName, product.ProductName, productId);

                        MessageBox.Show("Товар успешно обновлён!", "Оповещение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Log.Warning("Товар с ID {ProductId} не найден для редактирования", productId);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при редактировании товара ID {ProductId}", productId);
                MessageBox.Show("Ошибка при редактировании товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление товара из базы данных
        /// </summary>
        private void DeleteProduct()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var product = db.Items.FirstOrDefault(i => i.ProductID == productId);
                    if (product != null)
                    {
                        string productName = product.ProductName;
                        db.Items.Remove(product);
                        db.SaveChanges();

                        Log.Information("Товар удалён: {ProductName} (ID: {ProductId})", productName, productId);

                        MessageBox.Show("Товар удалён!", "Оповещение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Log.Warning("Товар с ID {ProductId} не найден для удаления", productId);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при удалении товара ID {ProductId}", productId);
                MessageBox.Show("Ошибка при удалении товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверка корректности заполнения формы
        /// </summary>
        /// <returns>true - если данные валидны, false - если есть ошибки</returns>
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(productNameInput.Text))
            {
                Log.Warning("Попытка сохранить товар без наименования");
                MessageBox.Show("Введите наименование товара", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                productNameInput.Focus();
                return false;
            }

            if (categoryComboBox.SelectedItem == null)
            {
                Log.Warning("Попытка сохранить товар без выбора категории");
                MessageBox.Show("Выберите категорию товара", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoryComboBox.Focus();
                return false;
            }

            if (measUnitsComboBox.SelectedItem == null)
            {
                Log.Warning("Попытка сохранить товар без выбора единицы измерения");
                MessageBox.Show("Выберите единицу измерения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                measUnitsComboBox.Focus();
                return false;
            }

            if (sellPriceNumeric.Value <= 0)
            {
                Log.Warning("Попытка сохранить товар с некорректной ценой продажи: {Price}", sellPriceNumeric.Value);
                MessageBox.Show("Цена продажи должна быть больше 0", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sellPriceNumeric.Focus();
                return false;
            }

            if (manufdatePicker.Value > DateTime.Now)
            {
                Log.Warning("Попытка сохранить товар с датой изготовления в будущем: {Date}", manufdatePicker.Value);
                MessageBox.Show("Дата изготовления не может быть в будущем", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                manufdatePicker.Focus();
                return false;
            }

            if (expDatePicker.Value <= manufdatePicker.Value)
            {
                Log.Warning("Некорректные даты: изготовление {ManufDate} <= срок годности {ExpDate}",
                    manufdatePicker.Value, expDatePicker.Value);
                MessageBox.Show("Дата истечения срока годности должна быть позже даты изготовления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                expDatePicker.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (productId == Guid.Empty)
                {
                    AddNewProduct();
                    Log.Information("Товар создан");
                }
                else
                {
                    EditProduct();
                    Log.Information("Товар отредактирован");
                }

                var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
                catalogForm.Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Log.Information("Пользователь {UserLogin} вернулся в каталог", currentUserLogin);

            if (currentUserRole == Roles.Admin)
            {
                var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
                catalogForm.Show();
            }
            else
            {
                var catalogForm = new CatalogFormKlad(currentUserId, currentUserLogin);
                catalogForm.Show();
            }
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Удалить товар"
        /// </summary>
        private void Deletebutton_Click(object sender, EventArgs e)
        {
            Log.Information("Пользователь {UserLogin} запросил удаление товара ID {ProductId}", currentUserLogin, productId);

            var result = MessageBox.Show("Вы уверены, что хотите удалить этот товар?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteProduct();
                var catalogForm = new CatalogFormAdmin(currentUserId, currentUserLogin);
                catalogForm.Show();
                this.Hide();
            }
            else
            {
                Log.Debug("Удаление товара ID {ProductId} отменено", productId);
            }
        }
    }
}