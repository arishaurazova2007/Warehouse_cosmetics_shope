using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;
using Serilog;
using System.Threading.Tasks;

namespace Warehouse_cosmetics_shope
{
    /// <summary>
    /// Главная форма каталога товаров для администратора.
    /// </summary>
    public partial class CatalogFormAdmin : Form
    {
        private string currentUserLogin;
        private Guid currentUserId;
        private List<Guid> currentFilterCategoryIds = null;
        private decimal? currentPriceFrom = null;
        private decimal? currentPriceTo = null;
        private bool? currentInStockOnly = null;
        private bool? currentNotInStockOnly = null;
        private bool? currentWithDiscount = null;
        private bool? currentWithoutDiscount = null;

        private readonly IWarehouseContext _db;


        public CatalogFormAdmin(Guid userId, string userLogin, IWarehouseContext db)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;
            _db = db;



            dataGridViewCatalog.DataError += (s, ev) =>
            {
                ev.ThrowException = false;

                if (ev.Exception != null)
                {
                    Log.Warning(ev.Exception, "DataGridView ошибка в строке {RowIndex}, колонке {ColumnIndex}",
                        ev.RowIndex, ev.ColumnIndex);
                }
            };

            Log.Information("Администратор {UserLogin} открыл каталог", currentUserLogin);
            InitSpinner();                                              // ← инициализируем крутилку
            this.Shown += async (s, e) => await LoadCatalogAsync();

            ShowUserLogin();
        }

