using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.BLL;
using BookHaven.DAL;
using BookHaven.Utilities;
using BookHaven.Enums;
using Models = BookHaven.Models;
using BookHaven.Helpers;

namespace BookHaven.UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationService _authenticationService;
        public LoginForm()
        {
            InitializeComponent();
            _authenticationService = new AuthenticationService();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void ShowError(string message, Exception ex)
        {
            Logger.LogError(message + " " + ex.Message);
            MessageBox.Show(message);
        }

        private void OpenMainForm()
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            Models.User user;

            try
            {
                if (_authenticationService.AuthenticateUser(userName, password, out user))
                {
                    OpenMainForm();
                }
                else
                {
                    MessageBox.Show("Please Check Username and Password.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Login failed.", ex);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            User.ManageUsersForm manageUsersForm = new User.ManageUsersForm();
            manageUsersForm.Show();
        }
    }
}
