using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;

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
                if (AuthenticateUser(out Guid userId, out string userLogin))
                {
                    var userRole = GetUserRole(userId);

                    if (userRole == Roles.Admin)
                    {
                        var catalogForm = new CatalogFormAdmin(userId, userLogin);
                        catalogForm.Show();
                        this.Hide();
                    }
                    else if (userRole == Roles.Storekeeper)
                    {
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

        private bool AuthenticateUser(out Guid userId, out string userLogin)
        {
            userId = Guid.Empty;
            userLogin = null;

            using (var db = new WarehouseContext())
            {
                string login = IdTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(login))
                {
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

                MessageBox.Show("Неверный логин или пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private Roles GetUserRole(Guid userId)
        {
            using (var db = new WarehouseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserID == userId);
                if (user != null)
                {
                    return user.Role;
                }
                return Roles.Storekeeper;
            }
        }

        private bool ValidateLoginData()
        {
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IdTextBox.Focus();
                return false;
            }

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