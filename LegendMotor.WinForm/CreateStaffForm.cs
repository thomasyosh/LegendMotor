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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LegendMotor.WinForm
{
    public partial class CreateStaffForm : Form
    {
        DataContext _ctx;
        private List<string> positionCodes = new List<string>();
        private List<string> binLocationCodes = new List<string>();
        private List<string> areaCodes = new List<string>();
        private string gender = "";
        private string binLocationCode = "";
        public CreateStaffForm()
        {
            InitializeComponent();
            _ctx = new DataContext();
        }

        private void CreateStaffForm_Load(object sender, EventArgs e)
        {
            positionCodes = _ctx.Position.Select(position => position.PositionCode).ToList();
            areaCodes = _ctx.Area.Select(areaCode => areaCode.AreaCode).ToList();
            binLocationCodes = _ctx.BinLocation.Select(binLocationCode => binLocationCode.BinLocationCode).ToList();
            Console.WriteLine(positionCodes);
            foreach (string positionCode in positionCodes)
            {
                comboBox1.Items.Add(positionCode);
            }

            foreach (string areaCode in areaCodes)
            {
                comboBox2.Items.Add(areaCode);
            }

            foreach (string binLocationCode in binLocationCodes)
            {
                comboBox3.Items.Add(binLocationCode);
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex <= -1 || comboBox1.SelectedIndex >= positionCodes.Count)
            {
                return;
            }



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                gender = "M";
                radioButton2.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                gender = "F";
                radioButton1.Checked = false;
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string positionCode = positionCodes[comboBox1.SelectedIndex];
            string areaCode = areaCodes[comboBox2.SelectedIndex];
            binLocationCode = binLocationCodes[comboBox3.SelectedIndex];
            Staff staff = new Staff();
            staff.StaffId = Guid.NewGuid().ToString();
            staff.Email = textBox1.Text;
            staff.Password = textBox2.Text;
            staff.Name = textBox3.Text;
            staff.Phone = textBox5.Text;
            staff.Address = textBox4.Text;
            staff.Gemder = gender;
            staff.PositionCode = positionCode;
            staff.AreaCode = areaCode;
            _ctx.Staff.Add(staff);
            

            if (!binLocationCode.Equals(""))
            {
                BinLocationStaff binLocationStaff = new BinLocationStaff();
                binLocationStaff.BinLocationCode = binLocationCode;
                binLocationStaff.StaffId = staff.StaffId;
                _ctx.BinLocationStaff.Add(binLocationStaff);
            }

            try
            {
                _ctx.SaveChanges();
                MessageBox.Show("New staff created successfully.");
            }catch (Exception ex)
            {
                MessageBox.Show("[Warning] Something is wrong.");
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
