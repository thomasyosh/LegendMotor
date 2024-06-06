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
    public partial class PurchasingOrderList : Form
    {
        private Form form;
        public PurchasingOrderList(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void PurchasingOrderList_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            AddDataGridView1Columns();
            dataGridView1.Rows.Add(Guid.NewGuid().ToString(), "2023-12-31", "Pending");
        }

        private void AddDataGridView1Columns()
        {
            DataGridViewTextBoxColumn orderColumn = new DataGridViewTextBoxColumn();
            orderColumn.Name = "Order ID";
            orderColumn.DataPropertyName = "Order ID";
            orderColumn.ReadOnly = true;
            orderColumn.HeaderText = "Order ID";
            orderColumn.MinimumWidth = 400;

            DataGridViewTextBoxColumn orderDateColumn = new DataGridViewTextBoxColumn();
            orderDateColumn.Name = "Order Date";
            orderDateColumn.DataPropertyName = "Order Date";
            orderDateColumn.ReadOnly = true;
            orderDateColumn.HeaderText = "Order Date";
            orderDateColumn.Width = 150;

            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            new DataGridViewComboBoxColumn();

            statusColumn.Items.Add("Cancelled");
            statusColumn.Items.Add("Complated");
            statusColumn.Items.Add("Confirmed");
            statusColumn.Items.Add("Deliveried");
            statusColumn.Items.Add("Pending");
            statusColumn.Items.Add("Rejected");
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.ReadOnly = true;
            statusColumn.Width = 100;



            DataGridViewButtonColumn detailsButton = new DataGridViewButtonColumn();
            detailsButton.Text = "Details";
            detailsButton.UseColumnTextForButtonValue = true;
            detailsButton.Width = 100;
            detailsButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewButtonColumn updateButton = new DataGridViewButtonColumn();
            updateButton.Text = "Update";
            updateButton.UseColumnTextForButtonValue = true;
            updateButton.Width = 100;
            updateButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns.Add(orderColumn);
            dataGridView1.Columns.Add(orderDateColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(detailsButton);
            dataGridView1.Columns.Add(updateButton);
        }

        private void PurchasingOrderList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                this.Hide();
                PurchasingOrderDetails purchasingOrderDetails = new PurchasingOrderDetails();
                purchasingOrderDetails.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                purchasingOrderDetails.Show();
            }
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
