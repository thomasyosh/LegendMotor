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
    public partial class SalesOfficerMenu : Form
    {
        private LoginForm loginForm;
        public SalesOfficerMenu(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void btn_searchSpare_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchSpareForm form = new SearchSpareForm(this);
            form.Show();
        }

        private void btn_viewDealers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dealer form = new Dealer(this);
            form.Show();
        }

        private void btn_viewOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            DealerOrder form = new DealerOrder(this, null);
            form.FormClosed += childForm_FormClosed;
            form.Show();
        }

        private void logout()
        {
            StaffManager.Instance.Clear();
            loginForm.Show();
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalesOfficerMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.logout();
        }
    }
}
