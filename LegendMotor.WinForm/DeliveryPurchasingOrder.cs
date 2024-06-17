using LegendMotor.Dal.Repository;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;

namespace LegendMotor.WinForm
{
    public partial class DeliveryPurchasingOrder : Form
    {
        private List<BinLocation> binLocations = new List<BinLocation>();
        private List<ListOrderLine> orderLines = new List<ListOrderLine>();
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IPurchasingOrderRepository _purchasingOrderRepository;
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        private readonly IOrderHeaderRepository _orderHeaderRepository;
        private readonly IBinLocationRepository _binLocationRepository;
        public DeliveryPurchasingOrder()
        {
            InitializeComponent();
            _orderLineRepository = new OrderLineRepository();
            _purchasingOrderRepository = new PurchasingOrderRepository();
            _incomingOrderRepository = new IncomingOrderRepository();
            _orderHeaderRepository = new OrderHeaderRepository();
            _binLocationRepository = new BinLocationRepository();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                this.Hide();
                AddSpareForm form = new AddSpareForm(orderLines[e.RowIndex].SpareId);
                form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                form.ShowDialog();
            }
            else if (e.ColumnIndex == 6)
            {
                string lineId = orderLines[e.RowIndex].LineId;
                string orderId = orderLines[e.RowIndex].OrderId;
                string orderHeaderId = orderLines[e.RowIndex].OrderHeaderId;
                string status = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                string query = "UPDATE OrderLine SET Status = @Status WHERE LineId = @LineId";
                OrderLine orderLine = _orderLineRepository.GetOrderLineById(lineId);
                orderLine.Status = status;
                _orderLineRepository.UpdateOrderLine(orderLine);

                query = "UPDATE PurchasingOrder SET Status = @Status WHERE OrderId = @OrderId";
                PurchasingOrder po = _purchasingOrderRepository.GetPurchasingOrderById(orderId);
                po.Status = "Processing";
                _purchasingOrderRepository.UpdatePurchaseOrder(po);
                string incomingOrderId = orderLines[e.RowIndex].IncomingOrderId;
                List<OrderLine> orderLineDetail = _orderLineRepository.GetOrderLineByIncomingOrderId(incomingOrderId);
                foreach (OrderLine item in orderLineDetail)
                {
                    string incomingOrderLineId = item.LineId;
                    string incomingOrderHeaderId = item.OrderHeaderId;
                    if (status == "Completed")
                    {
                        query = "UPDATE OrderLine SET Status = @Status WHERE LineId = @LineId";
                        item.Status = "Ready";
                        _orderLineRepository.UpdateOrderLine(item);
                    }
                    else
                    {
                        query = "UPDATE IncomingOrder SET Status = 'Processing' WHERE OrderId = @OrderId";
                        IncomingOrder incomingOrder = _incomingOrderRepository.GetIncomingOrderByOrderId(incomingOrderId);
                        incomingOrder.Status = "Processing";
                        _incomingOrderRepository.UpdateIncomingOrder(incomingOrder);
                    }

                    query = "UPDATE OrderHeader SET UpdatedAt = @UpdatedAt WHERE OrderHeaderId = @OrderHeaderId";
                    OrderHeader orderHeader = _orderHeaderRepository.GetOrderHeaderById(incomingOrderHeaderId);
                    orderHeader.UpdatedAt = DateTime.Now;
                    _orderHeaderRepository.UpdateOrderHeader(orderHeader);
                }
            }
        }


        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            comboBox1.SelectedIndex = 0;
            dataGridView1.Rows.Clear();
            orderLines.Clear();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOrderLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetOrderLine();
        }

        private void DeliveryPurchasingOrder_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
            getBinLocations();
        }
        private void AddDataGridViewColumns()
        {
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID";
            idColumn.DataPropertyName = "ID";
            idColumn.ReadOnly = true;
            idColumn.HeaderText = "ID";
            idColumn.MinimumWidth = 300;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.HeaderText = "Name";
            nameColumn.Width = 150;

            DataGridViewTextBoxColumn orderDateColumn = new DataGridViewTextBoxColumn();
            orderDateColumn.Name = "Order Date";
            orderDateColumn.DataPropertyName = "Order Date";
            orderDateColumn.ReadOnly = true;
            orderDateColumn.HeaderText = "Order Date";
            orderDateColumn.Width = 150;

            DataGridViewTextBoxColumn lastUpdateColumn = new DataGridViewTextBoxColumn();
            lastUpdateColumn.Name = "Last Update";
            lastUpdateColumn.DataPropertyName = "Last Update";
            lastUpdateColumn.ReadOnly = true;
            lastUpdateColumn.HeaderText = "Last Update";
            lastUpdateColumn.Width = 150;

            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.DataPropertyName = "Status";
            statusColumn.ReadOnly = false;
            statusColumn.HeaderText = "Status";
            statusColumn.Items.Add("Completed");
            statusColumn.Items.Add("Ready");
            statusColumn.Items.Add("Shipping");

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
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(orderDateColumn);
            dataGridView1.Columns.Add(lastUpdateColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(detailsButton);
            dataGridView1.Columns.Add(updateButton);

        }
        private void getBinLocations()
        {

            string query = "SELECT * FROM BinLocation";
            List<BinLocation> binLocations = _binLocationRepository.GetBinLocations();
            {
                foreach (BinLocation binLocation in binLocations)
                {
                    binLocations.Add(binLocation);
                    comboBox2.Items.Add(binLocation.Name);
                }
            }
        }

        private void GetOrderLine()
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a destination");
                return;
            }
            dataGridView1.Rows.Clear();
            orderLines.Clear();
            string query = "SELECT OrderLine.LineId AS LineId, PurchasingOrder.OrderId AS OrderId, OrderHeader.OrderHeaderId AS OrderHeaderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, OrderLine.Status AS Status, Spare.Name AS Name, Spare.SpareId AS SpareId, BinLocation_Spare.Id AS SparePartId, PurchasingOrder.IncomingOrderId AS IncomingOrderId FROM OrderLine JOIN OrderHeader ON OrderLine.OrderHeaderId = OrderHeader.OrderHeaderId JOIN PurchasingOrder ON OrderHeader.OrderHeaderId = PurchasingOrder.OrderHeaderId JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId JOIN Spare ON BinLocation_Spare.SpareId = Spare.SpareId WHERE BinLocation_Spare.BinLocationCode = @BinLocationCode";
            List<OrderLineDetail> orderLineDetails = _orderLineRepository.GetOrderLineDetailByBinLocationCode(binLocations[comboBox2.SelectedIndex].BinLocationCode);
            if (comboBox1.SelectedIndex > 0)
            {
                query += " AND OrderLine.Status = @Status";
                orderLineDetails.Where(olDetails => olDetails.Status.Equals(comboBox1.SelectedItem.ToString())).ToList();
            }
            else
            {
                query += " AND (OrderLine.Status = 'Ready' OR OrderLine.Status = 'Shipping')";
                orderLineDetails.Where(olDetails => olDetails.Status.Equals("Ready") || olDetails.Status.Equals("Shipping")).ToList();
            }
            if (textBox1.Text != "")
            {
                query += " AND PurchasingOrder.OrderId LIKE '%" + textBox1.Text + "%'";
                orderLineDetails.Where(olDetails => olDetails.OrderId.Contains(textBox1.Text)).ToList();
            }

            foreach (OrderLineDetail item in orderLineDetails)
            {
                ListOrderLine orderLine = new ListOrderLine();
                orderLine.LineId = item.LineId;
                orderLine.OrderId = item.OrderId;
                orderLine.OrderHeaderId = item.OrderHeaderId;
                orderLine.CreatedAt = item.CreatedAt;
                orderLine.UpdatedAt = item.UpdatedAt;
                orderLine.Status = item.Status;
                orderLine.Name = item.Name;
                orderLine.SpareId = item.SpareId;
                orderLine.SparePartId = item.SparePartId;
                orderLine.IncomingOrderId = item.IncomingOrderId;
                orderLines.Add(orderLine);
                dataGridView1.Rows.Add(orderLine.LineId, orderLine.Name, orderLine.CreatedAt, orderLine.UpdatedAt, orderLine.Status);
            }

        }
    }
}
