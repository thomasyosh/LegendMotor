using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using MySql.Data.MySqlClient;

namespace LegendMotor.WinForm
{
    public partial class LoginForm : Form
    {
        DataContext _ctx;
        public LoginForm()
        {
            InitializeComponent();
            this._ctx = new DataContext();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Staff staff = _ctx.Staff.FirstOrDefault(staff => staff.Name == "storemen");
            try
            {
                if (staff != null)
                {
                    MessageBox.Show("Login Successful");
                    StaffManager.Instance.SetStaff(staff);
                    this.getBinLocationCode();
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getBinLocationCode()
        {
            BinLocationStaff binLocationStaff = _ctx.BinLocationStaff.FirstOrDefault(staff => staff.StaffId == StaffManager.Instance.GetStaffId());
            try
            {
                if (binLocationStaff != null)
                {
                    StaffManager.Instance.SetBinLocationCode(binLocationStaff.BinLocationCode);
                }
            } catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            } finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
                this.Hide();
                string positionCode = StaffManager.Instance.GetStaffPosition();
                if (positionCode.Equals("admin"))
                {
                    AdminMenu adminMenu = new AdminMenu(this);
                    adminMenu.Show();
                }else if (positionCode.Equals("storemen"))
                {
                    StoremenMenu storemenMenu = new StoremenMenu(this);
                    storemenMenu.Show();
                }
            }
        }
    }
}
