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
    public partial class BinLocationIncomingOrderForm : Form
    {
        private Form form;
        private List<ListIncomingOrder> incomingOrders = new List<ListIncomingOrder>();
        private List<OrderLineDetail> orderLines = new List<OrderLineDetail>();
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IOrderHeaderRepository _orderHeaderRepository;
        public BinLocationIncomingOrderForm(Form form)
        {
            InitializeComponent();
            this.form = form;
            _incomingOrderRepository = new IncomingOrderRepository();
            _orderLineRepository = new OrderLineRepository();
            _orderHeaderRepository = new OrderHeaderRepository();
        }

        private void BinLocationIncomingOrderForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            AddDataGridView1Columns();
            GetOrders(null);
        }

        private void GetOrders(string orderId)
        {
            incomingOrders.Clear();
            dataGridView1.Rows.Clear();
            orderLines.Clear();
                string query = "SELECT IncomingOrder.OrderId AS OrderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, IncomingOrder.Status AS Status, IncomingOrder.OrderHeaderId AS OrderHeaderId FROM IncomingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId WHERE IncomingOrder.Status != 'Completed'";
                List<IncomingOrderDetails> incomingOrderDetails = _incomingOrderRepository.GetIncompleteIncomingOrderWithOrderHeader();
                if (!string.IsNullOrEmpty(orderId))
                {
                    if (!string.IsNullOrEmpty(orderId))
                    {
                        query += " AND IncomingOrder.OrderId Like %@OrderId%";
                        incomingOrderDetails = incomingOrderDetails
                            .Where(ioDetails => ioDetails.OrderId.Equals(orderId)).ToList();
                    }
                }
                    foreach (IncomingOrderDetails item in incomingOrderDetails)
                    {
                        ListIncomingOrder incomingOrder = new ListIncomingOrder();
                        incomingOrder.OrderId = item.OrderId;
                        incomingOrder.CreatedAt = item.CreatedAt;
                        incomingOrder.UpdatedAt = item.UpdatedAt;
                        incomingOrder.OrderHeaderId = item.OrderHeaderId;
                        incomingOrder.Status = item.Status;
                        incomingOrders.Add(incomingOrder);
                    
                        query = "SELECT OrderLine.LineId AS LineId, OrderLine.Quantity AS Quantity, OrderLine.Status AS Status, OrderLine.SparePartId AS SparePartId, BinLocation_Spare.BinLocationCode AS BinLocationCode, Spare.Name AS Name, Spare.SpareId AS SpareId FROM OrderLine JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId JOIN Spare ON Spare.SpareId = BinLocation_Spare.SpareId WHERE OrderLine.OrderHeaderId = @OrderHeaderId";
                        List<OrderLineDetail> orderLineDetails = _orderLineRepository
                                                            .GetOrderLineDetailByBinLocationCode(StaffManager.Instance.GetBinLocationCode())
                                                            .Where(olDetails=> olDetails.OrderHeaderId.Equals(incomingOrder.OrderHeaderId))
                                                            .ToList();
                            if (orderLineDetails != null)
                            {
                                incomingOrder.OrderLines = new List<OrderLineDetail>();
                                foreach (OrderLineDetail line in orderLineDetails)
                                {
                                    OrderLineDetail orderLine = new OrderLineDetail();
                                    orderLine.LineId = line.LineId;
                                    orderLine.Quantity = line.Quantity;
                                    orderLine.Status = line.Status;
                                    orderLine.SparePartId = line.SparePartId;
                                    orderLine.BinLocationCode = line.BinLocationCode;
                                    orderLine.Name = line.Name;
                                    orderLine.SpareId = line.SpareId;
                                    orderLine.OrderHeaderId = incomingOrder.OrderHeaderId;
                                    incomingOrder.OrderLines.Add(orderLine);
                                    if (orderLine.BinLocationCode == StaffManager.Instance.GetBinLocationCode())
                                    {
                                        orderLines.Add(orderLine);
                                        dataGridView1.Rows.Add(incomingOrder.OrderId, orderLine.SpareId, orderLine.Name, incomingOrder.CreatedAt, orderLine.Status);
                                    }
                                }
                        }
                    }
        }
        private void AddDataGridView1Columns()
        {
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Order ID";
            idColumn.DataPropertyName = "Order ID";
            idColumn.ReadOnly = true;
            idColumn.HeaderText = "Order ID";
            idColumn.MinimumWidth = 200;

            DataGridViewTextBoxColumn orderColumn = new DataGridViewTextBoxColumn();
            orderColumn.Name = "Spare ID";
            orderColumn.DataPropertyName = "Spare ID";
            orderColumn.ReadOnly = true;
            orderColumn.HeaderText = "Spare ID";
            orderColumn.MinimumWidth = 100;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.HeaderText = "Name";
            nameColumn.MinimumWidth = 100;

            DataGridViewTextBoxColumn orderDateColumn = new DataGridViewTextBoxColumn();
            orderDateColumn.Name = "Order Date";
            orderDateColumn.DataPropertyName = "Order Date";
            orderDateColumn.ReadOnly = true;
            orderDateColumn.HeaderText = "Order Date";
            orderDateColumn.Width = 150;

            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            new DataGridViewComboBoxColumn();

            statusColumn.Items.Add("Available");
            statusColumn.Items.Add("Pending");
            statusColumn.Items.Add("Picking up");
            statusColumn.Items.Add("Ready");
            statusColumn.Name = "Item Status";
            statusColumn.HeaderText = "Item Status";
            statusColumn.ReadOnly = false;
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

            dataGridView1.Columns.Add(idColumn);
            dataGridView1.Columns.Add(orderColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(orderDateColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(detailsButton);
            dataGridView1.Columns.Add(updateButton);
        }

        private void BinLocationIncomingOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            GetOrders(null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetOrders(textBox1.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                this.Hide();
                AddSpareForm form = new AddSpareForm(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                form.ShowDialog();
            }
            else if (e.ColumnIndex == 6)
            {
                string status = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                OrderLineDetail orderLine = orderLines[e.RowIndex];
                ListIncomingOrder incomingOrderDetails = incomingOrders.Find(x => x.OrderHeaderId == orderLine.OrderHeaderId);
                OrderLine ol = _orderLineRepository.GetOrderLineById(orderLines[e.RowIndex].LineId);
                ol.Status = status;
                _orderLineRepository.UpdateOrderLine(ol);
                string query = "UPDATE OrderLine SET Status = @Status WHERE LineId = @LineId";

                query = "UPDATE IncomingOrder SET Status = @Status WHERE OrderHeaderId = @OrderHeaderId";
                IncomingOrder io = _incomingOrderRepository.GetIncomingOrderByOrderHeaderId(incomingOrderDetails.OrderHeaderId);
                io.Status = "Processing";
                _incomingOrderRepository.UpdateIncomingOrder(io);

                 if (status == "Ready")
                {
                        int index = incomingOrderDetails.OrderLines.FindIndex(x => x.LineId == orderLine.LineId);
                        incomingOrderDetails.OrderLines[index].Status = "Ready";
                        bool isAllReady = true;
                        foreach (OrderLineDetail line in incomingOrderDetails.OrderLines)
                        {
                            if (line.Status != "Ready")
                            {
                                isAllReady = false;
                                break;
                            }
                        }
                        if (isAllReady)
                        {
                            IncomingOrder incomingOrder = _incomingOrderRepository.GetIncomingOrderByOrderHeaderId(incomingOrderDetails.OrderHeaderId);
                            incomingOrder.Status = "Ready";
                            _incomingOrderRepository.UpdateIncomingOrder(incomingOrder);
                        }
                }
                    OrderHeader orderHeader = _orderHeaderRepository.GetOrderHeaderById(orderLines[e.RowIndex].OrderHeaderId);
                    orderHeader.UpdatedAt = DateTime.Now;
                    _orderHeaderRepository.UpdateOrderHeader(orderHeader);

                GetOrders(textBox1.Text);
            }
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
