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

        public CatalogFormAdmin(Guid userId, string userLogin)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserLogin = userLogin;
            
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

            LoadCatalog();
            ShowUserLogin();
        }

        private void LoadCatalog()
        {
            Log.Debug("Загрузка каталога с фильтрами: Категории={CategoryCount}, Цена от={PriceFrom}, Цена до={PriceTo}",
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
                            ParentCategoryName = g.First().Category?.Parent?.CategoryName,
                            ChildCategoryName = g.First().Category?.CategoryName,
                            Units = GetUnitDisplayName(g.Key.Units),
                            g.Key.ManufDate,
                            g.Key.ExpDate,
                            g.Key.PurPrice,
                            SellPrice = GetPriceWithDiscount(g.First(), today),
                            Quantity = g.Sum(i => i.Quantity)
                        })
                        .OrderBy(i => i.ProductNumber)
                        .ToList();

                    dataGridViewCatalog.DataSource = displayList;
                    Log.Information("Загружено {ItemCount} товаров (сгруппировано)", displayList.Count);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при загрузке каталога");
                MessageBox.Show("Ошибка при загрузке каталога", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConfigureColumns();
        }

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
                dataGridViewCatalog.Columns["SellPrice"].HeaderText = "Цена продажи";
            if (dataGridViewCatalog.Columns.Contains("Quantity"))
                dataGridViewCatalog.Columns["Quantity"].HeaderText = "Остаток";

            if (dataGridViewCatalog.Columns.Contains("PurPrice"))
                dataGridViewCatalog.Columns["PurPrice"].DefaultCellStyle.Format = "C2";
            if (dataGridViewCatalog.Columns.Contains("SellPrice"))
                dataGridViewCatalog.Columns["SellPrice"].DefaultCellStyle.Format = "C2";
            if (dataGridViewCatalog.Columns.Contains("ExpDate"))
                dataGridViewCatalog.Columns["ExpDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            if (dataGridViewCatalog.Columns.Contains("ManufDate"))
                dataGridViewCatalog.Columns["ManufDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private decimal GetPriceWithDiscount(Item item, DateTime today)
        {
            if (IsDiscounted(item, today))
            {
                return item.SellPrice * 0.7m;
            }
            return item.SellPrice;
        }

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

        private void ShowUserLogin()
        {
            if (labelShowLogin != null)
            {
                labelShowLogin.Text = $"Ваш логин: {currentUserLogin}";
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл форму создания товара", currentUserLogin);
            var newItemForm = new NewItemForm(currentUserId, currentUserLogin);
            newItemForm.Show();
            this.Hide();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл форму фильтрации", currentUserLogin);
            var filterForm = new FiltrationForm();

            filterForm.FilterApplied += (selectedCategoryIds, priceFrom, priceTo, inStockOnly, notInStockOnly, withDiscount, withoutDiscount) =>
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
                LoadCatalog();
            };

            filterForm.ShowDialog();
        }

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

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл историю отгрузок", currentUserLogin);
            var historyForm = new ShipmentHistoryForm(currentUserId, currentUserLogin);
            historyForm.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} вышел из каталога", currentUserLogin);
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл редактирование категорий", currentUserLogin);
            var editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
        }

        private void dataGridViewCatalog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int productNumber = (int)dataGridViewCatalog.Rows[e.RowIndex].Cells["ProductNumber"].Value;

                    using (var db = new WarehouseContext())
                    {
                        // Находим первый товар с таким артикулом (для карточки)
                        var product = db.Items.FirstOrDefault(i => i.ProductNumber == productNumber);
                        if (product != null)
                        {
                            Log.Information("Администратор {UserLogin} открыл карточку товара {ProductName} (арт. {ProductNumber})",
                                currentUserLogin, product.ProductName, productNumber);
                            var itemForm = new ItemForm(product.ProductID, currentUserId, currentUserLogin, Roles.Admin);
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

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "Поиск")
            {
                searchBox.Text = String.Empty;
                searchBox.ForeColor = Color.Black;
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                searchBox.Text = "Поиск";
                searchBox.ForeColor = Color.Gray;
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text == "Поиск" || string.IsNullOrWhiteSpace(searchBox.Text))
            {
                LoadCatalog();
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
                using (var db = new WarehouseContext())
                {
                    var today = DateTime.Now.Date;
                    var allItems = db.Items
                        .Include(i => i.Category)
                        .Include(i => i.Category.Parent)
                        .Where(i => i.ExpDate > today)
                        .ToList();

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
                            g.Key.PurPrice,
                            SellPrice = GetPriceWithDiscount(g.First(), today),
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
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при поиске товаров по запросу {SearchText}", searchText);
                MessageBox.Show("Ошибка при поиске товаров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deliveryFromCatalogButton_Click(object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл форму поставки", currentUserLogin);
            var deliveryForm = new DeliveryForm(currentUserId, currentUserLogin);
            deliveryForm.Show();
            this.Hide();
        }

        private void LossFromCatalogButton_Click(Object sender, EventArgs e)
        {
            Log.Information("Администратор {UserLogin} открыл форму убытков", currentUserLogin);
            var lossForm = new LossForm(currentUserId, currentUserLogin);
            lossForm.Show();
            this.Hide();
        }
    }
}