using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Helpers;

namespace Warehouse_cosmetics_shope
{
    public partial class FiltrationForm : Form
    {
        public event Action<List<Guid>> FilterApplied;
        private List<CategoryInfo> _allCategories;

        public FiltrationForm()
        {
            InitializeComponent();
            LoadCategories();
            categoriesCheckedListBox.ItemCheck += categoriesCheckedListBox_ItemCheck;
        }

        private void LoadCategories()
        {
            using (var db = new WarehouseContext())
            {
                var categories = db.Categories.ToList();
                _allCategories = new List<CategoryInfo>();

                foreach (var cat in categories.Where(c => c.ParentID == null).OrderBy(c => c.CategoryName))
                {
                    AddCategoryWithChildren(cat, categories, 0);
                }

                categoriesCheckedListBox.DataSource = _allCategories;
                categoriesCheckedListBox.DisplayMember = "DisplayName";
                categoriesCheckedListBox.ValueMember = "CategoryID";
            }
        }

        private void AddCategoryWithChildren(Category cat, List<Category> all, int level)
        {
            //добавляем текущую категорию
            _allCategories.Add(new CategoryInfo
            {
                CategoryID = cat.CategoryID,
                DisplayName = new string(' ', level * 4) + cat.CategoryName,
                ParentID = cat.ParentID
            });

            //добавляем всех дочерних
            var children = all.Where(c => c.ParentID == cat.CategoryID).OrderBy(c => c.CategoryName);
            foreach (var child in children)
            {
                AddCategoryWithChildren(child, all, level + 1);
            }
        }

        private void categoriesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var selected = _allCategories[e.Index];
            int startIndex = e.Index + 1;
            int endIndex = FindLastChildIndex(selected.CategoryID, startIndex);

            for (int i = startIndex; i <= endIndex; i++)
            {
                categoriesCheckedListBox.SetItemChecked(i, e.NewValue == CheckState.Checked);
            }
        }

        private int FindLastChildIndex(Guid parentId, int startIndex)
        {
            int lastIndex = startIndex - 1;

            for (int i = startIndex; i < _allCategories.Count; i++)
            {
                if (IsDescendantOf(parentId, _allCategories[i].CategoryID))
                {
                    lastIndex = i;
                }
                else
                {
                    break;
                }
            }

            return lastIndex;
        }

        private bool IsDescendantOf(Guid parentId, Guid childId)
        {
            using (var db = new WarehouseContext())
            {
                var current = db.Categories.FirstOrDefault(c => c.CategoryID == childId);
                while (current != null)
                {
                    if (current.ParentID == parentId) return true;
                    current = db.Categories.FirstOrDefault(c => c.CategoryID == current.ParentID);
                }
                return false;
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            var selectedIds = new List<Guid>();

            for (int i = 0; i < categoriesCheckedListBox.Items.Count; i++)
            {
                if (categoriesCheckedListBox.GetItemChecked(i))
                {
                    selectedIds.Add(_allCategories[i].CategoryID);
                }
            }

            FilterApplied?.Invoke(selectedIds);
            this.Hide();
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < categoriesCheckedListBox.Items.Count; i++)
            {
                categoriesCheckedListBox.SetItemChecked(i, true);
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < categoriesCheckedListBox.Items.Count; i++)
            {
                categoriesCheckedListBox.SetItemChecked(i, false);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}