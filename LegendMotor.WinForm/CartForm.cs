using LegendMotor.Dal;
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
using System.Xml.Linq;

namespace LegendMotor.WinForm;

public partial class CartForm : Form
{
    private readonly DataContext _ctx;
    private Form form;
    private List<Dealer> dealers = new List<Dealer>();
    public CartForm(Form form)
    {
        InitializeComponent();
        this.form = form;
        this._ctx = new DataContext();
    }

    private void CartForm_Load(object sender, EventArgs e)
    {
        dataGridView1.AllowUserToResizeColumns = false;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
        GetDealers();
        AddDataGridViewColumns();
    }

    private void GetDealers()
    {
        dealers.Clear();
        var queryDealers = _ctx.Dealer;

        foreach (Dealer dealer in queryDealers)
        {
            dealers.Add(dealer);
            comboBox1.Items.Add(dealer.Name);
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

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

        DataGridViewTextBoxColumn categoryColumn = new DataGridViewTextBoxColumn();
        categoryColumn.Name = "Category";
        categoryColumn.DataPropertyName = "Category";
        categoryColumn.ReadOnly = true;
        categoryColumn.HeaderText = "Category";
        categoryColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn stockColumn = new DataGridViewTextBoxColumn();
        stockColumn.Name = "Stock";
        stockColumn.DataPropertyName = "Stock";
        stockColumn.ReadOnly = true;
        stockColumn.HeaderText = "Stock";
        stockColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn weightColumn = new DataGridViewTextBoxColumn();
        weightColumn.Name = "Weight";
        weightColumn.DataPropertyName = "Weight";
        weightColumn.ReadOnly = true;
        weightColumn.HeaderText = "Weight (kg)";
        weightColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

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

        DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
        subtotalColumn.Name = "Sub-Total";
        subtotalColumn.DataPropertyName = "Sub-Total";
        subtotalColumn.ReadOnly = false;
        subtotalColumn.HeaderText = "Sub-Total";
        subtotalColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        dataGridView1.Columns.Add(nameColumn);
        dataGridView1.Columns.Add(locationColumn);
        dataGridView1.Columns.Add(categoryColumn);
        dataGridView1.Columns.Add(stockColumn);
        dataGridView1.Columns.Add(weightColumn);
        dataGridView1.Columns.Add(priceColumn);
        dataGridView1.Columns.Add(quantityColumn);
        dataGridView1.Columns.Add(subtotalColumn);

        CartManager.Instance.GetItems().ForEach(item =>
        {
            dataGridView1.Rows.Add(item.Name, item.Location, item.Category, item.Stock, item.Weight, item.Price, item.Quantity, item.TotalPrice);
        });
    }

    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 6)
        {
            DataGridViewTextBoxCell tb = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[6];
            if (tb.Value != null)
            {
                // do stuff
                try
                {
                    int quantity = int.Parse(tb.Value.ToString());
                    CartItem item = CartManager.Instance.GetItems()[e.RowIndex];
                    if (quantity > item.Stock)
                    {
                        MessageBox.Show("Quantity exceeds stock");
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = item.Quantity;
                        return;
                    }
                    item = CartManager.Instance.UpdateItem(CartManager.Instance.GetItems()[e.RowIndex].SparePartId, quantity);
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = item.TotalPrice;
                    dataGridView1.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid quantity");
                    CartItem item = CartManager.Instance.GetItems()[e.RowIndex];
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = item.Quantity;
                    return;
                }

            }
        }

    }

    void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dataGridView1.IsCurrentCellDirty)
        {
            // This fires the cell value changed handler below
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }

}
/*
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

        DataGridViewTextBoxColumn categoryColumn = new DataGridViewTextBoxColumn();
        categoryColumn.Name = "Category";
        categoryColumn.DataPropertyName = "Category";
        categoryColumn.ReadOnly = true;
        categoryColumn.HeaderText = "Category";
        categoryColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn stockColumn = new DataGridViewTextBoxColumn();
        stockColumn.Name = "Stock";
        stockColumn.DataPropertyName = "Stock";
        stockColumn.ReadOnly = true;
        stockColumn.HeaderText = "Stock";
        stockColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn weightColumn = new DataGridViewTextBoxColumn();
        weightColumn.Name = "Weight";
        weightColumn.DataPropertyName = "Weight";
        weightColumn.ReadOnly = true;
        weightColumn.HeaderText = "Weight (kg)";
        weightColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

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

        DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
        subtotalColumn.Name = "Sub-Total";
        subtotalColumn.DataPropertyName = "Sub-Total";
        subtotalColumn.ReadOnly = false;
        subtotalColumn.HeaderText = "Sub-Total";
        subtotalColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        dataGridView1.Columns.Add(nameColumn);
        dataGridView1.Columns.Add(locationColumn);
        dataGridView1.Columns.Add(categoryColumn);
        dataGridView1.Columns.Add(stockColumn);
        dataGridView1.Columns.Add(weightColumn);
        dataGridView1.Columns.Add(priceColumn);
        dataGridView1.Columns.Add(quantityColumn);
        dataGridView1.Columns.Add(subtotalColumn);

        CartManager.Instance.GetItems().ForEach(item =>
        {
            dataGridView1.Rows.Add(item.Name, item.Location, item.Category, item.Stock, item.Weight, item.Price, item.Quantity, item.TotalPrice);
        });
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == -1)
        {
            MessageBox.Show("Please select a dealer");
            return;
        }
        this.Hide();
        CheckoutForm form = new CheckoutForm(this, dealers[comboBox1.SelectedIndex]);
        form.FormClosed += childForm_FormClosed;
        form.Show();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        this.Hide();
        ReservedForm form = new ReservedForm(this, null);
        form.FormClosed += childForm_FormClosed;
        form.Show();
    }

    private void CartForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.form.Show();
    }

    private void childForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.Show();
        dataGridView1.Rows.Clear();
        CartManager.Instance.GetItems().ForEach(item =>
        {
            dataGridView1.Rows.Add(item.Name, item.Location, item.Category, item.Stock, item.Weight, item.Price, item.Quantity, item.TotalPrice);
        });
    }

    // This event handler manually raises the CellValueChanged event 
    // by calling the CommitEdit method. 
    void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dataGridView1.IsCurrentCellDirty)
        {
            // This fires the cell value changed handler below
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }

    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 6)
        {
            DataGridViewTextBoxCell tb = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[6];
            if (tb.Value != null)
            {
                // do stuff
                try
                {
                    int quantity = int.Parse(tb.Value.ToString());
                    CartItem item = CartManager.Instance.GetItems()[e.RowIndex];
                    if (quantity > item.Stock)
                    {
                        MessageBox.Show("Quantity exceeds stock");
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = item.Quantity;
                        return;
                    }
                    item = CartManager.Instance.UpdateItem(CartManager.Instance.GetItems()[e.RowIndex].SparePartId, quantity);
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = item.TotalPrice;
                    dataGridView1.Invalidate();
                } catch (Exception ex)
                {
                    MessageBox.Show("Invalid quantity");
                    CartItem item = CartManager.Instance.GetItems()[e.RowIndex];
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = item.Quantity;
                    return;
                }
                
            }
        }

    }

    private void button3_Click(object sender, EventArgs e)
    {
        CartManager.Instance.Reset();
        dataGridView1.Rows.Clear();
        CartManager.Instance.GetItems().ForEach(item =>
        {
            dataGridView1.Rows.Add(item.Name, item.Location, item.Category, item.Stock, item.Weight, item.Price, item.Quantity, item.TotalPrice);
        });
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == -1)
        {
            MessageBox.Show("Please select a dealer");
            return;
        }
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            string query = "SELECT * FROM ReservedSpare WHERE DealerCode = @DealerCode";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@DealerCode", dealers[comboBox1.SelectedIndex].DealerCode);
            List<ReservedItem> items = new List<ReservedItem>();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    ReservedItem item = new ReservedItem();
           
                    item.ReservedSpareId = new Guid(dr["ReservedSpareId"].ToString().Trim());
                    item.DealerCode = dr["DealerCode"].ToString();
                    item.SparePartId = new Guid(dr["SparePartId"].ToString().Trim());
                    item.Quantity = int.Parse(dr["Quantity"].ToString());
                    item.ExpiryDate = DateTime.Parse(dr["ExpiryDate"].ToString());
                    items.Add(item);
                }
            }
            List<CartItem> carts = CartManager.Instance.GetItems();
            foreach (CartItem cart in carts)
            {
                ReservedItem item = items.Find(i => i.SparePartId == cart.SparePartId);
                if (item != null)
                {
                    item.Quantity += cart.Quantity;
                    query = "UPDATE ReservedSpare SET Quantity = @Quantity, ExpiryDate = @ExpiryDate WHERE ReservedSpareId = @ReservedSpareId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@ReservedSpareId", item.ReservedSpareId);
                    cmd.Parameters.AddWithValue("@ExpiryDate", DateTime.Now.AddDays(7));
                    cmd.ExecuteNonQuery();

                    query = "UPDATE BinLocation_Spare SET Reserved = Reserved + @Quantity WHERE Id = @SparePartId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                    cmd.Parameters.AddWithValue("@SparePartId", cart.SparePartId);
                    cmd.ExecuteNonQuery();
                } else
                {
                    query = "INSERT INTO ReservedSpare (ReservedSpareId, DealerCode, SparePartId, Quantity, ExpiryDate) VALUES (@ReservedSpareId, @DealerCode, @SparePartId, @Quantity, @ExpiryDate)";
                    cmd = new SqlCommand(query, con);
                    Guid id = Guid.NewGuid();
                    cmd.Parameters.AddWithValue("@ReservedSpareId", id.ToString());
                    cmd.Parameters.AddWithValue("@DealerCode", dealers[comboBox1.SelectedIndex].DealerCode);
                    cmd.Parameters.AddWithValue("@SparePartId", cart.SparePartId);
                    cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                    cmd.Parameters.AddWithValue("@ExpiryDate", DateTime.Now.AddDays(7));
                    cmd.ExecuteNonQuery();

                    query = "UPDATE BinLocation_Spare SET Reserved = Reserved + @Quantity WHERE Id = @SparePartId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                    cmd.Parameters.AddWithValue("@SparePartId", cart.SparePartId);
                    cmd.ExecuteNonQuery();
                }

            }
            CartManager.Instance.Clear();
            con.Close();
            this.Close();
        }
    }
}
*/