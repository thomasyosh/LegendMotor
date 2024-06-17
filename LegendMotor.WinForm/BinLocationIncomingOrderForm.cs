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
    public partial class BinLocationIncomingOrderForm : Form
    {
        private Form form;
        private List<ListIncomingOrder> incomingOrders = new List<ListIncomingOrder>();
        private List<OrderLine> orderLines = new List<OrderLine>();
        public BinLocationIncomingOrderForm(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void BinLocationIncomingOrderForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            AddDataGridView1Columns();
            GetOrders(null);
        }

        private void GetOrders(string orderId)
        {
            incomingOrders.Clear();
            dataGridView1.Rows.Clear();
            orderLines.Clear();
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                string query = "SELECT IncomingOrder.OrderId AS OrderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, IncomingOrder.Status AS Status, IncomingOrder.OrderHeaderId AS OrderHeaderId FROM IncomingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId WHERE IncomingOrder.Status != 'Completed'";
                if (!string.IsNullOrEmpty(orderId))
                {
                    if (!string.IsNullOrEmpty(orderId))
                    {
                        query += " AND IncomingOrder.OrderId Like %@OrderId%";
                    }
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(orderId))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                }
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListIncomingOrder incomingOrder = new ListIncomingOrder();
                        incomingOrder.OrderId = Guid.Parse(dr["OrderId"].ToString().Trim());
                        incomingOrder.CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString().Trim());
                        incomingOrder.UpdatedAt = DateTime.Parse(dr["UpdatedAt"].ToString().Trim());
                        incomingOrder.OrderHeaderId = Guid.Parse(dr["OrderHeaderId"].ToString().Trim());
                        incomingOrder.Status = dr["Status"].ToString().Trim();

                        incomingOrders.Add(incomingOrder);
                    
                        query = "SELECT OrderLine.LineId AS LineId, OrderLine.Quantity AS Quantity, OrderLine.Status AS Status, OrderLine.SparePartId AS SparePartId, BinLocation_Spare.BinLocationCode AS BinLocationCode, Spare.Name AS Name, Spare.SpareId AS SpareId FROM OrderLine JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId JOIN Spare ON Spare.SpareId = BinLocation_Spare.SpareId WHERE OrderLine.OrderHeaderId = @OrderHeaderId";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@OrderHeaderId", incomingOrder.OrderHeaderId);
                        cmd.Parameters.AddWithValue("@BinLocationCode", StaffManager.Instance.GetBinLocationCode());
                        using (SqlDataReader dr2 = cmd.ExecuteReader())
                        {
                            if (dr2.HasRows)
                            {
                                incomingOrder.OrderLines = new List<OrderLine>();
                                while (dr2.Read())
                                {
                                    OrderLine orderLine = new OrderLine();
                                    orderLine.LineId = Guid.Parse(dr2["LineId"].ToString().Trim());
                                    orderLine.Quantity = int.Parse(dr2["Quantity"].ToString().Trim());
                                    orderLine.Status = dr2["Status"].ToString().Trim();
                                    orderLine.SparePartId = Guid.Parse(dr2["SparePartId"].ToString().Trim());
                                    orderLine.BinLocationCode = dr2["BinLocationCode"].ToString().Trim();
                                    orderLine.Name = dr2["Name"].ToString().Trim();
                                    orderLine.SpareId = dr2["SpareId"].ToString().Trim();
                                    orderLine.OrderHeaderId = incomingOrder.OrderHeaderId;
                                    incomingOrder.OrderLines.Add(orderLine);
                                    if (orderLine.BinLocationCode == StaffManager.Instance.GetBinLocationCode())
                                    {
                                        orderLines.Add(orderLine);
                                        dataGridView1.Rows.Add(incomingOrder.OrderId, orderLine.SpareId, orderLine.Name, incomingOrder.CreatedAt, orderLine.Status);
                                    }
                                }
                            }
                        }
                    }
                }
                conn.Close();
            }
        }
        private void AddDataGridView1Columns()
        {
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Order ID";
            idColumn.DataPropertyName = "Order ID";
            idColumn.ReadOnly = true;
            idColumn.HeaderText = "Order ID";
            idColumn.MinimumWidth = 200;

            DataGridViewTextBoxColumn orderColumn = new DataGridViewTextBoxColumn();
            orderColumn.Name = "Spare ID";
            orderColumn.DataPropertyName = "Spare ID";
            orderColumn.ReadOnly = true;
            orderColumn.HeaderText = "Spare ID";
            orderColumn.MinimumWidth = 100;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.HeaderText = "Name";
            nameColumn.MinimumWidth = 100;

            DataGridViewTextBoxColumn orderDateColumn = new DataGridViewTextBoxColumn();
            orderDateColumn.Name = "Order Date";
            orderDateColumn.DataPropertyName = "Order Date";
            orderDateColumn.ReadOnly = true;
            orderDateColumn.HeaderText = "Order Date";
            orderDateColumn.Width = 150;

            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            new DataGridViewComboBoxColumn();

            statusColumn.Items.Add("Available");
            statusColumn.Items.Add("Pending");
            statusColumn.Items.Add("Picking up");
            statusColumn.Items.Add("Ready");
            statusColumn.Name = "Item Status";
            statusColumn.HeaderText = "Item Status";
            statusColumn.ReadOnly = false;
            statusColumn.Width = 100;

            DataGridViewButtonColumn detailsButton = new DataGridViewButtonColumn();
            detailsButton.Text = "Details";
            detailsButton.UseColumnTextForButtonValue = true;
            detailsButton.Width = 100;
            detailsButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewButtonColumn updateButton = new DataGridViewButtonColumn();
            updateButton.Text = "Update";
            updateButton.UseColumnTextForButtonValue = true;
            updateButton.Width = 100;
            updateButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns.Add(idColumn);
            dataGridView1.Columns.Add(orderColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(orderDateColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(detailsButton);
            dataGridView1.Columns.Add(updateButton);
        }

        private void BinLocationIncomingOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            GetOrders(null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetOrders(textBox1.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                this.Hide();
                AddSpareForm form = new AddSpareForm(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                form.ShowDialog();
            }
            else if (e.ColumnIndex == 6)
            {
                string status = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                OrderLine orderLine = orderLines[e.RowIndex];
                ListIncomingOrder incomingOrderDetails = incomingOrders.Find(x => x.OrderHeaderId == orderLine.OrderHeaderId);
                using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE OrderLine SET Status = @Status WHERE LineId = @LineId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@LineId", orderLines[e.RowIndex].LineId);
                    cmd.ExecuteNonQuery();

                    query = "UPDATE IncomingOrder SET Status = @Status WHERE OrderHeaderId = @OrderHeaderId";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", "Processing");
                    cmd.Parameters.AddWithValue("@OrderHeaderId", incomingOrderDetails.OrderHeaderId);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                 if (status == "Ready")
                {
                    using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
                    {
                        conn.Open();
                        int index = incomingOrderDetails.OrderLines.FindIndex(x => x.LineId == orderLine.LineId);
                        incomingOrderDetails.OrderLines[index].Status = "Ready";
                        bool isAllReady = true;
                        foreach (OrderLine line in incomingOrderDetails.OrderLines)
                        {
                            if (line.Status != "Ready")
                            {
                                isAllReady = false;
                                break;
                            }
                        }
                        if (isAllReady)
                        {
                            string query = "UPDATE IncomingOrder SET Status = @Status WHERE OrderHeaderId = @OrderHeaderId";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@Status", "Ready");
                            cmd.Parameters.AddWithValue("@OrderHeaderId", incomingOrderDetails.OrderHeaderId);
                            cmd.ExecuteNonQuery();
                        }

                        conn.Close();
                    }
                }
                using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE OrderHeader SET UpdatedAt = @UpdatedAt WHERE OrderHeaderId = @OrderHeaderId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@OrderHeaderId", orderLines[e.RowIndex].OrderHeaderId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                GetOrders(textBox1.Text);
            }
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
