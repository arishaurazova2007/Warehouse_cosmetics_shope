using System;
using System.Windows.Forms;
namespace Warehouse_cosmetics_shope
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
            this.Hide();
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm();
            registrationForm.FormClosed += (s, args) => this.Close();
            registrationForm.Show();
            this.Hide();
        }
    }
}