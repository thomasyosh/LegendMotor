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
    public partial class StockList : Form
    {
        private Form form;
        private List<BinLocationSpareDetails> spares = new List<BinLocationSpareDetails>();
        public StockList(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void StockList_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            AddDataGridView1Columns();
            GetStocks(null, null);
        }

        private void GetStocks(string name, string category)
        {
            dataGridView1.Rows.Clear();
            spares.Clear();
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                string query = "SELECT BinLocation_Spare.Id AS Id, BinLocation_Spare.SpareId As SpareId, BinLocation_Spare.Stock AS Stock, BinLocation_Spare.ROL AS ROL, BinLocation_Spare.DL AS DL, Spare.Name AS Name, Spare.Description AS Description, Spare.Category AS Category, Spare.Weight AS Weight, Spare.Price AS Price FROM BinLocation_Spare JOIN Spare ON Spare.SpareId=BinLocation_Spare.SpareId WHERE BinLocationCode = @BinLocationCode";
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(category))
                {
                    query += " AND Spare.Name LIKE '%" + name + "%' AND Spare.Category = '" + category + "'";
                }
                else if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(category))
                {
                    query += " AND ";
                    if (!string.IsNullOrEmpty(name))
                    {
                        query += "Spare.Name LIKE '%" + name + "%'";
                        
                    }
                    if (!string.IsNullOrEmpty(category))
                    {
                        query += "Spare.Category = '" + category + "'";
                    }
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BinLocationCode", StaffManager.Instance.GetBinLocationCode());
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BinLocationSpareDetails spare = new BinLocationSpareDetails();
                        spare.Id = Guid.Parse(dr["Id"].ToString());
                        spare.Name = dr["Name"].ToString();
                        spare.SpareId = dr["SpareId"].ToString();
                        spare.Stock = int.Parse(dr["Stock"].ToString());
                        spare.ROL = int.Parse(dr["ROL"].ToString());
                        spare.DL = int.Parse(dr["DL"].ToString());
                        spare.Category = dr["Category"].ToString();
                        spare.Description = dr["Description"].ToString();
                        spare.Weight = double.Parse(dr["Weight"].ToString());
                        spare.Price = double.Parse(dr["Price"].ToString());

                        spares.Add(spare);
                        dataGridView1.Rows.Add(spare.SpareId, spare.Name, spare.Description, spare.Category, spare.Weight, spare.Stock, spare.ROL);
                    }
                }
                conn.Close();
            }
        }

        private void AddDataGridView1Columns()
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
            nameColumn.Width = 100;

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.Name = "Description";
            descriptionColumn.DataPropertyName = "Description";
            descriptionColumn.ReadOnly = true;
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            descriptionColumn.MinimumWidth = 200;

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

            DataGridViewTextBoxColumn stockColumn = new DataGridViewTextBoxColumn();
            stockColumn.Name = "Stock";
            stockColumn.DataPropertyName = "Stock";
            stockColumn.ReadOnly = true;
            stockColumn.HeaderText = "Stock";
            stockColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn rolColumn = new DataGridViewTextBoxColumn();
            rolColumn.Name = "Reorder level";
            rolColumn.DataPropertyName = "Reorder level";
            rolColumn.ReadOnly = true;
            rolColumn.HeaderText = "Reorder level";
            rolColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


            dataGridView1.Columns.Add(idColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(descriptionColumn);
            dataGridView1.Columns.Add(categoryColumn);
            dataGridView1.Columns.Add(weightColumn);
            dataGridView1.Columns.Add(stockColumn);
            dataGridView1.Columns.Add(rolColumn);

        }

        private void StockList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GetStocks(textBox1.Text, cbx_category.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetStocks(textBox1.Text, cbx_category.Text);
        }
    }
}
