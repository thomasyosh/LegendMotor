using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LegendMotor.Dal;

namespace LegendMotor.WinForm;

public partial class LoginForm : Form
{
    private readonly DataContext _ctx;
    public LoginForm()
    {
         InitializeComponent();
            this._ctx = new DataContext();


    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            btn_login.PerformClick();
        }
    }   

    private void btn_login_Click(object sender, EventArgs e)
    {

        string username = txt_username.Text;
        string password = txt_password.Text;
            Console.WriteLine(password);
            Staff loginUser = _ctx.Staff.FirstOrDefault(staff => staff.Name.Equals(username) && staff.Password.Equals(password));

        try
        {
            if (loginUser !=null)
            {
                MessageBox.Show("Login Successful");
                StaffManager.Instance.SetStaff(loginUser);
                this.getBinLocationCode();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        } catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            MessageBox.Show(ex.Message);
        }
    }

    private void getBinLocationCode()
    {
        BinLocationStaff binLocation = _ctx.BinLocationStaff.FirstOrDefault(binLocation => binLocation.StaffId.Equals(StaffManager.Instance.GetStaffId()));
        try
        {
            if (binLocation !=null)
            {

                StaffManager.Instance.SetBinLocationCode(binLocation.BinLocationCode);
            }
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        } finally
        {
            txt_password.Text = "";
            txt_username.Text = "";
            this.Hide();
            string positionCode = StaffManager.Instance.GetStaffPosition();
            if (positionCode.Equals("admin"))
            {
                AdminMenu adminMenu = new AdminMenu(this);
                adminMenu.Show();
            }
            else if (positionCode.Equals("sales"))
            {
                SalesOfficerMenu salesOfficerMenu = new SalesOfficerMenu(this);
                salesOfficerMenu.Show();
            }
            else if (positionCode.Equals("smanager"))
            {
                SalesManagerMenu salesManagerMenu = new SalesManagerMenu(this);
                salesManagerMenu.Show();
            }
            else if (positionCode.Equals("storemen"))
            {
                StoremenMenu storemenMenu = new StoremenMenu(this);
                storemenMenu.Show();
            }
            else if (positionCode.Equals("amanager"))
            {
                AreaManagerMenu areaManagerMenu = new AreaManagerMenu(this);
                areaManagerMenu.Show();
            }
            else if (positionCode.Equals("pd"))
            {
                PurchasingDepartmentMenu productDepartmentMenu = new PurchasingDepartmentMenu(this);
                productDepartmentMenu.Show();
            }/* else if (positionCode.Equals("src"))
            {
                UpdateStockForm updateStockForm = new UpdateStockForm(this);
                updateStockForm.Show();
            } else if (positionCode.Equals("dm"))
            {
                DeliveryMenMenu deliveryMenMenu = new DeliveryMenMenu(this);
                deliveryMenMenu.Show();
            }*/
        }
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {

    }

    private void englishToolStripMenuItem_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en");
    }

    private void 繁體中文ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("zh-HK");
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("zh-HK");
    }

    private void 簡體中文ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("zh-Hans-HK");
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("zh-Hans-HK");
    }
}
