namespace Warehouse_cosmetics_shope
{
    partial class ShipmentHistoryForm
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
            this.shipmentHistoryFormLabel = new System.Windows.Forms.Label();
            this.buttonBackToCatalog = new System.Windows.Forms.Button();
            this.ShipHistoryDataGridView = new System.Windows.Forms.DataGridView();
            this.periodLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileExportButton = new System.Windows.Forms.Button();
            this.lowDatePicker = new System.Windows.Forms.DateTimePicker();
            this.upDatePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.ShipHistoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // shipmentHistoryFormLabel
            // 
            this.shipmentHistoryFormLabel.AutoSize = true;
            this.shipmentHistoryFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shipmentHistoryFormLabel.Location = new System.Drawing.Point(525, 37);
            this.shipmentHistoryFormLabel.Name = "shipmentHistoryFormLabel";
            this.shipmentHistoryFormLabel.Size = new System.Drawing.Size(236, 29);
            this.shipmentHistoryFormLabel.TabIndex = 1;
            this.shipmentHistoryFormLabel.Text = "История отгрузок";
            // 
            // buttonBackToCatalog
            // 
            this.buttonBackToCatalog.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBackToCatalog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonBackToCatalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToCatalog.Location = new System.Drawing.Point(1066, 30);
            this.buttonBackToCatalog.Name = "buttonBackToCatalog";
            this.buttonBackToCatalog.Size = new System.Drawing.Size(122, 36);
            this.buttonBackToCatalog.TabIndex = 2;
            this.buttonBackToCatalog.Text = "В каталог";
            this.buttonBackToCatalog.UseVisualStyleBackColor = false;
            this.buttonBackToCatalog.Click += new System.EventHandler(this.ButtonBackToCatalog_Click);
            // 
            // ShipHistoryDataGridView
            // 
            this.ShipHistoryDataGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ShipHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShipHistoryDataGridView.Location = new System.Drawing.Point(-2, 166);
            this.ShipHistoryDataGridView.Name = "ShipHistoryDataGridView";
            this.ShipHistoryDataGridView.RowHeadersWidth = 51;
            this.ShipHistoryDataGridView.RowTemplate.Height = 24;
            this.ShipHistoryDataGridView.Size = new System.Drawing.Size(1251, 569);
            this.ShipHistoryDataGridView.TabIndex = 3;
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.periodLabel.Location = new System.Drawing.Point(24, 116);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(79, 20);
            this.periodLabel.TabIndex = 4;
            this.periodLabel.Text = "Период:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(127, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "c";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(370, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "по";
            // 
            // fileExportButton
            // 
            this.fileExportButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.fileExportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.fileExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileExportButton.Location = new System.Drawing.Point(1052, 88);
            this.fileExportButton.Name = "fileExportButton";
            this.fileExportButton.Size = new System.Drawing.Size(147, 48);
            this.fileExportButton.TabIndex = 9;
            this.fileExportButton.Text = "Экспорт файла";
            this.fileExportButton.UseVisualStyleBackColor = false;
            this.fileExportButton.Click += new System.EventHandler(this.FileExportButton_Click);
            // 
            // lowDatePicker
            // 
            this.lowDatePicker.Location = new System.Drawing.Point(151, 116);
            this.lowDatePicker.Name = "lowDatePicker";
            this.lowDatePicker.Size = new System.Drawing.Size(200, 22);
            this.lowDatePicker.TabIndex = 10;
            // 
            // upDatePicker
            // 
            this.upDatePicker.Location = new System.Drawing.Point(405, 116);
            this.upDatePicker.Name = "upDatePicker";
            this.upDatePicker.Size = new System.Drawing.Size(200, 22);
            this.upDatePicker.TabIndex = 11;
            // 
            // ShipmentHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1247, 734);
            this.Controls.Add(this.upDatePicker);
            this.Controls.Add(this.lowDatePicker);
            this.Controls.Add(this.fileExportButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.periodLabel);
            this.Controls.Add(this.ShipHistoryDataGridView);
            this.Controls.Add(this.buttonBackToCatalog);
            this.Controls.Add(this.shipmentHistoryFormLabel);
            this.Name = "ShipmentHistoryForm";
            this.Text = "История изменений";
            ((System.ComponentModel.ISupportInitialize)(this.ShipHistoryDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label shipmentHistoryFormLabel;
        private System.Windows.Forms.Button buttonBackToCatalog;
        private System.Windows.Forms.DataGridView ShipHistoryDataGridView;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fileExportButton;
        private System.Windows.Forms.DateTimePicker lowDatePicker;
        private System.Windows.Forms.DateTimePicker upDatePicker;
    }
}