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
            this.newCategoryFormLabel = new System.Windows.Forms.Label();
            this.parentCategoryLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.parentCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryNameInput = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newCategoryFormLabel
            // 
            this.newCategoryFormLabel.AutoSize = true;
            this.newCategoryFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newCategoryFormLabel.ForeColor = System.Drawing.Color.Black;
            this.newCategoryFormLabel.Location = new System.Drawing.Point(422, 113);
            this.newCategoryFormLabel.Name = "newCategoryFormLabel";
            this.newCategoryFormLabel.Size = new System.Drawing.Size(251, 32);
            this.newCategoryFormLabel.TabIndex = 1;
            this.newCategoryFormLabel.Text = "Новая категория";
            // 
            // parentCategoryLabel
            // 
            this.parentCategoryLabel.AutoSize = true;
            this.parentCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parentCategoryLabel.ForeColor = System.Drawing.Color.Black;
            this.parentCategoryLabel.Location = new System.Drawing.Point(150, 209);
            this.parentCategoryLabel.Name = "parentCategoryLabel";
            this.parentCategoryLabel.Size = new System.Drawing.Size(244, 20);
            this.parentCategoryLabel.TabIndex = 2;
            this.parentCategoryLabel.Text = "Родительская категория";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.ForeColor = System.Drawing.Color.Black;
            this.nameLabel.Location = new System.Drawing.Point(286, 250);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(99, 20);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Название";
            // 
            // parentCategoryComboBox
            // 
            this.parentCategoryComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parentCategoryComboBox.FormattingEnabled = true;
            this.parentCategoryComboBox.Location = new System.Drawing.Point(400, 209);
            this.parentCategoryComboBox.Name = "parentCategoryComboBox";
            this.parentCategoryComboBox.Size = new System.Drawing.Size(523, 24);
            this.parentCategoryComboBox.TabIndex = 18;
            // 
            // categoryNameInput
            // 
            this.categoryNameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.categoryNameInput.Location = new System.Drawing.Point(400, 255);
            this.categoryNameInput.Name = "categoryNameInput";
            this.categoryNameInput.Size = new System.Drawing.Size(523, 15);
            this.categoryNameInput.TabIndex = 19;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Location = new System.Drawing.Point(476, 339);
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
            this.buttonBack.Location = new System.Drawing.Point(476, 403);
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
            this.ClientSize = new System.Drawing.Size(1100, 567);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.categoryNameInput);
            this.Controls.Add(this.parentCategoryComboBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.parentCategoryLabel);
            this.Controls.Add(this.newCategoryFormLabel);
            this.Name = "NewCategoryForm";
            this.Text = "Новая категория";
            this.Click += new System.EventHandler(this.buttonAdd_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newCategoryFormLabel;
        private System.Windows.Forms.Label parentCategoryLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox parentCategoryComboBox;
        private System.Windows.Forms.TextBox categoryNameInput;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonBack;
    }
}