using EasyControl.Model;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EasyControl
{
    public partial class UpdateStaffForm : Form
    {
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
        }

        private void UpdateStaffForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Config.ConnectionString))
            {
                string query = "SELECT * FROM Position";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        positionCodes.Add(dr["PositionCode"].ToString().Trim());
                        comboBox1.Items.Add(dr["Name"].ToString());
                    }
                }

                query = "SELECT * FROM Area";
                cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Area area = new Area();
                        area.AreaCode = dr["AreaCode"].ToString().Trim();
                        area.Name = dr["Name"].ToString();
                        areas.Add(area);
                        comboBox2.Items.Add(dr["Name"].ToString());
                    }
                }

                query = "SELECT * FROM BinLocation";
                cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        binLocationCodes.Add(dr["BinLocationCode"].ToString().Trim());
                        comboBox3.Items.Add(dr["Name"].ToString());
                    }
                }

                query = "SELECT * FROM Staff";
                cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["StaffId"].ToString());
                        Staff staff = new Staff();
                        staff.StaffId = dr["StaffId"].ToString().Trim();
                        staff.Name = dr["Name"].ToString();
                        staff.Gemder = dr["Gender"].ToString();
                        staff.Email = dr["Email"].ToString();
                        staff.Phone = dr["Phone"].ToString();
                        staff.Address = dr["Address"].ToString();
                        staff.AreaCode = dr["AreaCode"].ToString();
                        staff.PositionCode = dr["PositionCode"].ToString().Trim();
                        comboBox4.Items.Add(staff.Email);
                        staffs.Add(staff);
                    }
                }

                query = "SELECT * FROM BinLocationStaff";
                cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BinLocationStaff binLocationStaff = new BinLocationStaff();
                        binLocationStaff.BinLocationCode = dr["BinLocationCode"].ToString().Trim();
                        binLocationStaff.StaffId = dr["StaffId"].ToString().Trim();
                        binLocationStaffs.Add(binLocationStaff);
                    }
                }
                con.Close();
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
                    comboBox3.SelectedIndex = binLocationCodes.IndexOf(binLocationStaffs.First(x => x.StaffId == selectedStaff.StaffId).BinLocationCode);
                }
                else
                {
                    comboBox3.SelectedIndex = -1;
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
            if (name.Equals("") || gender.Equals("") || address.Equals("") || phone.Equals("") || positionCode.Equals("") || areaCode.Equals(""))
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            string binLocationCode = "";
            if (binLocationCodes.Count > 0 && comboBox3.SelectedIndex != -1 && comboBox3.SelectedIndex <= binLocationCodes.Count - 1)
            {
                binLocationCode = binLocationCodes[comboBox3.SelectedIndex];
            }
            SqlConnection con = new SqlConnection(Config.ConnectionString);
            string hashedPassword = password.Length > 0 ? Config.ComputeHash(password, new SHA256CryptoServiceProvider()) : null;
            Console.WriteLine(password);
            string query = "UPDATE Staff SET Name = @Name, Gender = @gender, Phone = @Phone, Address = @Address, AreaCode = @AreaCode, PositionCode = @PositionCode WHERE StaffId = @StaffId";
            if (hashedPassword != null)
            {
                query = "UPDATE Staff SET Name = @Name, Gender = @gender, Password = @Password, Phone = @Phone, Address = @Address, AreaCode = @AreaCode, PositionCode = @PositionCode WHERE StaffId = @StaffId";
            }
            try
            {
                int failed = 0;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StaffId", selectedStaff.StaffId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    if (hashedPassword != null)
                    {
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    }
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@AreaCode", areaCode);
                    cmd.Parameters.AddWithValue("@PositionCode", positionCode);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result < 0)
                    {
                        failed++;
                        Console.WriteLine("Error inserting data into Database!");
                    }
                    con.Close();
                }

                if (!binLocationCode.Equals(""))
                {
                    if (binLocationStaffs.Any(x => x.StaffId == selectedStaff.StaffId))
                    {
                        query = "DELETE FROM BinLocationStaff WHERE StaffId = @StaffId";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@StaffId", selectedStaff.StaffId);
                            con.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result < 0)
                            {
                                failed++;
                                Console.WriteLine("Error delete data from Database!");
                            }
                            con.Close();
                        }
                    }
                    query = "INSERT INTO BinLocationStaff (BinLocationCode, StaffId) VALUES (@BinLocationCode, @StaffId)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BinLocationCode", binLocationCode);
                        cmd.Parameters.AddWithValue("@StaffId", selectedStaff.StaffId);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result < 0)
                        {
                            failed++;
                            Console.WriteLine("Error inserting data into Database!");
                        }
                        con.Close();
                    }
                } else
                {
                    if (binLocationStaffs.Any(x => x.StaffId == selectedStaff.StaffId))
                    {
                        query = "DELETE FROM BinLocationStaff WHERE StaffId = @StaffId";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@StaffId", selectedStaff.StaffId);
                            con.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result < 0)
                            {
                                failed++;
                                Console.WriteLine("Error delete data from Database!");
                            }
                            con.Close();
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
