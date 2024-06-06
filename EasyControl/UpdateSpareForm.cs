using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyControl
{
    public partial class UpdateSpareForm : Form
    {
        public UpdateSpareForm()
        {
            InitializeComponent();
        }

        private void UpdateSpareForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
        }
        private void AddDataGridViewColumns()
        {
            DataGridViewComboBoxColumn supplierColumn = new DataGridViewComboBoxColumn();
            supplierColumn.Name = "Supplier";
            supplierColumn.DataPropertyName = "Supplier";
            supplierColumn.ReadOnly = false;
            supplierColumn.HeaderText = "Supplier";
            supplierColumn.Items.Add("Supplier A");
            supplierColumn.Items.Add("Supplier B");
            supplierColumn.Items.Add("Supplier C");
            supplierColumn.Items.Add("Supplier D");

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.Name = "Price";
            priceColumn.DataPropertyName = "Price";
            priceColumn.ReadOnly = false;
            priceColumn.HeaderText = "Price";
            priceColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.MinimumWidth = 100;
            deleteButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dataGridView1.Columns.Add(supplierColumn);
            dataGridView1.Columns.Add(priceColumn);
            dataGridView1.Columns.Add(deleteButton);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (dataGridView1.Rows.Count > 1)
                {

                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
