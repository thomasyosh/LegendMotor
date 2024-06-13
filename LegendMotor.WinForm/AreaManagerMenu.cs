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

    private void btn_searchSpare_Click(object sender, EventArgs e)
    {
        this.Hide();
        SearchSpareForm form = new SearchSpareForm(this);
        form.Show();
    }

    private void btn_viewDealers_Click(object sender, EventArgs e)
    {
        this.Hide();
        DealerForm form = new DealerForm(this);
        form.Show();
    }

    private void btn_viewOrder_Click(object sender, EventArgs e)
    {
        this.Hide();
        DealerOrderForm form = new DealerOrderForm(this, null);
        form.FormClosed += childForm_FormClosed;
        form.Show();
    }

    private void childForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.Show();
    }

    private void btn_SalesOverview_Click(object sender, EventArgs e)
    {
        this.Hide();
        SalesOverview form = new SalesOverview();
        form.FormClosed += childForm_FormClosed;
        form.Show();
    }

    private void accountInfo_Click(object sender, EventArgs e)
    {
        AccountInfoForm accountInfoForm = new AccountInfoForm();
        accountInfoForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
        this.Hide();
        accountInfoForm.Show();
    }
}
