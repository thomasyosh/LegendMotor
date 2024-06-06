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
    public partial class DeliveryMenMenu : Form
    {
        private LoginForm loginForm;
        public DeliveryMenMenu(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void btn_incomingOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeliveryIncomingOrderList deliveryIncomingOrderList = new DeliveryIncomingOrderList();
            deliveryIncomingOrderList.FormClosed += new FormClosedEventHandler(DeliveryIncomingOrderList_FormClosed);
            deliveryIncomingOrderList.Show();
        }

        private void DeliveryIncomingOrderList_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btn_purchasingOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeliveryPurchasingOrder deliveryPurchasingOrder = new DeliveryPurchasingOrder();
            deliveryPurchasingOrder.FormClosed += new FormClosedEventHandler(DeliveryIncomingOrderList_FormClosed);
            deliveryPurchasingOrder.Show();
        }

        private void logout()
        {
            StaffManager.Instance.Clear();
            loginForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeliveryMenMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.logout();
        }
    }
}
