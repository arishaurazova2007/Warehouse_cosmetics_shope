using System;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.Properties;
namespace Warehouse_cosmetics_shope
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (ValidateRegistrationData())
            {
                RegisterUser(); // Метод для БД
                MessageBox.Show(Resources.RegistrationSuccess, Resources.Registration,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
        private void RegisterUser()
        {
            // Регистрация пользователя
        }
        private bool ValidateRegistrationData()
        {
            // Проверка Фамилии
            if (string.IsNullOrWhiteSpace(surnameBox.Text))
            {
                MessageBox.Show(Resources.EnterSurname, Resources.Error,
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                surnameBox.Focus();
                return false;
            }
            // Проверка Имени
            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show(Resources.EnterName, Resources.Error,
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameBox.Focus();
                return false;
            }
            // Проверка Отчества
            if (string.IsNullOrWhiteSpace(patronimicBox.Text))
            {
                MessageBox.Show(Resources.EnterPatronymic, Resources.Error,
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                patronimicBox.Focus();
                return false;
            }
            // Проверка Пароля
            if (string.IsNullOrWhiteSpace(passwordBox.Text))
            {
                MessageBox.Show(Resources.EnterPassword, Resources.Error,
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordBox.Focus();
                return false;
            }
            // Проверка длины пароля
            if (passwordBox.Text.Length < 6)
            {
                MessageBox.Show(Resources.PasswordTooShort, Resources.Error,
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordBox.Focus();
                return false;
            }
            return true;
        }
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            // Настроим поля при загрузке
        }
    }
}
