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
    public partial class UpdateStockForm : Form
    {
        private LoginForm loginForm;
        private List<string> orders = new List<string>();
        private List<Model.PurchasingOrderDetails> purchasingOrders = new List<Model.PurchasingOrderDetails>();
        public UpdateStockForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void UpdateStockForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
            GetBinLocationOrders();
        }

        private void GetBinLocationOrders()
        {
            comboBox1.Items.Clear();
            orders.Clear();
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                string query = "SELECT PurchasingOrder.OrderId FROM PurchasingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = PurchasingOrder.OrderHeaderId JOIN OrderLine ON OrderLine.OrderHeaderId = OrderHeader.OrderHeaderId JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId WHERE BinLocation_Spare.BinLocationCode = @BinLocationCode AND PurchasingOrder.Status != 'Completed'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BinLocationCode", StaffManager.Instance.GetBinLocationCode());
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        orders.Add(dr["OrderId"].ToString().Trim());
                    }
                }
                conn.Close();
            }
            comboBox1.Items.AddRange(orders.ToArray());
        }

        private void GetBinLocationOrders(string orderId)
        {
            purchasingOrders.Clear();
            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                Model.PurchasingOrderDetails purchasingOrder = new Model.PurchasingOrderDetails();
                conn.Open();
                string query = "SELECT * FROM PurchasingOrder WHERE OrderId = @OrderId AND Status != 'Completed'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            purchasingOrder.OrderId = Guid.Parse(dr["OrderId"].ToString().Trim());
                            purchasingOrder.Status = dr["Status"].ToString().Trim();
                            purchasingOrder.IncomingOrderId = Guid.Parse(dr["IncomingOrderId"].ToString().Trim());
                            purchasingOrder.OrderHeaderId = Guid.Parse(dr["OrderHeaderId"].ToString().Trim());

                            purchasingOrders.Add(purchasingOrder);
                        }
                    }
                }

                query = "SELECT * FROM OrderHeader WHERE OrderHeaderId = @OrderHeaderId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderHeaderId", purchasingOrder.OrderHeaderId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            purchasingOrder.CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString());
                            purchasingOrder.UpdatedAt = DateTime.Parse(dr["UpdatedAt"].ToString());
                        }
                    }
                }

                query = "SELECT OrderLine.LineId AS LineId, OrderLine.Quantity AS Quantity, OrderLine.Status AS Status, OrderLine.SparePartId AS SparePartId, BinLocation_Spare.BinLocationCode AS BinLocationCode, Spare.Price AS Price, Spare.Name AS Name, Spare.SpareId AS SpareId FROM OrderLine JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId JOIN Spare ON Spare.SpareId = BinLocation_Spare.SpareId WHERE OrderLine.OrderHeaderId = @OrderHeaderId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderHeaderId", purchasingOrder.OrderHeaderId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            purchasingOrder.OrderLines = new List<Model.OrderLine>();
                            while (dr.Read())
                            {
                                Model.OrderLine orderLine = new Model.OrderLine();
                                orderLine.LineId = Guid.Parse(dr["LineId"].ToString().Trim());
                                orderLine.OrderHeaderId = purchasingOrder.OrderHeaderId;
                                orderLine.SparePartId = Guid.Parse(dr["SparePartId"].ToString().Trim());
                                orderLine.Quantity = int.Parse(dr["Quantity"].ToString());
                                orderLine.BinLocationCode = dr["BinLocationCode"].ToString().Trim();
                                orderLine.Status = dr["Status"].ToString().Trim();
                                orderLine.Price = float.Parse(dr["Price"].ToString());
                                orderLine.Name = dr["Name"].ToString();
                                orderLine.SpareId = dr["SpareId"].ToString().Trim();
                                purchasingOrder.OrderLines.Add(orderLine);
                                if (orderLine.Status.Equals("Completed") && orderLine.BinLocationCode.Equals(StaffManager.Instance.GetBinLocationCode()))
                                {
                                    dataGridView1.Rows.Add(orderLine.SpareId, orderLine.Name, orderLine.Quantity, 0, 0);
                                }
                            }
                        }
                    }
                }
                conn.Close();
            }
        }
        private void AddDataGridViewColumns()
        {
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Spare ID";
            idColumn.DataPropertyName = "Spare ID";
            idColumn.ReadOnly = true;
            idColumn.HeaderText = "Spare ID";
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            idColumn.MinimumWidth = 100;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.HeaderText = "Name";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.MinimumWidth = 200;

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.Name = "Quantity";
            quantityColumn.DataPropertyName = "Quantity";
            quantityColumn.ReadOnly = true;
            quantityColumn.HeaderText = "Quantity";
            quantityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn discrepancyColumn = new DataGridViewTextBoxColumn();
            discrepancyColumn.Name = "Discrepancy";
            discrepancyColumn.DataPropertyName = "Discrepancy";
            discrepancyColumn.ReadOnly = false;
            discrepancyColumn.HeaderText = "Discrepancy";
            discrepancyColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn scrapColumn = new DataGridViewTextBoxColumn();
            scrapColumn.Name = "Scarp";
            scrapColumn.DataPropertyName = "Scarp";
            scrapColumn.ReadOnly = false;
            scrapColumn.HeaderText = "Scarp";
            scrapColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridView1.Columns.Add(idColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(quantityColumn);
            dataGridView1.Columns.Add(discrepancyColumn);
            dataGridView1.Columns.Add(scrapColumn);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 3 || dataGridView1.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex <= -1 || comboBox1.SelectedIndex >= orders.Count)
            {
                return;
            }
            GetBinLocationOrders(orders[comboBox1.SelectedIndex]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                Model.PurchasingOrderDetails purchasingOrder = purchasingOrders[comboBox1.SelectedIndex];
                foreach (OrderLine orderLine in purchasingOrder.OrderLines)
                {
                    int index = dataGridView1.Rows.IndexOf(dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Spare ID"].Value.ToString().Equals(orderLine.SpareId)).FirstOrDefault());
                    if (index == -1)
                    {
                        continue;
                    }
                    int discrepancy = int.Parse(dataGridView1.Rows[index].Cells["Discrepancy"].Value.ToString());
                    int scrap = int.Parse(dataGridView1.Rows[index].Cells["Scarp"].Value.ToString());
                    int grn = orderLine.Quantity + discrepancy - scrap;
                    Console.WriteLine("Discrepancy: " + discrepancy + " Scrap: " + scrap + " GRN: " + grn);
                    string query = "UPDATE OrderLine SET Status = @Status, GRN = @GRN WHERE LineId = @LineId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", "Completed");
                        cmd.Parameters.AddWithValue("@LineId", orderLine.LineId);
                        cmd.Parameters.AddWithValue("@GRN", grn);
                        cmd.ExecuteNonQuery();
                    }

                    query = "SELECT COUNT(*) FROM OrderLine WHERE OrderHeaderId = @OrderHeaderId AND Status != 'Completed'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderHeaderId", purchasingOrder.OrderHeaderId);
                        int count = (int)cmd.ExecuteScalar();
                        if (count == 0)
                        {
                            query = "UPDATE PurchasingOrder SET Status = @Status WHERE OrderId = @OrderId";
                            using (SqlCommand cmd2 = new SqlCommand(query, conn))
                            {
                                cmd2.Parameters.AddWithValue("@Status", "Completed");
                                cmd2.Parameters.AddWithValue("@OrderId", purchasingOrder.OrderId);
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }

                    query = "UPDATE OrderHeader SET UpdatedAt = @UpdatedAt WHERE OrderHeaderId = @OrderHeaderId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@OrderHeaderId", purchasingOrder.OrderHeaderId);
                        cmd.ExecuteNonQuery();
                    }

                    query = "UPDATE BinLocation_Spare SET Stock = Stock + @Stock WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Stock", grn);
                        cmd.Parameters.AddWithValue("@Id", orderLine.SparePartId);
                        cmd.ExecuteNonQuery();
                    }

                    if (purchasingOrder.IncomingOrderId != null)
                    {
                        query = "SELECT * FROM IncomingOrder WHERE OrderId = @OrderId";
                        Model.IncomingOrderDetails incomingOrderDetails = new Model.IncomingOrderDetails();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@OrderId", purchasingOrder.IncomingOrderId);
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    incomingOrderDetails.OrderId = Guid.Parse(dr["OrderId"].ToString().Trim());
                                    incomingOrderDetails.OrderHeaderId = Guid.Parse(dr["OrderHeaderId"].ToString().Trim());
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

                        query = "SELECT OrderLine.LineId AS LineId, OrderLine.SparePartId AS SparePartId FROM OrderLine JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId JOIN Spare ON Spare.SpareId = BinLocation_Spare.SpareId WHERE OrderLine.OrderHeaderId = @OrderHeaderId AND BinLocation_Spare.SpareId = @SpareId AND BinLocation_Spare.BinLocationCode = @BinLocationCode";

                        Guid LineId = Guid.Empty;
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@OrderHeaderId", incomingOrderDetails.OrderHeaderId);
                            cmd.Parameters.AddWithValue("@SpareId", orderLine.SpareId);
                            cmd.Parameters.AddWithValue("@BinLocationCode", StaffManager.Instance.GetBinLocationCode());
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        LineId = Guid.Parse(dr["LineId"].ToString().Trim());
                                        
                                    }
                                }
                            }
                        }

                        query = "UPDATE OrderLine SET Status = @Status WHERE LineId = @LineId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Status", "Available");
                            cmd.Parameters.AddWithValue("@LineId", LineId);
                            cmd.ExecuteNonQuery();
                        }

                        //query = "SELECT * FROM OrderLine WHERE OrderHeaderId = @OrderHeaderId";
                        //bool isReady = true;
                        //using (SqlCommand cmd = new SqlCommand(query, conn))
                        //{
                        //    cmd.Parameters.AddWithValue("@OrderHeaderId", incomingOrderDetails.OrderHeaderId);
                        //    using (SqlDataReader dr = cmd.ExecuteReader())
                        //    {
                        //        if (dr.HasRows)
                        //        {
                        //            while (dr.Read())
                        //            {
                        //                string status = dr["Status"].ToString().Trim();
                        //                if (!status.Equals("Available"))
                        //                {
                        //                    isReady = false;
                        //                    break;
                        //                }
                        //            }
                        //        }
                        //    }
                        //}

                        //if (isReady)
                        //{
                        //    query = "UPDATE IncomingOrder SET Status = @Status WHERE OrderId = @OrderId";
                        //    using (SqlCommand cmd = new SqlCommand(query, conn))
                        //    {
                        //        cmd.Parameters.AddWithValue("@Status", "Ready");
                        //        cmd.Parameters.AddWithValue("@OrderId", incomingOrderDetails.OrderId);
                        //        cmd.ExecuteNonQuery();
                        //    }
                        //}

                        query = "UPDATE OrderHeader SET UpdatedAt = @UpdatedAt WHERE OrderHeaderId = @OrderHeaderId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                            cmd.Parameters.AddWithValue("@OrderHeaderId", incomingOrderDetails.OrderHeaderId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                conn.Close();

                this.fetchData();
            }
        }

        private void logout()
        {
            StaffManager.Instance.Clear();
            loginForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fetchData()
        {
            dataGridView1.Rows.Clear();
            comboBox1.SelectedIndex = -1;
            GetBinLocationOrders();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.fetchData();
        }

        private void UpdateStockForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.logout();
        }
    }
}
