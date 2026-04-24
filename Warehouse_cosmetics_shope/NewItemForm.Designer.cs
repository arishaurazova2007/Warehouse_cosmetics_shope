namespace Warehouse_cosmetics_shope
{
    partial class NewItemForm
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
            this.itemNumberTitle = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.unitComboBox = new System.Windows.Forms.ComboBox();
            this.measUnitsLabel = new System.Windows.Forms.Label();
            this.showProductNumberLabel = new System.Windows.Forms.Label();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.itemFormTitleLabel = new System.Windows.Forms.Label();
            this.sellPriceLabel = new System.Windows.Forms.Label();
            this.sellPriceNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.sellPriceNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // itemNumberTitle
            // 
            this.itemNumberTitle.AutoSize = true;
            this.itemNumberTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.itemNumberTitle.ForeColor = System.Drawing.Color.Black;
            this.itemNumberTitle.Location = new System.Drawing.Point(227, 202);
            this.itemNumberTitle.Name = "itemNumberTitle";
            this.itemNumberTitle.Size = new System.Drawing.Size(85, 22);
            this.itemNumberTitle.TabIndex = 57;
            this.itemNumberTitle.Text = "Артикул";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(337, 245);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(489, 24);
            this.categoryComboBox.TabIndex = 53;
            // 
            // unitComboBox
            // 
            this.unitComboBox.FormattingEnabled = true;
            this.unitComboBox.Location = new System.Drawing.Point(337, 339);
            this.unitComboBox.Name = "unitComboBox";
            this.unitComboBox.Size = new System.Drawing.Size(210, 24);
            this.unitComboBox.TabIndex = 52;
            // 
            // measUnitsLabel
            // 
            this.measUnitsLabel.AutoSize = true;
            this.measUnitsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.measUnitsLabel.ForeColor = System.Drawing.Color.Black;
            this.measUnitsLabel.Location = new System.Drawing.Point(168, 341);
            this.measUnitsLabel.Name = "measUnitsLabel";
            this.measUnitsLabel.Size = new System.Drawing.Size(148, 22);
            this.measUnitsLabel.TabIndex = 51;
            this.measUnitsLabel.Text = "Ед. измерения";
            // 
            // showProductNumberLabel
            // 
            this.showProductNumberLabel.AutoSize = true;
            this.showProductNumberLabel.Location = new System.Drawing.Point(334, 206);
            this.showProductNumberLabel.Name = "showProductNumberLabel";
            this.showProductNumberLabel.Size = new System.Drawing.Size(264, 16);
            this.showProductNumberLabel.TabIndex = 47;
            this.showProductNumberLabel.Text = "Будет задан после добавления товара";
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productNameTextBox.Location = new System.Drawing.Point(337, 167);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(489, 15);
            this.productNameTextBox.TabIndex = 44;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(514, 438);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(140, 39);
            this.buttonBack.TabIndex = 43;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(350, 438);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 39);
            this.buttonSave.TabIndex = 42;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(206, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 22);
            this.label4.TabIndex = 37;
            this.label4.Text = "Категория";
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.productNameLabel.ForeColor = System.Drawing.Color.Black;
            this.productNameLabel.Location = new System.Drawing.Point(214, 164);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(100, 22);
            this.productNameLabel.TabIndex = 36;
            this.productNameLabel.Text = "Название";
            // 
            // itemFormTitleLabel
            // 
            this.itemFormTitleLabel.AutoSize = true;
            this.itemFormTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.itemFormTitleLabel.ForeColor = System.Drawing.Color.Black;
            this.itemFormTitleLabel.Location = new System.Drawing.Point(366, 69);
            this.itemFormTitleLabel.Name = "itemFormTitleLabel";
            this.itemFormTitleLabel.Size = new System.Drawing.Size(279, 31);
            this.itemFormTitleLabel.TabIndex = 35;
            this.itemFormTitleLabel.Text = "Добавление товара";
            // 
            // sellPriceLabel
            // 
            this.sellPriceLabel.AutoSize = true;
            this.sellPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.sellPriceLabel.ForeColor = System.Drawing.Color.Black;
            this.sellPriceLabel.Location = new System.Drawing.Point(167, 294);
            this.sellPriceLabel.Name = "sellPriceLabel";
            this.sellPriceLabel.Size = new System.Drawing.Size(145, 22);
            this.sellPriceLabel.TabIndex = 58;
            this.sellPriceLabel.Text = "Цена продажи";
            this.sellPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sellPriceNumeric
            // 
            this.sellPriceNumeric.Location = new System.Drawing.Point(337, 294);
            this.sellPriceNumeric.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.sellPriceNumeric.Name = "sellPriceNumeric";
            this.sellPriceNumeric.Size = new System.Drawing.Size(210, 22);
            this.sellPriceNumeric.TabIndex = 59;
            // 
            // NewItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1005, 553);
            this.Controls.Add(this.sellPriceNumeric);
            this.Controls.Add(this.sellPriceLabel);
            this.Controls.Add(this.itemNumberTitle);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.unitComboBox);
            this.Controls.Add(this.measUnitsLabel);
            this.Controls.Add(this.showProductNumberLabel);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.itemFormTitleLabel);
            this.Name = "NewItemForm";
            this.Text = "Новый товар";
            ((System.ComponentModel.ISupportInitialize)(this.sellPriceNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemNumberTitle;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox unitComboBox;
        private System.Windows.Forms.Label measUnitsLabel;
        private System.Windows.Forms.Label showProductNumberLabel;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label itemFormTitleLabel;
        private System.Windows.Forms.Label sellPriceLabel;
        private System.Windows.Forms.NumericUpDown sellPriceNumeric;
    }
}