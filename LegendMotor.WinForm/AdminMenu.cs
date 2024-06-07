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

public partial class AdminMenu : Form
{
    private LoginForm loginForm;
    public AdminMenu(LoginForm loginForm)
    {
        InitializeComponent();
        this.loginForm = loginForm;
    }

    private void btn_searchSpare_Click(object sender, EventArgs e)
    {
        this.Hide();
       CreateStaffForm createStaffForm = new CreateStaffForm();
        createStaffForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
        this.Hide();
        createStaffForm.Show();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        UpdateStaffForm updateStaffForm = new UpdateStaffForm();
        updateStaffForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
        this.Hide();
        updateStaffForm.Show();
    }

    private void logout()
    {
        StaffManager.Instance.Clear();
        loginForm.Show();
    }

    private void AdminMenu_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.logout();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        this.logout();
        this.Close();
    }

    private void childForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.Show();
    }

    private void AdminMenu_FormClosed_1(object sender, FormClosedEventArgs e)
    {
        this.logout();
    }
}
