using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LegendMotor.Domain.Models;

namespace LegendMotor.WinForm
{
    public partial class PurchasingDepartmentMenu : Form
    {
        private LoginForm loginForm;
        public PurchasingDepartmentMenu(LoginForm form)
        {
            InitializeComponent();
            this.loginForm = form;
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

        private void PurchasingDepartment_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.logout();
        }

        private void childFormClose(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }


        private void btn_spare_Click(object sender, EventArgs e)
        {
            SpareManagement spareManagement = new SpareManagement();
            spareManagement.FormClosed += new FormClosedEventHandler(childFormClose);
            spareManagement.Show();
            this.Hide();
        }

        private void btn_supplier_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewSupplier viewSupplier = new ViewSupplier();
            viewSupplier.FormClosed += new FormClosedEventHandler(childFormClose);
            viewSupplier.Show();
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            this.Hide();
            PurchasingDepartment purchasingDepartment = new PurchasingDepartment();
            purchasingDepartment.FormClosed += new FormClosedEventHandler(childFormClose);
            purchasingDepartment.Show();
        }
    }
}
