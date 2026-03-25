using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class FiltrationForm : Form
    {
        private int currentUserId;
        public FiltrationForm()
        {
            InitializeComponent();
        }
        public FiltrationForm(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        private void buttonShow_Click(object sender, EventArgs e)
        {
           
            FilterCriteria criteria = GetFilterCriteria();
            ApplyFilter(criteria);
            this.Hide();
        }
        private FilterCriteria GetFilterCriteria()
        {
            FilterCriteria criteria = new FilterCriteria();
            // Категория
            criteria.CategoryPerfumeMen = checkBoxPerfumeMen.Checked;
            criteria.CategoryPerfumeWomen = checkBoxPerfumeWomen.Checked;
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
    }
    public class FilterCriteria
    {
        // Категория
        public bool CategoryPerfumeMen { get; set; }
        public bool CategoryPerfumeWomen { get; set; }
        public bool CategoryCosmetics { get; set; }
        // Вид
        public bool TypePerfume { get; set; }
        public bool TypePerfumeWater { get; set; }
        public bool TypeToiletWater { get; set; }
        public bool TypeCare { get; set; }
        public bool TypeDecor { get; set; }
        // Цена
        public string PriceFrom { get; set; }
        public string PriceTo { get; set; }
        // Наличие
        public bool InStock { get; set; }
        public bool NotInStock { get; set; }
    }
}