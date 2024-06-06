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
    public partial class DealerOrder : Form
    {
        private Form form;
        private List<Model.Dealer> dealers = new List<Model.Dealer>();
        private List<ListIncomingOrder> incomingOrders = new List<ListIncomingOrder>();
        private string dealerCode;
        private string status = "";
        public DealerOrder(Form form, string dealerCode)
        {
            InitializeComponent();
            this.form = form;
            this.dealerCode = dealerCode;
        }

        private void DealerOrder_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
            GetDealers();
        }

        private void GetDealers()
        {
            dealers.Clear();
            string query = "SELECT * FROM Dealer";
            using (SqlConnection con = new SqlConnection(Config.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
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
                        dealers.Add(dealer);
                        comboBox1.Items.Add(dealer.Name);
                    }
                }
                con.Close();
            }
            if (dealerCode != null)
            {
                comboBox1.SelectedIndex = dealers.FindIndex(x => x.DealerCode == dealerCode);
            } else
            {
                GetOrders();
            }
        }

        private void AddDataGridViewColumns()
        {
            DataGridViewTextBoxColumn orderNoColumn = new DataGridViewTextBoxColumn();
            orderNoColumn.Name = "Order No";
            orderNoColumn.DataPropertyName = "OrderNo";
            orderNoColumn.ReadOnly = true;
            orderNoColumn.HeaderText = "Order No";
            orderNoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            orderNoColumn.MinimumWidth = 400;

            DataGridViewTextBoxColumn orderDateColumn = new DataGridViewTextBoxColumn();
            orderDateColumn.Name = "Order Date";
            orderDateColumn.DataPropertyName = "OrderDate";
            orderDateColumn.ReadOnly = true;
            orderDateColumn.HeaderText = "OrderDate";

            DataGridViewTextBoxColumn updateColumn = new DataGridViewTextBoxColumn();
            updateColumn.Name = "Last Update";
            updateColumn.DataPropertyName = "Last Update";
            updateColumn.ReadOnly = true;
            updateColumn.HeaderText = "Last Update";

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.DataPropertyName = "Status";
            statusColumn.ReadOnly = true;
            statusColumn.HeaderText = "Status";

            DataGridViewButtonColumn detailsButton = new DataGridViewButtonColumn();
            detailsButton.Text = "Details";
            detailsButton.UseColumnTextForButtonValue = true;
            detailsButton.Width = 100;
            detailsButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewButtonColumn invoiceButton = new DataGridViewButtonColumn();
            invoiceButton.Text = "Invoice";
            invoiceButton.UseColumnTextForButtonValue = true;
            invoiceButton.Width = 100;
            invoiceButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns.Add(orderNoColumn);
            dataGridView1.Columns.Add(orderDateColumn);
            dataGridView1.Columns.Add(updateColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(detailsButton);
            dataGridView1.Columns.Add(invoiceButton);
        }

        private void GetOrders()
        {
            incomingOrders.Clear();
            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                string query = "SELECT IncomingOrder.OrderId AS OrderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, IncomingOrder.Status AS Status FROM IncomingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId JOIN Staff ON IncomingOrder.StaffId = Staff.StaffId WHERE Staff.AreaCode = @AreaCode ORDER BY OrderHeader.CreatedAt ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AreaCode", StaffManager.Instance.GetStaffArea());
                if (dealerCode != null && status != "")
                {
                    query = "SELECT IncomingOrder.OrderId AS OrderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, IncomingOrder.Status AS Status FROM IncomingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId JOIN Staff ON IncomingOrder.StaffId = Staff.StaffId WHERE Staff.AreaCode = @AreaCode AND IncomingOrder.DealerCode = @DealerCode AND IncomingOrder.Status = @Status ORDER BY OrderHeader.CreatedAt ASC";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DealerCode", dealerCode);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@AreaCode", StaffManager.Instance.GetStaffArea());
                }
                else if (status != "")
                {
                    query = "SELECT IncomingOrder.OrderId AS OrderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, IncomingOrder.Status AS Status FROM IncomingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId JOIN Staff ON IncomingOrder.StaffId = Staff.StaffId WHERE Staff.AreaCode = @AreaCode AND IncomingOrder.Status = @Status ORDER BY OrderHeader.CreatedAt ASC";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@AreaCode", StaffManager.Instance.GetStaffArea());
                }
                else if (dealerCode != null)
                {
                    query = "SELECT IncomingOrder.OrderId AS OrderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, IncomingOrder.Status AS Status FROM IncomingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId JOIN Staff ON IncomingOrder.StaffId = Staff.StaffId WHERE Staff.AreaCode = @AreaCode AND IncomingOrder.DealerCode = @DealerCode ORDER BY OrderHeader.CreatedAt ASC";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DealerCode", dealerCode);
                    cmd.Parameters.AddWithValue("@AreaCode", StaffManager.Instance.GetStaffArea());
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
                        dataGridView1.Rows.Add(incomingOrder.OrderId, incomingOrder.CreatedAt.ToString("yyyy-MM-dd HH:mm"), incomingOrder.UpdatedAt.ToString("yyyy-MM-dd HH:mm"), incomingOrder.Status);
                    }
                }
                conn.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                dealerCode = dealers[comboBox1.SelectedIndex].DealerCode;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                this.Hide();
                Guid orderId = (Guid)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                IncomingOrderDetails form = new IncomingOrderDetails(orderId);
                form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                form.Show();
            } else if (e.ColumnIndex == 5)
            {
                this.Hide();
                Guid orderId = (Guid)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                Invoice form = new Invoice(orderId);
                form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                form.ShowDialog();
            }
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            GetOrders();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            GetOrders();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = comboBox2.SelectedItem.ToString();
        }
    }
}
