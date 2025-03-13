using BookHaven.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHaven.UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();
        public LoginForm()
        {
            InitializeComponent();
            if (_dbHelper.TestConnection())
            {
                MessageBox.Show("Ok.");
            }
            else
            {
                MessageBox.Show("Fail.");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
