namespace Warehouse_cosmetics_shope
{
    partial class ItemForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.itemFormTitleLabel = new System.Windows.Forms.Label();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.manufDateLabel = new System.Windows.Forms.Label();
            this.expDateLabel = new System.Windows.Forms.Label();
            this.purPriceLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.productNameInput = new System.Windows.Forms.TextBox();
            this.buttonEditCategory = new System.Windows.Forms.Button();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.showProductNumberLabel = new System.Windows.Forms.Label();
            this.manufdatePicker = new System.Windows.Forms.DateTimePicker();
            this.expDatePicker = new System.Windows.Forms.DateTimePicker();
            this.sellPriceLabel = new System.Windows.Forms.Label();
            this.measUnitsLabel = new System.Windows.Forms.Label();
            this.measUnitsComboBox = new System.Windows.Forms.ComboBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.purPriceNumeric = new System.Windows.Forms.NumericUpDown();
            this.sellPriceNumeric = new System.Windows.Forms.NumericUpDown();
            this.quantityPickOrShowNumeric = new System.Windows.Forms.NumericUpDown();
            this.itemNumberTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.purPriceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellPriceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityPickOrShowNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // itemFormTitleLabel
            // 
            this.itemFormTitleLabel.AutoSize = true;
            this.itemFormTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.itemFormTitleLabel.ForeColor = System.Drawing.Color.Black;
            this.itemFormTitleLabel.Location = new System.Drawing.Point(390, 49);
            this.itemFormTitleLabel.Name = "itemFormTitleLabel";
            this.itemFormTitleLabel.Size = new System.Drawing.Size(23, 31);
            this.itemFormTitleLabel.TabIndex = 0;
            this.itemFormTitleLabel.Text = "/";
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.productNameLabel.ForeColor = System.Drawing.Color.Black;
            this.productNameLabel.Location = new System.Drawing.Point(282, 137);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(100, 22);
            this.productNameLabel.TabIndex = 1;
            this.productNameLabel.Text = "Название";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(274, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Категория";
            // 
            // manufDateLabel
            // 
            this.manufDateLabel.AutoSize = true;
            this.manufDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.manufDateLabel.ForeColor = System.Drawing.Color.Black;
            this.manufDateLabel.Location = new System.Drawing.Point(193, 309);
            this.manufDateLabel.Name = "manufDateLabel";
            this.manufDateLabel.Size = new System.Drawing.Size(188, 22);
            this.manufDateLabel.TabIndex = 5;
            this.manufDateLabel.Text = "Дата изготовления";
            // 
            // expDateLabel
            // 
            this.expDateLabel.AutoSize = true;
            this.expDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.expDateLabel.ForeColor = System.Drawing.Color.Black;
            this.expDateLabel.Location = new System.Drawing.Point(286, 354);
            this.expDateLabel.Name = "expDateLabel";
            this.expDateLabel.Size = new System.Drawing.Size(95, 22);
            this.expDateLabel.TabIndex = 6;
            this.expDateLabel.Text = "Годен до";
            // 
            // purPriceLabel
            // 
            this.purPriceLabel.AutoSize = true;
            this.purPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.purPriceLabel.ForeColor = System.Drawing.Color.Black;
            this.purPriceLabel.Location = new System.Drawing.Point(249, 451);
            this.purPriceLabel.Name = "purPriceLabel";
            this.purPriceLabel.Size = new System.Drawing.Size(136, 22);
            this.purPriceLabel.TabIndex = 7;
            this.purPriceLabel.Text = "Цена закупки";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.quantityLabel.ForeColor = System.Drawing.Color.Black;
            this.quantityLabel.Location = new System.Drawing.Point(298, 538);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(85, 22);
            this.quantityLabel.TabIndex = 8;
            this.quantityLabel.Text = "Остаток";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(409, 652);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 39);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(573, 652);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(140, 39);
            this.buttonBack.TabIndex = 10;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // productNameInput
            // 
            this.productNameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productNameInput.Location = new System.Drawing.Point(405, 140);
            this.productNameInput.Name = "productNameInput";
            this.productNameInput.Size = new System.Drawing.Size(489, 15);
            this.productNameInput.TabIndex = 11;
            // 
            // buttonEditCategory
            // 
            this.buttonEditCategory.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonEditCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditCategory.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonEditCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditCategory.Location = new System.Drawing.Point(748, 259);
            this.buttonEditCategory.Name = "buttonEditCategory";
            this.buttonEditCategory.Size = new System.Drawing.Size(146, 31);
            this.buttonEditCategory.TabIndex = 19;
            this.buttonEditCategory.Text = "Редактировать";
            this.buttonEditCategory.UseVisualStyleBackColor = false;
            this.buttonEditCategory.Click += new System.EventHandler(this.buttonEditCategory_Click);
            // 
            // Deletebutton
            // 
            this.Deletebutton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Deletebutton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Deletebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Deletebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Deletebutton.Location = new System.Drawing.Point(748, 529);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(146, 31);
            this.Deletebutton.TabIndex = 20;
            this.Deletebutton.Text = "Удалить товар";
            this.Deletebutton.UseVisualStyleBackColor = false;
            this.Deletebutton.Click += new System.EventHandler(this.Deletebutton_Click);
            // 
            // showProductNumberLabel
            // 
            this.showProductNumberLabel.AutoSize = true;
            this.showProductNumberLabel.Location = new System.Drawing.Point(402, 179);
            this.showProductNumberLabel.Name = "showProductNumberLabel";
            this.showProductNumberLabel.Size = new System.Drawing.Size(264, 16);
            this.showProductNumberLabel.TabIndex = 21;
            this.showProductNumberLabel.Text = "Будет задан после добавления товара";
            // 
            // manufdatePicker
            // 
            this.manufdatePicker.Location = new System.Drawing.Point(405, 308);
            this.manufdatePicker.Name = "manufdatePicker";
            this.manufdatePicker.Size = new System.Drawing.Size(281, 22);
            this.manufdatePicker.TabIndex = 23;
            this.manufdatePicker.Value = new System.DateTime(2024, 4, 5, 17, 7, 0, 0);
            // 
            // expDatePicker
            // 
            this.expDatePicker.Location = new System.Drawing.Point(405, 355);
            this.expDatePicker.Name = "expDatePicker";
            this.expDatePicker.Size = new System.Drawing.Size(281, 22);
            this.expDatePicker.TabIndex = 24;
            // 
            // sellPriceLabel
            // 
            this.sellPriceLabel.AutoSize = true;
            this.sellPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.sellPriceLabel.ForeColor = System.Drawing.Color.Black;
            this.sellPriceLabel.Location = new System.Drawing.Point(199, 496);
            this.sellPriceLabel.Name = "sellPriceLabel";
            this.sellPriceLabel.Size = new System.Drawing.Size(185, 22);
            this.sellPriceLabel.TabIndex = 25;
            this.sellPriceLabel.Text = "Цена для продажи";
            // 
            // measUnitsLabel
            // 
            this.measUnitsLabel.AutoSize = true;
            this.measUnitsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.measUnitsLabel.ForeColor = System.Drawing.Color.Black;
            this.measUnitsLabel.Location = new System.Drawing.Point(236, 404);
            this.measUnitsLabel.Name = "measUnitsLabel";
            this.measUnitsLabel.Size = new System.Drawing.Size(148, 22);
            this.measUnitsLabel.TabIndex = 27;
            this.measUnitsLabel.Text = "Ед. измерения";
            // 
            // measUnitsComboBox
            // 
            this.measUnitsComboBox.FormattingEnabled = true;
            this.measUnitsComboBox.Location = new System.Drawing.Point(405, 402);
            this.measUnitsComboBox.Name = "measUnitsComboBox";
            this.measUnitsComboBox.Size = new System.Drawing.Size(281, 24);
            this.measUnitsComboBox.TabIndex = 28;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(405, 218);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(489, 24);
            this.categoryComboBox.TabIndex = 30;
            // 
            // purPriceNumeric
            // 
            this.purPriceNumeric.Location = new System.Drawing.Point(405, 451);
            this.purPriceNumeric.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.purPriceNumeric.Name = "purPriceNumeric";
            this.purPriceNumeric.Size = new System.Drawing.Size(281, 22);
            this.purPriceNumeric.TabIndex = 31;
            // 
            // sellPriceNumeric
            // 
            this.sellPriceNumeric.Location = new System.Drawing.Point(405, 496);
            this.sellPriceNumeric.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.sellPriceNumeric.Name = "sellPriceNumeric";
            this.sellPriceNumeric.Size = new System.Drawing.Size(281, 22);
            this.sellPriceNumeric.TabIndex = 32;
            // 
            // quantityPickOrShowNumeric
            // 
            this.quantityPickOrShowNumeric.Location = new System.Drawing.Point(405, 538);
            this.quantityPickOrShowNumeric.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.quantityPickOrShowNumeric.Name = "quantityPickOrShowNumeric";
            this.quantityPickOrShowNumeric.Size = new System.Drawing.Size(281, 22);
            this.quantityPickOrShowNumeric.TabIndex = 33;
            // 
            // itemNumberTitle
            // 
            this.itemNumberTitle.AutoSize = true;
            this.itemNumberTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.itemNumberTitle.ForeColor = System.Drawing.Color.Black;
            this.itemNumberTitle.Location = new System.Drawing.Point(295, 175);
            this.itemNumberTitle.Name = "itemNumberTitle";
            this.itemNumberTitle.Size = new System.Drawing.Size(85, 22);
            this.itemNumberTitle.TabIndex = 34;
            this.itemNumberTitle.Text = "Артикул";
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1122, 743);
            this.Controls.Add(this.itemNumberTitle);
            this.Controls.Add(this.quantityPickOrShowNumeric);
            this.Controls.Add(this.sellPriceNumeric);
            this.Controls.Add(this.purPriceNumeric);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.measUnitsComboBox);
            this.Controls.Add(this.measUnitsLabel);
            this.Controls.Add(this.sellPriceLabel);
            this.Controls.Add(this.expDatePicker);
            this.Controls.Add(this.manufdatePicker);
            this.Controls.Add(this.showProductNumberLabel);
            this.Controls.Add(this.Deletebutton);
            this.Controls.Add(this.buttonEditCategory);
            this.Controls.Add(this.productNameInput);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.purPriceLabel);
            this.Controls.Add(this.expDateLabel);
            this.Controls.Add(this.manufDateLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.itemFormTitleLabel);
            this.Name = "ItemForm";
            this.Text = "Товар";
            ((System.ComponentModel.ISupportInitialize)(this.purPriceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellPriceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityPickOrShowNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label itemFormTitleLabel;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label manufDateLabel;
        private System.Windows.Forms.Label expDateLabel;
        private System.Windows.Forms.Label purPriceLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TextBox productNameInput;
        private System.Windows.Forms.Button buttonEditCategory;
        private System.Windows.Forms.Button Deletebutton;
        private System.Windows.Forms.Label showProductNumberLabel;
        private System.Windows.Forms.DateTimePicker manufdatePicker;
        private System.Windows.Forms.DateTimePicker expDatePicker;
        private System.Windows.Forms.Label sellPriceLabel;
        private System.Windows.Forms.Label measUnitsLabel;
        private System.Windows.Forms.ComboBox measUnitsComboBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.NumericUpDown purPriceNumeric;
        private System.Windows.Forms.NumericUpDown sellPriceNumeric;
        private System.Windows.Forms.NumericUpDown quantityPickOrShowNumeric;
        private System.Windows.Forms.Label itemNumberTitle;
    }
}