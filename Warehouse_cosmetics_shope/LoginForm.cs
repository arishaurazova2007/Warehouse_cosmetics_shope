using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Properties;
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
                var userId = AuthenticateUser();
                if (userId != Guid.Empty)
                {
                    var userRole = GetUserRole(userId);
                    if (userRole == Roles.Админ)
                    {
                        var catalogForm = new CatalogFormAdmin(userId);
                        catalogForm.Show();
                        this.Hide();
                    }
                    else if (userRole == Roles.Кладовщик)
                    {
                        var catalogForm = new CatalogFormKlad(userId);
                        catalogForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show(Resources.InvalidCredentials, Resources.LoginErrorTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                }
            }
        }
        public Guid AuthenticateUser()
        {
            using (var db = new WarehouseContext())
            {
                var inputId = IdTextBox.Text.Trim();
                // загружаю ВСЕХ пользователей
                var users = db.Users.ToList();
                // фильтрую в памяти
                var user = users.FirstOrDefault(u =>
                {
                    var fullName = $"{u.Surname ?? ""} {u.Name ?? ""} {u.Patronymic ?? ""}".Trim();
                    return fullName == inputId || u.UserID.ToString() == inputId;
                });

                if (user != null && BCrypt.Net.BCrypt.Verify(textBoxPassword.Text, user.Password))
                {
                    return user.UserID;
                }
                return Guid.Empty;
            }
        }
        public Roles GetUserRole(Guid userId)
        {
            using (var db = new WarehouseContext())
            {
                var user = db.Users.Find(userId);
                if (user != null)
                {
                    return user.Role;
                }
                return Roles.Кладовщик;
            }
        }
        // Проверка данных перед авторизацией
        public bool ValidateLoginData()
        {
            // Проверка ID
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                MessageBox.Show(Resources.EnterEmployeeId, Resources.Error,
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IdTextBox.Focus();
                return false;
            }
            // Проверка пароля
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show(Resources.EnterPassword, Resources.Error,
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return false;
            }
            return true;
        }
    }
}
