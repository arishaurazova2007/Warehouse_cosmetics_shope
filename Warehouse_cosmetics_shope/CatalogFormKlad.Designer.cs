namespace Warehouse_cosmetics_shope
{
    partial class CatalogFormKlad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOtgruzka = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArticul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labelID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonOtgruzka);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 49);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(694, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(663, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID:";
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonExit.FlatAppearance.BorderSize = 2;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(117, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(120, 49);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonOtgruzka
            // 
            this.buttonOtgruzka.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonOtgruzka.FlatAppearance.BorderSize = 2;
            this.buttonOtgruzka.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOtgruzka.Location = new System.Drawing.Point(0, 0);
            this.buttonOtgruzka.Name = "buttonOtgruzka";
            this.buttonOtgruzka.Size = new System.Drawing.Size(120, 49);
            this.buttonOtgruzka.TabIndex = 0;
            this.buttonOtgruzka.Text = "Отгрузка";
            this.buttonOtgruzka.UseVisualStyleBackColor = true;
            this.buttonOtgruzka.Click += new System.EventHandler(this.buttonOtgruzka_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(30, 89);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(250, 32);
            this.labelLogin.TabIndex = 9;
            this.labelLogin.Text = "Каталог товаров";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewProducts);
            this.panel2.Location = new System.Drawing.Point(1, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(801, 296);
            this.panel2.TabIndex = 10;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colCategory,
            this.colType,
            this.colArticul,
            this.colUnit,
            this.colExpiration,
            this.colPrice,
            this.colStock});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProducts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProducts.EnableHeadersVisualStyles = false;
            this.dataGridViewProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.dataGridViewProducts.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersVisible = false;
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.RowTemplate.Height = 24;
            this.dataGridViewProducts.Size = new System.Drawing.Size(801, 296);
            this.dataGridViewProducts.TabIndex = 6;
            // 
            // colName
            // 
            this.colName.HeaderText = "Название";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 125;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Категория";
            this.colCategory.MinimumWidth = 6;
            this.colCategory.Name = "colCategory";
            this.colCategory.Width = 120;
            // 
            // colType
            // 
            this.colType.HeaderText = "Вид";
            this.colType.MinimumWidth = 6;
            this.colType.Name = "colType";
            this.colType.Width = 80;
            // 
            // colArticul
            // 
            this.colArticul.HeaderText = "Арт.";
            this.colArticul.MinimumWidth = 6;
            this.colArticul.Name = "colArticul";
            this.colArticul.Width = 80;
            // 
            // colUnit
            // 
            this.colUnit.HeaderText = "Ед.изм-я.";
            this.colUnit.MinimumWidth = 6;
            this.colUnit.Name = "colUnit";
            this.colUnit.Width = 73;
            // 
            // colExpiration
            // 
            this.colExpiration.HeaderText = "Срок годности";
            this.colExpiration.MinimumWidth = 6;
            this.colExpiration.Name = "colExpiration";
            this.colExpiration.Width = 93;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Закупочная цена";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 103;
            // 
            // colStock
            // 
            this.colStock.HeaderText = "Остаток";
            this.colStock.MinimumWidth = 6;
            this.colStock.Name = "colStock";
            this.colStock.Width = 125;
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.buttonFilter.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFilter.ForeColor = System.Drawing.Color.Black;
            this.buttonFilter.Location = new System.Drawing.Point(305, 95);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(108, 26);
            this.buttonFilter.TabIndex = 9;
            this.buttonFilter.Text = "Фильтровать";
            this.buttonFilter.UseVisualStyleBackColor = false;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSearch.Location = new System.Drawing.Point(458, 98);
            this.textBoxSearch.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(237, 22);
            this.textBoxSearch.TabIndex = 11;
            this.textBoxSearch.Text = "Поиск";
            this.textBoxSearch.Click += new System.EventHandler(this.TextBox1_LostFocus);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(689, 99);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(86, 22);
            this.buttonSearch.TabIndex = 12;
            this.buttonSearch.Text = "Искать";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(693, 16);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 16);
            this.labelID.TabIndex = 9;
            // 
            // CatalogFormKlad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.panel1);
            this.Name = "CatalogFormKlad";
            this.Text = "Каталог кладовщика";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOtgruzka;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticul;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelID;
    }
}