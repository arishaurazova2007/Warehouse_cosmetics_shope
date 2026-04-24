namespace Warehouse_cosmetics_shope
{
    partial class ShipmentForm
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
            this.shipmentFormLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.clientNameLabel = new System.Windows.Forms.Label();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.clientTypeComboBox = new System.Windows.Forms.ComboBox();
            this.buttonGenerateList = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.shipmentSearchBox = new System.Windows.Forms.TextBox();
            this.shipmentSearchButton = new System.Windows.Forms.Button();
            this.clientNameTextBox = new System.Windows.Forms.TextBox();
            this.itemsToShipmentLabel = new System.Windows.Forms.Label();
            this.catalogInShipmentLabel = new System.Windows.Forms.Label();
            this.catalogInShipmentGridView = new System.Windows.Forms.DataGridView();
            this.shipmentDataDridView = new System.Windows.Forms.DataGridView();
            this.quantityNumeric = new System.Windows.Forms.NumericUpDown();
            this.clientTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.catalogInShipmentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDataDridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // shipmentFormLabel
            // 
            this.shipmentFormLabel.AutoSize = true;
            this.shipmentFormLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.shipmentFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shipmentFormLabel.Location = new System.Drawing.Point(932, 101);
            this.shipmentFormLabel.Name = "shipmentFormLabel";
            this.shipmentFormLabel.Size = new System.Drawing.Size(273, 32);
            this.shipmentFormLabel.TabIndex = 7;
            this.shipmentFormLabel.Text = "Товары к отгрузке";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantityLabel.Location = new System.Drawing.Point(822, 288);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(119, 22);
            this.quantityLabel.TabIndex = 10;
            this.quantityLabel.Text = "Количество";
            // 
            // clientNameLabel
            // 
            this.clientNameLabel.AutoSize = true;
            this.clientNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientNameLabel.Location = new System.Drawing.Point(865, 434);
            this.clientNameLabel.Name = "clientNameLabel";
            this.clientNameLabel.Size = new System.Drawing.Size(76, 22);
            this.clientNameLabel.TabIndex = 12;
            this.clientNameLabel.Text = "Клиент";
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonAddProduct.FlatAppearance.BorderSize = 0;
            this.buttonAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddProduct.ForeColor = System.Drawing.Color.Black;
            this.buttonAddProduct.Location = new System.Drawing.Point(943, 523);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(271, 63);
            this.buttonAddProduct.TabIndex = 18;
            this.buttonAddProduct.Text = "Добавить  товар";
            this.buttonAddProduct.UseVisualStyleBackColor = false;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // clientTypeComboBox
            // 
            this.clientTypeComboBox.BackColor = System.Drawing.Color.White;
            this.clientTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clientTypeComboBox.ForeColor = System.Drawing.Color.Black;
            this.clientTypeComboBox.FormattingEnabled = true;
            this.clientTypeComboBox.Location = new System.Drawing.Point(967, 360);
            this.clientTypeComboBox.Name = "clientTypeComboBox";
            this.clientTypeComboBox.Size = new System.Drawing.Size(306, 24);
            this.clientTypeComboBox.TabIndex = 19;
            // 
            // buttonGenerateList
            // 
            this.buttonGenerateList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonGenerateList.FlatAppearance.BorderSize = 0;
            this.buttonGenerateList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGenerateList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGenerateList.ForeColor = System.Drawing.Color.Black;
            this.buttonGenerateList.Location = new System.Drawing.Point(943, 605);
            this.buttonGenerateList.Name = "buttonGenerateList";
            this.buttonGenerateList.Size = new System.Drawing.Size(271, 61);
            this.buttonGenerateList.TabIndex = 20;
            this.buttonGenerateList.Text = "Сформировать список";
            this.buttonGenerateList.UseVisualStyleBackColor = false;
            this.buttonGenerateList.Click += new System.EventHandler(this.buttonGenerateList_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.Location = new System.Drawing.Point(985, 700);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(192, 41);
            this.buttonBack.TabIndex = 21;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.productNameLabel.ForeColor = System.Drawing.Color.Black;
            this.productNameLabel.Location = new System.Drawing.Point(874, 216);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(67, 22);
            this.productNameLabel.TabIndex = 34;
            this.productNameLabel.Text = "Товар";
            // 
            // shipmentSearchBox
            // 
            this.shipmentSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shipmentSearchBox.ForeColor = System.Drawing.Color.Gray;
            this.shipmentSearchBox.Location = new System.Drawing.Point(967, 213);
            this.shipmentSearchBox.MaximumSize = new System.Drawing.Size(300, 50);
            this.shipmentSearchBox.Name = "shipmentSearchBox";
            this.shipmentSearchBox.Size = new System.Drawing.Size(226, 27);
            this.shipmentSearchBox.TabIndex = 33;
            this.shipmentSearchBox.Text = "Поиск";
            shipmentSearchBox.Enter += ShipmentSearchBox_Enter;
            shipmentSearchBox.Leave += ShipmentSearchBox_Leave;
            // 
            // shipmentSearchButton
            // 
            this.shipmentSearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.shipmentSearchButton.FlatAppearance.BorderSize = 0;
            this.shipmentSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shipmentSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shipmentSearchButton.ForeColor = System.Drawing.Color.White;
            this.shipmentSearchButton.Location = new System.Drawing.Point(1199, 213);
            this.shipmentSearchButton.Name = "shipmentSearchButton";
            this.shipmentSearchButton.Size = new System.Drawing.Size(74, 29);
            this.shipmentSearchButton.TabIndex = 32;
            this.shipmentSearchButton.Text = "Искать";
            this.shipmentSearchButton.UseVisualStyleBackColor = false;
            shipmentSearchButton.Click += ShipmentSearchButton_Click;
            // 
            // clientNameTextBox
            // 
            this.clientNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientNameTextBox.Location = new System.Drawing.Point(967, 436);
            this.clientNameTextBox.Name = "clientNameTextBox";
            this.clientNameTextBox.Size = new System.Drawing.Size(306, 20);
            this.clientNameTextBox.TabIndex = 35;
            // 
            // itemsToShipmentLabel
            // 
            this.itemsToShipmentLabel.AutoSize = true;
            this.itemsToShipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemsToShipmentLabel.Location = new System.Drawing.Point(35, 396);
            this.itemsToShipmentLabel.Name = "itemsToShipmentLabel";
            this.itemsToShipmentLabel.Size = new System.Drawing.Size(125, 29);
            this.itemsToShipmentLabel.TabIndex = 53;
            this.itemsToShipmentLabel.Text = "Отгрузка";
            // 
            // catalogInShipmentLabel
            // 
            this.catalogInShipmentLabel.AutoSize = true;
            this.catalogInShipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.catalogInShipmentLabel.Location = new System.Drawing.Point(34, 42);
            this.catalogInShipmentLabel.Name = "catalogInShipmentLabel";
            this.catalogInShipmentLabel.Size = new System.Drawing.Size(112, 29);
            this.catalogInShipmentLabel.TabIndex = 52;
            this.catalogInShipmentLabel.Text = "Каталог";
            // 
            // catalogInShipmentGridView
            // 
            this.catalogInShipmentGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.catalogInShipmentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catalogInShipmentGridView.Location = new System.Drawing.Point(40, 76);
            this.catalogInShipmentGridView.MultiSelect = false;
            this.catalogInShipmentGridView.Name = "catalogInShipmentGridView";
            this.catalogInShipmentGridView.RowHeadersWidth = 51;
            this.catalogInShipmentGridView.RowTemplate.Height = 24;
            this.catalogInShipmentGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.catalogInShipmentGridView.Size = new System.Drawing.Size(721, 293);
            this.catalogInShipmentGridView.TabIndex = 51;
            catalogInShipmentGridView.CellClick += CatalogInShipmentGridView_CellClick;
            // 
            // shipmentDataDridView
            // 
            this.shipmentDataDridView.AllowUserToAddRows = false;
            this.shipmentDataDridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.shipmentDataDridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shipmentDataDridView.Location = new System.Drawing.Point(40, 428);
            this.shipmentDataDridView.Name = "shipmentDataDridView";
            this.shipmentDataDridView.RowHeadersWidth = 51;
            this.shipmentDataDridView.RowTemplate.Height = 24;
            this.shipmentDataDridView.Size = new System.Drawing.Size(721, 356);
            this.shipmentDataDridView.TabIndex = 49;
            // 
            // quantityNumeric
            // 
            this.quantityNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantityNumeric.Location = new System.Drawing.Point(967, 286);
            this.quantityNumeric.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.quantityNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityNumeric.Name = "quantityNumeric";
            this.quantityNumeric.Size = new System.Drawing.Size(306, 27);
            this.quantityNumeric.TabIndex = 54;
            this.quantityNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // clientTypeLabel
            // 
            this.clientTypeLabel.AutoSize = true;
            this.clientTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientTypeLabel.Location = new System.Drawing.Point(822, 362);
            this.clientTypeLabel.Name = "clientTypeLabel";
            this.clientTypeLabel.Size = new System.Drawing.Size(125, 22);
            this.clientTypeLabel.TabIndex = 55;
            this.clientTypeLabel.Text = "Тип клиента";
            // 
            // ShipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1329, 820);
            this.Controls.Add(this.clientTypeLabel);
            this.Controls.Add(this.quantityNumeric);
            this.Controls.Add(this.itemsToShipmentLabel);
            this.Controls.Add(this.catalogInShipmentLabel);
            this.Controls.Add(this.catalogInShipmentGridView);
            this.Controls.Add(this.shipmentDataDridView);
            this.Controls.Add(this.clientNameTextBox);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.shipmentSearchBox);
            this.Controls.Add(this.shipmentSearchButton);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonGenerateList);
            this.Controls.Add(this.clientTypeComboBox);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.clientNameLabel);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.shipmentFormLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ShipmentForm";
            this.Text = "Отгрузка";
            ((System.ComponentModel.ISupportInitialize)(this.catalogInShipmentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDataDridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label shipmentFormLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label clientNameLabel;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.ComboBox clientTypeComboBox;
        private System.Windows.Forms.Button buttonGenerateList;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.TextBox shipmentSearchBox;
        private System.Windows.Forms.Button shipmentSearchButton;
        private System.Windows.Forms.TextBox clientNameTextBox;
        private System.Windows.Forms.Label itemsToShipmentLabel;
        private System.Windows.Forms.Label catalogInShipmentLabel;
        private System.Windows.Forms.DataGridView catalogInShipmentGridView;
        private System.Windows.Forms.DataGridView shipmentDataDridView;
        private System.Windows.Forms.NumericUpDown quantityNumeric;
        private System.Windows.Forms.Label clientTypeLabel;
    }
}