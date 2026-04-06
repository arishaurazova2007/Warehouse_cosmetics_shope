using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;

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
            // Проверка на пустые поля
            if (!ValidateEmptyFields())
                return;

            // Проверка на посторонние символы
            if (!ValidateNoSpecialChars())
                return;

            // Проверка на существующий ID
            if (!ValidateUniqueLogin())
                return;

            // Если всё хорошо
            RegisterUser(out Guid userId, out string userLogin);
            var catalogFormStoreK = new CatalogFormKlad(userId, userLogin);
            catalogFormStoreK.Show();
            this.Hide();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Проверка: все поля обязательны для заполнения
        /// </summary>
        private bool ValidateEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(surnameBox.Text))
            {
                MessageBox.Show("Поля обязательны для заполнения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                surnameBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show("Поля обязательны для заполнения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(patronimicBox.Text))
            {
                MessageBox.Show("Поля обязательны для заполнения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                patronimicBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(passwordBox.Text))
            {
                MessageBox.Show("Поля обязательны для заполнения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordBox.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверка: поля не должны содержать посторонние символы (только буквы)
        /// </summary>
        private bool ValidateNoSpecialChars()
        {
            // Только русские буквы, пробел и дефис
            string pattern = @"^[а-яА-ЯёЁ\s\-]+$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(surnameBox.Text, pattern))
            {
                MessageBox.Show("Поля содержат посторонние символы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                surnameBox.Focus();
                surnameBox.SelectAll();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(nameBox.Text, pattern))
            {
                MessageBox.Show("Поля содержат посторонние символы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameBox.Focus();
                nameBox.SelectAll();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(patronimicBox.Text, pattern))
            {
                MessageBox.Show("Поля содержат посторонние символы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                patronimicBox.Focus();
                patronimicBox.SelectAll();
                return false;
            }
            if (passwordBox.Text.Contains(" "))
            {
                MessageBox.Show("Поля содержат посторонние символы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordBox.Focus();
                passwordBox.SelectAll();
                return false;
            }
            string loginPattern = @"^[a-zA-Z0-9]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(loginBox.Text, loginPattern))
            {
                MessageBox.Show("Логин должен содержать только латинские буквы и цифры", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loginBox.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверка: Логин сотрудника не должен существовать
        /// </summary>
        private bool ValidateUniqueLogin()
        {
            using (var db = new WarehouseContext())
            {
                // Проверяем, существует ли пользователь с таким логином
                var existingUser = db.Users.FirstOrDefault(u => u.UserLogin == loginBox.Text.Trim());

                if (existingUser != null)
                {
                    MessageBox.Show("Логин уже существует", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        private void RegisterUser(out Guid userId, out string userLogin)
        {
            using (var db = new WarehouseContext())
            {
                var newUser = new User
                {
                    UserID = Guid.NewGuid(),
                    UserLogin = loginBox.Text.Trim(),
                    Surname = surnameBox.Text.Trim(),
                    Name = nameBox.Text.Trim(),
                    Patronymic = patronimicBox.Text.Trim(),
                    Password = BCrypt.Net.BCrypt.HashPassword(passwordBox.Text),
                    Role = Roles.Storekeeper
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                userId = newUser.UserID;
                userLogin = newUser.UserLogin;
            }
        }
    }
}