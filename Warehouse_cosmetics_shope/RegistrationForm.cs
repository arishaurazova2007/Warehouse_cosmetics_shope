using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;
using Serilog;
using BCrypt.Net;

namespace Warehouse_cosmetics_shope
{
    public partial class RegistrationForm : Form
    {
        /// <summary>
        /// Конструктор формы регистрации
        /// </summary>
        public RegistrationForm()
        {
            InitializeComponent();
            Log.Information("Открыта форма регистрации");
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Зарегистрироваться"
        /// </summary>
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Log.Information("Начало процесса регистрации нового пользователя");

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

            Log.Information("Пользователь {UserLogin} успешно зарегистрирован (ID: {UserId})", userLogin, userId);

            var catalogFormStoreK = new CatalogFormKlad(userId, userLogin);
            catalogFormStoreK.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Log.Information("Регистрация отменена, возврат на главную форму");
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
                Log.Warning("Попытка регистрации без фамилии");
                MessageBox.Show("Поля обязательны для заполнения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                surnameBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                Log.Warning("Попытка регистрации без имени");
                MessageBox.Show("Поля обязательны для заполнения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(patronimicBox.Text))
            {
                Log.Warning("Попытка регистрации без отчества");
                MessageBox.Show("Поля обязательны для заполнения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                patronimicBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(passwordBox.Text))
            {
                Log.Warning("Попытка регистрации без пароля");
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
                Log.Warning("Фамилия содержит недопустимые символы: {Surname}", surnameBox.Text);
                MessageBox.Show("Поля содержат посторонние символы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                surnameBox.Focus();
                surnameBox.SelectAll();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(nameBox.Text, pattern))
            {
                Log.Warning("Имя содержит недопустимые символы: {Name}", nameBox.Text);
                MessageBox.Show("Поля содержат посторонние символы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameBox.Focus();
                nameBox.SelectAll();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(patronimicBox.Text, pattern))
            {
                Log.Warning("Отчество содержит недопустимые символы: {Patronymic}", patronimicBox.Text);
                MessageBox.Show("Поля содержат посторонние символы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                patronimicBox.Focus();
                patronimicBox.SelectAll();
                return false;
            }

            if (passwordBox.Text.Contains(" "))
            {
                Log.Warning("Пароль содержит пробелы");
                MessageBox.Show("Поля содержат посторонние символы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordBox.Focus();
                passwordBox.SelectAll();
                return false;
            }

            string loginPattern = @"^[a-zA-Z0-9]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(loginBox.Text, loginPattern))
            {
                Log.Warning("Логин содержит недопустимые символы: {Login}", loginBox.Text);
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
            try
            {
                using (var db = new WarehouseContext())
                {
                    string login = loginBox.Text.Trim();
                    var existingUser = db.Users.FirstOrDefault(u => u.UserLogin == login);

                    if (existingUser != null)
                    {
                        Log.Warning("Попытка регистрации с уже существующим логином: {Login}", login);
                        MessageBox.Show("Логин уже существует", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при проверке уникальности логина");
                MessageBox.Show("Ошибка при проверке логина", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="userId">Возвращает идентификатор созданного пользователя</param>
        /// <param name="userLogin">Возвращает логин созданного пользователя</param>
        private void RegisterUser(out Guid userId, out string userLogin)
        {
            userId = Guid.Empty;
            userLogin = null;

            try
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
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при регистрации пользователя");
                MessageBox.Show("Ошибка при регистрации", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}