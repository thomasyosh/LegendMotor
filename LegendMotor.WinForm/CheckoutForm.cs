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
    public partial class CheckoutForm : Form
    {
        private Form form;
        private Dealer dealer;
        public CheckoutForm(Form form, Dealer dealer)
        {
            InitializeComponent();
            this.form = form;
            this.dealer = dealer;
            lbl_dealer_value.Text = dealer.Name;
            txt_invoiceAddress.Text = dealer.Address;
            txt_invoiceName.Text = dealer.Name;
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
        }

        private void GetItems()
        {
            List<CartItem> items = CartManager.Instance.GetItems();
            for (int i = 0; i < items.Count; i++)
            {
                dataGridView1.Rows.Add(items[i].Name, items[i].Location, items[i].Price, items[i].Quantity, items[i].TotalPrice);
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

            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(locationColumn);
            dataGridView1.Columns.Add(priceColumn);
            dataGridView1.Columns.Add(quantityColumn);
            dataGridView1.Columns.Add(subTotalColumn);

            GetItems();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_delivery.Enabled = !checkBox1.Checked;
            if (checkBox1.Checked)
            {
                txt_delivery.Text = txt_invoiceAddress.Text;
            }
            else
            {
                txt_delivery.Text = "";
            }
        }

        private void CheckoutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }

        private void txt_invoiceAddress_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_delivery.Text = txt_invoiceAddress.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_invoiceName.Text == "")
            {
                MessageBox.Show("Please fill the invoice name");
                return;
            }
            if (txt_invoiceAddress.Text == "")
            {
                MessageBox.Show("Please fill the invoice address");
                return;
            }
            if (txt_delivery.Text == "")
            {
                MessageBox.Show("Please fill the delivery address");
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a contact type");
                return;
            }
            using (SqlConnection con = new SqlConnection(Config.ConnectionString))
            {
                con.Open();
                string query = "INSERT INTO OrderHeader (OrderHeaderId, CreatedAt, UpdatedAt) VALUES (@OrderHeaderId, @CreatedAt, @UpdatedAt)";
                Guid orderHeaderId = Guid.NewGuid();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@OrderHeaderId", orderHeaderId);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    int result = cmd.ExecuteNonQuery();
                    if (result == 0)
                    {
                        MessageBox.Show("Failed to create order");
                        con.Close();
                        return;
                    }
                }

                List<RequireOrderItem> items = new List<RequireOrderItem>();
                bool needWaitingPurhcingOrder = false;
                foreach (CartItem item in CartManager.Instance.GetItems())
                {
                    query = "SELECT * FROM BinLocation_Spare WHERE Id = @Id";
                    bool needWaitingPurhcingOrderLine = false;
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", item.SparePartId);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                int reorderLevel = Convert.ToInt32(dr["ROL"]);
                                int curStock = Convert.ToInt32(dr["Stock"]);
                                int newStock = curStock - item.Quantity > 0 ? curStock - item.Quantity : 0;
                                if (newStock == 0)
                                {
                                    needWaitingPurhcingOrderLine = true;
                                    needWaitingPurhcingOrder = true;
                                }
                                if (newStock <= reorderLevel)
                                {
                                    RequireOrderItem requireOrderItem = new RequireOrderItem();
                                    requireOrderItem.SparePartId = item.SparePartId;
                                    requireOrderItem.Quantity = item.Quantity + reorderLevel * 2 - curStock;
                                    requireOrderItem.Price = item.Price;
                                    items.Add(requireOrderItem);
                                    if (newStock >= 0)
                                    {
                                        query = "UPDATE BinLocation_Spare SET Stock = @Stock WHERE BinLocationCode = @BinLocationCode AND Id = @Id";
                                        using (SqlCommand cmd2 = new SqlCommand(query, con))
                                        {
                                            cmd2.Parameters.AddWithValue("@Stock", newStock);
                                            cmd2.Parameters.AddWithValue("@BinLocationCode", dr["BinLocationCode"].ToString());
                                            cmd2.Parameters.AddWithValue("@Id", item.SparePartId);
                                            cmd2.ExecuteNonQuery();
                                        }
                                    }
                                } else
                                {
                                    query = "UPDATE BinLocation_Spare SET Stock = @Stock WHERE BinLocationCode = @BinLocationCode AND Id = @Id";
                                    using (SqlCommand cmd2 = new SqlCommand(query, con))
                                    {
                                        cmd2.Parameters.AddWithValue("@Stock", newStock);
                                        cmd2.Parameters.AddWithValue("@BinLocationCode", dr["BinLocationCode"].ToString());
                                        cmd2.Parameters.AddWithValue("@Id", item.SparePartId);
                                        cmd2.ExecuteNonQuery();
                                    }
                                }
                                
                            }
                        }
                    }

                    query = "INSERT INTO OrderLine (LineId, OrderHeaderId, SparePartId, Quantity, Status) VALUES (@LineId, @OrderHeaderId, @SparePartId, @Quantity, @Status)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@LineId", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@OrderHeaderId", orderHeaderId);
                        cmd.Parameters.AddWithValue("@SparePartId", item.SparePartId);
                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@Price", item.Price);
                        cmd.Parameters.AddWithValue("@Status", needWaitingPurhcingOrderLine ? "Pending" : "Available");

                        cmd.ExecuteNonQuery();
                    }

                    if (item.ReservedItemId != Guid.Empty)
                    {
                        query = "DELETE FROM ReservedSpare WHERE ReservedSpareId = @ReservedSpareId";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ReservedSpareId", item.ReservedItemId);
                            cmd.ExecuteNonQuery();
                        }

                        query = "UPDATE BinLocation_Spare SET Reserved = Reserved - @ReservedQuantity WHERE Id = @SparePartId";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ReservedQuantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@SparePartId", item.SparePartId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                

                query = "INSERT INTO Invoice (InvoiceId, InvoiceDate, InvoiceAmount) VALUES (@InvoiceId, @InvoiceDate, @InvoiceAmount)";
                Guid invoiceId = Guid.NewGuid();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId);
                    cmd.Parameters.AddWithValue("@InvoiceDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@InvoiceAmount", CartManager.Instance.GetTotalPrice());
                    cmd.ExecuteNonQuery();
                }

                query = "INSERT INTO IncomingOrder (OrderId, InvoiceName, InvoiceAddress, DeliveryAddress, DealerCode, Type, Remark, Status, StaffId, OrderHeaderId, InvoiceId) VALUES (@OrderId, @InvoiceName, @InvoiceAddress, @DeliveryAddress, @DealerCode, @Type, @Remark, @Status, @StaffId, @OrderHeaderId, @InvoiceId)";
                Guid incomingOrderId = Guid.NewGuid();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@OrderId", incomingOrderId);
                    cmd.Parameters.AddWithValue("@InvoiceName", txt_invoiceName.Text);
                    cmd.Parameters.AddWithValue("@InvoiceAddress", txt_invoiceAddress.Text);
                    cmd.Parameters.AddWithValue("@DeliveryAddress", txt_delivery.Text);
                    cmd.Parameters.AddWithValue("@DealerCode", dealer.DealerCode);
                    cmd.Parameters.AddWithValue("@Type", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Remark", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@Status", needWaitingPurhcingOrder ? "Pending" : "Available");
                    cmd.Parameters.AddWithValue("@StaffId", StaffManager.Instance.GetStaffId());
                    cmd.Parameters.AddWithValue("@OrderHeaderId", orderHeaderId);
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId);
                    cmd.ExecuteNonQuery();
                }

                if (items.Count > 0)
                {
                    query = "INSERT INTO OrderHeader (OrderHeaderId, CreatedAt, UpdatedAt) VALUES (@OrderHeaderId, @CreatedAt, @UpdatedAt)";
                    Guid purchasingOrderHeaderId = Guid.NewGuid();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@OrderHeaderId", purchasingOrderHeaderId);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }

                    query = "INSERT INTO OrderLine (LineId, OrderHeaderId, SparePartId, Quantity) VALUES (@LineId, @OrderHeaderId, @SparePartId, @Quantity)";
                    foreach (RequireOrderItem item in items)
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@LineId", Guid.NewGuid());
                            cmd.Parameters.AddWithValue("@OrderHeaderId", purchasingOrderHeaderId);
                            cmd.Parameters.AddWithValue("@SparePartId", item.SparePartId);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@Price", item.Price);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    query = "INSERT INTO PurchasingOrder (OrderId, Status, IncomingOrderId, OrderHeaderId) VALUES (@OrderId, @Status, @IncomingOrderId, @OrderHeaderId)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@Status", "Pending");
                        cmd.Parameters.AddWithValue("@IncomingOrderId", incomingOrderId);
                        cmd.Parameters.AddWithValue("@OrderHeaderId", purchasingOrderHeaderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                CartManager.Instance.Clear();
                MessageBox.Show("Order created successfully");
                this.Close();
            }
        }
    }
}
