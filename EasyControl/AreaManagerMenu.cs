using EasyControl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyControl
{
    public partial class AreaManagerMenu : Form
    {
        private LoginForm loginForm;
        public AreaManagerMenu(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BinLocationManagement binLocationManagement = new BinLocationManagement(this);
            binLocationManagement.Show();
        }

        private void logout()
        {
            StaffManager.Instance.Clear();
            loginForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.logout();
            this.Close();
        }

        private void AreaManagerMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.logout();
        }
    }
}
