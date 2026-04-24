using System;
using System.Windows.Forms;
using Serilog;

namespace Warehouse_cosmetics_shope
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Log.Information("Главная форма открыта");
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Войти" (открывает форму авторизации)
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Log.Information("Пользователь перешёл к форме авторизации");
            var loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) =>
            {
                Log.Information("Форма авторизации закрыта");
                this.Close();
            };
            loginForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Зарегистрироваться" (открывает форму регистрации)
        /// </summary>
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Log.Information("Пользователь перешёл к форме регистрации");
            var registrationForm = new RegistrationForm();
            registrationForm.FormClosed += (s, args) =>
            {
                Log.Information("Форма регистрации закрыта");
                this.Close();
            };
            registrationForm.Show();
            this.Hide();
        }
    }
}