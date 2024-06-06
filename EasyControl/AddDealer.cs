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

namespace EasyControl
{
    public partial class AddDealer : Form
    {
        private Model.Dealer dealer;
        public AddDealer(Model.Dealer dealer)
        {
            InitializeComponent();
            this.dealer = dealer;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string address = txt_addres.Text;
            string telephone = textBox3.Text;
            string fax = textBox4.Text;
            string telex = textBox5.Text;

            if (name == "")
            {
                MessageBox.Show("Name is required");
                return;
            }
            if (address == "")
            {
                MessageBox.Show("Address is required");
                return;
            }
            using (SqlConnection con = new SqlConnection(Config.ConnectionString))
            {
                if (dealer == null)
                {
                    string query = "SELECT COUNT(*) FROM Dealer";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = (int)cmd.ExecuteScalar();
                    count++;
                    string dealerCode = "DE" + count.ToString("00000000");

                    query = "INSERT INTO Dealer (DealerCode, Name, Email, Address, Phone, Fax, Telex) VALUES (@DealerCode, @Name, @Email, @Address, @Phone, @Fax, @Telex)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@DealerCode", dealerCode);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Phone", telephone);
                    cmd.Parameters.AddWithValue("@Fax", fax);
                    cmd.Parameters.AddWithValue("@Telex", telex);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Dealer added successfully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add dealer");
                    }
                } else
                {
                    // update dealer
                    string query = "UPDATE Dealer SET Name = @Name, Email = @Email, Address = @Address, Phone = @Phone, Fax = @Fax, Telex = @Telex WHERE DealerCode = @DealerCode";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@DealerCode", dealer.DealerCode);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Phone", telephone);
                    cmd.Parameters.AddWithValue("@Fax", fax);
                    cmd.Parameters.AddWithValue("@Telex", telex);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Dealer updated successfully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update dealer");
                    }
                }
            }
        }

        private void AddDealer_Load(object sender, EventArgs e)
        {
            if (dealer != null)
            {
                textBox1.Text = dealer.Name;
                textBox2.Text = dealer.Email;
                txt_addres.Text = dealer.Address;
                textBox3.Text = dealer.Phone;
                textBox4.Text = dealer.Fax;
                textBox5.Text = dealer.Telex;
                this.Text = "Update Dealer";
                btn_add.Text = "Update";
            }
        }
    }
}
