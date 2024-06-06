using EasyControl.Model;
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
    public partial class DeliveryPurchasingOrder : Form
    {
        private List<BinLocation> binLocations = new List<BinLocation>();
        private List<ListOrderLine> orderLines = new List<ListOrderLine>();
        public DeliveryPurchasingOrder()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                this.Hide();
                AddSpareForm form = new AddSpareForm(orderLines[e.RowIndex].SpareId);
                form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                form.ShowDialog();
            } else if (e.ColumnIndex == 6)
            {
                Guid lineId = orderLines[e.RowIndex].LineId;
                Guid orderId = orderLines[e.RowIndex].OrderId;
                Guid orderHeaderId = orderLines[e.RowIndex].OrderHeaderId;
                string status = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE OrderLine SET Status = @Status WHERE LineId = @LineId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@LineId", lineId);
                    cmd.ExecuteNonQuery();

                    query = "UPDATE PurchasingOrder SET Status = @Status WHERE OrderId = @OrderId";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", "Processing");
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
                {
                    conn.Open();
                    Guid incomingOrderId = orderLines[e.RowIndex].IncomingOrderId;
                    string query = "SELECT OrderLine.LineId AS LineId, OrderLine.OrderHeaderId AS OrderHeaderId FROM OrderLine JOIN OrderHeader ON OrderLine.OrderHeaderId = OrderHeader.OrderHeaderId JOIN IncomingOrder ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId WHERE IncomingOrder.OrderId = @OrderId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderId", incomingOrderId);
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Guid incomingOrderLineId = Guid.Parse(dr["LineId"].ToString().Trim());
                            Guid incomingOrderHeaderId = Guid.Parse(dr["OrderHeaderId"].ToString().Trim());
                            if (status == "Completed")
                            {
                                query = "UPDATE OrderLine SET Status = @Status WHERE LineId = @LineId";
                                cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@Status", "Ready");
                                cmd.Parameters.AddWithValue("@LineId", incomingOrderLineId);
                                cmd.ExecuteNonQuery();
                            } else
                            {
                                query = "UPDATE IncomingOrder SET Status = 'Processing' WHERE OrderId = @OrderId";
                                cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@OrderId", incomingOrderId);
                                cmd.ExecuteNonQuery();
                            }

                            query = "UPDATE OrderHeader SET UpdatedAt = @UpdatedAt WHERE OrderHeaderId = @OrderHeaderId";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                            cmd.Parameters.AddWithValue("@OrderHeaderId", incomingOrderHeaderId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            comboBox1.SelectedIndex = 0;
            dataGridView1.Rows.Clear();
            orderLines.Clear();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOrderLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetOrderLine();
        }

        private void DeliveryPurchasingOrder_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
            getBinLocations();
        }
        private void AddDataGridViewColumns()
        {
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID";
            idColumn.DataPropertyName = "ID";
            idColumn.ReadOnly = true;
            idColumn.HeaderText = "ID";
            idColumn.MinimumWidth = 300;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.HeaderText = "Name";
            nameColumn.Width = 150;

            DataGridViewTextBoxColumn orderDateColumn = new DataGridViewTextBoxColumn();
            orderDateColumn.Name = "Order Date";
            orderDateColumn.DataPropertyName = "Order Date";
            orderDateColumn.ReadOnly = true;
            orderDateColumn.HeaderText = "Order Date";
            orderDateColumn.Width = 150;

            DataGridViewTextBoxColumn lastUpdateColumn = new DataGridViewTextBoxColumn();
            lastUpdateColumn.Name = "Last Update";
            lastUpdateColumn.DataPropertyName = "Last Update";
            lastUpdateColumn.ReadOnly = true;
            lastUpdateColumn.HeaderText = "Last Update";
            lastUpdateColumn.Width = 150;

            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.DataPropertyName = "Status";
            statusColumn.ReadOnly = false;
            statusColumn.HeaderText = "Status";
            statusColumn.Items.Add("Completed");
            statusColumn.Items.Add("Ready");
            statusColumn.Items.Add("Shipping");

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
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(orderDateColumn);
            dataGridView1.Columns.Add(lastUpdateColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(detailsButton);
            dataGridView1.Columns.Add(updateButton);

        }
        private void getBinLocations()
        {
            using (SqlConnection con = new SqlConnection(Config.ConnectionString))
            {
                string query = "SELECT * FROM BinLocation";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BinLocation binLocation = new BinLocation();
                        binLocation.BinLocationCode = dr["BinLocationCode"].ToString().Trim();
                        binLocation.Name = dr["Name"].ToString();
                        binLocation.Address = dr["Address"].ToString();
                        binLocations.Add(binLocation);
                        comboBox2.Items.Add(dr["Name"].ToString());
                    }
                }
                con.Close();
            }
        }

        private void GetOrderLine()
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a destination");
                return;
            }
            dataGridView1.Rows.Clear();
            orderLines.Clear();
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                string query = "SELECT OrderLine.LineId AS LineId, PurchasingOrder.OrderId AS OrderId, OrderHeader.OrderHeaderId AS OrderHeaderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, OrderLine.Status AS Status, Spare.Name AS Name, Spare.SpareId AS SpareId, BinLocation_Spare.Id AS SparePartId, PurchasingOrder.IncomingOrderId AS IncomingOrderId FROM OrderLine JOIN OrderHeader ON OrderLine.OrderHeaderId = OrderHeader.OrderHeaderId JOIN PurchasingOrder ON OrderHeader.OrderHeaderId = PurchasingOrder.OrderHeaderId JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId JOIN Spare ON BinLocation_Spare.SpareId = Spare.SpareId WHERE BinLocation_Spare.BinLocationCode = @BinLocationCode";
                if (comboBox1.SelectedIndex > 0)
                {
                    query += " AND OrderLine.Status = @Status";
                }
                else
                {
                    query += " AND (OrderLine.Status = 'Ready' OR OrderLine.Status = 'Shipping')";
                }
                if (textBox1.Text != "")
                {
                    query += " AND PurchasingOrder.OrderId LIKE '%" + textBox1.Text + "%'";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BinLocationCode", binLocations[comboBox2.SelectedIndex].BinLocationCode);
                    if (comboBox1.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue("@Status", comboBox1.SelectedItem.ToString());
                    }
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ListOrderLine orderLine = new ListOrderLine();
                            orderLine.LineId = Guid.Parse(dr["LineId"].ToString().Trim());
                            orderLine.OrderId = Guid.Parse(dr["OrderId"].ToString().Trim());
                            orderLine.OrderHeaderId = Guid.Parse(dr["OrderHeaderId"].ToString().Trim());
                            orderLine.CreatedAt = Convert.ToDateTime(dr["CreatedAt"]);
                            orderLine.UpdatedAt = Convert.ToDateTime(dr["UpdatedAt"]);
                            orderLine.Status = dr["Status"].ToString();
                            orderLine.Name = dr["Name"].ToString();
                            orderLine.SpareId = dr["SpareId"].ToString();
                            orderLine.SparePartId = Guid.Parse(dr["SparePartId"].ToString().Trim());
                            orderLine.IncomingOrderId = Guid.Parse(dr["IncomingOrderId"].ToString().Trim());
                            orderLines.Add(orderLine);
                            dataGridView1.Rows.Add(orderLine.LineId, orderLine.Name, orderLine.CreatedAt, orderLine.UpdatedAt, orderLine.Status);
                        }
                    }
                }
            }

        }
    }
}
