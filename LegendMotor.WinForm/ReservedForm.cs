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
    public partial class ReservedForm : Form
    {
        private Form form;
        private List<Dealer> dealers = new List<Dealer>();
        private List<ReservedDetailItem> reservedItems = new List<ReservedDetailItem>();
        private string dealerCode;
        public ReservedForm(Form form, string dealerCode)
        {
            InitializeComponent();
            this.form = form;
            this.dealerCode = dealerCode;

            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
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
                comboBox1.SelectedIndex = comboBox1.FindStringExact(dealers.Find(x => x.DealerCode == dealerCode).Name);
            }
        }

        private void GetItems()
        {
            reservedItems.Clear();
            dataGridView1.Rows.Clear();
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }
            string query = "SELECT Spare.SpareId AS SpareId, Spare.Name AS Name, Spare.Description AS Description, Spare.Category AS Category, Spare.Weight AS Weight, Spare.Price AS Price, BinLocation.BinLocationCode AS BinLocationCode, BinLocation.Name AS Location, BinLocation_Spare.Stock AS Quantity, BinLocation_Spare.Id AS SparePartId, BinLocation_Spare.Reserved AS Reserved, ReservedSpare.ReservedSpareId AS ReservedId, ReservedSpare.Quantity AS ReservedQuantity, ReservedSpare.ExpiryDate AS ExpiryDate FROM Spare JOIN BinLocation_Spare ON Spare.SpareId = BinLocation_Spare.SpareId JOIN BinLocation ON BinLocation.BinLocationCode = BinLocation_Spare.BinLocationCode JOIN ReservedSpare ON ReservedSpare.SparePartId = BinLocation_Spare.Id WHERE ReservedSpare.DealerCode = @DealerCode AND ReservedSpare.ExpiryDate > @ExpiryDate";
            using (SqlConnection con = new SqlConnection(Config.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DealerCode", dealers[comboBox1.SelectedIndex].DealerCode);
                cmd.Parameters.AddWithValue("@ExpiryDate", DateTime.Now);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ReservedDetailItem item = new ReservedDetailItem();
                        item.SpareId = dr["SpareId"].ToString();
                        item.Name = dr["Name"].ToString();
                        item.Description = dr["Description"].ToString();
                        item.SparePartId = Guid.Parse(dr["SparePartId"].ToString().Trim());
                        item.BinLocationCode = dr["BinLocationCode"].ToString().Trim();
                        item.Location = dr["Location"].ToString();
                        item.Category = dr["Category"].ToString();
                        item.Quantity = Convert.ToInt32(dr["Quantity"]);
                        item.Price = Convert.ToDouble(dr["Price"]);
                        item.Weight = Convert.ToDouble(dr["Weight"]);
                        item.ReservedQuantity = Convert.ToInt32(dr["ReservedQuantity"]);
                        item.ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"]);
                        item.ReservedSpareId = Guid.Parse(dr["ReservedId"].ToString().Trim());
                        reservedItems.Add(item);
                        dataGridView1.Rows.Add(item.Name, item.Location, item.Price, item.ReservedQuantity, item.ExpiryDate.ToString("yyyy-MM-dd"));
                    }
                }
                con.Close();
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
            quantityColumn.ReadOnly = true;
            quantityColumn.HeaderText = "Quantity";
            quantityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn expiryDateColumn = new DataGridViewTextBoxColumn();
            expiryDateColumn.Name = "Expiry Date";
            expiryDateColumn.DataPropertyName = "ExpiryDate";
            expiryDateColumn.ReadOnly = true;
            expiryDateColumn.HeaderText = "Expiry Date";
            expiryDateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.Text = "Add to cart";
            button.UseColumnTextForButtonValue = true;
            button.Width = 150;
            button.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewButtonColumn btn_delete = new DataGridViewButtonColumn();
            btn_delete.Text = "Remove";
            btn_delete.UseColumnTextForButtonValue = true;
            btn_delete.Width = 150;
            btn_delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(locationColumn);
            dataGridView1.Columns.Add(priceColumn);
            dataGridView1.Columns.Add(quantityColumn);
            dataGridView1.Columns.Add(button);
            dataGridView1.Columns.Add(btn_delete);
        }

        private void ReservedForm_Load(object sender, EventArgs e)
        {
            GetDealers();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItems();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                ReservedDetailItem spare = reservedItems[e.RowIndex];
                CartItem item = new CartItem();
                item.SpareId = spare.SpareId;
                item.SparePartId = spare.SparePartId;
                item.Name = spare.Name;
                item.Description = spare.Description;
                item.Location = spare.Location;
                item.BinLocationCode = spare.BinLocationCode;
                item.Category = spare.Category;
                item.Quantity = spare.ReservedQuantity;
                item.Price = spare.Price;
                item.Weight = spare.Weight;
                item.Stock = spare.Quantity;
                item.ReservedItemId = spare.ReservedSpareId;
                CartManager.Instance.AddItem(item);
                MessageBox.Show("Item added to cart");
            } else if (e.ColumnIndex == 5)
            {
                ReservedDetailItem item = reservedItems[e.RowIndex];
                string query = "DELETE FROM ReservedSpare WHERE ReservedSpareId = @ReservedSpareId";
                using (SqlConnection con = new SqlConnection(Config.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ReservedSpareId", item.ReservedSpareId);
                    cmd.ExecuteNonQuery();

                    query = "UPDATE BinLocation_Spare SET Reserved = Reserved - @ReservedQuantity WHERE Id = @SparePartId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ReservedQuantity", item.ReservedQuantity);
                    cmd.Parameters.AddWithValue("@SparePartId", item.SparePartId);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                reservedItems.RemoveAt(e.RowIndex);
            }
        }
    }
}
