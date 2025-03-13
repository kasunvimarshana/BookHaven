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

namespace BookHaven.UI.Forms.User
{
    public partial class ManageUsersForm : Form
    {
        private readonly UserService _userService;
        private Models.User? _selectedUser;
        private bool _isUpdateMode = false; // Flag to track update mode

        public ManageUsersForm()
        {
            InitializeComponent();
            _userService = new UserService();
            InitializeLayout();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            InitializeUserRoleComboBox();
            ResetForm();
            // BindUserToControls();
        }

        private void InitializeLayout()
        {
            dgvUsers.Dock = DockStyle.Fill; // Make the DataGridView fill the available space
        }

        private void InitializeUserRoleComboBox()
        {
            cmbUserRole.DataSource = Enum.GetValues(typeof(UserRole));
            //cmbUserRole.SelectedItem = UserRole.SalesClerk;
        }

        private void ResetForm()
        {
            //txtUsername.Text = string.Empty;
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            cmbUserRole.SelectedIndex = -1;
            _selectedUser = null;
            _isUpdateMode = false; // Reset update mode flag when clearing fields
            ToggleButtons(isUpdateMode: false);
        }

        private void ToggleButtons(bool isUpdateMode)
        {
            btnAddUser.Visible = !isUpdateMode;
            btnUpdateUser.Visible = isUpdateMode;
            btnDeleteUser.Visible = isUpdateMode;
        }

        private void LoadUsers()
        {
            try
            {
                List<Models.User> users = _userService.GetAllUsers();
                dgvUsers.DataSource = users;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                ShowError("Failed to load users.", ex);
            }
        }

        private void ConfigureDataGridView()
        {
            //Ensure Password column is not visible
            //foreach (DataGridViewColumn column in dgvUsers.Columns)
            //{
            //    if (column.Name == "Password")
            //    {
            //        column.Visible = false;
            //        break;
            //    }
            //}
            if (dgvUsers.Columns.Contains("Password"))
            {
                dgvUsers.Columns["Password"].Visible = false;
            }

            if (dgvUsers.Columns.Contains("CreatedAt"))
            {
                dgvUsers.Columns["CreatedAt"].DefaultCellStyle.Format = "d";
            }

            dgvUsers.ClearSelection();
        }

        private void BindUserToControls()
        {
            if (_selectedUser == null)
            {
                return;
            }

            // Data binding for the controls
            txtUsername.DataBindings.Clear();
            //txtPassword.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            cmbUserRole.DataBindings.Clear();

            txtUsername.DataBindings.Add("Text", _selectedUser, "Username");
            //txtPassword.DataBindings.Add("Text", _selectedUser, "Password");
            txtFullName.DataBindings.Add("Text", _selectedUser, "FullName");
            txtEmail.DataBindings.Add("Text", _selectedUser, "Email");
            cmbUserRole.DataBindings.Add("SelectedItem", _selectedUser, "Role");
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int count = dgvUsers.SelectedRows.Count;
            if (e.RowIndex < 0)
            {
                return;
            }

            _isUpdateMode = true; // Set update mode flag when selecting a user for update
            _selectedUser = GetUserFromGrid(e.RowIndex);
            BindUserToControls();
            ToggleButtons(isUpdateMode: true);
        }

        private Models.User GetUserFromGrid(int rowIndex)
        {
            return new Models.User
            {
                Id = Convert.ToInt32(dgvUsers.Rows[rowIndex].Cells["Id"].Value),
                Username = dgvUsers.Rows[rowIndex].Cells["Username"].Value?.ToString(),
                Password = dgvUsers.Rows[rowIndex].Cells["Password"].Value?.ToString(),
                FullName = dgvUsers.Rows[rowIndex].Cells["FullName"].Value?.ToString(),
                Email = dgvUsers.Rows[rowIndex].Cells["Email"].Value?.ToString(),
                CreatedAt = Convert.ToDateTime(dgvUsers.Rows[rowIndex].Cells["CreatedAt"].Value),
                Role = Enum.TryParse(
                        dgvUsers.Rows[rowIndex].Cells["Role"].Value?.ToString(),
                        out UserRole role
                    ) ? role : UserRole.SalesClerk
            };
        }

        private void ShowError(string message, Exception ex)
        {
            Logger.LogError(message + " " + ex.Message);
            MessageBox.Show(message);
        }

        private void ProcessUserAction(bool isUpdate)
        {
            if (!TryGetUserInput(out Models.User user, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                bool success = isUpdate ? _userService.UpdateUser(user) : _userService.CreateUser(user);
                string action = isUpdate ? "updated" : "added";

                if (success)
                {
                    MessageBox.Show(
                        $"User {action} successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadUsers();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show($"Error {action} user.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"User {(isUpdate ? "update" : "add")} failed.", ex);
            }
        }

        private bool TryGetUserInput(out Models.User user, out string errorMessage)
        {
            int id = _selectedUser?.Id ?? 0;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            UserRole role = (UserRole)cmbUserRole.SelectedItem; // SelectedItem may be null here
            DateTime createdAt = _selectedUser?.CreatedAt ?? DateTime.Now;

            user = new Models.User
            {
                Id = id,
                Username = username,
                Password = password,
                FullName = fullName,
                Email = email,
                Role = role,
                CreatedAt = createdAt
            };

            return ValidateUser(user, _isUpdateMode, out errorMessage);
        }

        private static bool ValidateUser(Models.User user, bool isUpdateMode, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                errorMessage = "Username is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.FullName))
            {
                errorMessage = "Full Name is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                errorMessage = "Email is required.";
                return false;
            }
            if (!isUpdateMode && string.IsNullOrWhiteSpace(user.Password))
            {
                errorMessage = "Password is required.";
                return false;
            }
            if (!Enum.IsDefined(typeof(UserRole), user.Role))
            {
                errorMessage = "Please select a valid user role.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ProcessUserAction(isUpdate: false);
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            ProcessUserAction(isUpdate: true);
        }


        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedUser == null)
                {
                    MessageBox.Show("Please select a user to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedUser.Username}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                if (_userService.DeleteUser(_selectedUser.Id))
                {
                    MessageBox.Show(
                        "User deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadUsers();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Error deleting user.");
                }
            }
            catch (Exception ex)
            {
                ShowError("User deletion failed.", ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
