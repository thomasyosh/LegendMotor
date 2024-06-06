using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EasyControl
{
    public partial class AddSupplierForm : Form
    {
        private string supplierCode;
        public AddSupplierForm(string supplierCode)
        {
            InitializeComponent();
            this.supplierCode = supplierCode;
            if (supplierCode != null)
            {
                this.Text = "Edit Supplier";
                this.button1.Text = "Save";
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string address = textBox2.Text;
            string phone = textBox3.Text;
            string email = textBox4.Text;
            if (name == "" || address == "" || phone == "" || email == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            try
            {
                if (supplierCode != null)
                {
                    using (SqlConnection con = new SqlConnection(Config.ConnectionString))
                    {
                        string query = "UPDATE Supplier SET Name = '" + name + "', Address = '" + address + "', Phone = '" + phone + "', Email = '" + email + "' WHERE SupplierCode = '" + supplierCode + "'";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        int result = cmd.ExecuteNonQuery();
                        if (result < 0)
                        {
                            Console.WriteLine("Error updating data into Database!");
                        }
                        con.Close();
                    }
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(Config.ConnectionString))
                    {
                        string query = "SELECT COUNT(*) FROM Supplier";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        int count = (int)cmd.ExecuteScalar();
                        count++;
                        string supplierCode = "S" + count.ToString("000000000");
                        con.Close();
                        query = "INSERT INTO Supplier (SupplierCode, Name, Address, Phone, Email) VALUES ('" + supplierCode + "', '" + name + "', '" + address + "', '" + phone + "', '" + email + "')";
                        con.Open();
                        cmd = new SqlCommand(query, con);
                        int result = cmd.ExecuteNonQuery();
                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                        }
                        con.Close();
                    }
                }
                this.Close();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddSupplierForm_Load(object sender, EventArgs e)
        {
            if (supplierCode != null)
            {
                using (SqlConnection con = new SqlConnection(Config.ConnectionString))
                {
                    string query = "SELECT * FROM Supplier WHERE SupplierCode = '" + supplierCode + "'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox1.Text = dr["Name"].ToString();
                        textBox2.Text = dr["Address"].ToString();
                        textBox3.Text = dr["Phone"].ToString();
                        textBox4.Text = dr["Email"].ToString();
                    }
                    con.Close();
                }
            }
        }
    }
}
