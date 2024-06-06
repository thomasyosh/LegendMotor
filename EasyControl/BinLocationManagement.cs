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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EasyControl
{
    public partial class BinLocationManagement : Form
    {
        private Form form;
        private List<BinLocation> binLocations = new List<BinLocation>();
        private List<BinLocationSpare> spares = new List<BinLocationSpare>();
        public BinLocationManagement(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void BinLocationManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            AddDataGridViewColumns();
            getBinLocations();
        }
        private void AddDataGridViewColumns()
        {
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Spare ID";
            idColumn.DataPropertyName = "Spare ID";
            idColumn.ReadOnly = true;
            idColumn.HeaderText = "Spare ID";
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            idColumn.Width = 150;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.HeaderText = "Name";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.MinimumWidth = 200;

            DataGridViewTextBoxColumn rolColumn = new DataGridViewTextBoxColumn();
            rolColumn.Name = "Re-order level";
            rolColumn.DataPropertyName = "Re-oreder level";
            rolColumn.ReadOnly = false;
            rolColumn.HeaderText = "Re-oreder level";
            rolColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn dlColumn = new DataGridViewTextBoxColumn();
            dlColumn.Name = "Danger level";
            dlColumn.DataPropertyName = "Danger level";
            dlColumn.ReadOnly = false;
            dlColumn.HeaderText = "Danger level";
            dlColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn stockColumn = new DataGridViewTextBoxColumn();
            stockColumn.Name = "Stock";
            stockColumn.DataPropertyName = "Stock";
            stockColumn.ReadOnly = false;
            stockColumn.HeaderText = "Stock";
            stockColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewButtonColumn updateButton = new DataGridViewButtonColumn();
            updateButton.Text = "Update";
            updateButton.UseColumnTextForButtonValue = true;
            updateButton.Width = 100;
            updateButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns.Add(idColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(rolColumn);
            dataGridView1.Columns.Add(dlColumn);
            dataGridView1.Columns.Add(stockColumn);
            dataGridView1.Columns.Add(updateButton);
        }

        private void getBinLocations()
        {
            using (SqlConnection con = new SqlConnection(Config.ConnectionString))
            {
                string query = "SELECT * FROM BinLocation";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BinLocation binLocation = new BinLocation();
                        binLocation.BinLocationCode = dr["BinLocationCode"].ToString().Trim();
                        binLocation.Name = dr["Name"].ToString();
                        binLocation.Address = dr["Address"].ToString();
                        binLocations.Add(binLocation);
                        comboBox1.Items.Add(dr["Name"].ToString());
                    }
                }
                con.Close();
            }
        }

        private void childFormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            if (comboBox1.SelectedIndex != -1)
            {
                getSpare(binLocations[comboBox1.SelectedIndex].BinLocationCode);
            }
        }

        private void BinLocationManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }

        private void getSpare(string binLocationCode)
        {
            spares.Clear();
            dataGridView1.Rows.Clear();
            using (SqlConnection con = new SqlConnection(Config.ConnectionString))
            {
                string query = "SELECT BinLocation_Spare.Id AS Id, BinLocation_Spare.SpareId As SpareId, BinLocation_Spare.Stock AS Stock, BinLocation_Spare.ROL AS ROL, BinLocation_Spare.DL AS DL, Spare.Name AS Name FROM BinLocation_Spare JOIN Spare ON Spare.SpareId=BinLocation_Spare.SpareId WHERE BinLocationCode = @BinLocationCode";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BinLocationCode", binLocationCode);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BinLocationSpare spare = new BinLocationSpare();
                        spare.Id = Guid.Parse(dr["Id"].ToString());
                        spare.Name = dr["Name"].ToString();
                        spare.SpareId = dr["SpareId"].ToString();
                        spare.Stock = int.Parse(dr["Stock"].ToString());
                        spare.ROL = int.Parse(dr["ROL"].ToString());
                        spare.DL = int.Parse(dr["DL"].ToString());
                        spares.Add(spare);
                        dataGridView1.Rows.Add(spare.SpareId, spare.Name, spare.ROL, spare.DL, spare.Stock);
                    }
                }
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "Address: " + binLocations[comboBox1.SelectedIndex].Address;
            getSpare(binLocations[comboBox1.SelectedIndex].BinLocationCode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a bin location");
                return;
            }
            AddBinLocationSpareForm addBinLocationSpareForm = new AddBinLocationSpareForm(binLocations[comboBox1.SelectedIndex].BinLocationCode, spares);
            addBinLocationSpareForm.FormClosing += new FormClosingEventHandler(childFormClosing);
            addBinLocationSpareForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    string spareId = spares[e.RowIndex].SpareId;
                    int rol = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    int dl = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    int stock = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

                    using (SqlConnection con = new SqlConnection(Config.ConnectionString))
                    {
                        string query = "UPDATE BinLocation_Spare SET ROL = @ROL, DL = @DL, Stock = @Stock WHERE SpareId = @SpareId";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ROL", rol);
                        cmd.Parameters.AddWithValue("@DL", dl);
                        cmd.Parameters.AddWithValue("@Stock", stock);
                        cmd.Parameters.AddWithValue("@SpareId", spareId);
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("Updated successfully");
                            spares[e.RowIndex].ROL = rol;
                            spares[e.RowIndex].DL = dl;
                            spares[e.RowIndex].Stock = stock;
                        }
                        else
                        {
                            MessageBox.Show("Failed to update");
                        }
                        con.Close();
                    }
                }
            }
        }
    }
}
