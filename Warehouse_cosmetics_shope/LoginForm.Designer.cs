namespace Warehouse_cosmetics_shope
{
    partial class LoginForm
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
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.ForeColor = System.Drawing.Color.White;
            this.labelLogin.Location = new System.Drawing.Point(236, 56);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(352, 32);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Войти в учётную запись";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxPassword.Location = new System.Drawing.Point(209, 93);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(200, 19);
            this.textBoxPassword.TabIndex = 2;
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.White;
            this.panelLogin.Controls.Add(this.IdTextBox);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.labelId);
            this.panelLogin.Controls.Add(this.textBoxPassword);
            this.panelLogin.Location = new System.Drawing.Point(182, 122);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(441, 138);
            this.panelLogin.TabIndex = 3;
            // 
            // IdTextBox
            // 
            this.IdTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.IdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.IdTextBox.Location = new System.Drawing.Point(209, 34);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(200, 19);
            this.IdTextBox.TabIndex = 5;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(76, 93);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 16);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Пароль";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(57, 34);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(100, 16);
            this.labelId.TabIndex = 3;
            this.labelId.Text = "ID сотрудника";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.Location = new System.Drawing.Point(319, 293);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(193, 37);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Войти";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(319, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.labelLogin);
            this.Name = "LoginForm";
            this.Text = "Авторизация";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox IdTextBox;
    }
}