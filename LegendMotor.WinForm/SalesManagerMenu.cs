using LegendMotor.Dal;
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

public partial class SalesManagerMenu : Form
{
    private readonly DataContext _ctx;
    private LoginForm loginForm;
    public SalesManagerMenu(LoginForm loginForm)
    {
        InitializeComponent();
        this.loginForm = loginForm;
        this._ctx = new DataContext();
    }

    private void btn_searchSpare_Click(object sender, EventArgs e)
    {
        this.Hide();
        SearchSpareForm form = new SearchSpareForm(this);
        form.Show();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btn_createNewOrder_Click(object sender, EventArgs e)
    {

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

    private void btn_SalesOverview_Click(object sender, EventArgs e)
    {
/*      this.Hide();
        SalesOverview form = new SalesOverview();
        form.FormClosed += childForm_FormClosed;
        form.Show();*/
    }

    private void childForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.Show();
    }

    private void logout()
    {
        StaffManager.Instance.Clear();
        loginForm.Show();
    }

    private void SalesManagerMenu_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.logout();
    }
}
