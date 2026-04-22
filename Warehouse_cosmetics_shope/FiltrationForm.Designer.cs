namespace Warehouse_cosmetics_shope
{
    partial class FiltrationForm
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
            this.filterFormLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.availabilityLabel = new System.Windows.Forms.Label();
            this.checkBoxInStock = new System.Windows.Forms.CheckBox();
            this.checkBoxNotInStock = new System.Windows.Forms.CheckBox();
            this.buttonShow = new System.Windows.Forms.Button();
            this.categoriesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.withoutDiscCheckBox = new System.Windows.Forms.CheckBox();
            this.withDiscCheckBox = new System.Windows.Forms.CheckBox();
            this.discountLabel = new System.Windows.Forms.Label();
            this.priceFromNumeric = new System.Windows.Forms.NumericUpDown();
            this.priceToNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.priceFromNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceToNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // filterFormLabel
            // 
            this.filterFormLabel.AutoSize = true;
            this.filterFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterFormLabel.ForeColor = System.Drawing.Color.Black;
            this.filterFormLabel.Location = new System.Drawing.Point(213, 9);
            this.filterFormLabel.Name = "filterFormLabel";
            this.filterFormLabel.Size = new System.Drawing.Size(151, 25);
            this.filterFormLabel.TabIndex = 2;
            this.filterFormLabel.Text = "Фильтровать";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceLabel.ForeColor = System.Drawing.Color.Black;
            this.priceLabel.Location = new System.Drawing.Point(214, 290);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(56, 20);
            this.priceLabel.TabIndex = 16;
            this.priceLabel.Text = "Цена";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromLabel.ForeColor = System.Drawing.Color.Black;
            this.fromLabel.Location = new System.Drawing.Point(213, 323);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(27, 18);
            this.fromLabel.TabIndex = 18;
            this.fromLabel.Text = "От";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toLabel.ForeColor = System.Drawing.Color.Black;
            this.toLabel.Location = new System.Drawing.Point(441, 323);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(29, 18);
            this.toLabel.TabIndex = 19;
            this.toLabel.Text = "До";
            // 
            // availabilityLabel
            // 
            this.availabilityLabel.AutoSize = true;
            this.availabilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.availabilityLabel.ForeColor = System.Drawing.Color.Black;
            this.availabilityLabel.Location = new System.Drawing.Point(214, 361);
            this.availabilityLabel.Name = "availabilityLabel";
            this.availabilityLabel.Size = new System.Drawing.Size(89, 20);
            this.availabilityLabel.TabIndex = 21;
            this.availabilityLabel.Text = "Наличие";
            // 
            // checkBoxInStock
            // 
            this.checkBoxInStock.AutoSize = true;
            this.checkBoxInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxInStock.Location = new System.Drawing.Point(215, 387);
            this.checkBoxInStock.Name = "checkBoxInStock";
            this.checkBoxInStock.Size = new System.Drawing.Size(137, 22);
            this.checkBoxInStock.TabIndex = 22;
            this.checkBoxInStock.Text = "Есть на складе";
            this.checkBoxInStock.UseVisualStyleBackColor = true;
            // 
            // checkBoxNotInStock
            // 
            this.checkBoxNotInStock.AutoSize = true;
            this.checkBoxNotInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxNotInStock.Location = new System.Drawing.Point(402, 387);
            this.checkBoxNotInStock.Name = "checkBoxNotInStock";
            this.checkBoxNotInStock.Size = new System.Drawing.Size(130, 22);
            this.checkBoxNotInStock.TabIndex = 23;
            this.checkBoxNotInStock.Text = "Нет на складе";
            this.checkBoxNotInStock.UseVisualStyleBackColor = true;
            // 
            // buttonShow
            // 
            this.buttonShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShow.ForeColor = System.Drawing.Color.Black;
            this.buttonShow.Location = new System.Drawing.Point(603, 490);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(156, 34);
            this.buttonShow.TabIndex = 24;
            this.buttonShow.Text = "Показать";
            this.buttonShow.UseVisualStyleBackColor = false;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // categoriesCheckedListBox
            // 
            this.categoriesCheckedListBox.FormattingEnabled = true;
            this.categoriesCheckedListBox.Location = new System.Drawing.Point(177, 49);
            this.categoriesCheckedListBox.Name = "categoriesCheckedListBox";
            this.categoriesCheckedListBox.Size = new System.Drawing.Size(474, 225);
            this.categoriesCheckedListBox.TabIndex = 26;
            // 
            // withoutDiscCheckBox
            // 
            this.withoutDiscCheckBox.AutoSize = true;
            this.withoutDiscCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.withoutDiscCheckBox.Location = new System.Drawing.Point(402, 451);
            this.withoutDiscCheckBox.Name = "withoutDiscCheckBox";
            this.withoutDiscCheckBox.Size = new System.Drawing.Size(109, 22);
            this.withoutDiscCheckBox.TabIndex = 29;
            this.withoutDiscCheckBox.Text = "Без скидки";
            this.withoutDiscCheckBox.UseVisualStyleBackColor = true;
            // 
            // withDiscCheckBox
            // 
            this.withDiscCheckBox.AutoSize = true;
            this.withDiscCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.withDiscCheckBox.Location = new System.Drawing.Point(215, 451);
            this.withDiscCheckBox.Name = "withDiscCheckBox";
            this.withDiscCheckBox.Size = new System.Drawing.Size(112, 22);
            this.withDiscCheckBox.TabIndex = 28;
            this.withDiscCheckBox.Text = "Со скидкой";
            this.withDiscCheckBox.UseVisualStyleBackColor = true;
            // 
            // discountLabel
            // 
            this.discountLabel.AutoSize = true;
            this.discountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountLabel.ForeColor = System.Drawing.Color.Black;
            this.discountLabel.Location = new System.Drawing.Point(214, 425);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(77, 20);
            this.discountLabel.TabIndex = 27;
            this.discountLabel.Text = "Скидка";
            // 
            // priceFromNumeric
            // 
            this.priceFromNumeric.Location = new System.Drawing.Point(246, 323);
            this.priceFromNumeric.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.priceFromNumeric.Name = "priceFromNumeric";
            this.priceFromNumeric.Size = new System.Drawing.Size(138, 22);
            this.priceFromNumeric.TabIndex = 30;
            // 
            // priceToNumeric
            // 
            this.priceToNumeric.Location = new System.Drawing.Point(476, 322);
            this.priceToNumeric.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.priceToNumeric.Name = "priceToNumeric";
            this.priceToNumeric.Size = new System.Drawing.Size(138, 22);
            this.priceToNumeric.TabIndex = 31;
            // 
            // FiltrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 545);
            this.Controls.Add(this.priceToNumeric);
            this.Controls.Add(this.priceFromNumeric);
            this.Controls.Add(this.withoutDiscCheckBox);
            this.Controls.Add(this.withDiscCheckBox);
            this.Controls.Add(this.discountLabel);
            this.Controls.Add(this.categoriesCheckedListBox);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.checkBoxNotInStock);
            this.Controls.Add(this.checkBoxInStock);
            this.Controls.Add(this.availabilityLabel);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.filterFormLabel);
            this.Name = "FiltrationForm";
            this.Text = "Фильтрация";
            ((System.ComponentModel.ISupportInitialize)(this.priceFromNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceToNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filterFormLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label availabilityLabel;
        private System.Windows.Forms.CheckBox checkBoxInStock;
        private System.Windows.Forms.CheckBox checkBoxNotInStock;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.CheckedListBox categoriesCheckedListBox;
        private System.Windows.Forms.CheckBox withoutDiscCheckBox;
        private System.Windows.Forms.CheckBox withDiscCheckBox;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.NumericUpDown priceFromNumeric;
        private System.Windows.Forms.NumericUpDown priceToNumeric;
    }
}