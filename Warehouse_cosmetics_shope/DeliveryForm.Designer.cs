using System.Windows.Forms;

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
            this.deliveryFormLabel = new System.Windows.Forms.Label();
            this.deliverySearchBox = new System.Windows.Forms.TextBox();
            this.deliverySearchButton = new System.Windows.Forms.Button();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.deliveryPurPriceLabel = new System.Windows.Forms.Label();
            this.deliveryPurPriceNumeric = new System.Windows.Forms.NumericUpDown();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.deliveryQuantityNumeric = new System.Windows.Forms.NumericUpDown();
            this.ExpDateLabel = new System.Windows.Forms.Label();
            this.manufdatePicker = new System.Windows.Forms.DateTimePicker();
            this.expDatePicker = new System.Windows.Forms.DateTimePicker();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.fileImportButton = new System.Windows.Forms.Button();
            this.addItemButton = new System.Windows.Forms.Button();
            this.addFuulDeliveryButton = new System.Windows.Forms.Button();
            this.cancelDeliveryButton = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.catalogInDeliveryGridView = new System.Windows.Forms.DataGridView();
            this.catalogInDelivryLabel = new System.Windows.Forms.Label();
            this.itemsToDeliveryLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryDataDridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryPurPriceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryQuantityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogInDeliveryGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // deliveryDataDridView
            // 
            this.deliveryDataDridView.AllowUserToAddRows = false;
            this.deliveryDataDridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.deliveryDataDridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deliveryDataDridView.Location = new System.Drawing.Point(33, 424);
            this.deliveryDataDridView.Name = "deliveryDataDridView";
            this.deliveryDataDridView.RowHeadersWidth = 51;
            this.deliveryDataDridView.RowTemplate.Height = 24;
            this.deliveryDataDridView.Size = new System.Drawing.Size(721, 356);
            this.deliveryDataDridView.TabIndex = 0;
            // 
            // deliveryFormLabel
            // 
            this.deliveryFormLabel.AutoSize = true;
            this.deliveryFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.deliveryFormLabel.Location = new System.Drawing.Point(968, 54);
            this.deliveryFormLabel.Name = "deliveryFormLabel";
            this.deliveryFormLabel.Size = new System.Drawing.Size(141, 31);
            this.deliveryFormLabel.TabIndex = 1;
            this.deliveryFormLabel.Text = "Поставка";
            // 
            // deliverySearchBox
            // 
            this.deliverySearchBox.ForeColor = System.Drawing.Color.Gray;
            this.deliverySearchBox.Location = new System.Drawing.Point(958, 131);
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
            this.deliverySearchButton.Location = new System.Drawing.Point(1190, 128);
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
            this.productNameLabel.Location = new System.Drawing.Point(865, 131);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(67, 22);
            this.productNameLabel.TabIndex = 6;
            this.productNameLabel.Text = "Товар";
            // 
            // deliveryPurPriceLabel
            // 
            this.deliveryPurPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.deliveryPurPriceLabel.ForeColor = System.Drawing.Color.Black;
            this.deliveryPurPriceLabel.Location = new System.Drawing.Point(791, 183);
            this.deliveryPurPriceLabel.Name = "deliveryPurPriceLabel";
            this.deliveryPurPriceLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deliveryPurPriceLabel.Size = new System.Drawing.Size(145, 48);
            this.deliveryPurPriceLabel.TabIndex = 7;
            this.deliveryPurPriceLabel.Text = "Закупочная цена";
            // 
            // deliveryPurPriceNumeric
            // 
            this.deliveryPurPriceNumeric.Location = new System.Drawing.Point(958, 195);
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
            // quantityLabel
            // 
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.quantityLabel.ForeColor = System.Drawing.Color.Black;
            this.quantityLabel.Location = new System.Drawing.Point(843, 261);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.quantityLabel.Size = new System.Drawing.Size(93, 27);
            this.quantityLabel.TabIndex = 33;
            this.quantityLabel.Text = "Кол-во";
            // 
            // deliveryQuantityNumeric
            // 
            this.deliveryQuantityNumeric.Location = new System.Drawing.Point(958, 262);
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
            this.ExpDateLabel.Location = new System.Drawing.Point(807, 317);
            this.ExpDateLabel.Name = "ExpDateLabel";
            this.ExpDateLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ExpDateLabel.Size = new System.Drawing.Size(129, 48);
            this.ExpDateLabel.TabIndex = 35;
            this.ExpDateLabel.Text = "Срок годности";
            // 
            // manufdatePicker
            // 
            this.manufdatePicker.Location = new System.Drawing.Point(1018, 321);
            this.manufdatePicker.Name = "manufdatePicker";
            this.manufdatePicker.Size = new System.Drawing.Size(166, 22);
            this.manufdatePicker.TabIndex = 36;
            this.manufdatePicker.Value = new System.DateTime(2024, 4, 5, 17, 7, 0, 0);
            // 
            // expDatePicker
            // 
            this.expDatePicker.Location = new System.Drawing.Point(1018, 369);
            this.expDatePicker.Name = "expDatePicker";
            this.expDatePicker.Size = new System.Drawing.Size(166, 22);
            this.expDatePicker.TabIndex = 37;
            this.expDatePicker.Value = new System.DateTime(2024, 4, 5, 17, 7, 0, 0);
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromLabel.Location = new System.Drawing.Point(974, 323);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(18, 20);
            this.fromLabel.TabIndex = 38;
            this.fromLabel.Text = "c";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toLabel.Location = new System.Drawing.Point(974, 371);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(29, 20);
            this.toLabel.TabIndex = 39;
            this.toLabel.Text = "по";
            // 
            // fileImportButton
            // 
            this.fileImportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.fileImportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fileImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileImportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileImportButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileImportButton.Location = new System.Drawing.Point(940, 448);
            this.fileImportButton.Name = "fileImportButton";
            this.fileImportButton.Size = new System.Drawing.Size(202, 49);
            this.fileImportButton.TabIndex = 40;
            this.fileImportButton.Text = "Импорт файла";
            this.fileImportButton.UseVisualStyleBackColor = false;
            this.fileImportButton.Click += new System.EventHandler(this.fileImportButton_Click);
            // 
            // addItemButton
            // 
            this.addItemButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.addItemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addItemButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addItemButton.Location = new System.Drawing.Point(940, 520);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(202, 47);
            this.addItemButton.TabIndex = 42;
            this.addItemButton.Text = "Добавить в список";
            this.addItemButton.UseVisualStyleBackColor = false;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // addFuulDeliveryButton
            // 
            this.addFuulDeliveryButton.Location = new System.Drawing.Point(845, 608);
            this.addFuulDeliveryButton.Name = "addFuulDeliveryButton";
            this.addFuulDeliveryButton.Size = new System.Drawing.Size(183, 50);
            this.addFuulDeliveryButton.TabIndex = 43;
            this.addFuulDeliveryButton.Text = "Подтвердить";
            this.addFuulDeliveryButton.UseVisualStyleBackColor = true;
            this.addFuulDeliveryButton.Click += new System.EventHandler(this.addFuulDeliveryButton_Click);
            // 
            // cancelDeliveryButton
            // 
            this.cancelDeliveryButton.Location = new System.Drawing.Point(1049, 608);
            this.cancelDeliveryButton.Name = "cancelDeliveryButton";
            this.cancelDeliveryButton.Size = new System.Drawing.Size(183, 50);
            this.cancelDeliveryButton.TabIndex = 44;
            this.cancelDeliveryButton.Text = "Отменить";
            this.cancelDeliveryButton.UseVisualStyleBackColor = true;
            this.cancelDeliveryButton.Click += new System.EventHandler(this.cancelDeliveryButton_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(969, 680);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(140, 39);
            this.buttonBack.TabIndex = 45;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // catalogInDeliveryGridView
            // 
            this.catalogInDeliveryGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.catalogInDeliveryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catalogInDeliveryGridView.Location = new System.Drawing.Point(33, 72);
            this.catalogInDeliveryGridView.Name = "catalogInDeliveryGridView";
            this.catalogInDeliveryGridView.RowHeadersWidth = 51;
            this.catalogInDeliveryGridView.RowTemplate.Height = 24;
            this.catalogInDeliveryGridView.Size = new System.Drawing.Size(721, 293);
            this.catalogInDeliveryGridView.TabIndex = 46;
            catalogInDeliveryGridView.AutoGenerateColumns = true;
            catalogInDeliveryGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            catalogInDeliveryGridView.MultiSelect = false;
            this.catalogInDeliveryGridView.CellClick += CatalogInDeliveryGridView_CellClick;
            // catalogInDelivryLabel
            // 
            this.catalogInDelivryLabel.AutoSize = true;
            this.catalogInDelivryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.catalogInDelivryLabel.Location = new System.Drawing.Point(27, 38);
            this.catalogInDelivryLabel.Name = "catalogInDelivryLabel";
            this.catalogInDelivryLabel.Size = new System.Drawing.Size(112, 29);
            this.catalogInDelivryLabel.TabIndex = 47;
            this.catalogInDelivryLabel.Text = "Каталог";
            // 
            // itemsToDeliveryLabel
            // 
            this.itemsToDeliveryLabel.AutoSize = true;
            this.itemsToDeliveryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemsToDeliveryLabel.Location = new System.Drawing.Point(28, 392);
            this.itemsToDeliveryLabel.Name = "itemsToDeliveryLabel";
            this.itemsToDeliveryLabel.Size = new System.Drawing.Size(127, 29);
            this.itemsToDeliveryLabel.TabIndex = 48;
            this.itemsToDeliveryLabel.Text = "Поставка";
            // 
            // DeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1329, 820);
            this.Controls.Add(this.itemsToDeliveryLabel);
            this.Controls.Add(this.catalogInDelivryLabel);
            this.Controls.Add(this.catalogInDeliveryGridView);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.cancelDeliveryButton);
            this.Controls.Add(this.addFuulDeliveryButton);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.fileImportButton);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.expDatePicker);
            this.Controls.Add(this.manufdatePicker);
            this.Controls.Add(this.ExpDateLabel);
            this.Controls.Add(this.deliveryQuantityNumeric);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.deliveryPurPriceNumeric);
            this.Controls.Add(this.deliveryPurPriceLabel);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.deliverySearchBox);
            this.Controls.Add(this.deliverySearchButton);
            this.Controls.Add(this.deliveryFormLabel);
            this.Controls.Add(this.deliveryDataDridView);
            this.Name = "DeliveryForm";
            this.Text = "Поставка";
            ((System.ComponentModel.ISupportInitialize)(this.deliveryDataDridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryPurPriceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryQuantityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogInDeliveryGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView deliveryDataDridView;
        private System.Windows.Forms.Label deliveryFormLabel;
        private System.Windows.Forms.TextBox deliverySearchBox;
        private System.Windows.Forms.Button deliverySearchButton;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label deliveryPurPriceLabel;
        private System.Windows.Forms.NumericUpDown deliveryPurPriceNumeric;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.NumericUpDown deliveryQuantityNumeric;
        private System.Windows.Forms.Label ExpDateLabel;
        private System.Windows.Forms.DateTimePicker manufdatePicker;
        private System.Windows.Forms.DateTimePicker expDatePicker;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Button fileImportButton;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Button addFuulDeliveryButton;
        private System.Windows.Forms.Button cancelDeliveryButton;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridView catalogInDeliveryGridView;
        private System.Windows.Forms.Label catalogInDelivryLabel;
        private System.Windows.Forms.Label itemsToDeliveryLabel;
    }
}