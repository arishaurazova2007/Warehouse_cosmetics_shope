using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    public partial class NewCategoryForm : Form
    {
        private Guid currentUserId;
        public NewCategoryForm()
        {
            InitializeComponent();
        }
        public NewCategoryForm(Guid userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddCategory(); // Сохранение в БД
            var editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
            this.Hide();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
            this.Hide();
        }
        private void AddCategory()
        {
            
        }
        private void LoadParentCategories()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var categories = db.Categories.ToList();

                    // Настройка ComboBox
                    comboBoxParentCategory.DataSource = categories;
                    comboBoxParentCategory.DisplayMember = "CategoryName"; // Что видит пользователь
                    comboBoxParentCategory.ValueMember = "CategoryID";     // Что сохраняем в БД
                    comboBoxParentCategory.SelectedIndex = -1;             // По умолчанию ничего не выбрано
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void NewCategoryForm_Load(object sender, EventArgs e)
        {
            LoadParentCategories();
        }
    }
}