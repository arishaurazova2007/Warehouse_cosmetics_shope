namespace Warehouse_cosmetics_shope
{
    partial class EditCategoryForm
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
            this.editCategoryLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryNameLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryNameInput = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNewCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editCategoryLabel
            // 
            this.editCategoryLabel.AutoSize = true;
            this.editCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editCategoryLabel.ForeColor = System.Drawing.Color.Black;
            this.editCategoryLabel.Location = new System.Drawing.Point(352, 98);
            this.editCategoryLabel.Name = "editCategoryLabel";
            this.editCategoryLabel.Size = new System.Drawing.Size(400, 32);
            this.editCategoryLabel.TabIndex = 1;
            this.editCategoryLabel.Text = "Редактирование категорий";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.categoryLabel.ForeColor = System.Drawing.Color.Black;
            this.categoryLabel.Location = new System.Drawing.Point(203, 211);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(107, 20);
            this.categoryLabel.TabIndex = 2;
            this.categoryLabel.Text = "Категория";
            // 
            // categoryNameLabel
            // 
            this.categoryNameLabel.AutoSize = true;
            this.categoryNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.categoryNameLabel.ForeColor = System.Drawing.Color.Black;
            this.categoryNameLabel.Location = new System.Drawing.Point(211, 247);
            this.categoryNameLabel.Name = "categoryNameLabel";
            this.categoryNameLabel.Size = new System.Drawing.Size(99, 20);
            this.categoryNameLabel.TabIndex = 3;
            this.categoryNameLabel.Text = "Название";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(327, 207);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(525, 24);
            this.categoryComboBox.TabIndex = 18;
            // 
            // categoryNameInput
            // 
            this.categoryNameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.categoryNameInput.Location = new System.Drawing.Point(327, 252);
            this.categoryNameInput.Name = "categoryNameInput";
            this.categoryNameInput.Size = new System.Drawing.Size(525, 15);
            this.categoryNameInput.TabIndex = 19;
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(462, 305);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(174, 37);
            this.buttonDelete.TabIndex = 20;
            this.buttonDelete.Text = "Удалить категорию";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(479, 416);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 39);
            this.buttonSave.TabIndex = 21;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(479, 461);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(140, 39);
            this.buttonBack.TabIndex = 22;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonNewCategory
            // 
            this.buttonNewCategory.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonNewCategory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonNewCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewCategory.Location = new System.Drawing.Point(462, 348);
            this.buttonNewCategory.Name = "buttonNewCategory";
            this.buttonNewCategory.Size = new System.Drawing.Size(174, 37);
            this.buttonNewCategory.TabIndex = 23;
            this.buttonNewCategory.Text = "Новая категория";
            this.buttonNewCategory.UseVisualStyleBackColor = false;
            this.buttonNewCategory.Click += new System.EventHandler(this.buttonNewCategory_Click);
            // 
            // EditCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1100, 567);
            this.Controls.Add(this.buttonNewCategory);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.categoryNameInput);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.categoryNameLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.editCategoryLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "EditCategoryForm";
            this.Text = "Редактирование категорий";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label editCategoryLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label categoryNameLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.TextBox categoryNameInput;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonNewCategory;
    }
}