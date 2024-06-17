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
    public partial class DeliveryIncomingOrderList : Form
    {
        private List<ListIncomingOrder> incomingOrders = new List<ListIncomingOrder>();
        DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
        public DeliveryIncomingOrderList()
        {
            InitializeComponent();
        }

        private void DeliveryIncomingOrderList_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            AddDataGridView1Columns();
            GetOrders(null, null);
        }
        private void AddDataGridView1Columns()
        {
            DataGridViewTextBoxColumn orderColumn = new DataGridViewTextBoxColumn();
            orderColumn.Name = "Order ID";
            orderColumn.DataPropertyName = "Order ID";
            orderColumn.ReadOnly = true;
            orderColumn.HeaderText = "Order ID";
            orderColumn.MinimumWidth = 400;

            DataGridViewTextBoxColumn orderDateColumn = new DataGridViewTextBoxColumn();
            orderDateColumn.Name = "Order Date";
            orderDateColumn.DataPropertyName = "Order Date";
            orderDateColumn.ReadOnly = true;
            orderDateColumn.HeaderText = "Order Date";
            orderDateColumn.Width = 150;

            statusColumn.Items.Add("Ready");
            statusColumn.Items.Add("Shipping");
            statusColumn.Items.Add("Completed");
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
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

            dataGridView1.Columns.Add(orderColumn);
            dataGridView1.Columns.Add(orderDateColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(detailsButton);
            dataGridView1.Columns.Add(updateButton);
        }

        private void GetOrders(string orderId, string status)
        {
            incomingOrders.Clear();
            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                string query = "SELECT IncomingOrder.OrderId AS OrderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, IncomingOrder.Status AS Status FROM IncomingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId";
                if (!string.IsNullOrEmpty(orderId) || !string.IsNullOrEmpty(status))
                {
                    query += " WHERE ";
                    if (!string.IsNullOrEmpty(orderId))
                    {
                        query += " OrderId = @OrderId AND (Status = 'Ready' OR Status = 'Shipping')";
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        query += " Status = @Status";
                    }
                }
                else if (!string.IsNullOrEmpty(orderId) && !string.IsNullOrEmpty(status))
                {
                    query += " WHERE OrderId = @OrderId AND Status = @Status";
                } else
                {
                    query += " WHERE Status = 'Ready' OR Status = 'Shipping'";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(orderId))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                }
                if (!string.IsNullOrEmpty(status))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListIncomingOrder incomingOrder = new ListIncomingOrder();
                        incomingOrder.OrderId = Guid.Parse(dr["OrderId"].ToString().Trim());
                        incomingOrder.CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString().Trim());
                        incomingOrder.UpdatedAt = DateTime.Parse(dr["UpdatedAt"].ToString().Trim());
                        incomingOrder.Status = dr["Status"].ToString().Trim();

                        incomingOrders.Add(incomingOrder);
                        dataGridView1.Rows.Add(incomingOrder.OrderId, incomingOrder.CreatedAt, incomingOrder.Status);
                    }
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetOrders(textBox1.Text, comboBox1.Text);
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ListIncomingOrder order = incomingOrders[e.RowIndex];
            if (e.ColumnIndex == 3)
            {
                IncomingOrderDetails incomingOrderDetails = new IncomingOrderDetails(order.OrderId);
                incomingOrderDetails.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                incomingOrderDetails.ShowDialog();
            }
            else if (e.ColumnIndex == 4)
            {
                string status = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE IncomingOrder SET Status = @Status WHERE OrderId = @OrderId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@OrderId", order.OrderId);
                    cmd.ExecuteNonQuery();

                    query = "UPDATE OrderHeader SET UpdatedAt = @UpdatedAt WHERE OrderHeaderId = @OrderHeaderId";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@OrderHeaderId", order.OrderHeaderId);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                GetOrders(textBox1.Text, comboBox1.Text);
            }
        }
    }
}
