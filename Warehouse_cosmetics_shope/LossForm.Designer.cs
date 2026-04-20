namespace Warehouse_cosmetics_shope
{
    partial class LossForm
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
            this.lossLabel = new System.Windows.Forms.Label();
            this.rubleLabel = new System.Windows.Forms.Label();
            this.lossDataDridView = new System.Windows.Forms.DataGridView();
            this.lessMoneyNumeric = new System.Windows.Forms.NumericUpDown();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lossDataDridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lessMoneyNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // lossLabel
            // 
            this.lossLabel.AutoSize = true;
            this.lossLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lossLabel.Location = new System.Drawing.Point(891, 52);
            this.lossLabel.Name = "lossLabel";
            this.lossLabel.Size = new System.Drawing.Size(112, 31);
            this.lossLabel.TabIndex = 2;
            this.lossLabel.Text = "Убыток";
            // 
            // rubleLabel
            // 
            this.rubleLabel.AutoSize = true;
            this.rubleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rubleLabel.Location = new System.Drawing.Point(1069, 172);
            this.rubleLabel.Name = "rubleLabel";
            this.rubleLabel.Size = new System.Drawing.Size(43, 46);
            this.rubleLabel.TabIndex = 3;
            this.rubleLabel.Text = "₽";
            // 
            // lossDataDridView
            // 
            this.lossDataDridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lossDataDridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lossDataDridView.Location = new System.Drawing.Point(38, 52);
            this.lossDataDridView.Name = "lossDataDridView";
            this.lossDataDridView.RowHeadersWidth = 51;
            this.lossDataDridView.RowTemplate.Height = 24;
            this.lossDataDridView.Size = new System.Drawing.Size(679, 622);
            this.lossDataDridView.TabIndex = 4;
            // 
            // lessMoneyNumeric
            // 
            this.lessMoneyNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lessMoneyNumeric.Location = new System.Drawing.Point(786, 165);
            this.lessMoneyNumeric.Maximum = new decimal(new int[] {
            -559939584,
            902409669,
            54,
            0});
            this.lessMoneyNumeric.Name = "lessMoneyNumeric";
            this.lessMoneyNumeric.Size = new System.Drawing.Size(277, 53);
            this.lessMoneyNumeric.TabIndex = 5;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(845, 635);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(198, 39);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // LossForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1161, 702);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.lessMoneyNumeric);
            this.Controls.Add(this.lossDataDridView);
            this.Controls.Add(this.rubleLabel);
            this.Controls.Add(this.lossLabel);
            this.Name = "LossForm";
            this.Text = "Убыток";
            ((System.ComponentModel.ISupportInitialize)(this.lossDataDridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lessMoneyNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lossLabel;
        private System.Windows.Forms.Label rubleLabel;
        private System.Windows.Forms.DataGridView lossDataDridView;
        private System.Windows.Forms.NumericUpDown lessMoneyNumeric;
        private System.Windows.Forms.Button buttonBack;
    }
}