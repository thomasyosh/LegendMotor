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
    public partial class IncomingOrderList : Form
    {
        private Form form;
        private List<ListIncomingOrder> incomingOrders = new List<ListIncomingOrder>();
        public IncomingOrderList(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void IncomingOrderList_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            AddDataGridView1Columns();
            if (StaffManager.Instance.GetBinLocationCode() != null)
            {
                GetBinLocationOrders(null, null);
            } else
            {
                GetOrders(null, null);
            }
            
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
                        query += "OrderId = @OrderId";
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        query += "Status = @Status";
                    }
                } else if (!string.IsNullOrEmpty(orderId) && !string.IsNullOrEmpty(status))
                {
                    query += " WHERE OrderId = @OrderId AND Status = @Status";
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

        private void GetBinLocationOrders(string orderId, string status)
        {
            incomingOrders.Clear();
            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                string query = "SELECT IncomingOrder.OrderId AS OrderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, IncomingOrder.Status AS Status FROM IncomingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId JOIN OrderLine ON OrderLine.OrderHeaderId = OrderHeader.OrderHeaderId JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId WHERE BinLocation_Spare.BinLocationCode = @BinLocationCode";
                if (!string.IsNullOrEmpty(orderId) || !string.IsNullOrEmpty(status))
                {
                    if (!string.IsNullOrEmpty(orderId))
                    {
                        query += " AND OrderId = @OrderId";
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        query += " AND Status = @Status";
                    }
                }
                else if (!string.IsNullOrEmpty(orderId) && !string.IsNullOrEmpty(status))
                {
                    query += " AND OrderId = @OrderId AND Status = @Status";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BinLocationCode", StaffManager.Instance.GetBinLocationCode());
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

            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            new DataGridViewComboBoxColumn();

            statusColumn.Items.Add("Pending");
            statusColumn.Items.Add("Picking up");
            statusColumn.Items.Add("Ready");
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.ReadOnly = true;
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

        private void IncomingOrderList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                this.Hide();
                IncomingOrderDetails incomingOrderDetails = new IncomingOrderDetails(incomingOrders[e.RowIndex].OrderId);
                incomingOrderDetails.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                incomingOrderDetails.Show();

            }
            else if (e.ColumnIndex == 4)
            {
                MessageBox.Show("Update button clicked");
            }
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StaffManager.Instance.GetBinLocationCode() != null)
            {
                GetBinLocationOrders(textBox1.Text, comboBox1.Text);
            }
            else
            {
                GetOrders(textBox1.Text, comboBox1.Text);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            if (StaffManager.Instance.GetBinLocationCode() != null)
            {
                GetBinLocationOrders(null, null);
            }
            else
            {
                GetOrders(null, null);
            }
        }
    }
}
