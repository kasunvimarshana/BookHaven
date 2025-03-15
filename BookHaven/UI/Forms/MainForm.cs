using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.Helpers;
using BookHaven.UI.Forms;

namespace BookHaven.UI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //
        }

        private void btnBookManager_Click(object sender, EventArgs e)
        {
            Book.ManageBooksForm manageBooksForm = new Book.ManageBooksForm();
            manageBooksForm.Show();
        }

        private void btnCustomerManager_Click(object sender, EventArgs e)
        {
            Customer.ManageCustomersForm manageCustomersForm = new Customer.ManageCustomersForm();
            manageCustomersForm.Show();
        }

        private void btnSupplierManager_Click(object sender, EventArgs e)
        {
            Supplier.ManageSuppliersForm manageSuppliersForm = new Supplier.ManageSuppliersForm();
            manageSuppliersForm.Show();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            User.ManageUsersForm manageUsersForm = new User.ManageUsersForm();
            manageUsersForm.Show();
        }

        private void btnOrderManager_Click(object sender, EventArgs e)
        {
            Order.ManageOrdersForm manageOrdersForm = new Order.ManageOrdersForm();
            manageOrdersForm.Show();
        }

        private void btnSaleManager_Click(object sender, EventArgs e)
        {
            Sale.ManageSalesForm manageSalesForm = new Sale.ManageSalesForm();
            manageSalesForm.Show();
        }
    }
}
