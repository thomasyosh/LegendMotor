using LegendMotor.Domain.Models;
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

namespace LegendMotor.WinForm
{
    public partial class Invoice : Form
    {
        private InvoiceDetails invoice = new InvoiceDetails();
        public Invoice(Guid orderId)
        {
            InitializeComponent();
            invoice.OrderId = orderId;
        }

        private void GetInvoiceDetails()
        {
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM IncomingOrder WHERE OrderId = @OrderId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", invoice.OrderId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            invoice.OrderId = Guid.Parse(dr["OrderId"].ToString().Trim());
                            invoice.Status = dr["Status"].ToString();
                            invoice.OrderHeaderId = Guid.Parse(dr["OrderHeaderId"].ToString());
                            invoice.InvoiceId = Guid.Parse(dr["InvoiceId"].ToString());
                            invoice.InvoiceName = dr["InvoiceName"].ToString();
                            invoice.InvoiceAddress = dr["InvoiceAddress"].ToString();
                            invoice.DeliveryAddress = dr["DeliveryAddress"].ToString();
                            invoice.StaffId = dr["StaffId"].ToString();
                            invoice.Remark = dr["Remark"].ToString();
                            invoice.Dealer = new Model.Dealer();
                            invoice.Dealer.DealerCode = dr["DealerCode"].ToString();
                        }
                    }
                }

                query = "SELECT OrderLine.LineId AS LineId, OrderLine.Quantity AS Quantity, OrderLine.Status AS Status, OrderLine.SparePartId AS SparePartId, BinLocation_Spare.BinLocationCode AS BinLocationCode, Spare.Name AS Name, Spare.SpareId AS SpareId, Spare.Price AS Price, Spare.Weight AS Weight FROM OrderLine JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId JOIN Spare ON Spare.SpareId = BinLocation_Spare.SpareId WHERE OrderLine.OrderHeaderId = @OrderHeaderId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderHeaderId", invoice.OrderHeaderId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        invoice.OrderLines = new List<OrderLine>();
                        while (dr.Read())
                        {
                            OrderLine orderLine = new OrderLine();
                            orderLine.LineId = Guid.Parse(dr["LineId"].ToString().Trim());
                            orderLine.Quantity = int.Parse(dr["Quantity"].ToString().Trim());
                            orderLine.Status = dr["Status"].ToString().Trim();
                            orderLine.SparePartId = Guid.Parse(dr["SparePartId"].ToString().Trim());
                            orderLine.BinLocationCode = dr["BinLocationCode"].ToString().Trim();
                            orderLine.Name = dr["Name"].ToString().Trim();
                            orderLine.SpareId = dr["SpareId"].ToString().Trim();
                            orderLine.Price = double.Parse(dr["Price"].ToString().Trim());
                            orderLine.Weight = double.Parse(dr["Weight"].ToString().Trim());
                            invoice.OrderLines.Add(orderLine);
                        }
                    }
                }

                query = "SELECT * FROM Dealer WHERE DealerCode = @DealerCode";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DealerCode", invoice.Dealer.DealerCode);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            invoice.Dealer.DealerCode = dr["DealerCode"].ToString().Trim();
                            invoice.Dealer.Name = dr["Name"].ToString();
                            invoice.Dealer.Email = dr["Email"].ToString();
                            invoice.Dealer.Phone = dr["Phone"].ToString();
                            invoice.Dealer.Fax = dr["Fax"].ToString();
                            invoice.Dealer.Telex = dr["Telex"].ToString();
                            invoice.Dealer.Address = dr["Address"].ToString();
                        }
                    }
                }

                query = "SELECT * FROM Staff WHERE StaffId = @StaffId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", invoice.StaffId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            invoice.StaffName = dr["Name"].ToString().Trim();
                        }
                    }
                }

                query = "SELECT * FROM OrderHeader WHERE OrderHeaderId = @OrderHeaderId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderHeaderId", invoice.OrderHeaderId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            invoice.CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString().Trim());
                            invoice.UpdatedAt = DateTime.Parse(dr["UpdatedAt"].ToString().Trim());
                        }
                    }
                }

                query = "SELECT * FROM Invoice WHERE InvoiceId = @InvoiceId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@InvoiceId", invoice.InvoiceId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            invoice.InvoiceDate = DateTime.Parse(dr["InvoiceDate"].ToString().Trim());
                            invoice.InvoiceAmount = double.Parse(dr["InvoiceAmount"].ToString().Trim());
                        }
                    }
                }

                conn.Close();
            }
            lbl_deliveryAddress.Text = invoice.DeliveryAddress;
            lbl_invoiceAddress.Text = invoice.InvoiceAddress;
            lbl_orderDate.Text = "Order Date: " + invoice.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
            lbl_orderNo.Text = "Order No: " + invoice.OrderId.ToString();
            lbl_dealer.Text = "Dealer: " + invoice.Dealer.DealerCode + " - " + invoice.Dealer.Name;

            lbl_contact.Text = "Contact: " + invoice.Dealer.Phone;
            double weight = 0;
            double price = 0;
            for (int i = 0; i < invoice.OrderLines.Count; i++)
            {
                weight += invoice.OrderLines[i].TotalWeight;
                price += invoice.OrderLines[i].TotalPrice;
                listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), invoice.OrderLines[i].Name, invoice.OrderLines[i].Price.ToString(), invoice.OrderLines[i].Quantity.ToString(), invoice.OrderLines[i].TotalPrice.ToString() }));
            }
            lbl_totalWeight.Text = "Total Weight: " + weight.ToString();
            lbl_totalPrice.Text = "Total Price: " + price.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            if (invoice.OrderId != null)
            {
                GetInvoiceDetails();
            }
        }
    }
}
