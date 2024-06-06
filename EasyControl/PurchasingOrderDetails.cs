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
    public partial class PurchasingOrderDetails : Form
    {
        public PurchasingOrderDetails()
        {
            InitializeComponent();
        }

        private void PurchasingOrderDetails_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
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
            dataGridView1.Columns.Add(priceColumn);
            dataGridView1.Columns.Add(quantityColumn);
            dataGridView1.Columns.Add(subTotalColumn);
        }
    }
}
