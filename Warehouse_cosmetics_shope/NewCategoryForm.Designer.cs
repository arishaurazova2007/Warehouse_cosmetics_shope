namespace Warehouse_cosmetics_shope
{
    partial class NewCategoryForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxParentCategory = new System.Windows.Forms.ComboBox();
            this.textBoxCategoryName = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(298, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Новая категория";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(106, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Родительская категория";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(242, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Название";
            // 
            // comboBoxParentCategory
            // 
            this.comboBoxParentCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxParentCategory.FormattingEnabled = true;
            this.comboBoxParentCategory.Location = new System.Drawing.Point(356, 148);
            this.comboBoxParentCategory.Name = "comboBoxParentCategory";
            this.comboBoxParentCategory.Size = new System.Drawing.Size(281, 24);
            this.comboBoxParentCategory.TabIndex = 18;
            // 
            // textBoxCategoryName
            // 
            this.textBoxCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCategoryName.Location = new System.Drawing.Point(356, 194);
            this.textBoxCategoryName.Name = "textBoxCategoryName";
            this.textBoxCategoryName.Size = new System.Drawing.Size(281, 15);
            this.textBoxCategoryName.TabIndex = 19;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Location = new System.Drawing.Point(366, 263);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(140, 39);
            this.buttonAdd.TabIndex = 20;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(366, 327);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(140, 39);
            this.buttonBack.TabIndex = 21;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // NewCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxCategoryName);
            this.Controls.Add(this.comboBoxParentCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewCategoryForm";
            this.Text = "Новая категория";
            this.Click += new System.EventHandler(this.buttonAdd_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxParentCategory;
        private System.Windows.Forms.TextBox textBoxCategoryName;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonBack;
    }
}