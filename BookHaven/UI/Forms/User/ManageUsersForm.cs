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
        private readonly UserService _userService = new UserService();
        private Models.User? _selectedUser;
        private bool isUpdateMode = false; // Flag to track update mode

        public ManageUsersForm()
        {
            InitializeComponent();
            InitializeLayout();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            cmbUserRole.DataSource = Enum.GetValues(typeof(UserRole));
            cmbUserRole.SelectedItem = UserRole.SalesClerk;

            BindUserToControls();
        }

        private void InitializeLayout()
        {
            dgvUsers.Dock = DockStyle.Fill; // Make the DataGridView fill the available space
        }

        private void ClearFields()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cmbUserRole.SelectedIndex = -1;
            _selectedUser = null;
            isUpdateMode = false; // Reset update mode flag when clearing fields
        }

        private void LoadUsers()
        {
            try
            {
                List<Models.User> users = _userService.GetAllUsers();
                dgvUsers.DataSource = users;

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

                dgvUsers.ClearSelection();
                _selectedUser = null;
            }
            catch (Exception ex)
            {
                Logger.LogError("LoadUsers failed: " + ex.Message);
                MessageBox.Show("Failed to load users.");
            }
        }

        private void BindUserToControls()
        {
            if (_selectedUser != null)
            {
                // Data binding for the controls
                txtUsername.DataBindings.Clear();
                //txtPassword.DataBindings.Clear();
                cmbUserRole.DataBindings.Clear();

                txtUsername.DataBindings.Add("Text", _selectedUser, "Username");
                //txtPassword.DataBindings.Add("Text", _selectedUser, "Password");
                cmbUserRole.DataBindings.Add("SelectedItem", _selectedUser, "Role");
            }
        }

        public static bool ValidateUserForm(
            string username, 
            string password, 
            object selectedRole, 
            bool isUpdateMode, 
            out string errorMessage
        )
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(username))
            {
                errorMessage = "Username is required.";
                return false;
            }

            // Skip password validation if it's an update
            if (!isUpdateMode && string.IsNullOrEmpty(password))
            {
                errorMessage = "Password is required.";
                return false;
            }

            if (selectedRole == null || !Enum.IsDefined(typeof(UserRole), selectedRole))
            {
                errorMessage = "Please select a valid user role.";
                return false;
            }

            return true;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int count = dgvUsers.SelectedRows.Count;
            if (e.RowIndex >= 0)
            {
                _selectedUser = new Models.User
                {
                    Id = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["Id"].Value),
                    Username = dgvUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString(),
                    Password = dgvUsers.Rows[e.RowIndex].Cells["Password"].Value.ToString(),
                    Role = Enum.TryParse(
                        dgvUsers.Rows[e.RowIndex].Cells["Role"].Value.ToString(),
                        out UserRole role
                    ) ? role : throw new Exception("Invalid Role")
                };

                //txtUsername.Text = _selectedUser.Username;
                //txtPassword.Text = _selectedUser.Password;
                //cmbUserRole.SelectedItem = _selectedUser.Role;

                BindUserToControls();

                isUpdateMode = true; // Set update mode flag when selecting a user for update
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                UserRole role = (UserRole)cmbUserRole.SelectedItem;

                if (
                    !ValidateUserForm(
                        username,
                        password,
                        role,
                        isUpdateMode,
                        out string errorMessage
                    )
                )
                {
                    MessageBox.Show(errorMessage);
                    return;
                }

                Models.User user = new Models.User
                {
                    Username = username,
                    Password = password,
                    Role = role
                };

                if (_userService.CreateUser(user))
                {
                    MessageBox.Show(
                        "User added successfully.", 
                        "Success", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information
                    );
                    LoadUsers();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Error adding user.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("btnAddUser_Click failed: " + ex.Message);
                MessageBox.Show("An unexpected error occurred.");
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                UserRole role = (UserRole)cmbUserRole.SelectedItem;

                if (_selectedUser == null)
                {
                    MessageBox.Show(
                        "Please select a user to update.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                if (
                    !ValidateUserForm(
                        username, 
                        password, 
                        role, 
                        isUpdateMode, 
                        out string errorMessage
                    )
                )
                {
                    MessageBox.Show(errorMessage);
                    return;
                }

                Models.User user = new Models.User
                {
                    Id = _selectedUser.Id,
                    Username = username,
                    Role = role
                };

                // Only update password if it's provided (password should be optional in update)
                if (!string.IsNullOrEmpty(password))
                {
                    user.Password = password;
                }

                if (_userService.UpdateUser(user))
                {
                    MessageBox.Show(
                        "User updated successfully.", 
                        "Success", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information
                    );
                    LoadUsers();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Error updating user.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("btnUpdateUser_Click failed: " + ex.Message);
                MessageBox.Show("An unexpected error occurred.");
            }
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

                if (confirmResult == DialogResult.Yes)
                {
                    if (_userService.DeleteUser(_selectedUser.Id))
                    {
                        MessageBox.Show(
                            "User deleted successfully.", 
                            "Success", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information
                        );
                        LoadUsers();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting user.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("btnDeleteUser_Click failed: " + ex.Message);
                MessageBox.Show("An unexpected error occurred.");
            }
        }
    }
}
