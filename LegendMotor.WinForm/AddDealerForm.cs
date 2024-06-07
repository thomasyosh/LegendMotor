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
using LegendMotor.Domain.Models;
using LegendMotor.Dal;
using ZstdSharp.Unsafe;
using Serilog;
using Microsoft.EntityFrameworkCore;

namespace LegendMotor.WinForm
{
    public partial class AddDealerForm : Form
    {
        private Dealer dealer;
        private readonly DataContext _ctx;
        public AddDealerForm(Dealer dealer)
        {
            InitializeComponent();
            this.dealer = dealer;
            this._ctx = new DataContext();
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

                if (dealer == null)
                {
                    string query = "SELECT COUNT(*) FROM Dealer";
                    var queryDealer = _ctx.Dealer;
                    int count = queryDealer.Count();
                    count++;
                    string dealerCode = "DE" + count.ToString("00000000");
                    query = "INSERT INTO Dealer (DealerCode, Name, Email, Address, Phone, Fax, Telex) VALUES (@DealerCode, @Name, @Email, @Address, @Phone, @Fax, @Telex)";
                    Dealer dealerAdded = new Dealer();
                    dealerAdded.DealerCode = dealerCode;
                    dealerAdded.Name    =  name;
                    dealerAdded.Email   =  email;
                    dealerAdded.Address =  address;
                    dealerAdded.Phone   =  telephone;
                    dealerAdded.Fax     =  fax;
                    dealerAdded.Telex = telex;
                    try
                    {
                        _ctx.Dealer.Add(dealerAdded);
                        _ctx.SaveChangesAsync();
                        MessageBox.Show("Dealer added successfully");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Failed to add dealer");
                    }
                } else
                {
                    // update dealer
                    Dealer updateDealer = _ctx.Dealer.FirstOrDefault(dealer=>dealer.DealerCode.Equals(dealer.DealerCode));
                    updateDealer.Name      = name;
                    updateDealer.Email     =email;
                    updateDealer.Address   =address;
                    updateDealer.Phone     =telephone;
                    updateDealer.Fax       =fax;
                    updateDealer.Telex     =telex;
                    try
                    {
                    _ctx.Dealer.Update(updateDealer);
                    _ctx.SaveChanges();

                    
                    MessageBox.Show("Dealer updated successfully");
                        
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Failed to update dealer");
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
