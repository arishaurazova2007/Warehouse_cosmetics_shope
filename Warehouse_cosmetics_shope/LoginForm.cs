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
            MainForm mainForm = new MainForm();

            mainForm.Show();
            this.Hide();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLoginData())
            {
                int userId = AuthenticateUser(); // Метод для БД

                if (userId > 0)
                {
                    // Успешная авторизация
                    string userRole = GetUserRole(userId); // Метод для БД
                    if (userRole == "Admin")
                    {
                        CatalogFormAdmin catalogForm = new CatalogFormAdmin(userId);
                        catalogForm.Show();
                        this.Hide();
                    }
                    else if (userRole == "Kladovshik")
                    {
                        CatalogFormKlad catalogForm = new CatalogFormKlad();
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
        private int AuthenticateUser()
        {
            //добавлю код для проверки ID/пароля в БД
            // Верну ID пользователя при успехе, или 0 при ошибке
            return 0;
        }
        private string GetUserRole(int userId)
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
