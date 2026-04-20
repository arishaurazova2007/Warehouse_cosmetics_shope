namespace Warehouse_cosmetics_shope
{
    partial class HistoryChangeForm
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
            this.buttonBackToCatalog = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(461, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "История отгрузок";
            // 
            // buttonBackToCatalog
            // 
            this.buttonBackToCatalog.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBackToCatalog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonBackToCatalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToCatalog.Location = new System.Drawing.Point(48, 30);
            this.buttonBackToCatalog.Name = "buttonBackToCatalog";
            this.buttonBackToCatalog.Size = new System.Drawing.Size(122, 36);
            this.buttonBackToCatalog.TabIndex = 2;
            this.buttonBackToCatalog.Text = "В каталог";
            this.buttonBackToCatalog.UseVisualStyleBackColor = false;
            this.buttonBackToCatalog.Click += new System.EventHandler(this.buttonBackToCatalog_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1156, 509);
            this.dataGridView1.TabIndex = 3;
            // 
            // HistoryChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1156, 621);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonBackToCatalog);
            this.Controls.Add(this.label1);
            this.Name = "HistoryChangeForm";
            this.Text = "История изменений";
            this.Load += new System.EventHandler(this.HistoryChangeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBackToCatalog;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}