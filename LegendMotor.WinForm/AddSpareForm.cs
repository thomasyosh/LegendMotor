using LegendMotor.Dal.Repository;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
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
using ZstdSharp.Unsafe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LegendMotor.WinForm
{
    public partial class AddSpareForm : Form
    {
        private readonly ISparePriceRepository _sparePriceRepository;
        private readonly ISpareRepository _spareRepository;
        private readonly ISupplierRepository _supplierRepository;
        private List<Supplier> suppliers = new List<Supplier>();
        private List<SupplierPrice> supplierPrices = new List<SupplierPrice>();
        DataGridViewComboBoxColumn supplierColumn = new DataGridViewComboBoxColumn();
        private string spareId;
        public AddSpareForm(string spareId)
        {
            InitializeComponent();
            this._sparePriceRepository = new SparePriceRepository();
            this._spareRepository = new SpareRepository();
            this._supplierRepository = new SupplierRepository();
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
            Spare item = _spareRepository.GetSpareBySpareId(spareId);
            if (item != null)
            {
                textBox1.Text = item.Name;
                richTextBox1.Text = item.Description;
                comboBox1.Text = item.Category;
                comboBox1.SelectedIndex = comboBox1.FindStringExact(item.Category);
                textBox2.Text = item.Price.ToString();
                textBox3.Text = item.Weight.ToString();
                byte[] img = (item.Url);
                pictureBox1.Image = Image.FromStream(new MemoryStream(img));
            }

            var sparePrice = _sparePriceRepository.GetSparePriceBySpareId(spareId);
            if (sparePrice != null)
            {
                SupplierPrice supplierPrice = new SupplierPrice();
                supplierPrice.SupplierCode = sparePrice.SupplierCode;
                supplierPrice.Price = float.Parse(sparePrice.PurchasingPrice.ToString());
                supplierPrices.Add(supplierPrice);
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
            if (StaffManager.Instance.GetStaffPosition() == "pd")
            {
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
            var supplierItem = _supplierRepository.GetAllSupplier();

            foreach (var item in supplierItem)
            {
                supplierColumn.Items.Add(item.Name);
                suppliers.Add(item);
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

        private void button3_Click(object sender, EventArgs e)
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
            }
            catch (FormatException ex)
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
            var spareItem = _spareRepository.GetAllSpare();
            int failed = 0;
            if (this.spareId == null)
            {
                int count = 0;
                count++;
                string spareId = Guid.NewGuid().ToString();
                Spare spare = new Spare();
                spare.SpareId = spareId;
                spare.Name = name;
                spare.Description = description;
                spare.Category = category;
                spare.Price = (int)price;
                spare.Weight = (int)weight;
                spare.Url = ImageToByteArray(pictureBox1.Image);
                spare.Count = count;
                try
                {
                    _spareRepository.CreateSpare(spare);
                    MessageBox.Show("Spare added successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting data into Database!");
                    failed++;
                }

                for (int i = 0; i < supplierPrices.Count; i++)
                {

                    SparePrice sparePrice = new SparePrice();
                    sparePrice.SpareID = spareId;
                    sparePrice.SupplierCode = supplierPrices[i].SupplierCode;

                    try
                    {
                        _sparePriceRepository.CreateSparePrice(sparePrice);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                        failed++;
                    }
                }
            }
            else
            {

                Spare updateSpare = _spareRepository.GetSpareBySpareId(spareId);
                updateSpare.SpareId = spareId;
                updateSpare.Name = name;
                updateSpare.Description = description;
                updateSpare.Category = category;
                updateSpare.Price = (int)price;
                updateSpare.Weight = (int)weight;
                updateSpare.Url = ImageToByteArray(pictureBox1.Image);
                updateSpare.Count = supplierPrices.Count;

                try
                {
                    _spareRepository.UpdateSpareBySpare(updateSpare);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting data into Database!");
                    failed++;
                }

                _spareRepository.DeleteSpareBySpareId(spareId);

                for (int i = 0; i < supplierPrices.Count; i++)
                {
                    SparePrice sparePrice = new SparePrice();
                    sparePrice.SpareID = spareId;
                    sparePrice.SupplierCode = supplierPrices[i].SupplierCode;
                    sparePrice.PurchasingPrice = supplierPrices[i].Price;
                    try
                    {
                        _sparePriceRepository.CreateSparePrice(sparePrice);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                        failed++;
                    }
                }
            }
            if (failed == 0)
            {
                this.Close();
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
            }
            else if (e.ColumnIndex == 1)
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
