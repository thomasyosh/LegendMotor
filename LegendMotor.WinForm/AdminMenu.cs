using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegendMotor.WinForm
{
    public partial class AdminMenu : Form
    {
        private LoginForm loginForm;
        public AdminMenu(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateStaffForm createStaffForm = new CreateStaffForm();
            createStaffForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateStaffForm updateStaffForm = new UpdateStaffForm();
            updateStaffForm.Show();
        }
    }
}