        /// <summary>
        /// Загружает и отображает список товаров с учётом активных фильтров:
        /// категория, диапазон цен, наличие на складе, наличие скидки.
        /// Исключает товары с истёкшим сроком годности.
        /// </summary>
        /// <summary>
        /// Асинхронно загружает каталог товаров, не блокируя UI
        /// </summary>
        private async Task LoadCatalogAsync()
        {
            spinnerPanel.Visible = true;
            spinnerPanel.BringToFront();

            try
            {
                var today = DateTime.Now.Date;

                // Запрос к БД — в фоновом потоке
                var allItems = await Task.Run(() =>
                    _db.Items
                        .Include(i => i.Category)
                        .Include(i => i.Category.Parent)
                        .Where(i => i.ExpDate > today)
                        .ToList()
                );

                var filtered = allItems.AsEnumerable();

                if (currentFilterCategoryIds != null && currentFilterCategoryIds.Any())
                    filtered = filtered.Where(i => currentFilterCategoryIds.Contains(i.CategoryID));

                if (currentPriceFrom.HasValue)
                    filtered = filtered.Where(i => i.SellPrice >= currentPriceFrom.Value);

                if (currentPriceTo.HasValue)
                    filtered = filtered.Where(i => i.SellPrice <= currentPriceTo.Value);

                if (currentInStockOnly == true)
                    filtered = filtered.Where(i => i.Quantity > 0);
                else if (currentNotInStockOnly == true)
                    filtered = filtered.Where(i => i.Quantity == 0);

                if (currentWithDiscount == true || currentWithoutDiscount == true)
                {
                    var discountedIds = filtered
                        .Where(i => IsDiscounted(i, today))
                        .Select(i => i.ProductID)
                        .ToList();

                    if (currentWithDiscount == true)
                        filtered = filtered.Where(i => discountedIds.Contains(i.ProductID));
                    else if (currentWithoutDiscount == true)
                        filtered = filtered.Where(i => !discountedIds.Contains(i.ProductID));
                }

                var displayList = filtered.Select(i => new
                {
                    i.ProductNumber,
                    i.ProductName,
                    ParentCategoryName = i.Category?.Parent?.CategoryName,
                    ChildCategoryName = i.Category?.CategoryName,
                    Units = GetUnitDisplayName(i.Units),
                    i.ManufDate,
                    i.ExpDate,
                    PurPrice = ConvertPurPrice(i),
                    SellPrice = Math.Round(i.SellPrice / CurrencySettings.CurrentRate, 2),
                    i.Quantity
                }).ToList();

                // Обновляем UI — здесь мы уже в главном потоке
                dataGridViewCatalog.DataSource = displayList;
                ConfigureColumns();

                Log.Information("Загружено {ItemCount} товаров", displayList.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке каталога");
                MessageBox.Show("Ошибка при загрузке каталога", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                spinnerPanel.Visible = false;  // скрываем в любом случае
            }
        }

        /// <summary>
        /// Настраивает заголовки, форматирование и видимость колонок DataGridView
        /// после загрузки данных. Отображает текущую валюту в заголовке цены продажи.
        /// </summary>
        private void ConfigureColumns()
        {
            if (dataGridViewCatalog.Columns.Contains("ProductNumber"))
                dataGridViewCatalog.Columns["ProductNumber"].HeaderText = "Артикул";
            if (dataGridViewCatalog.Columns.Contains("ProductName"))
                dataGridViewCatalog.Columns["ProductName"].HeaderText = "Название";
            if (dataGridViewCatalog.Columns.Contains("ParentCategoryName"))
            {
                dataGridViewCatalog.Columns["ParentCategoryName"].HeaderText = "Категория";
                dataGridViewCatalog.Columns["ParentCategoryName"].Visible = false;
            }
            if (dataGridViewCatalog.Columns.Contains("ChildCategoryName"))
                dataGridViewCatalog.Columns["ChildCategoryName"].HeaderText = "Категория";
            if (dataGridViewCatalog.Columns.Contains("Units"))
                dataGridViewCatalog.Columns["Units"].HeaderText = "Ед. изм.";
            if (dataGridViewCatalog.Columns.Contains("ManufDate"))
            {
                dataGridViewCatalog.Columns["ManufDate"].HeaderText = "Дата производства";
                dataGridViewCatalog.Columns["ManufDate"].Visible = false;
            }
            if (dataGridViewCatalog.Columns.Contains("ExpDate"))
                dataGridViewCatalog.Columns["ExpDate"].HeaderText = "Годен до";
            if (dataGridViewCatalog.Columns.Contains("PurPrice"))
                dataGridViewCatalog.Columns["PurPrice"].HeaderText = "Цена закупки";
            if (dataGridViewCatalog.Columns.Contains("SellPrice"))
                dataGridViewCatalog.Columns["SellPrice"].HeaderText = "Цена продажи(" + CurrencySettings.CurrentCurrency + ")";
            if (dataGridViewCatalog.Columns.Contains("Quantity"))
                dataGridViewCatalog.Columns["Quantity"].HeaderText = "Остаток";

            if (dataGridViewCatalog.Columns.Contains("PurPrice"))
                dataGridViewCatalog.Columns["PurPrice"].DefaultCellStyle.Format = "N2";
            if (dataGridViewCatalog.Columns.Contains("SellPrice"))
                dataGridViewCatalog.Columns["SellPrice"].DefaultCellStyle.Format = "N2";
            if (dataGridViewCatalog.Columns.Contains("ExpDate"))
                dataGridViewCatalog.Columns["ExpDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            if (dataGridViewCatalog.Columns.Contains("ManufDate"))
                dataGridViewCatalog.Columns["ManufDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        /// <summary>
        /// Возвращает цену продажи товара с учётом скидки (если применима)
        /// и пересчитывает в текущую выбранную валюту.
        /// </summary>
        /// <param name="item">Товар для расчёта цены</param>
        /// <param name="today">Текущая дата</param>
        /// <returns>Цена продажи в текущей валюте</returns>
        private decimal GetPriceWithDiscount(Item item, DateTime today)
        {
            if (IsDiscounted(item, today))
            {
                return item.SellPrice * 0.7m;
            }
            return item.SellPrice;
        }

        /// <summary>
        /// Определяет, имеет ли товар скидку (осталось менее 1/3 срока годности).
        /// </summary>
        private bool IsDiscounted(Item item, DateTime today)
        {
            double totalDays = 1095;
            if (item.ManufDate != null && item.ManufDate != DateTime.MinValue)
            {
                totalDays = (item.ExpDate - item.ManufDate).TotalDays;
                if (totalDays <= 0) totalDays = 1095;
            }
            double daysRemaining = (item.ExpDate - today).TotalDays;
            double remainingPercent = daysRemaining / totalDays;
            return remainingPercent < 0.33;
        }

        /// <summary>
        /// Возвращает отображаемое название единицы измерения товара на русском языке.
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
        /// Отображает логин текущего пользователя в метке на форме.
        /// </summary>
        private void ShowUserLogin()
        {
            if (labelShowLogin != null)
            {
                labelShowLogin.Text = $"Ваш логин: {currentUserLogin}";
            }
        }

        /// <summary>
        /// Создаёт панель-крутилку и навешивает центрирование
        /// </summary>
        private void InitSpinner()
        {
            spinnerPanel = new Panel
            {
                Size = new System.Drawing.Size(220, 70),
                BackColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };

            var label = new Label
            {
                Text = "⏳ Загрузка...",
                Font = new System.Drawing.Font("Segoe UI", 12),
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            spinnerPanel.Controls.Add(label);
            this.Controls.Add(spinnerPanel);
            spinnerPanel.BringToFront();

            this.Resize += (s, e) => CenterSpinner();
            this.Shown += (s, e) => CenterSpinner();
        }

        /// <summary>
        /// Центрирует панель крутилки на форме
        /// </summary>
        private void CenterSpinner()
        {
            spinnerPanel.Location = new System.Drawing.Point(
                (this.ClientSize.Width - spinnerPanel.Width) / 2,
                (this.ClientSize.Height - spinnerPanel.Height) / 2
            );
        }

        /// <summary>
        /// Обработчик кнопки "Добавить товар". Открывает форму создания нового товара.
        /// </summary>
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл форму создания товара", currentUserLogin);
            var newItemForm = new NewItemForm(currentUserId, currentUserLogin, _db);
            newItemForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик кнопки "Фильтр". Открывает форму фильтрации и применяет
        /// выбранные параметры к каталогу после подтверждения.
        /// </summary>
        private async void buttonFilter_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл форму фильтрации", currentUserLogin);
            var filterForm = new FiltrationForm(_db);

            filterForm.FilterApplied += async (selectedCategoryIds, priceFrom, priceTo, inStockOnly, notInStockOnly, withDiscount, withoutDiscount) =>
            {
                if (selectedCategoryIds == null || selectedCategoryIds.Count == 0)
                {
                    Log.Warning("Применён фильтр без выбора категорий");
                }

                Log.Debug("Применены фильтры: Категорий={CategoryCount}, Цена от={PriceFrom}, Цена до={PriceTo}",
                    selectedCategoryIds.Count, priceFrom, priceTo);

                var allCategoryIds = new List<Guid>();
                foreach (var catId in selectedCategoryIds)
                {
                    allCategoryIds.Add(catId);
                    allCategoryIds.AddRange(GetAllDescendantIds(catId));
                }
                currentFilterCategoryIds = allCategoryIds.Distinct().ToList();

                currentPriceFrom = priceFrom;
                currentPriceTo = priceTo;
                currentInStockOnly = inStockOnly;
                currentNotInStockOnly = notInStockOnly;
                currentWithDiscount = withDiscount;
                currentWithoutDiscount = withoutDiscount;
                await LoadCatalogAsync();
            };

            filterForm.ShowDialog();
        }

        /// <summary>
        /// Рекурсивно собирает идентификаторы всех дочерних категорий для заданной родительской.
        /// </summary>
        private List<Guid> GetAllDescendantIds(Guid parentId)
        {
            var result = new List<Guid>();
            try
            {
                var children = _db.Categories.Where(c => c.ParentID == parentId).ToList();
                foreach (var child in children)
                {
                    result.Add(child.CategoryID);
                    result.AddRange(GetAllDescendantIds(child.CategoryID));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при получении дочерних категорий для ParentId={ParentId}", parentId);
            }
            return result;
        }


        // <summary>
        /// Обработчик кнопки "История". Открывает форму истории отгрузок.
        /// </summary>
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл историю отгрузок", currentUserLogin);
            var historyForm = new ShipmentHistoryForm(currentUserId, currentUserLogin, _db);
            historyForm.FormClosed += (s, args) => this.Show();
            historyForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик кнопки "Выход". Закрывает каталог и возвращает на главную форму.
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} вышел из каталога", currentUserLogin);
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик кнопки "Редактировать категории". Открывает форму управления категориями.
        /// </summary>
        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл редактирование категорий", currentUserLogin);
            var editCategoryForm = new EditCategoryForm(_db);
            editCategoryForm.Show();
        }

        /// <summary>
        /// Обработчик клика по строке DataGridView. Открывает карточку выбранного товара.
        /// </summary>
        private void dataGridViewCatalog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int productNumber = (int)dataGridViewCatalog.Rows[e.RowIndex].Cells["ProductNumber"].Value;

                    // Находим первый товар с таким артикулом (для карточки)
                    var product = _db.Items.FirstOrDefault(i => i.ProductNumber == productNumber);
                    if (product != null)
                    {
                        Log.Information("Администратор {UserLogin} открыл карточку товара {ProductName} (арт. {ProductNumber})",
                            currentUserLogin, product.ProductName, productNumber);
                        var itemForm = new ItemForm(product.ProductID, currentUserId, currentUserLogin, Roles.Admin, _db);
                        itemForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        Log.Warning("Товар с артикулом {ProductNumber} не найден в БД", productNumber);
                        MessageBox.Show("Товар не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Ошибка при открытии карточки товара");
                    MessageBox.Show("Ошибка при открытии карточки товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Форматирует строки DataGridView: подсвечивает жёлтым товары,
        /// у которых осталось менее 1/3 срока годности.
        /// </summary>
        private void dataGridViewCatalog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (e.ColumnIndex < 0) return;

                // Получаем дату истечения срока годности
                var expDateCell = dataGridViewCatalog.Rows[e.RowIndex].Cells["ExpDate"];
                if (expDateCell == null || expDateCell.Value == null || expDateCell.Value == DBNull.Value) return;

                DateTime expDate;
                try
                {
                    expDate = Convert.ToDateTime(expDateCell.Value);
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "Ошибка преобразования даты истечения срока годности в строке {RowIndex}", e.RowIndex);
                    return;
                }

                DateTime today = DateTime.Now.Date;
                double totalDays = 1095;

                var manufDateCell = dataGridViewCatalog.Rows[e.RowIndex].Cells["ManufDate"];
                if (manufDateCell != null && manufDateCell.Value != null && manufDateCell.Value != DBNull.Value)
                {
                    try
                    {
                        DateTime manufDate = Convert.ToDateTime(manufDateCell.Value);
                        totalDays = (expDate - manufDate).TotalDays;
                        if (totalDays <= 0) totalDays = 1095;
                    }
                    catch (Exception ex)
                    {
                        Log.Warning(ex, "Ошибка преобразования даты изготовления в строке {RowIndex}, используем стандартный срок", e.RowIndex);
                        totalDays = 1095;
                    }
                }

                double daysRemaining = (expDate - today).TotalDays;
                double remainingPercent = daysRemaining / totalDays;

                if (remainingPercent < 0.33)
                {
                    dataGridViewCatalog.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 157);
                }
                else
                {
                    dataGridViewCatalog.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Log.Error(ex, "Выход за границы диапазона в CellFormatting. RowIndex: {RowIndex}, ColumnIndex: {ColumnIndex}",
                    e.RowIndex, e.ColumnIndex);
            }
            catch (NullReferenceException ex)
            {
                Log.Error(ex, "NullReferenceException в CellFormatting. Возможно, отсутствует колонка или ячейка");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Критическая ошибка в CellFormatting. Строка: {RowIndex}, Колонка: {ColumnIndex}",
                    e.RowIndex, e.ColumnIndex);
            }
        }

        /// <summary>
        /// Очищает placeholder-текст поля поиска при получении фокуса.
        /// </summary>
        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "Поиск")
            {
                searchBox.Text = String.Empty;
                searchBox.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Восстанавливает placeholder-текст поля поиска при потере фокуса,
        /// если поле осталось пустым.
        /// </summary>
        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                searchBox.Text = "Поиск";
                searchBox.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Выполняет живой поиск товаров по артикулу или названию при вводе текста.
        /// Учитывает активные фильтры. При пустом запросе восстанавливает полный каталог.
        /// </summary>
        private async void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text == "Поиск" || string.IsNullOrWhiteSpace(searchBox.Text))
            {
                await LoadCatalogAsync();
                return;
            }

            string searchText = searchBox.Text.Trim().ToLower();

            if (searchText.Length < 3)
            {
                Log.Warning("Поисковый запрос слишком короткий: {SearchText} (минимальная длина 3 символа)", searchText);
            }

            Log.Debug("Поиск товаров по запросу: {SearchText}", searchText);

            try
            {

                var today = DateTime.Now.Date;
                spinnerPanel.Visible = true;
                spinnerPanel.BringToFront();

                var allItems = await Task.Run(() =>
                    _db.Items
                        .Include(i => i.Category)
                        .Include(i => i.Category.Parent)
                        .Where(i => i.ExpDate > today)
                        .ToList()
                );

                var filtered = allItems
                    .Where(i => i.ProductNumber.ToString().Contains(searchText) ||
                                i.ProductName.ToLower().Contains(searchText))
                    .AsEnumerable();

                if (currentFilterCategoryIds != null && currentFilterCategoryIds.Any())
                {
                    filtered = filtered.Where(i => currentFilterCategoryIds.Contains(i.CategoryID));
                }

                if (currentPriceFrom.HasValue)
                {
                    filtered = filtered.Where(i => i.SellPrice >= currentPriceFrom.Value);
                }
                if (currentPriceTo.HasValue)
                {
                    filtered = filtered.Where(i => i.SellPrice <= currentPriceTo.Value);
                }

                if (currentInStockOnly == true)
                {
                    filtered = filtered.Where(i => i.Quantity > 0);
                }
                else if (currentNotInStockOnly == true)
                {
                    filtered = filtered.Where(i => i.Quantity == 0);
                }
                else
                {
                    filtered = filtered.Where(i => i.Quantity > 0);
                }

                if (currentWithDiscount == true || currentWithoutDiscount == true)
                {
                    var discountedIds = filtered
                        .Where(i => IsDiscounted(i, today))
                        .Select(i => i.ProductID)
                        .ToList();

                    if (currentWithDiscount == true)
                    {
                        filtered = filtered.Where(i => discountedIds.Contains(i.ProductID));
                    }
                    else if (currentWithoutDiscount == true)
                    {
                        filtered = filtered.Where(i => !discountedIds.Contains(i.ProductID));
                    }
                }

                var displayList = filtered
                    .GroupBy(i => new
                    {
                        i.ProductNumber,
                        i.ProductName,
                        i.CategoryID,
                        i.Units,
                        i.SellPrice,
                        i.PurPrice,
                        i.ManufDate,
                        i.ExpDate
                    })
                    .Select(g => new
                    {
                        g.Key.ProductNumber,
                        g.Key.ProductName,
                        ParentCategoryName = g.First().Category?.Parent?.CategoryName ?? string.Empty,
                        ChildCategoryName = g.First().Category?.CategoryName ?? string.Empty,
                        Units = GetUnitDisplayName(g.Key.Units),
                        g.Key.ManufDate,
                        g.Key.ExpDate,
                        PurPrice = ConvertPurPrice(g.First()),
                        SellPrice = Math.Round(GetPriceWithDiscount(g.First(), today) / CurrencySettings.CurrentRate, 2),
                        Quantity = g.Sum(i => i.Quantity)
                    })
                    .OrderBy(i => i.ProductNumber)
                    .ToList();



                dataGridViewCatalog.DataSource = displayList;
                ConfigureColumns();

                if (displayList.Count == 0)
                {
                    Log.Warning("По запросу '{SearchText}' ничего не найдено", searchText);
                }
                else
                {
                    Log.Information("По запросу '{SearchText}' найдено {ItemCount} товаров", searchText, displayList.Count);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при поиске товаров по запросу {SearchText}", searchText);
                MessageBox.Show("Ошибка при поиске товаров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                spinnerPanel.Visible = false;  // ← добавить
            }
        }


        // <summary>
        /// Обработчик кнопки "Поставка". Открывает форму оформления поставки товаров.
        /// </summary>
        private void deliveryFromCatalogButton_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл форму поставки", currentUserLogin);
            var deliveryForm = new DeliveryForm(currentUserId, currentUserLogin, _db);
            deliveryForm.FormClosed += (s, args) => this.Show();
            deliveryForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик кнопки "Убытки". Открывает форму регистрации убытков/списания товаров.
        /// </summary>
        private void LossFromCatalogButton_Click(Object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл форму убытков", currentUserLogin);
            var lossForm = new LossForm(currentUserId, currentUserLogin, _db);
            lossForm.FormClosed += (s, args) => this.Show();
            lossForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик кнопки "Карта склада". Открывает тепловую карту размещения товаров.
        /// </summary>
        private void buttonWarehoeseMap_Click(object sender, EventArgs e)
        {
            var heatMap = new HeatMapForm(currentUserId, currentUserLogin, Roles.Admin, _db);
            heatMap.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик кнопки "Валюта". Открывает форму управления валютными курсами.
        /// После закрытия обновляет каталог с пересчётом цен в новой валюте.
        /// </summary>
        private void buttonCurrency_Click(object sender, EventArgs e)
        {
            var currencyForm = new CurrencyForm(currentUserId, currentUserLogin, _db);
            currencyForm.FormClosed += async (s, args) => { this.Show(); await LoadCatalogAsync(); };
            currencyForm.Show();
            this.Hide();

        }

        /// <summary>
        /// Пересчитывает цену закупки товара в текущую выбранную валюту с учётом
        /// курса на момент закупки и актуального курса валюты закупки.
        /// </summary>
        private decimal ConvertPurPrice(Item item)
        {
            // Если нет данных о валюте — возвращаем как есть
            if (string.IsNullOrEmpty(item.CurrencyCode) || item.PurchaseRate <= 0)
                return Math.Round(item.PurPrice / CurrencySettings.CurrentRate, 2);


            // Переводим: рубли → валюта закупки → выбранная валюта
            // 1. PurPrice хранится в рублях, делим на PurchaseRate → получаем в валюте закупки
            // 2. Получаем текущий курс валюты закупки
            // 3. Умножаем на текущий курс → рубли по новому курсу
            // 4. Делим на текущий курс выбранной валюты
            try
            {

                var purchaseCurrencyRate = _db.CurrencyRates.Find(item.CurrencyCode);
                if (purchaseCurrencyRate == null)
                    return Math.Round(item.PurPrice / CurrencySettings.CurrentRate, 2);


                decimal amountInPurchaseCurrency = item.PurPrice / item.PurchaseRate;
                decimal amountInRubNow = amountInPurchaseCurrency * purchaseCurrencyRate.Rate;
                return Math.Round(amountInRubNow / CurrencySettings.CurrentRate, 2);

            }
            catch { return item.PurPrice; }
        }


    }
}