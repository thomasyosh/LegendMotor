using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LegendMotor.WinForm
{
    public partial class UpdateStaffForm : Form
    {
        DataContext _ctx = new DataContext();
        private List<Staff> staffs;
        public UpdateStaffForm()
        {
            InitializeComponent();
        }

        private void UpdateStaffForm_Load(object sender, EventArgs e)
        {
            DbSet<Staff> staffs = _ctx.Staff;
            DbSet<Position> positions = _ctx.Position;
            DbSet<Area> areas = _ctx.Area;
            foreach (Staff staff in staffs)
            {
                comboBox4.Items.Add(staff.Email);
            }

            foreach (Position position in positions)
            {
                string name = position.PositionCode;
                comboBox1.Items.Add(name);
            }

            foreach (Area area in areas)
            {
                string areaName = area.Name;
                comboBox2.Items.Add(areaName);
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string staffEmail = this.comboBox4.Text.Trim();
            Staff staff = _ctx.Staff.FirstOrDefault(staff => staff.Email.Equals(staffEmail));
            staff.StaffId = textBox1.Text;
            staff.Password = textBox2.Text;
            staff.Name = textBox3.Text;
            staff.Address = textBox4.Text;
            staff.Phone = textBox5.Text;
            staff.PositionCode = comboBox1.Text;
            staff.AreaCode = comboBox2.Text;
            try
            {
                _ctx.SaveChanges();
                MessageBox.Show("Update staff successfully");
            }catch (Exception ex)
            {
                MessageBox.Show("Something wrong is occurred");
            }
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string staffEmail = this.comboBox4.Text.Trim();
            Staff staff = _ctx.Staff.FirstOrDefault(staff => staff.Email.Equals(staffEmail));
            textBox1.Text = staff.StaffId;
            textBox2.Text = staff.Password;
            textBox3.Text = staff.Name;
            textBox4.Text = staff.Address;
            textBox5.Text = staff.Phone;
            comboBox1.Text = staff.PositionCode;
            comboBox2.Text = staff.AreaCode;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
