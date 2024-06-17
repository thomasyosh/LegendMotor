using LegendMotor.Dal.Repository;
using LegendMotor.Domain.Abstractions.Repositories;
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
    public partial class SalesOrderDetails : Form
    {
        private string staffId;
        private List<ListIncomingOrder> incomingOrders = new List<ListIncomingOrder>();
        private IStaffRepository _staffRepository;
        private IIncomingOrderRepository _incomingOrderRepository;
        public SalesOrderDetails(string staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
            this._staffRepository = new StaffRepository();
            this._incomingOrderRepository = new IncomingOrderRepository();
        }

        private void GetSales()
        {

                string query = "SELECT Staff.Name AS Name, Staff.Email AS Email, Staff.Phone AS Contact, Position.Name AS Position FROM Staff JOIN Position ON Position.PositionCode = Staff.PositionCode WHERE StaffId = @StaffId";
                StaffDetails staffDetails = _staffRepository.GetStaffDetails(staffId);
                {
                    lbl_name.Text = "Name: " + staffDetails.Name.ToString().Trim();
                    lbl_position.Text = "Position: " + staffDetails.Description.ToString().Trim();
                    lbl_email.Text = "Email: " + staffDetails.Email.ToString().Trim();
                    lbl_contact.Text = "Contact: " + staffDetails.Phone.ToString().Trim();
                }

        }

        private void GetOrders(string status)
        {
            incomingOrders.Clear();
            dataGridView1.Rows.Clear();
            var queryIncomingOrder = _incomingOrderRepository.GetIncomingOrderByStaffIdAndStatus(staffId, status);

                    foreach (var item in queryIncomingOrder)
                    {
                        ListIncomingOrder incomingOrder = new ListIncomingOrder();
                        incomingOrder.OrderId = item.OrderId.ToString();
                        incomingOrder.CreatedAt = DateTime.Parse(item.CreatedAt.ToString().Trim());
                        incomingOrder.UpdatedAt = DateTime.Parse(item.UpdatedAt.ToString().Trim());
                        incomingOrder.OrderHeaderId = item.OrderHeaderId.ToString().Trim();
                        incomingOrder.Status = item.Status.ToString().Trim();
                        incomingOrder.InvoiceId = item.InvoiceId.ToString().Trim();

                        incomingOrders.Add(incomingOrder);
                        dataGridView1.Rows.Add(incomingOrder.OrderId, incomingOrder.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"), incomingOrder.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"), incomingOrder.Status);
                    }
        }

        private void AddDataGridViewColumns()
        {
            DataGridViewTextBoxColumn orderNoColumn = new DataGridViewTextBoxColumn();
            orderNoColumn.Name = "Order No";
            orderNoColumn.DataPropertyName = "OrderNo";
            orderNoColumn.ReadOnly = true;
            orderNoColumn.HeaderText = "Order No";
            orderNoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            orderNoColumn.MinimumWidth = 400;

            DataGridViewTextBoxColumn orderDateColumn = new DataGridViewTextBoxColumn();
            orderDateColumn.Name = "Order Date";
            orderDateColumn.DataPropertyName = "OrderDate";
            orderDateColumn.ReadOnly = true;
            orderDateColumn.HeaderText = "OrderDate";

            DataGridViewTextBoxColumn updateColumn = new DataGridViewTextBoxColumn();
            updateColumn.Name = "Last Update";
            updateColumn.DataPropertyName = "Last Update";
            updateColumn.ReadOnly = true;
            updateColumn.HeaderText = "Last Update";

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.DataPropertyName = "Status";
            statusColumn.ReadOnly = true;
            statusColumn.HeaderText = "Status";

            DataGridViewButtonColumn detailsButton = new DataGridViewButtonColumn();
            detailsButton.Text = "Details";
            detailsButton.UseColumnTextForButtonValue = true;
            detailsButton.Width = 100;
            detailsButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewButtonColumn invoiceButton = new DataGridViewButtonColumn();
            invoiceButton.Text = "Invoice";
            invoiceButton.UseColumnTextForButtonValue = true;
            invoiceButton.Width = 100;
            invoiceButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns.Add(orderNoColumn);
            dataGridView1.Columns.Add(orderDateColumn);
            dataGridView1.Columns.Add(updateColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(detailsButton);
            dataGridView1.Columns.Add(invoiceButton);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                GetOrders(null);
            }
            else 
            {
                GetOrders(comboBox1.Text);
            }
        }

        private void SalesOrderDetails_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            AddDataGridViewColumns();
            GetSales();
            GetOrders(null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                Guid orderId = (Guid)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                IncomingOrderDetailsForm form = new IncomingOrderDetailsForm(orderId);
                form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                form.ShowDialog();
            }
            else if (e.ColumnIndex == 5)
            {
                Guid orderId = (Guid)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                /*Invoice form = new Invoice(orderId);
                form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                form.ShowDialog();*/
            }
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
