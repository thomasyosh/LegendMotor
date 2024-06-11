using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using Microsoft.EntityFrameworkCore;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LegendMotor.WinForm;

public partial class UpdateStaffForm : Form
{
    private readonly DataContext _ctx;
    private List<string> positionCodes = new List<string>();
    private List<string> binLocationCodes = new List<string>();
    private List<Area> areas = new List<Area>();
    private List<Staff> staffs = new List<Staff>();
    private List<BinLocationStaff> binLocationStaffs = new List<BinLocationStaff>();
    private Staff selectedStaff = null;
    private string gender = "";
    public UpdateStaffForm()
    {
        InitializeComponent();
        this._ctx = new DataContext();
    }

    private void UpdateStaffForm_Load(object sender, EventArgs e)
    {
        var positions = _ctx.Position;

        foreach (var position in positions)
        {
            positionCodes.Add(position.PositionCode);
            comboBox1.Items.Add(position.Name);
        }

        var queryareas = _ctx.Area;
        foreach (var queryarea in queryareas)
        {
            areas.Add(queryarea);
            comboBox2.Items.Add(queryarea.Name);
        }

        var binLocations = _ctx.BinLocation;
        foreach (var binLocation in binLocations)
        {
            binLocationCodes.Add(binLocation.BinLocationCode);
            comboBox3.Items.Add(binLocation.Name);
        }


        var queryStaffs = _ctx.Staff;
        foreach (var queryStaff in queryStaffs)
        {
            Console.WriteLine(queryStaff.StaffId);
            Staff staff = new Staff();
            comboBox4.Items.Add(queryStaff.Email);
            staffs.Add(queryStaff);
        }

        var queryBinLocaionStaffs = _ctx.BinLocationStaff;
        foreach (var staff in queryBinLocaionStaffs)
        {
            binLocationStaffs.Add(staff);
        }
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


    private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
    {
        if (comboBox4.SelectedIndex != -1)
        {
            selectedStaff = staffs[comboBox4.SelectedIndex];
            textBox4.Text = selectedStaff.Name;
            textBox3.Text = selectedStaff.Address;
            textBox2.Text = selectedStaff.Phone;
            comboBox1.SelectedIndex = positionCodes.IndexOf(selectedStaff.PositionCode);
            comboBox2.SelectedIndex = areas.IndexOf(areas.First(x => x.AreaCode == selectedStaff.AreaCode));
            if (binLocationStaffs.Any(x => x.StaffId == selectedStaff.StaffId))
            {
                comboBox3.Visible = true;
                label7.Visible = true;

                comboBox3.SelectedIndex = binLocationCodes.IndexOf(binLocationStaffs.First(x => x.StaffId == selectedStaff.StaffId).BinLocationCode);
            }
            else
            {
                comboBox3.SelectedIndex = -1;
                comboBox3.Visible = false;
                label7.Visible = false;
            }
            if (selectedStaff.Gemder == "M")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        string name = textBox4.Text;
        string address = textBox3.Text;
        string phone = textBox2.Text;
        string password = textBox5.Text;
        string positionCode = positionCodes[comboBox1.SelectedIndex];
        string areaCode = areas[comboBox2.SelectedIndex].AreaCode;
        if (password.Equals("") || name.Equals("") || gender.Equals("") || address.Equals("") || phone.Equals("") || positionCode.Equals("") || areaCode.Equals(""))
        {
            MessageBox.Show("Please fill in all fields");
            return;
        }
        string binLocationCode = "";
        if (binLocationCodes.Count > 0 && comboBox3.SelectedIndex != -1 && comboBox3.SelectedIndex <= binLocationCodes.Count - 1)
        {
            binLocationCode = binLocationCodes[comboBox3.SelectedIndex];
        }
        Console.WriteLine(password);
        var queryStaff = _ctx.Staff.FirstOrDefault(staff => staff.StaffId == selectedStaff.StaffId);
        queryStaff.Password = BCrypt.Net.BCrypt.HashPassword(password);
        queryStaff.Name = name;
        queryStaff.Phone = phone;
        queryStaff.Address = address;
        queryStaff.AreaCode = areaCode;
        queryStaff.PositionCode = positionCode;
        _ctx.Staff.Update(queryStaff);
        try
        {
            int failed = 0;

            _ctx.SaveChanges();
            if (!binLocationCode.Equals(""))
            {

                if (binLocationStaffs.Any(x => x.StaffId == selectedStaff.StaffId))
                {
                    var binLocationStaff = _ctx.BinLocationStaff.FirstOrDefault(staff => staff.StaffId.Equals(selectedStaff.StaffId));
                    try
                    {
                        _ctx.BinLocationStaff.Remove(binLocationStaff);
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        Console.WriteLine("Error delete data from Database!");
                    }

                }

            }
            if (failed == 0)
            {
                MessageBox.Show("Staff updated successfully");
                staffs[comboBox4.SelectedIndex].Name = name;
                staffs[comboBox4.SelectedIndex].Phone = phone;
                staffs[comboBox4.SelectedIndex].Address = address;
                staffs[comboBox4.SelectedIndex].AreaCode = areaCode;
                staffs[comboBox4.SelectedIndex].PositionCode = positionCode;
                if (binLocationStaffs.Any(x => x.StaffId == selectedStaff.StaffId))
                {
                    binLocationStaffs.First(x => x.StaffId == selectedStaff.StaffId).BinLocationCode = binLocationCode;
                }
                else
                {
                    binLocationStaffs.Add(new BinLocationStaff { BinLocationCode = binLocationCode, StaffId = selectedStaff.StaffId });
                }
            }
            else
            {
                Console.WriteLine(failed);
                MessageBox.Show("Failed to update staff");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            MessageBox.Show(ex.Message);
            // if (con.State == ConnectionState.Open)
            //     con.Close();
        }
    }

    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void label7_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        textBox5.Text = "abcd1234";
    }
}
