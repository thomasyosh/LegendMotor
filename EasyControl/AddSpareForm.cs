using EasyControl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EasyControl
{
    public partial class AddSpareForm : Form
    {
        private List<Supplier> suppliers = new List<Supplier>();
        private List<SupplierPrice> supplierPrices = new List<SupplierPrice>();
        DataGridViewComboBoxColumn supplierColumn = new DataGridViewComboBoxColumn();
        private string spareId;
        public AddSpareForm(string spareId)
        {
            InitializeComponent();
            this.spareId = spareId;
            if (spareId != null)
            {
                this.Text = "Edit Spare";
                button1.Text = "Update";
                comboBox1.Enabled = false;
            }
            if (StaffManager.Instance.GetStaffPosition() != "pd")
            {
                this.Text = "Spare";
                comboBox1.Enabled = false;
                this.btn_upload.Visible = false;
                this.button1.Visible = false;
                this.button2.Visible = false;
                this.textBox1.ReadOnly = true;
                this.textBox2.ReadOnly = true;
                this.textBox3.ReadOnly = true;
                this.richTextBox1.ReadOnly = true;
                this.comboBox1.Enabled = false;

            }
        }

        private void LoadSpare()
        {
            using (SqlConnection con = new SqlConnection(Config.ConnectionString))
            {
                string query = "SELECT * FROM Spare WHERE SpareId = @SpareId";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SpareId", spareId);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        textBox1.Text = dr["Name"].ToString();
                        richTextBox1.Text = dr["Description"].ToString();
                        comboBox1.Text = dr["Category"].ToString();
                        comboBox1.SelectedIndex = comboBox1.FindStringExact(dr["Category"].ToString());
                        textBox2.Text = dr["Price"].ToString();
                        textBox3.Text = dr["Weight"].ToString();
                        byte[] img = (byte[])dr["Url"];
                        pictureBox1.Image = Image.FromStream(new MemoryStream(img));
                    }
                }
                query = "SELECT * FROM Spare_Price WHERE SpareId = @SpareId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SpareId", spareId);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SupplierPrice supplierPrice = new SupplierPrice();
                        supplierPrice.SupplierCode = dr["SupplierCode"].ToString();
                        supplierPrice.Price = float.Parse(dr["PurchasePrice"].ToString());
                        supplierPrices.Add(supplierPrice);
                    }
                }
                con.Close();
            }
            for (int i = 0; i < supplierPrices.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = suppliers.Find(x => x.SupplierCode == supplierPrices[i].SupplierCode).Name;
                dataGridView1.Rows[i].Cells[1].Value = supplierPrices[i].Price;
            }   
        }

        private void AddSpareForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
        }
        private void AddDataGridViewColumns()
        {
            supplierColumn.Name = "Supplier";
            supplierColumn.DataPropertyName = "Supplier";
            supplierColumn.ReadOnly = StaffManager.Instance.GetStaffPosition() != "pd";
            supplierColumn.HeaderText = "Supplier";

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.Name = "Price";
            priceColumn.DataPropertyName = "Price";
            priceColumn.ReadOnly = StaffManager.Instance.GetStaffPosition() != "pd";
            priceColumn.HeaderText = "Price";
            priceColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns.Add(supplierColumn);
            dataGridView1.Columns.Add(priceColumn);
            if (StaffManager.Instance.GetStaffPosition() == "pd") { 
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                deleteButton.MinimumWidth = 100;
                deleteButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                dataGridView1.Columns.Add(deleteButton);

                dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
                dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            }

            GetSupplier();
            if (spareId != null)
            {
                LoadSpare();
            }   
        }

        private void GetSupplier()
        {
            suppliers.Clear();
            supplierColumn.Items.Clear();
            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection(Config.ConnectionString);
            string query = "SELECT * FROM Supplier";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierCode = dr["SupplierCode"].ToString().Trim();
                    supplier.Name = dr["Name"].ToString();
                    supplier.Address = dr["Address"].ToString();
                    supplier.Email = dr["Email"].ToString();
                    supplier.Phone = dr["Phone"].ToString();
                    supplierColumn.Items.Add(supplier.Name);
                    suppliers.Add(supplier);
                }
                con.Close();
            }
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (supplierPrices.Count == 0)
            {
                MessageBox.Show("No supplier available");
                return;
            }
            for (int i = 0; i < supplierPrices.Count; i++)
            {
                if (supplierPrices[i].Price == 0 || supplierPrices[i].SupplierCode == null)
                {
                    MessageBox.Show("Please fill in all fields for supplier price");
                    return;
                }
            }
            float price = 0;
            float weight = 0; 
            string name = textBox1.Text;
            string description = richTextBox1.Text;
            string category = comboBox1.Text;
            string priceString = textBox2.Text;
            string weightString = textBox3.Text;
            try
            {
                price = float.Parse(priceString);
            } catch (FormatException ex)
            {
                MessageBox.Show("Price must be a number");
                return;
            }
            try
            {
                weight = float.Parse(weightString);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Weight must be a number");
                return;
            }
            if (name == "" || description == "" || category == "" || price == 0 || weight == 0 || pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            using (SqlConnection con = new SqlConnection(Config.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Spare";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                int failed = 0;
                if (this.spareId == null)
                {
                    int count = (int)cmd.ExecuteScalar();
                    count++;
                    string spareId = category + count.ToString("00000");

                    query = "INSERT INTO Spare (SpareId, Name, Description, Category, Price, Weight, Url, Count) VALUES (@SpareId, @Name, @Description, @Category, @Price, @Weight, @Url, @Count)";

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SpareId", spareId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Weight", weight);
                    cmd.Parameters.AddWithValue("@Url", ImageToByteArray(pictureBox1.Image));
                    cmd.Parameters.AddWithValue("@Count", supplierPrices.Count);
                    int result = cmd.ExecuteNonQuery();
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                        failed++;
                    }

                    for (int i = 0; i < supplierPrices.Count; i++)
                    {
                        query = "INSERT INTO Spare_Price (SpareId, SupplierCode, PurchasePrice) VALUES (@SpareId, @SupplierCode, @PurchasePrice)";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SpareId", spareId);
                        cmd.Parameters.AddWithValue("@SupplierCode", supplierPrices[i].SupplierCode);
                        cmd.Parameters.AddWithValue("@PurchasePrice", supplierPrices[i].Price);
                        result = cmd.ExecuteNonQuery();
                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                            failed++;
                        }
                    }
                } else
                {
                    query = "UPDATE Spare SET Name = @Name, Description = @Description, Category = @Category, Price = @Price, Weight = @Weight, Url = @Url, Count = @Count WHERE SpareId = @SpareId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SpareId", spareId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Weight", weight);
                    cmd.Parameters.AddWithValue("@Url", ImageToByteArray(pictureBox1.Image));
                    cmd.Parameters.AddWithValue("@Count", supplierPrices.Count);
                    int result = cmd.ExecuteNonQuery();
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                        failed++;
                    }

                    query = "DELETE FROM Spare_Price WHERE SpareId = @SpareId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SpareId", spareId);
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < supplierPrices.Count; i++)
                    {
                        query = "INSERT INTO Spare_Price (SpareId, SupplierCode, PurchasePrice) VALUES (@SpareId, @SupplierCode, @PurchasePrice)";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SpareId", spareId);
                        cmd.Parameters.AddWithValue("@SupplierCode", supplierPrices[i].SupplierCode);
                        cmd.Parameters.AddWithValue("@PurchasePrice", supplierPrices[i].Price);
                        result = cmd.ExecuteNonQuery();
                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                            failed++;
                        }
                    }
                }
                
                con.Close();
                if (failed == 0)
                {
                    this.Close();
                }
            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(imageIn, typeof(byte[]));
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
            if (e.ColumnIndex == 0)
            {
                // My combobox column is the second one so I hard coded a 1, flavor to taste
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
                if (cb.Value != null)
                {
                    supplierPrices[e.RowIndex].SupplierCode = suppliers[cb.Items.IndexOf(cb.Value)].SupplierCode;
                    // do stuff
                    dataGridView1.Invalidate();
                }
            } else if (e.ColumnIndex == 1)
            {
                DataGridViewTextBoxCell tb = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[1];
                if (tb.Value != null)
                {
                    // do stuff
                    supplierPrices[e.RowIndex].Price = float.Parse(tb.Value.ToString());
                    dataGridView1.Invalidate();
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (dataGridView1.Rows.Count > 1)
                {

                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    supplierPrices.RemoveAt(e.RowIndex);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SupplierPrice supplierPrice = new SupplierPrice();
            supplierPrice.Price = 0;
            supplierPrices.Add(supplierPrice);
            dataGridView1.Rows.Add();
        }
    }
}
