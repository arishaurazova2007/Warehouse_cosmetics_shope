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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPriceFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPriceTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxInStock = new System.Windows.Forms.CheckBox();
            this.checkBoxNotInStock = new System.Windows.Forms.CheckBox();
            this.buttonShow = new System.Windows.Forms.Button();
            this.categoriesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(213, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Фильтровать";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(214, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Цена";
            // 
            // textBoxPriceFrom
            // 
            this.textBoxPriceFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPriceFrom.Location = new System.Drawing.Point(248, 323);
            this.textBoxPriceFrom.Name = "textBoxPriceFrom";
            this.textBoxPriceFrom.Size = new System.Drawing.Size(143, 22);
            this.textBoxPriceFrom.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(213, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "От";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(441, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "До";
            // 
            // textBoxPriceTo
            // 
            this.textBoxPriceTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPriceTo.Location = new System.Drawing.Point(476, 323);
            this.textBoxPriceTo.Name = "textBoxPriceTo";
            this.textBoxPriceTo.Size = new System.Drawing.Size(143, 22);
            this.textBoxPriceTo.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(214, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Наличие";
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
            this.buttonShow.Location = new System.Drawing.Point(603, 404);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(156, 34);
            this.buttonShow.TabIndex = 24;
            this.buttonShow.Text = "Показать";
            this.buttonShow.UseVisualStyleBackColor = false;
            this.buttonShow.Click += new System.EventHandler(buttonShow_Click);
            // 
            // categoriesCheckedListBox
            // 
            this.categoriesCheckedListBox.FormattingEnabled = true;
            this.categoriesCheckedListBox.Location = new System.Drawing.Point(177, 49);
            this.categoriesCheckedListBox.Name = "categoriesCheckedListBox";
            this.categoriesCheckedListBox.Size = new System.Drawing.Size(474, 225);
            this.categoriesCheckedListBox.TabIndex = 26;
            // 
            // FiltrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.categoriesCheckedListBox);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.checkBoxNotInStock);
            this.Controls.Add(this.checkBoxInStock);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxPriceTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPriceFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FiltrationForm";
            this.Text = "Фильтрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPriceFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPriceTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxInStock;
        private System.Windows.Forms.CheckBox checkBoxNotInStock;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.CheckedListBox categoriesCheckedListBox;
    }
}