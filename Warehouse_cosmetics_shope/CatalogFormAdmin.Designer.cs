namespace Warehouse_cosmetics_shope
{
    partial class CatalogFormAdmin
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
            this.buttonHistory = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.catalogLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonEditCategory = new System.Windows.Forms.Button();
            this.lossFromCatalogButton = new System.Windows.Forms.Button();
            this.deliveryFromCatalogButton = new System.Windows.Forms.Button();
            this.labelShowLogin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelShowUserLogin = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewCatalog = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalog)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonHistory
            // 
            this.buttonHistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonHistory.FlatAppearance.BorderSize = 2;
            this.buttonHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHistory.Location = new System.Drawing.Point(125, 0);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(120, 49);
            this.buttonHistory.TabIndex = 0;
            this.buttonHistory.Text = "История";
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(930, 96);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(140, 29);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Искать";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // searchBox
            // 
            this.searchBox.ForeColor = System.Drawing.Color.Gray;
            this.searchBox.Location = new System.Drawing.Point(624, 99);
            this.searchBox.MaximumSize = new System.Drawing.Size(300, 50);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(300, 22);
            this.searchBox.TabIndex = 3;
            this.searchBox.Text = "Поиск";
            this.searchBox.Enter += new System.EventHandler(this.searchBox_Enter);
            // 
            // catalogLabel
            // 
            this.catalogLabel.AutoSize = true;
            this.catalogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.catalogLabel.Location = new System.Drawing.Point(33, 89);
            this.catalogLabel.Name = "catalogLabel";
            this.catalogLabel.Size = new System.Drawing.Size(250, 32);
            this.catalogLabel.TabIndex = 5;
            this.catalogLabel.Text = "Каталог товаров";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.buttonPlus);
            this.panel2.Controls.Add(this.buttonFilter);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.searchBox);
            this.panel2.Controls.Add(this.searchButton);
            this.panel2.Controls.Add(this.catalogLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1132, 150);
            this.panel2.TabIndex = 8;
            // 
            // buttonPlus
            // 
            this.buttonPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPlus.FlatAppearance.BorderSize = 0;
            this.buttonPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlus.Location = new System.Drawing.Point(297, 89);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(34, 37);
            this.buttonPlus.TabIndex = 9;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = false;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.buttonFilter.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFilter.ForeColor = System.Drawing.Color.Black;
            this.buttonFilter.Location = new System.Drawing.Point(377, 93);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(133, 33);
            this.buttonFilter.TabIndex = 8;
            this.buttonFilter.Text = "Фильтровать";
            this.buttonFilter.UseVisualStyleBackColor = false;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonEditCategory);
            this.panel1.Controls.Add(this.lossFromCatalogButton);
            this.panel1.Controls.Add(this.deliveryFromCatalogButton);
            this.panel1.Controls.Add(this.labelShowLogin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelShowUserLogin);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonHistory);
            this.panel1.Location = new System.Drawing.Point(-7, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1272, 49);
            this.panel1.TabIndex = 7;
            // 
            // buttonEditCategory
            // 
            this.buttonEditCategory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonEditCategory.FlatAppearance.BorderSize = 2;
            this.buttonEditCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditCategory.Location = new System.Drawing.Point(478, 0);
            this.buttonEditCategory.Name = "buttonEditCategory";
            this.buttonEditCategory.Size = new System.Drawing.Size(139, 49);
            this.buttonEditCategory.TabIndex = 12;
            this.buttonEditCategory.Text = "Редактирование категорий";
            this.buttonEditCategory.UseVisualStyleBackColor = true;
            this.buttonEditCategory.Click += new System.EventHandler(this.buttonEditCategory_Click);
            // 
            // lossFromCatalogButton
            // 
            this.lossFromCatalogButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.lossFromCatalogButton.FlatAppearance.BorderSize = 2;
            this.lossFromCatalogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lossFromCatalogButton.Location = new System.Drawing.Point(360, 0);
            this.lossFromCatalogButton.Name = "lossFromCatalogButton";
            this.lossFromCatalogButton.Size = new System.Drawing.Size(120, 49);
            this.lossFromCatalogButton.TabIndex = 11;
            this.lossFromCatalogButton.Text = "Убыток";
            this.lossFromCatalogButton.UseVisualStyleBackColor = true;
            this.lossFromCatalogButton.Click += new System.EventHandler(this.LossFromCatalogButton_Click);
            // 
            // deliveryFromCatalogButton
            // 
            this.deliveryFromCatalogButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.deliveryFromCatalogButton.FlatAppearance.BorderSize = 2;
            this.deliveryFromCatalogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deliveryFromCatalogButton.Location = new System.Drawing.Point(243, 0);
            this.deliveryFromCatalogButton.Name = "deliveryFromCatalogButton";
            this.deliveryFromCatalogButton.Size = new System.Drawing.Size(120, 49);
            this.deliveryFromCatalogButton.TabIndex = 10;
            this.deliveryFromCatalogButton.Text = "Поставка";
            this.deliveryFromCatalogButton.UseVisualStyleBackColor = true;
            this.deliveryFromCatalogButton.Click += new System.EventHandler(this.deliveryFromCatalogButton_Click);
            // 
            // labelShowLogin
            // 
            this.labelShowLogin.AutoSize = true;
            this.labelShowLogin.Location = new System.Drawing.Point(877, 16);
            this.labelShowLogin.Name = "labelShowLogin";
            this.labelShowLogin.Size = new System.Drawing.Size(77, 16);
            this.labelShowLogin.TabIndex = 9;
            this.labelShowLogin.Text = "Ваш логин:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(716, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(694, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 8;
            // 
            // labelShowUserLogin
            // 
            this.labelShowUserLogin.AutoSize = true;
            this.labelShowUserLogin.Location = new System.Drawing.Point(663, 16);
            this.labelShowUserLogin.Name = "labelShowUserLogin";
            this.labelShowUserLogin.Size = new System.Drawing.Size(0, 16);
            this.labelShowUserLogin.TabIndex = 2;
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonExit.FlatAppearance.BorderSize = 2;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(7, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(120, 49);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dataGridViewCatalog);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 150);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1132, 478);
            this.panel3.TabIndex = 9;
            // 
            // dataGridViewCatalog
            // 
            this.dataGridViewCatalog.AllowUserToOrderColumns = true;
            this.dataGridViewCatalog.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewCatalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCatalog.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCatalog.Name = "dataGridViewCatalog";
            this.dataGridViewCatalog.RowHeadersWidth = 51;
            this.dataGridViewCatalog.RowTemplate.Height = 24;
            this.dataGridViewCatalog.Size = new System.Drawing.Size(1132, 624);
            this.dataGridViewCatalog.TabIndex = 0;
            this.dataGridViewCatalog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCatalog_CellClick);
            this.dataGridViewCatalog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewCatalog_CellFormatting);
            // 
            // CatalogFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1132, 628);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "CatalogFormAdmin";
            this.Text = "Каталог администратора";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonHistory;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label catalogLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelShowUserLogin;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewCatalog;
        private System.Windows.Forms.Label labelShowLogin;
        private System.Windows.Forms.Button lossFromCatalogButton;
        private System.Windows.Forms.Button deliveryFromCatalogButton;
        private System.Windows.Forms.Button buttonEditCategory;
    }
}