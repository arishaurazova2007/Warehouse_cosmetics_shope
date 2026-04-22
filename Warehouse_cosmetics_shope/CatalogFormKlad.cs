using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;
using Serilog;

namespace Warehouse_cosmetics_shope
{
    public partial class CatalogFormKlad : Form
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

        /// <summary>
        /// Конструктор формы каталога кладовщика
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="userLogin">Логин текущего пользователя</param>
        public CatalogFormKlad(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;

            Log.Information("Кладовщик {UserLogin} открыл каталог", currentUserLogin);

            LoadCatalog();
            ShowUserLogin();
            kladCatalogGrid.CellClick += KladCatalogGrid_CellClick;
            kladCatalogGrid.CellFormatting += KladCatalogGrid_CellFormatting;
            kladCatalogGrid.DataError += (s, ev) => ev.ThrowException = false;
            searchButton.Click += SearchButton_Click;
        }

        /// <summary>
        /// Загружает каталог товаров с учётом всех активных фильтров
        /// </summary>
        private void LoadCatalog()
        {
            Log.Debug("Загрузка каталога кладовщика с фильтрами: Категории={CategoryCount}, Цена от={PriceFrom}, Цена до={PriceTo}",
                currentFilterCategoryIds?.Count ?? 0, currentPriceFrom, currentPriceTo);

            try
            {
                using (var db = new WarehouseContext())
                {
                    var today = DateTime.Now.Date;

                    var allItems = db.Items
                        .Include(i => i.Category)
                        .Include(i => i.Category.Parent)
                        .Where(i => i.ExpDate > today)
                        .ToList();

                    var filtered = allItems.AsEnumerable();

                    // 1. Фильтр по категориям (с учётом дочерних)
                    if (currentFilterCategoryIds != null && currentFilterCategoryIds.Any())
                    {
                        var allCategoryIds = new List<Guid>();
                        foreach (var catId in currentFilterCategoryIds)
                        {
                            allCategoryIds.Add(catId);
                            allCategoryIds.AddRange(GetAllDescendantIds(catId));
                        }
                        var expandedIds = allCategoryIds.Distinct().ToList();
                        filtered = filtered.Where(i => expandedIds.Contains(i.CategoryID));
                    }

                    // 2. Фильтр по цене
                    if (currentPriceFrom.HasValue)
                    {
                        filtered = filtered.Where(i => i.SellPrice >= currentPriceFrom.Value);
                    }
                    if (currentPriceTo.HasValue)
                    {
                        filtered = filtered.Where(i => i.SellPrice <= currentPriceTo.Value);
                    }

                    // 3. Фильтр по наличию
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

                    // 4. Фильтр по скидке
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

                    var displayList = filtered.Select(i => new
                    {
                        i.ProductNumber,
                        i.ProductName,
                        ParentCategoryName = i.Category?.Parent?.CategoryName,
                        ChildCategoryName = i.Category?.CategoryName,
                        Units = GetUnitDisplayName(i.Units),
                        i.ManufDate,
                        i.ExpDate,
                        i.PurPrice,
                        SellPrice = GetPriceWithDiscount(i, today),
                        i.Quantity
                    }).ToList();

                    kladCatalogGrid.DataSource = displayList;

                    Log.Information("Загружено {ItemCount} товаров", displayList.Count);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке каталога кладовщика");
                MessageBox.Show("Ошибка при загрузке каталога", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConfigureColumns();
        }

        /// <summary>
        /// Возвращает цену товара с учётом скидки (если осталось менее 1/3 срока годности)
        /// </summary>
        /// <param name="item">Товар</param>
        /// <param name="today">Текущая дата</param>
        /// <returns>Цена со скидкой или обычная цена</returns>
        private decimal GetPriceWithDiscount(Item item, DateTime today)
        {
            if (IsDiscounted(item, today))
            {
                return item.SellPrice * 0.7m;
            }
            return item.SellPrice;
        }

        /// <summary>
        /// Определяет, имеет ли товар скидку (осталось менее 1/3 срока годности)
        /// </summary>
        /// <param name="item">Проверяемый товар</param>
        /// <param name="today">Текущая дата</param>
        /// <returns>true - товар со скидкой, false - без скидки</returns>
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
        /// Возвращает список всех дочерних категорий для указанной родительской категории
        /// </summary>
        /// <param name="parentId">Идентификатор родительской категории</param>
        /// <returns>Список идентификаторов всех дочерних категорий</returns>
        private List<Guid> GetAllDescendantIds(Guid parentId)
        {
            var result = new List<Guid>();
            try
            {
                using (var db = new WarehouseContext())
                {
                    var children = db.Categories.Where(c => c.ParentID == parentId).ToList();
                    foreach (var child in children)
                    {
                        result.Add(child.CategoryID);
                        result.AddRange(GetAllDescendantIds(child.CategoryID));
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при получении дочерних категорий для ParentId={ParentId}", parentId);
            }
            return result;
        }

        /// <summary>
        /// Настраивает отображение колонок в таблице каталога
        /// </summary>
        private void ConfigureColumns()
        {
            if (kladCatalogGrid.Columns.Contains("ProductNumber"))
                kladCatalogGrid.Columns["ProductNumber"].HeaderText = "Артикул";
            if (kladCatalogGrid.Columns.Contains("ProductName"))
                kladCatalogGrid.Columns["ProductName"].HeaderText = "Название";
            if (kladCatalogGrid.Columns.Contains("ParentCategoryName"))
            {
                kladCatalogGrid.Columns["ParentCategoryName"].HeaderText = "Категория";
                kladCatalogGrid.Columns["ParentCategoryName"].Visible = false;
            }
            if (kladCatalogGrid.Columns.Contains("ChildCategoryName"))
                kladCatalogGrid.Columns["ChildCategoryName"].HeaderText = "Категория";
            if (kladCatalogGrid.Columns.Contains("Units"))
                kladCatalogGrid.Columns["Units"].HeaderText = "Ед. изм.";
            if (kladCatalogGrid.Columns.Contains("ManufDate"))
            {
                kladCatalogGrid.Columns["ManufDate"].HeaderText = "Дата производства";
                kladCatalogGrid.Columns["ManufDate"].Visible = false;
            }
            if (kladCatalogGrid.Columns.Contains("ExpDate"))
                kladCatalogGrid.Columns["ExpDate"].HeaderText = "Годен до";
            if (kladCatalogGrid.Columns.Contains("PurPrice"))
                kladCatalogGrid.Columns["PurPrice"].HeaderText = "Цена закупки";
            if (kladCatalogGrid.Columns.Contains("SellPrice"))
                kladCatalogGrid.Columns["SellPrice"].HeaderText = "Цена продажи";
            if (kladCatalogGrid.Columns.Contains("Quantity"))
                kladCatalogGrid.Columns["Quantity"].HeaderText = "Остаток";

            if (kladCatalogGrid.Columns.Contains("PurPrice"))
                kladCatalogGrid.Columns["PurPrice"].DefaultCellStyle.Format = "C2";
            if (kladCatalogGrid.Columns.Contains("SellPrice"))
                kladCatalogGrid.Columns["SellPrice"].DefaultCellStyle.Format = "C2";
            if (kladCatalogGrid.Columns.Contains("ExpDate"))
                kladCatalogGrid.Columns["ExpDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            if (kladCatalogGrid.Columns.Contains("ManufDate"))
                kladCatalogGrid.Columns["ManufDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        /// <summary>
        /// Возвращает русское название единицы измерения
        /// </summary>
        /// <param name="unit">Единица измерения из перечисления</param>
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
        /// Отображает логин текущего пользователя на форме
        /// </summary>
        private void ShowUserLogin()
        {
            if (labelShowLogin != null)
            {
                labelShowLogin.Text = $"Ваш логин: {currentUserLogin}";
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Выход"
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Log.Information("Кладовщик {UserLogin} вышел из каталога", currentUserLogin);
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Фильтр"
        /// </summary>
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            Log.Information("Кладовщик {UserLogin} открыл форму фильтрации", currentUserLogin);
            var filterForm = new FiltrationForm();

            filterForm.FilterApplied += (selectedCategoryIds, priceFrom, priceTo, inStockOnly, notInStockOnly, withDiscount, withoutDiscount) =>
            {
                if (selectedCategoryIds == null || selectedCategoryIds.Count == 0)
                {
                    Log.Warning("Применён фильтр без выбора категорий");
                }

                Log.Debug("Применены фильтры: Категорий={CategoryCount}, Цена от={PriceFrom}, Цена до={PriceTo}",
                    selectedCategoryIds.Count, priceFrom, priceTo);

                currentFilterCategoryIds = selectedCategoryIds;
                currentPriceFrom = priceFrom;
                currentPriceTo = priceTo;
                currentInStockOnly = inStockOnly;
                currentNotInStockOnly = notInStockOnly;
                currentWithDiscount = withDiscount;
                currentWithoutDiscount = withoutDiscount;
                LoadCatalog();
            };

            filterForm.ShowDialog();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отгрузка"
        /// </summary>
        private void buttonOtgruzka_Click(object sender, EventArgs e)
        {
            Log.Information("Кладовщик {UserLogin} открыл форму отгрузки", currentUserLogin);
            var otgruzkaForm = new ShipmentForm(currentUserId, currentUserLogin);
            otgruzkaForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик клика по ячейке таблицы каталога
        /// </summary>
        private void KladCatalogGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int productNumber = (int)kladCatalogGrid.Rows[e.RowIndex].Cells["ProductNumber"].Value;

                    using (var db = new WarehouseContext())
                    {
                        var product = db.Items.FirstOrDefault(i => i.ProductNumber == productNumber);
                        if (product != null)
                        {
                            Log.Information("Кладовщик {UserLogin} открыл карточку товара {ProductName} (арт. {ProductNumber})",
                                currentUserLogin, product.ProductName, productNumber);
                            var itemForm = new ItemForm(product.ProductID, currentUserId, currentUserLogin, Roles.Storekeeper, true);
                            itemForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            Log.Warning("Товар с артикулом {ProductNumber} не найден в БД", productNumber);
                            MessageBox.Show("Товар не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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
        /// Обработчик форматирования ячеек таблицы каталога (подсветка товаров с истекающим сроком)
        /// </summary>
        private void KladCatalogGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var expDateCell = kladCatalogGrid.Rows[e.RowIndex].Cells["ExpDate"];
                var manufDateCell = kladCatalogGrid.Rows[e.RowIndex].Cells["ManufDate"];

                if (expDateCell.Value == null) return;

                DateTime expDate = (DateTime)expDateCell.Value;
                DateTime today = DateTime.Now.Date;
                double totalDays = 1095;

                if (manufDateCell.Value != null && manufDateCell.Value != DBNull.Value)
                {
                    DateTime manufDate = (DateTime)manufDateCell.Value;
                    totalDays = (expDate - manufDate).TotalDays;
                    if (totalDays <= 0) totalDays = 1095;
                }

                double daysRemaining = (expDate - today).TotalDays;
                double remainingPercent = daysRemaining / totalDays;

                if (remainingPercent < 0.33)
                {
                    kladCatalogGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 157);
                }
                else
                {
                    kladCatalogGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при форматировании ячейки таблицы каталога");
            }
        }

        /// <summary>
        /// Обработчик входа курсора в поле поиска
        /// </summary>
        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "Поиск")
            {
                searchBox.Text = string.Empty;
                searchBox.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Обработчик выхода курсора из поля поиска
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
        /// Обработчик нажатия кнопки поиска
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = searchBox.Text.Trim().ToLower();

            if (searchText == "поиск" || string.IsNullOrWhiteSpace(searchText))
            {
                LoadCatalog();
                return;
            }

            Log.Debug("Поиск товаров по запросу: {SearchText}", searchText);

            try
            {
                var today = DateTime.Now.Date;

                using (var db = new WarehouseContext())
                {
                    var allItems = db.Items
                        .Include(i => i.Category)
                        .Include(i => i.Category.Parent)
                        .Where(i => i.ExpDate > today)
                        .ToList();

                    var filtered = allItems
                        .Where(i => i.ProductNumber.ToString().Contains(searchText) ||
                                    i.ProductName.ToLower().Contains(searchText))
                        .AsEnumerable();

                    //фильтр по категориям (с учётом дочерних)
                    if (currentFilterCategoryIds != null && currentFilterCategoryIds.Any())
                    {
                        var allCategoryIds = new List<Guid>();
                        foreach (var catId in currentFilterCategoryIds)
                        {
                            allCategoryIds.Add(catId);
                            allCategoryIds.AddRange(GetAllDescendantIds(catId));
                        }
                        var expandedIds = allCategoryIds.Distinct().ToList();
                        filtered = filtered.Where(i => expandedIds.Contains(i.CategoryID));
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

                    var displayList = filtered.Select(i => new
                    {
                        i.ProductNumber,
                        i.ProductName,
                        ParentCategoryName = i.Category?.Parent?.CategoryName ?? string.Empty,
                        ChildCategoryName = i.Category?.CategoryName ?? string.Empty,
                        Units = GetUnitDisplayName(i.Units),
                        i.ManufDate,
                        i.ExpDate,
                        i.PurPrice,
                        SellPrice = GetPriceWithDiscount(i, today),
                        i.Quantity
                    }).ToList();

                    kladCatalogGrid.DataSource = displayList;
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
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при поиске товаров по запросу {SearchText}", searchText);
                MessageBox.Show("Ошибка при поиске товаров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}