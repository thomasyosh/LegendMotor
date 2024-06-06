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
    public partial class SearchSpareForm : Form
    {
        private List<SearchSpareResultModel> spares = new List<SearchSpareResultModel>();
        private Form form;
        public SearchSpareForm(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void SearchSpareForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();

            GetSpares(null, null);
            //dataGridView1.Rows.Add("Spare1", "The description of spare", "Location A", "A", 0.5, 50, 100);
        }

        private void GetSpares(string name, string category)
        {
            spares.Clear();
            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection(Config.ConnectionString);
            string query = "SELECT Spare.SpareId AS SpareId, Spare.Name AS Name, Spare.Description AS Description, Spare.Category AS Category, Spare.Weight AS Weight, Spare.Price AS Price, BinLocation.BinLocationCode AS BinLocationCode, BinLocation.Name AS Location, BinLocation_Spare.Stock AS Quantity, BinLocation_Spare.Id AS SparePartId, BinLocation_Spare.Reserved AS Reserved FROM Spare JOIN BinLocation_Spare ON Spare.SpareId = BinLocation_Spare.SpareId JOIN BinLocation ON BinLocation.BinLocationCode = BinLocation_Spare.BinLocationCode";
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(category))
            {
                query += " WHERE Spare.Name LIKE '%" + name + "%' AND Spare.Category LIKE '%" + category + "%'";
            }
            else if (!string.IsNullOrEmpty(name))
            {
                query += " WHERE Spare.Name LIKE '%" + name + "%'";
            }
            else if (!string.IsNullOrEmpty(category))
            {
                query += " WHERE Spare.Category LIKE '%" + category + "%'";
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    SearchSpareResultModel spare = new SearchSpareResultModel();
                    spare.Name = dr["Name"].ToString();
                    spare.Description = dr["Description"].ToString();
                    spare.SpareId = dr["SpareID"].ToString().Trim();
                    spare.SparePartId = Guid.Parse(dr["SparePartId"].ToString().Trim());
                    spare.BinLocationCode = dr["BinLocationCode"].ToString().Trim();
                    spare.Location = dr["Location"].ToString();
                    spare.Category = dr["Category"].ToString();
                    spare.Quantity = Convert.ToInt32(dr["Quantity"]);
                    spare.Price = Convert.ToDouble(dr["Price"]);
                    spare.Weight = Convert.ToDouble(dr["Weight"]);
                    spare.Reserved = Convert.ToInt32(dr["Reserved"]);


                    spares.Add(spare);
                    dataGridView1.Rows.Add(spare.Name, spare.Description, spare.Location, spare.Category, spare.Weight, spare.Price, spare.Available);
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

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.Name = "Description";
            descriptionColumn.DataPropertyName = "Description";
            descriptionColumn.ReadOnly = true;
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            descriptionColumn.MinimumWidth = 200;

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
            quantityColumn.ReadOnly = true;
            quantityColumn.HeaderText = "Quantity";
            quantityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.Text = "Add to cart";
            button.UseColumnTextForButtonValue = true;
            button.Width = 150;
            button.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(descriptionColumn);
            dataGridView1.Columns.Add(locationColumn);
            dataGridView1.Columns.Add(categoryColumn);
            dataGridView1.Columns.Add(weightColumn);
            dataGridView1.Columns.Add(priceColumn);
            dataGridView1.Columns.Add(quantityColumn);
            dataGridView1.Columns.Add(button);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            CartForm form = new CartForm(this);
            form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
            form.Show();
        }

        private void SearchSpareForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetSpares(textBox1.Text, comboBox1.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                SearchSpareResultModel spare = spares[e.RowIndex];
                CartItem item = new CartItem();
                item.SpareId = spare.SpareId;
                item.SparePartId = spare.SparePartId;
                item.Name = spare.Name;
                item.Description = spare.Description;
                item.Location = spare.Location;
                item.BinLocationCode = spare.BinLocationCode;
                item.Category = spare.Category;
                item.Quantity = 1;
                item.Price = spare.Price;
                item.Weight = spare.Weight;
                item.Stock = spare.Available;
                CartManager.Instance.AddItem(item);
                MessageBox.Show("Item added to cart");
            }
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            GetSpares(textBox1.Text, comboBox1.Text);
        }
    }
}
