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

namespace EasyControl
{
    public partial class CreateStaffForm : Form
    {
        private List<string> positionCodes = new List<string>();
        private List<string> binLocationCodes = new List<string>();
        private List<string> areaCodes = new List<string>();
        private string gender = "";
        public CreateStaffForm()
        {
            InitializeComponent();
        }

        private void CreateStaffForm_Load(object sender, EventArgs e)
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
                        areaCodes.Add(dr["AreaCode"].ToString().Trim());
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
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox4.Text;
            string address = textBox3.Text;
            string phone = textBox2.Text;
            string password = textBox5.Text;
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a position and area");
                return;
            }
            string positionCode = positionCodes[comboBox1.SelectedIndex];
            string areaCode = areaCodes[comboBox2.SelectedIndex];
            if (gender.Equals("") || name.Equals("") || email.Equals("") || address.Equals("") || phone.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            string binLocationCode = "";
            if (positionCode.Equals("storemen") || positionCode.Equals("src"))
            {
                if (comboBox3.SelectedIndex <= -1 || comboBox3.SelectedIndex >= binLocationCodes.Count)
                {
                    MessageBox.Show("Please select a bin location");
                    return;
                }
                binLocationCode = binLocationCodes[comboBox3.SelectedIndex];
            }
            string staffId = Guid.NewGuid().ToString();
            SqlConnection con = new SqlConnection(Config.ConnectionString);
            string hashedPassword = Config.ComputeHash(password, new SHA256CryptoServiceProvider());
            Console.WriteLine(password);
            string query = "INSERT INTO STaff (StaffId, Name, Gender, Email, Password, Phone, Address, AreaCode, PositionCode) VALUES (@StaffId, @Name, @Gender, @Email, @Password, @Phone, @Address, @AreaCode, @PositionCode)";
            try
            {
                int failed = 0;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StaffId", staffId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
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
                    query = "INSERT INTO BinLocationStaff (BinLocationCode, StaffId) VALUES (@BinLocationCode, @StaffId)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BinLocationCode", binLocationCode);
                        cmd.Parameters.AddWithValue("@StaffId", staffId);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result < 0)
                        {
                            failed++;
                            Console.WriteLine("Error inserting data into Database!");
                        }
                        con.Close();
                    }
                }
                if (failed == 0)
                {
                    MessageBox.Show("Staff created successfully");
                    this.Close();
                }
                else
                {
                    Console.WriteLine(failed);
                    MessageBox.Show("Failed to create staff");
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

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = Config.CreatePassword(8);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex <= -1 || comboBox1.SelectedIndex >= positionCodes.Count)
            {
                return;
            }
            if (positionCodes[comboBox1.SelectedIndex].Trim().Equals("storemen") || positionCodes[comboBox1.SelectedIndex].Trim().Equals("src"))
            {
                comboBox3.Visible = true;
                label7.Visible = true;
            }
            else
            {
                comboBox3.Visible = false;
                comboBox3.SelectedIndex = -1;
                label7.Visible = false;
            }
        }
    }
}
