namespace Warehouse_cosmetics_shope
{
    partial class RegistrationForm
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
            this.surnameTitle = new System.Windows.Forms.Label();
            this.nameTitle = new System.Windows.Forms.Label();
            this.patronymicTitle = new System.Windows.Forms.Label();
            this.passwordTitle = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.patronimicBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.surnameBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.registrationTitle = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.loginTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // surnameTitle
            // 
            this.surnameTitle.AutoSize = true;
            this.surnameTitle.Location = new System.Drawing.Point(41, 67);
            this.surnameTitle.Name = "surnameTitle";
            this.surnameTitle.Size = new System.Drawing.Size(66, 16);
            this.surnameTitle.TabIndex = 1;
            this.surnameTitle.Text = "Фамилия";
            // 
            // nameTitle
            // 
            this.nameTitle.AutoSize = true;
            this.nameTitle.Location = new System.Drawing.Point(60, 99);
            this.nameTitle.Name = "nameTitle";
            this.nameTitle.Size = new System.Drawing.Size(33, 16);
            this.nameTitle.TabIndex = 2;
            this.nameTitle.Text = "Имя";
            // 
            // patronymicTitle
            // 
            this.patronymicTitle.AutoSize = true;
            this.patronymicTitle.Location = new System.Drawing.Point(41, 137);
            this.patronymicTitle.Name = "patronymicTitle";
            this.patronymicTitle.Size = new System.Drawing.Size(70, 16);
            this.patronymicTitle.TabIndex = 3;
            this.patronymicTitle.Text = "Отчество";
            // 
            // passwordTitle
            // 
            this.passwordTitle.AutoSize = true;
            this.passwordTitle.Location = new System.Drawing.Point(51, 173);
            this.passwordTitle.Name = "passwordTitle";
            this.passwordTitle.Size = new System.Drawing.Size(56, 16);
            this.passwordTitle.TabIndex = 5;
            this.passwordTitle.Text = "Пароль";
            // 
            // registerButton
            // 
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registerButton.Location = new System.Drawing.Point(4, 3);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(199, 34);
            this.registerButton.TabIndex = 11;
            this.registerButton.Text = "Зарегистрироваться";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(305, 385);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(199, 34);
            this.backButton.TabIndex = 12;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.loginBox);
            this.panel1.Controls.Add(this.loginTitle);
            this.panel1.Controls.Add(this.passwordBox);
            this.panel1.Controls.Add(this.patronimicBox);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.surnameBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.surnameTitle);
            this.panel1.Controls.Add(this.passwordTitle);
            this.panel1.Controls.Add(this.nameTitle);
            this.panel1.Controls.Add(this.patronymicTitle);
            this.panel1.Location = new System.Drawing.Point(188, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 277);
            this.panel1.TabIndex = 13;
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.passwordBox.Location = new System.Drawing.Point(151, 170);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(195, 19);
            this.passwordBox.TabIndex = 17;
            // 
            // patronimicBox
            // 
            this.patronimicBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.patronimicBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.patronimicBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.patronimicBox.Location = new System.Drawing.Point(151, 134);
            this.patronimicBox.Name = "patronimicBox";
            this.patronimicBox.Size = new System.Drawing.Size(195, 19);
            this.patronimicBox.TabIndex = 15;
            // 
            // nameBox
            // 
            this.nameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nameBox.Location = new System.Drawing.Point(151, 99);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(195, 19);
            this.nameBox.TabIndex = 14;
            // 
            // surnameBox
            // 
            this.surnameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.surnameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.surnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.surnameBox.Location = new System.Drawing.Point(151, 64);
            this.surnameBox.Name = "surnameBox";
            this.surnameBox.Size = new System.Drawing.Size(195, 19);
            this.surnameBox.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.panel2.Controls.Add(this.registerButton);
            this.panel2.Location = new System.Drawing.Point(108, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 40);
            this.panel2.TabIndex = 12;
            // 
            // registrationTitle
            // 
            this.registrationTitle.AutoSize = true;
            this.registrationTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.registrationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registrationTitle.ForeColor = System.Drawing.Color.White;
            this.registrationTitle.Location = new System.Drawing.Point(311, 32);
            this.registrationTitle.Name = "registrationTitle";
            this.registrationTitle.Size = new System.Drawing.Size(193, 32);
            this.registrationTitle.TabIndex = 14;
            this.registrationTitle.Text = "Регистрация";
            // 
            // loginBox
            // 
            this.loginBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.loginBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loginBox.Location = new System.Drawing.Point(151, 30);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(195, 19);
            this.loginBox.TabIndex = 19;
            // 
            // loginTitle
            // 
            this.loginTitle.AutoSize = true;
            this.loginTitle.Location = new System.Drawing.Point(51, 33);
            this.loginTitle.Name = "loginTitle";
            this.loginTitle.Size = new System.Drawing.Size(46, 16);
            this.loginTitle.TabIndex = 18;
            this.loginTitle.Text = "Логин";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.registrationTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backButton);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label surnameTitle;
        private System.Windows.Forms.Label nameTitle;
        private System.Windows.Forms.Label patronymicTitle;
        private System.Windows.Forms.Label passwordTitle;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label registrationTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox patronimicBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox surnameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.Label loginTitle;
    }
}