using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegendMotor.WinForm;

public partial class StoremenMenu : Form
{
    private LoginForm loginForm;
    public StoremenMenu(LoginForm loginForm)
    {
        InitializeComponent();
        this.loginForm = loginForm;
    }

    private void childForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.Show();
    }

    private void btn_stock_Click(object sender, EventArgs e)
    {
        this.Hide();
        StockList stockList = new StockList(this);
        stockList.Show();
    }

    private void btn_incomingOrder_Click(object sender, EventArgs e)
    {
        this.Hide();
        BinLocationIncomingOrderForm incomingOrderList = new BinLocationIncomingOrderForm(this);
        incomingOrderList.Show();
    }

    private void btn_purchasingOrder_Click(object sender, EventArgs e)
    {
        this.Hide();
        PurchasingOrderList purchasingOrderList = new PurchasingOrderList(this);
        purchasingOrderList.Show();
    }

    private void logout()
    {
        StaffManager.Instance.Clear();
        loginForm.Show();
    }

    private void StoremenMenu_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.logout();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        this.logout();
        this.Close();
    }
}
