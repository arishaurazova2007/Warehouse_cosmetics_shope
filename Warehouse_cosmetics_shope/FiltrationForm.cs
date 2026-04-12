using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class FiltrationForm : Form
    {
        private Guid currentUserId;
        public FiltrationForm()
        {
            InitializeComponent();
        }
        public FiltrationForm(Guid userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        private void buttonShow_Click(object sender, EventArgs e)
        {

            var criteria = GetFilterCriteria();
            ApplyFilter(criteria);
            this.Hide();
        }
        private FilterCriteria GetFilterCriteria()
        {
            var criteria = new FilterCriteria();
            // Категория
            criteria.CategoryPerfumeMen = checkBoxPerfumeMen.Checked;
            criteria.CategoryCosmetics = checkBoxCosmetics.Checked;
            // Вид
            criteria.TypePerfume = checkBoxPerfume.Checked;
            criteria.TypePerfumeWater = checkBoxPerfumeWater.Checked;
            criteria.TypeToiletWater = checkBoxToiletWater.Checked;
            criteria.TypeCare = checkBoxCare.Checked;
            criteria.TypeDecor = checkBoxDecor.Checked;
            // Цена
            criteria.PriceFrom = textBoxPriceFrom.Text;
            criteria.PriceTo = textBoxPriceTo.Text;
            // Наличие
            criteria.InStock = checkBoxInStock.Checked;
            criteria.NotInStock = checkBoxNotInStock.Checked;
            return criteria;
        }
        private void ApplyFilter(FilterCriteria criteria)
        {
            // Применение фильтра (БД)
        }
        private void ResetFilter()
        {
            // Сброс фильтра
        }
        private void LoadAllProducts()
        {
            // Загрузка всех товаров (без фильтра)
        }
        private void FiltrationForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxPerfumeMen_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    public class FilterCriteria
    {
        /// <summary>
        /// Категория: Парфюм для мужчин
        /// </summary>
        public bool CategoryPerfumeMen { get; set; }
        /// <summary>
        /// Категория: Парфюм для женщин
        /// </summary>
        public bool CategoryPerfumeWomen { get; set; }
        /// <summary>
        /// Категория: Косметика
        /// </summary>
        public bool CategoryCosmetics { get; set; }
        /// <summary>
        /// Вид: Парфюм
        /// </summary>
        public bool TypePerfume { get; set; }
        /// <summary>
        /// Вид: Парфюмированная вода
        /// </summary>
        public bool TypePerfumeWater { get; set; }
        /// <summary>
        /// Вид: Туалетная вода
        /// </summary>
        public bool TypeToiletWater { get; set; }
        /// <summary>
        /// Вид: Уходовая косметика
        /// </summary>
        public bool TypeCare { get; set; }
        /// <summary>
        /// Вид: Декоративная косметика
        /// </summary>
        public bool TypeDecor { get; set; }
        /// <summary>
        /// Цена: от
        /// </summary>
        public string PriceFrom { get; set; }
        /// <summary>
        /// Цена: до
        /// </summary>
        public string PriceTo { get; set; }
        /// <summary>
        /// Наличие: в наличии
        /// </summary>
        public bool InStock { get; set; }
        /// <summary>
        /// Наличие: нет в наличии
        /// </summary>
        public bool NotInStock { get; set; }
    }
}
