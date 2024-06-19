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
    public partial class PurchasingOrderList : Form
    {
        private Form form;
        private List<PurchasingOrderDetailsForm> purchasingOrders = new List<PurchasingOrderDetailsForm>();
        public PurchasingOrderList(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void PurchasingOrderList_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            AddDataGridView1Columns();
            GetOrders();
        }

        private void GetOrders()
        {
            comboBox1.Items.Clear();
            purchasingOrders.Clear();
            /*using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                string query = "SELECT PurchasingOrder.OrderId AS OrderId, PurchasingOrder.Status AS Status, PurchasingOrder.IncomingOrderId AS IncomingOrderId, Purchasing.OrderHeaderId AS OrderHeaderId" +
                    ", OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt" + 
                    " FROM PurchasingOrder" + 
                    " JOIN OrderHeader ON OrderHeader.OrderHeaderId = PurchasingOrder.OrderHeaderId" +
                    " WHERE PurchasingOrder.Status != 'Completed'";
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    query += " AND OrderHeader.OrderId LIKE @OrderId";
                }
                if (!string.IsNullOrEmpty(comboBox1.Text))
                {
                    query += " AND PurchasingOrder.Status = @Status";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", textBox1.Text);
                    }
                    if (!string.IsNullOrEmpty(comboBox1.Text))
                    {
                        cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
                    }
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Model.PurchasingOrderDetails purchasingOrder = new Model.PurchasingOrderDetails();
                            purchasingOrder.OrderId = Guid.Parse(dr["OrderId"].ToString().Trim());
                            purchasingOrder.Status = dr["Status"].ToString().Trim();
                            purchasingOrder.IncomingOrderId = Guid.Parse(dr["IncomingOrderId"].ToString().Trim());
                            purchasingOrder.OrderHeaderId = Guid.Parse(dr["OrderHeaderId"].ToString().Trim());
                            purchasingOrder.CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString().Trim());
                            purchasingOrder.UpdatedAt = DateTime.Parse(dr["UpdatedAt"].ToString().Trim());
                            purchasingOrders.Add(purchasingOrder);
                            dataGridView1.Rows.Add(purchasingOrder.OrderId, purchasingOrder.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"), purchasingOrder.Status);
                        }
                    }
                }
                conn.Close();
            }*/
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

            statusColumn.Items.Add("Processing");
            statusColumn.Items.Add("Pending");
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

        private void PurchasingOrderList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                this.Hide();
                /*PurchasingOrderDetailsForm purchasingOrderDetails = new PurchasingOrderDetails(purchasingOrders[e.RowIndex].OrderId);
                purchasingOrderDetails.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                purchasingOrderDetails.Show();*/
            } else if (e.ColumnIndex == 4)
            {
                string status = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                /*using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
                {
                    conn.Open();

                    string query = "UPDATE PurchasingOrder SET Status = @Status WHERE OrderHeaderId = @OrderHeaderId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@OrderHeaderId", purchasingOrders[e.RowIndex].OrderHeaderId);
                    cmd.ExecuteNonQuery();

                    query = "UPDATE OrderHeader SET UpdatedAt = @UpdatedAt WHERE OrderHeaderId = @OrderHeaderId";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@OrderHeaderId", purchasingOrders[e.RowIndex].OrderHeaderId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }*/
            }
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetOrders();
        }
    }
}
