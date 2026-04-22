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
            this.topPanel = new System.Windows.Forms.Panel();
            this.labelShowLogin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOtgruzka = new System.Windows.Forms.Button();
            this.catalogLabel = new System.Windows.Forms.Label();
            this.kladCatalogGrid = new System.Windows.Forms.DataGridView();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.deliveryFromCatalogButton = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kladCatalogGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.deliveryFromCatalogButton);
            this.topPanel.Controls.Add(this.labelShowLogin);
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Controls.Add(this.buttonExit);
            this.topPanel.Controls.Add(this.buttonOtgruzka);
            this.topPanel.Location = new System.Drawing.Point(1, 1);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1132, 49);
            this.topPanel.TabIndex = 8;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(694, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 8;
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonExit.FlatAppearance.BorderSize = 2;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(1, 0);
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
            this.buttonOtgruzka.Location = new System.Drawing.Point(119, 0);
            this.buttonOtgruzka.Name = "buttonOtgruzka";
            this.buttonOtgruzka.Size = new System.Drawing.Size(120, 49);
            this.buttonOtgruzka.TabIndex = 0;
            this.buttonOtgruzka.Text = "Отгрузка";
            this.buttonOtgruzka.UseVisualStyleBackColor = true;
            this.buttonOtgruzka.Click += new System.EventHandler(this.buttonOtgruzka_Click);
            // 
            // catalogLabel
            // 
            this.catalogLabel.AutoSize = true;
            this.catalogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.catalogLabel.Location = new System.Drawing.Point(40, 89);
            this.catalogLabel.Name = "catalogLabel";
            this.catalogLabel.Size = new System.Drawing.Size(250, 32);
            this.catalogLabel.TabIndex = 9;
            this.catalogLabel.Text = "Каталог товаров";
            // 
            // kladCatalogGrid
            // 
            this.kladCatalogGrid.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.kladCatalogGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kladCatalogGrid.Location = new System.Drawing.Point(1, 151);
            this.kladCatalogGrid.Name = "kladCatalogGrid";
            this.kladCatalogGrid.RowHeadersWidth = 51;
            this.kladCatalogGrid.RowTemplate.Height = 24;
            this.kladCatalogGrid.Size = new System.Drawing.Size(1132, 477);
            this.kladCatalogGrid.TabIndex = 13;
            kladCatalogGrid.CellClick += KladCatalogGrid_CellClick;
            kladCatalogGrid.CellFormatting += KladCatalogGrid_CellFormatting;

            // 
            // searchBox
            // 
            this.searchBox.ForeColor = System.Drawing.Color.Gray;
            this.searchBox.Location = new System.Drawing.Point(624, 99);
            this.searchBox.MaximumSize = new System.Drawing.Size(300, 50);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(300, 22);
            this.searchBox.TabIndex = 15;
            this.searchBox.Text = "Поиск";
            searchBox.Enter += searchBox_Enter;
            searchBox.Leave += searchBox_Leave;
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
            this.searchButton.TabIndex = 14;
            this.searchButton.Text = "Искать";
            this.searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += SearchButton_Click;
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.buttonFilter.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFilter.ForeColor = System.Drawing.Color.Black;
            this.buttonFilter.Location = new System.Drawing.Point(332, 93);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(133, 33);
            this.buttonFilter.TabIndex = 16;
            this.buttonFilter.Text = "Фильтровать";
            this.buttonFilter.UseVisualStyleBackColor = false;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // deliveryFromCatalogButton
            // 
            this.deliveryFromCatalogButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.deliveryFromCatalogButton.FlatAppearance.BorderSize = 2;
            this.deliveryFromCatalogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deliveryFromCatalogButton.Location = new System.Drawing.Point(237, 0);
            this.deliveryFromCatalogButton.Name = "deliveryFromCatalogButton";
            this.deliveryFromCatalogButton.Size = new System.Drawing.Size(120, 49);
            this.deliveryFromCatalogButton.TabIndex = 11;
            this.deliveryFromCatalogButton.Text = "Поставка";
            this.deliveryFromCatalogButton.UseVisualStyleBackColor = true;
            // 
            // CatalogFormKlad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1132, 628);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.kladCatalogGrid);
            this.Controls.Add(this.catalogLabel);
            this.Controls.Add(this.topPanel);
            this.Name = "CatalogFormKlad";
            this.Text = "Каталог кладовщика";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kladCatalogGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOtgruzka;
        private System.Windows.Forms.Label catalogLabel;
        private System.Windows.Forms.Label labelShowLogin;
        private System.Windows.Forms.DataGridView kladCatalogGrid;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button deliveryFromCatalogButton;
    }
}