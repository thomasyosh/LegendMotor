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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LegendMotor.Domain.Models;

namespace LegendMotor.WinForm;

public partial class IncomingOrderDetails : Form
{
    private Guid orderId;
    private IncomingOrderDetails incomingOrderDetails;
    private List<BinLocation> binLocations = new List<BinLocation>();
    public IncomingOrderDetails(Guid orderId)
    {
        InitializeComponent();
        this.orderId = orderId;
    }

    private void IncomingOrderDetails_Load(object sender, EventArgs e)
    {/*
        dataGridView1.AllowUserToResizeColumns = false;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        GetBinLocations();
        AddDataGridViewColumns();
        GetOrderDetails();
        if (StaffManager.Instance.GetStaffPosition() == "dm")
        {
            comboBox1.Enabled = false;
            richTextBox1.Enabled = false;
            btn_update.Enabled = false;
        }
        if (incomingOrderDetails.Status == "Completed")
        {
            comboBox1.Enabled = false;
            richTextBox1.Enabled = false;
            btn_update.Enabled = false;
        }
    }

    private void GetBinLocations()
    {
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            string query = "SELECT * FROM BinLocation";
            SqlCommand cmd = new SqlCommand(query, con);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    BinLocation binLocation = new BinLocation();
                    binLocation.BinLocationCode = dr["BinLocationCode"].ToString().Trim();
                    binLocation.Name = dr["Name"].ToString();
                    binLocation.Address = dr["Address"].ToString();

                    binLocations.Add(binLocation);
                }
            }
            con.Close();
        }
    }

    private void GetOrderDetails()
    {
        using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
        {
            conn.Open();
            string query = "SELECT * FROM IncomingOrder WHERE OrderId = @OrderId";
            string dealerCode = "";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        incomingOrderDetails = new Model.IncomingOrderDetails();
                        incomingOrderDetails.OrderId = Guid.Parse(dr["OrderId"].ToString().Trim());
                        incomingOrderDetails.OrderHeaderId = Guid.Parse(dr["OrderHeaderId"].ToString().Trim());
                        incomingOrderDetails.Status = dr["Status"].ToString();
                        incomingOrderDetails.Remark = dr["Remark"].ToString();
                        incomingOrderDetails.StaffId = dr["StaffId"].ToString();
                        incomingOrderDetails.InvoiceName = dr["InvoiceName"].ToString();
                        incomingOrderDetails.InvoiceAddress = dr["InvoiceAddress"].ToString();
                        incomingOrderDetails.DeliveryAddress = dr["DeliveryAddress"].ToString();

                        dealerCode = dr["DealerCode"].ToString().Trim();
                    }
                }
            }
            query = "SELECT Name FROM Staff WHERE StaffId = @StaffId";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StaffId", incomingOrderDetails.StaffId);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        incomingOrderDetails.StaffName = dr["Name"].ToString();
                    }
                }
            }

            query = "SELECT * FROM OrderHeader WHERE OrderHeaderId = @OrderHeaderId";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@OrderHeaderId", incomingOrderDetails.OrderHeaderId);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        incomingOrderDetails.CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString());
                        incomingOrderDetails.UpdatedAt = DateTime.Parse(dr["UpdatedAt"].ToString());
                    }
                }
            }
            query = "SELECT * FROM Dealer WHERE DealerCode = @DealerCode";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@DealerCode", dealerCode);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model.Dealer dealer = new Model.Dealer();
                        dealer.DealerCode = dr["DealerCode"].ToString().Trim();
                        dealer.Name = dr["Name"].ToString();
                        dealer.Email = dr["Email"].ToString();
                        dealer.Phone = dr["Phone"].ToString();
                        dealer.Fax = dr["Fax"].ToString();
                        dealer.Telex = dr["Telex"].ToString();
                        dealer.Address = dr["Address"].ToString();

                        incomingOrderDetails.Dealer = dealer;
                    }
                }
            }

            query = "SELECT OrderLine.LineId AS LineId, OrderLine.Quantity AS Quantity, OrderLine.Status AS Status, OrderLine.SparePartId AS SparePartId, BinLocation_Spare.BinLocationCode AS BinLocationCode, Spare.Price AS Price, Spare.Name AS Name FROM OrderLine JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId JOIN Spare ON Spare.SpareId = BinLocation_Spare.SpareId WHERE OrderLine.OrderHeaderId = @OrderHeaderId";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@OrderHeaderId", incomingOrderDetails.OrderHeaderId);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows) { 
                        incomingOrderDetails.OrderLines = new List<Model.OrderLine>();
                        while (dr.Read())
                        {
                            Model.OrderLine orderLine = new Model.OrderLine();
                            orderLine.LineId = Guid.Parse(dr["LineId"].ToString().Trim());
                            orderLine.OrderHeaderId = incomingOrderDetails.OrderHeaderId;
                            orderLine.SparePartId = Guid.Parse(dr["SparePartId"].ToString().Trim());
                            orderLine.Quantity = int.Parse(dr["Quantity"].ToString());
                            orderLine.BinLocationCode = dr["BinLocationCode"].ToString().Trim();
                            orderLine.Status = dr["Status"].ToString().Trim();
                            orderLine.Price = float.Parse(dr["Price"].ToString());
                            orderLine.Name = dr["Name"].ToString();
                            incomingOrderDetails.OrderLines.Add(orderLine);
                            dataGridView1.Rows.Add(orderLine.Name, binLocations.Find(x => x.BinLocationCode == orderLine.BinLocationCode).Name, orderLine.Price, orderLine.Quantity, orderLine.TotalPrice, orderLine.Status);
                        }
                    }
                }
            }
            conn.Close();

            lbl_dealer_value.Text = incomingOrderDetails.Dealer.Name;
            lbl_deliveryAddress_value.Text = incomingOrderDetails.DeliveryAddress;
            lbl_invoiceAddress_value.Text = incomingOrderDetails.InvoiceAddress;
            lbl_invoiceName_value.Text = incomingOrderDetails.InvoiceName;
            comboBox1.SelectedIndex = comboBox1.FindStringExact(incomingOrderDetails.Status);
            richTextBox1.Text = incomingOrderDetails.Remark;
            lbl_orderDate.Text = "Order date: " + incomingOrderDetails.CreatedAt.ToString("yyyy-MM-dd");
            lbl_staff.Text = "Staff: " + incomingOrderDetails.StaffName;
        }
    }

    private void AddDataGridViewColumns()
    {
        DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
        nameColumn.Name = "Name";
        nameColumn.DataPropertyName = "Name";
        nameColumn.ReadOnly = true;
        nameColumn.HeaderText = "Name";
        nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        nameColumn.MinimumWidth = 100;

        DataGridViewTextBoxColumn locationColumn = new DataGridViewTextBoxColumn();
        locationColumn.Name = "Location";
        locationColumn.DataPropertyName = "Location";
        locationColumn.ReadOnly = true;
        locationColumn.HeaderText = "Location";
        locationColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        locationColumn.MinimumWidth = 200;

        DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
        priceColumn.Name = "Price";
        priceColumn.DataPropertyName = "Price";
        priceColumn.ReadOnly = true;
        priceColumn.HeaderText = "Price";
        priceColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
        quantityColumn.Name = "Quantity";
        quantityColumn.DataPropertyName = "Quantity";
        quantityColumn.ReadOnly = false;
        quantityColumn.HeaderText = "Quantity";
        quantityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();
        subTotalColumn.Name = "SubTotal";
        subTotalColumn.DataPropertyName = "SubTotal";
        subTotalColumn.ReadOnly = true;
        subTotalColumn.HeaderText = "SubTotal";
        subTotalColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
        statusColumn.Name = "Status";
        statusColumn.DataPropertyName = "Status";
        statusColumn.ReadOnly = true;
        statusColumn.HeaderText = "Status";
        statusColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        dataGridView1.Columns.Add(nameColumn);
        dataGridView1.Columns.Add(locationColumn);
        dataGridView1.Columns.Add(priceColumn);
        dataGridView1.Columns.Add(quantityColumn);
        dataGridView1.Columns.Add(subTotalColumn);
        dataGridView1.Columns.Add(statusColumn);
    }

    private void btn_update_Click(object sender, EventArgs e)
    {
        string status = comboBox1.SelectedItem.ToString();
        if (status == incomingOrderDetails.Status)
        {
            return;
        }
        using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
        {
            conn.Open();
            string query = "UPDATE IncomingOrder SET Status = @Status WHERE OrderId = @OrderId";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        this.Close();
    }*/
    }
}
