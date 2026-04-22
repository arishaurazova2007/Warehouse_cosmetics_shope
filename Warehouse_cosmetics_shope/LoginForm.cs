using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;
using Serilog;
using BCrypt.Net;

namespace Warehouse_cosmetics_shope
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Конструктор формы авторизации
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            Log.Information("Открыта форма авторизации");
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Log.Information("Пользователь вернулся на главную форму");
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Войти"
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLoginData())
            {
                if (AuthenticateUser(out Guid userId, out string userLogin))
                {
                    var userRole = GetUserRole(userId);

                    if (userRole == Roles.Admin)
                    {
                        Log.Information("Администратор {UserLogin} успешно вошёл в систему", userLogin);
                        var catalogForm = new CatalogFormAdmin(userId, userLogin);
                        catalogForm.Show();
                        this.Hide();
                    }
                    else if (userRole == Roles.Storekeeper)
                    {
                        Log.Information("Кладовщик {UserLogin} успешно вошёл в систему", userLogin);
                        var catalogForm = new CatalogFormKlad(userId, userLogin);
                        catalogForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                }
            }
        }

        /// <summary>
        /// Аутентифицирует пользователя по логину и паролю
        /// </summary>
        /// <param name="userId">Возвращает идентификатор пользователя при успешной аутентификации</param>
        /// <param name="userLogin">Возвращает логин пользователя при успешной аутентификации</param>
        /// <returns>true - если аутентификация успешна, false - если логин или пароль неверны</returns>
        private bool AuthenticateUser(out Guid userId, out string userLogin)
        {
            userId = Guid.Empty;
            userLogin = null;

            try
            {
                using (var db = new WarehouseContext())
                {
                    string login = IdTextBox.Text.Trim();

                    if (string.IsNullOrWhiteSpace(login))
                    {
                        Log.Warning("Попытка входа с пустым логином");
                        MessageBox.Show("Введите логин", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    var user = db.Users.FirstOrDefault(u => u.UserLogin == login);

                    if (user != null && BCrypt.Net.BCrypt.Verify(textBoxPassword.Text, user.Password))
                    {
                        userId = user.UserID;
                        userLogin = user.UserLogin;
                        return true;
                    }

                    Log.Warning("Неудачная попытка входа с логином {Login}", login);
                    MessageBox.Show("Неверный логин или пароль", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при аутентификации пользователя");
                MessageBox.Show("Ошибка при входе в систему", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Получает роль пользователя по его идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Роль пользователя (Admin или Storekeeper)</returns>
        private Roles GetUserRole(Guid userId)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.UserID == userId);
                    if (user != null)
                    {
                        return user.Role;
                    }
                    Log.Warning("Пользователь с ID {UserId} не найден при получении роли", userId);
                    return Roles.Storekeeper;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при получении роли пользователя {UserId}", userId);
                return Roles.Storekeeper;
            }
        }

        /// <summary>
        /// Проверяет, что поля логина и пароля не пустые
        /// </summary>
        /// <returns>true - если данные введены, false - если есть пустые поля</returns>
        private bool ValidateLoginData()
        {
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Log.Warning("Попытка входа без ввода логина");
                MessageBox.Show("Введите логин", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IdTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                Log.Warning("Попытка входа без ввода пароля");
                MessageBox.Show("Введите пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return false;
            }

            return true;
        }
    }
}