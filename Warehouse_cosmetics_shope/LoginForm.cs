using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;
using Serilog;

namespace Warehouse_cosmetics_shope
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            Log.Information("Открыта форма авторизации");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Log.Information("Пользователь вернулся на главную форму");
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLoginData())
            {
                if (AuthenticateUser(out Guid userId, out string userLogin, out string errorMessage))
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
                    MessageBox.Show(errorMessage, "Ошибка входа",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                }
            }
        }

        private bool AuthenticateUser(out Guid userId, out string userLogin, out string errorMessage)
        {
            userId = Guid.Empty;
            userLogin = null;
            errorMessage = null;

            try
            {
                using (var db = new WarehouseContext())
                {
                    string login = IdTextBox.Text.Trim();

                    if (string.IsNullOrWhiteSpace(login))
                    {
                        errorMessage = "Введите логин";
                        Log.Warning("Попытка входа с пустым логином");
                        return false;
                    }

                    var user = db.Users.FirstOrDefault(u => u.UserLogin == login);

                    if (user == null)
                    {
                        errorMessage = $"Пользователь с логином '{login}' не найден";
                        Log.Warning("Пользователь с логином {Login} не найден", login);
                        return false;
                    }

                    bool passwordValid;
                    try
                    {
                        passwordValid = BCrypt.Net.BCrypt.Verify(textBoxPassword.Text, user.Password);
                    }
                    catch (Exception ex)
                    {
                        errorMessage = $"Ошибка проверки пароля: {ex.Message}";
                        Log.Error(ex, "Ошибка при проверке пароля для пользователя {Login}", login);
                        return false;
                    }

                    if (!passwordValid)
                    {
                        errorMessage = "Неверный пароль";
                        Log.Warning("Неверный пароль для пользователя {Login}", login);
                        return false;
                    }

                    userId = user.UserID;
                    userLogin = user.UserLogin;
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка подключения к базе данных: {ex.Message}";
                Log.Error(ex, "Ошибка при аутентификации пользователя");
                return false;
            }
        }

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