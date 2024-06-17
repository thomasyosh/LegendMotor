using LegendMotor.Dal.Repository;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;

namespace LegendMotor.WinForm
{
    public partial class DeliveryIncomingOrderList : Form
    {
        private List<ListIncomingOrder> incomingOrders = new List<ListIncomingOrder>();
        DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        private readonly IOrderHeaderRepository _orderHeaderRepository;
        public DeliveryIncomingOrderList()
        {
            InitializeComponent();
            _incomingOrderRepository = new IncomingOrderRepository();
            _orderHeaderRepository = new OrderHeaderRepository();
        }

        private void DeliveryIncomingOrderList_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            AddDataGridView1Columns();
            GetOrders(null, null);
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

            statusColumn.Items.Add("Ready");
            statusColumn.Items.Add("Shipping");
            statusColumn.Items.Add("Completed");
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
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

            dataGridView1.Columns.Add(orderColumn);
            dataGridView1.Columns.Add(orderDateColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(detailsButton);
            dataGridView1.Columns.Add(updateButton);
        }

        private void GetOrders(string orderId, string status)
        {
            incomingOrders.Clear();
            dataGridView1.Rows.Clear();
                string query = "SELECT IncomingOrder.OrderId AS OrderId, OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt, IncomingOrder.Status AS Status FROM IncomingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId";
                List<IncomingOrderDetails> details = _incomingOrderRepository.GetAllIncomingOrderWithOrderHeader();
                if (!string.IsNullOrEmpty(orderId) || !string.IsNullOrEmpty(status))
                {
                    query += " WHERE ";
                    if (!string.IsNullOrEmpty(orderId))
                    {
                        details = details.Where(ioDetails => ioDetails.OrderId.Equals(orderId)
                                         && ioDetails.Status.Equals("Ready")
                                         || ioDetails.Status.Equals("Shipping")).ToList();
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        query += " Status = @Status";
                        details = details.Where(ioDetails => ioDetails.Status.Equals(status)).ToList();
                    }
                }
                else if (!string.IsNullOrEmpty(orderId) && !string.IsNullOrEmpty(status))
                {
                    query += " WHERE OrderId = @OrderId AND Status = @Status";
                    details = details.Where(ioDetails => ioDetails.Status.Equals(status)
                                            && ioDetails.OrderId.Equals (orderId)
                                            ).ToList();
                } else
                {
                    query += " WHERE Status = 'Ready' OR Status = 'Shipping'";
                    details = details.Where(ioDetails => ioDetails.Status.Equals("Ready")
                                || ioDetails.Status.Equals("Shipping")
                        ).ToList();
                }
                    foreach (var item in details)
                    {
                        ListIncomingOrder incomingOrder = new ListIncomingOrder();
                        incomingOrder.OrderId = item.OrderId;
                        incomingOrder.CreatedAt = item.CreatedAt;
                        incomingOrder.UpdatedAt = item.UpdatedAt;
                        incomingOrder.Status = item.Status;
                        incomingOrders.Add(incomingOrder);
                        dataGridView1.Rows.Add(incomingOrder.OrderId, incomingOrder.CreatedAt, incomingOrder.Status);
                    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetOrders(textBox1.Text, comboBox1.Text);
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ListIncomingOrder order = incomingOrders[e.RowIndex];
            if (e.ColumnIndex == 3)
            {
                IncomingOrderDetailsForm incomingOrderDetails = new IncomingOrderDetailsForm(order.OrderId);
                incomingOrderDetails.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                incomingOrderDetails.ShowDialog();
            }
            else if (e.ColumnIndex == 4)
            {
                string status = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string query = "UPDATE IncomingOrder SET Status = @Status WHERE OrderId = @OrderId";
                    IncomingOrder incomingOrder = _incomingOrderRepository.GetIncomingOrderByOrderId(order.OrderId);
                    incomingOrder.Status = status;
                    _incomingOrderRepository.UpdateIncomingOrder(incomingOrder);

                    query = "UPDATE OrderHeader SET UpdatedAt = @UpdatedAt WHERE OrderHeaderId = @OrderHeaderId";
                    OrderHeader header = _orderHeaderRepository.GetOrderHeaderById(order.OrderHeaderId);
                    header.UpdatedAt = DateTime.Now;
                    _orderHeaderRepository.UpdateOrderHeader(header);
                GetOrders(textBox1.Text, comboBox1.Text);
            }
        }
    }
}
