using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;

namespace Warehouse_cosmetics_shope
{
    public partial class HeatMapForm : Form
    {
        private Guid currentUserId;
        private string currentUserLogin;
        private Roles currentUserRole;

        private const int COLUMNS = 8;
        private const int CELL_WIDTH = 60;
        private const int CELL_HEIGHT = 40;
        private const int CELL_MARGIN = 4;

        public HeatMapForm(Guid userId, string userLogin, Roles userRole)
        {
            InitializeComponent();
            this.currentUserId = userId;
            this.currentUserLogin = userLogin;
            this.currentUserRole = userRole;
            this.Text = "Тепловая карта склада";
            this.BackColor = ColorTranslator.FromHtml("#C8EEF2");
        }

        private void HeatMapForm_Load(object sender, EventArgs e)
        {
            DrawHeatMap();
            DrawLegend();
        }

        /// <summary>
        /// Рисует тепловую карту по товарам из БД
        /// </summary>
        private void DrawHeatMap()
        {
            var toRemove = mapPanel.Controls
                .OfType<Control>()
                .Where(c => c.Tag?.ToString() == "cell")
                .ToList();
            foreach (var c in toRemove) mapPanel.Controls.Remove(c);

            using (var db = new WarehouseContext())
            {
                var items = db.Items
                    .Where(i => i.CellNumber > 0)
                    .OrderBy(i => i.CellNumber)
                    .ToList();

                int startX = 10;
                int startY = 10;

                foreach (var item in items)
                {
                    int cellIndex = item.CellNumber - 1;
                    int col = cellIndex % COLUMNS;
                    int row = cellIndex / COLUMNS;

                    int x = startX + col * (CELL_WIDTH + CELL_MARGIN);
                    int y = startY + row * (CELL_HEIGHT + CELL_MARGIN);

                    Color cellColor = GetCellColor(item);

                    var btn = new Button();
                    btn.Size = new Size(CELL_WIDTH, CELL_HEIGHT);
                    btn.Location = new Point(x, y);
                    btn.BackColor = cellColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.White;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Tag = "cell";
                    btn.Cursor = Cursors.Hand;
                    btn.Name = item.ProductID.ToString();

                    var tooltip = new ToolTip();
                    tooltip.SetToolTip(btn,
                        $"{item.ProductName}\nЯчейка: {item.CellNumber}\nОстаток: {item.Quantity}");

                    btn.Click += CellButton_Click;
                    mapPanel.Controls.Add(btn);
                }
            }
        }

        /// <summary>
        /// Определяет цвет ячейки по сроку годности и количеству товара
        /// </summary>
        private Color GetCellColor(Item item)
        {
            int daysLeft = (item.ExpDate - DateTime.Now).Days;
            bool isExpiringSoon = daysLeft < 30;
            bool isMidExpiry = daysLeft >= 30 && daysLeft <= 90;
            // иначе — свежий (> 90 дней)

            bool isManyQty = item.Quantity > 70;
            bool isMediumQty = item.Quantity >= 40 && item.Quantity <= 70;
            bool isFewQty = item.Quantity < 40;

            if (isExpiringSoon)
            {
                if (isManyQty) return ColorTranslator.FromHtml("#650606");
                if (isMediumQty) return ColorTranslator.FromHtml("#D80707");
                return ColorTranslator.FromHtml("#A357FF"); // мало
            }
            else if (isMidExpiry)
            {
                if (isManyQty) return ColorTranslator.FromHtml("#324D10");
                if (isMediumQty) return ColorTranslator.FromHtml("#EEFF57");
                return ColorTranslator.FromHtml("#5BE0EF"); // мало
            }
            else // свежий > 90 дней
            {
                if (isManyQty) return ColorTranslator.FromHtml("#5EBC2B");
                if (isMediumQty) return ColorTranslator.FromHtml("#77F38D");
                return ColorTranslator.FromHtml("#4535EF"); // мало
            }
        }

        /// <summary>
        /// Клик по ячейке — открывает карточку товара в режиме просмотра
        /// </summary>
        private void CellButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            if (Guid.TryParse(btn.Name, out Guid productId))
            {
                var itemForm = new ItemForm(
                    productId,
                    currentUserId,
                    currentUserLogin,
                    currentUserRole,
                    isReadOnly: true   // всегда только просмотр
                );
                itemForm.Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Кнопка Назад
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (currentUserRole == Roles.Admin)
            {
                var catalog = new CatalogFormAdmin(currentUserId, currentUserLogin);
                catalog.Show();
            }
            else
            {
                var catalog = new CatalogFormKlad(currentUserId, currentUserLogin);
                catalog.Show();
            }
            this.Hide();
        }

        private void DrawLegend()
        {
            legendPanel.Controls.Clear();

            var title = new Label
            {
                Text = "Условные\nобозначения:",
                Font = new System.Drawing.Font("Segoe UI", 9f,
                    System.Drawing.FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            legendPanel.Controls.Add(title);

            var legendItems = new[]
            {
        ("#650606", "Срок годности < 30 дней, товара много (>70)"),
        ("#324D10", "Срок годности 30–90 дней, товара много (>70)"),
        ("#5EBC2B", "Срок годности > 90 дней, товара много (>70)"),
        ("#D80707", "Срок годности < 30 дней, товара среднее (40–70)"),
        ("#EEFF57", "Срок годности 30–90 дней, товара среднее (40–70)"),
        ("#77F38D", "Срок годности > 90 дней, товара среднее (40–70)"),
        ("#A357FF", "Срок годности < 30 дней, товара мало (<40)"),
        ("#5BE0EF", "Срок годности 30–90 дней, товара мало (<40)"),
        ("#4535EF", "Срок годности > 90 дней, товара мало (<40)"),
    };

            int startY = 60;
            int gap = 5; // отступ между группами (после 3 и 6)

            for (int i = 0; i < legendItems.Length; i++)
            {
                // Доп. отступ между группами
                int groupOffset = (i / 3) * gap;
                int y = startY + i * 40 + groupOffset;

                var colorBox = new Panel
                {
                    BackColor = ColorTranslator.FromHtml(legendItems[i].Item1),
                    Size = new Size(30, 20),
                    Location = new Point(10, y),
                    BorderStyle = BorderStyle.FixedSingle
                };
                legendPanel.Controls.Add(colorBox);

                var label = new Label
                {
                    Text = legendItems[i].Item2,
                    Location = new Point(48, y),
                    Size = new Size(175, 40),
                    BackColor = Color.Transparent,
                    Font = new System.Drawing.Font("Segoe UI", 8f)
                };
                legendPanel.Controls.Add(label);
            }
        }
    }
}