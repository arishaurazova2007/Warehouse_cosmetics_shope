using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();

            mainForm.Show();
            this.Hide();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLoginData())
            {
                var userId = AuthenticateUser(); // Метод для БД

                if (userId != Guid.Empty)
                {
                    // Успешная авторизация
                    var userRole = GetUserRole(userId); // Метод для БД
                    if (userRole == "Admin")
                    {
                        var catalogForm = new CatalogFormAdmin(userId);
                        catalogForm.Show();
                        this.Hide();
                    }
                    else if (userRole == "Kladovshik")
                    {
                        var catalogForm = new CatalogFormKlad();
                        catalogForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный ID или пароль", "Ошибка авторизации",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                }
            }
        }
        private Guid AuthenticateUser()
        {
            //добавлю код для проверки ID/пароля в БД
            // Верну ID пользователя при успехе, или Guid.Empty при ошибке
            return Guid.Empty;
        }
        private string GetUserRole(Guid userId)
        {
            // Получение роли пользователя
            return "Kladovshik";
        }
        // Проверка данных перед авторизацией
        private bool ValidateLoginData()
        {
            // Проверка ID
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                MessageBox.Show("Введите ID сотрудника", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IdTextBox.Focus();
                return false;
            }
            // Проверка пароля
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return false;
            }
            return true;
        }
    }
}
