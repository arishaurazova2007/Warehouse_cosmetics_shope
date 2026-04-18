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
            ((System.ComponentModel.ISupportInitialize)(this.lossDataDridView)).BeginInit();
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
            // LossForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1161, 702);
            this.Controls.Add(this.lossDataDridView);
            this.Controls.Add(this.rubleLabel);
            this.Controls.Add(this.lossLabel);
            this.Name = "LossForm";
            this.Text = "Убыток";
            ((System.ComponentModel.ISupportInitialize)(this.lossDataDridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lossLabel;
        private System.Windows.Forms.Label rubleLabel;
        private System.Windows.Forms.DataGridView lossDataDridView;
    }
}