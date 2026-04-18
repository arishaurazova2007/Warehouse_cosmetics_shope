namespace Warehouse_cosmetics_shope
{
    partial class DeliveryForm
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
            this.deliveryDataDridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.deliverySearchBox = new System.Windows.Forms.TextBox();
            this.deliverySearchButton = new System.Windows.Forms.Button();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.deliveryPurPriceLabel = new System.Windows.Forms.Label();
            this.deliveryPurPriceNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.deliveryQuantityNumeric = new System.Windows.Forms.NumericUpDown();
            this.ExpDateLabel = new System.Windows.Forms.Label();
            this.manufdatePicker = new System.Windows.Forms.DateTimePicker();
            this.expDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fileImportButton = new System.Windows.Forms.Button();
            this.deliveyLoadFileFilter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryDataDridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryPurPriceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryQuantityNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // deliveryDataDridView
            // 
            this.deliveryDataDridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.deliveryDataDridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deliveryDataDridView.Location = new System.Drawing.Point(33, 30);
            this.deliveryDataDridView.Name = "deliveryDataDridView";
            this.deliveryDataDridView.RowHeadersWidth = 51;
            this.deliveryDataDridView.RowTemplate.Height = 24;
            this.deliveryDataDridView.Size = new System.Drawing.Size(679, 688);
            this.deliveryDataDridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(910, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поставка";
            // 
            // deliverySearchBox
            // 
            this.deliverySearchBox.ForeColor = System.Drawing.Color.Gray;
            this.deliverySearchBox.Location = new System.Drawing.Point(900, 130);
            this.deliverySearchBox.MaximumSize = new System.Drawing.Size(300, 50);
            this.deliverySearchBox.Name = "deliverySearchBox";
            this.deliverySearchBox.Size = new System.Drawing.Size(226, 22);
            this.deliverySearchBox.TabIndex = 5;
            this.deliverySearchBox.Text = "Поиск";
            // 
            // deliverySearchButton
            // 
            this.deliverySearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.deliverySearchButton.FlatAppearance.BorderSize = 0;
            this.deliverySearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deliverySearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deliverySearchButton.ForeColor = System.Drawing.Color.White;
            this.deliverySearchButton.Location = new System.Drawing.Point(1132, 127);
            this.deliverySearchButton.Name = "deliverySearchButton";
            this.deliverySearchButton.Size = new System.Drawing.Size(74, 29);
            this.deliverySearchButton.TabIndex = 4;
            this.deliverySearchButton.Text = "Искать";
            this.deliverySearchButton.UseVisualStyleBackColor = false;
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.productNameLabel.ForeColor = System.Drawing.Color.Black;
            this.productNameLabel.Location = new System.Drawing.Point(807, 130);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(67, 22);
            this.productNameLabel.TabIndex = 6;
            this.productNameLabel.Text = "Товар";
            // 
            // deliveryPurPriceLabel
            // 
            this.deliveryPurPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.deliveryPurPriceLabel.ForeColor = System.Drawing.Color.Black;
            this.deliveryPurPriceLabel.Location = new System.Drawing.Point(749, 182);
            this.deliveryPurPriceLabel.Name = "deliveryPurPriceLabel";
            this.deliveryPurPriceLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deliveryPurPriceLabel.Size = new System.Drawing.Size(129, 48);
            this.deliveryPurPriceLabel.TabIndex = 7;
            this.deliveryPurPriceLabel.Text = "Закупочная цена";
            // 
            // deliveryPurPriceNumeric
            // 
            this.deliveryPurPriceNumeric.Location = new System.Drawing.Point(900, 194);
            this.deliveryPurPriceNumeric.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.deliveryPurPriceNumeric.Name = "deliveryPurPriceNumeric";
            this.deliveryPurPriceNumeric.Size = new System.Drawing.Size(226, 22);
            this.deliveryPurPriceNumeric.TabIndex = 32;
            this.deliveryPurPriceNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(785, 260);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(93, 27);
            this.label2.TabIndex = 33;
            this.label2.Text = "Кол-во";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // deliveryQuantityNumeric
            // 
            this.deliveryQuantityNumeric.Location = new System.Drawing.Point(900, 261);
            this.deliveryQuantityNumeric.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.deliveryQuantityNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deliveryQuantityNumeric.Name = "deliveryQuantityNumeric";
            this.deliveryQuantityNumeric.Size = new System.Drawing.Size(226, 22);
            this.deliveryQuantityNumeric.TabIndex = 34;
            this.deliveryQuantityNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ExpDateLabel
            // 
            this.ExpDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.ExpDateLabel.ForeColor = System.Drawing.Color.Black;
            this.ExpDateLabel.Location = new System.Drawing.Point(749, 316);
            this.ExpDateLabel.Name = "ExpDateLabel";
            this.ExpDateLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ExpDateLabel.Size = new System.Drawing.Size(129, 48);
            this.ExpDateLabel.TabIndex = 35;
            this.ExpDateLabel.Text = "Срок годности";
            // 
            // manufdatePicker
            // 
            this.manufdatePicker.Location = new System.Drawing.Point(960, 320);
            this.manufdatePicker.Name = "manufdatePicker";
            this.manufdatePicker.Size = new System.Drawing.Size(166, 22);
            this.manufdatePicker.TabIndex = 36;
            this.manufdatePicker.Value = new System.DateTime(2024, 4, 5, 17, 7, 0, 0);
            // 
            // expDatePicker
            // 
            this.expDatePicker.Location = new System.Drawing.Point(960, 368);
            this.expDatePicker.Name = "expDatePicker";
            this.expDatePicker.Size = new System.Drawing.Size(166, 22);
            this.expDatePicker.TabIndex = 37;
            this.expDatePicker.Value = new System.DateTime(2024, 4, 5, 17, 7, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(916, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "c";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(916, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "по";
            // 
            // fileImportButton
            // 
            this.fileImportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.fileImportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fileImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileImportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileImportButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileImportButton.Location = new System.Drawing.Point(787, 447);
            this.fileImportButton.Name = "fileImportButton";
            this.fileImportButton.Size = new System.Drawing.Size(183, 49);
            this.fileImportButton.TabIndex = 40;
            this.fileImportButton.Text = "Импорт файла";
            this.fileImportButton.UseVisualStyleBackColor = false;
            this.fileImportButton.Click += new System.EventHandler(this.fileImportButton_Click);
            // 
            // deliveyLoadFileFilter
            // 
            this.deliveyLoadFileFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.deliveyLoadFileFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deliveyLoadFileFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deliveyLoadFileFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deliveyLoadFileFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deliveyLoadFileFilter.Location = new System.Drawing.Point(991, 447);
            this.deliveyLoadFileFilter.Name = "deliveyLoadFileFilter";
            this.deliveyLoadFileFilter.Size = new System.Drawing.Size(183, 49);
            this.deliveyLoadFileFilter.TabIndex = 41;
            this.deliveyLoadFileFilter.Text = "Загрузить файл";
            this.deliveyLoadFileFilter.UseVisualStyleBackColor = false;
            this.deliveyLoadFileFilter.Click += new System.EventHandler(this.deliveyLoadFileFilter_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(882, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 47);
            this.button1.TabIndex = 42;
            this.button1.Text = "Добавить в список";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(787, 607);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 50);
            this.button2.TabIndex = 43;
            this.button2.Text = "Подтвердить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(991, 607);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 50);
            this.button3.TabIndex = 44;
            this.button3.Text = "Отменить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(911, 679);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(140, 39);
            this.buttonBack.TabIndex = 45;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            // 
            // DeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1264, 750);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deliveyLoadFileFilter);
            this.Controls.Add(this.fileImportButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expDatePicker);
            this.Controls.Add(this.manufdatePicker);
            this.Controls.Add(this.ExpDateLabel);
            this.Controls.Add(this.deliveryQuantityNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deliveryPurPriceNumeric);
            this.Controls.Add(this.deliveryPurPriceLabel);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.deliverySearchBox);
            this.Controls.Add(this.deliverySearchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deliveryDataDridView);
            this.Name = "DeliveryForm";
            this.Text = "Поставка";
            this.Load += new System.EventHandler(this.DeliveryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deliveryDataDridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryPurPriceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryQuantityNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView deliveryDataDridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox deliverySearchBox;
        private System.Windows.Forms.Button deliverySearchButton;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label deliveryPurPriceLabel;
        private System.Windows.Forms.NumericUpDown deliveryPurPriceNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown deliveryQuantityNumeric;
        private System.Windows.Forms.Label ExpDateLabel;
        private System.Windows.Forms.DateTimePicker manufdatePicker;
        private System.Windows.Forms.DateTimePicker expDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button fileImportButton;
        private System.Windows.Forms.Button deliveyLoadFileFilter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonBack;
    }
}