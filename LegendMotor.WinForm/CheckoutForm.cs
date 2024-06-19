using LegendMotor.Dal.Repository;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;


namespace LegendMotor.WinForm
{
    public partial class CheckoutForm : Form
    {
        private Form form;
        private Dealer dealer;
        private readonly IOrderHeaderRepository _orderHeaderRepository;
        private readonly IBinLocationSpareRepository _binLocationSpareRepository;
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IReservedSpareRepository _reservedSpareRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IPurchasingOrderRepository _purchasingOrderRepository;
        public CheckoutForm(Form form, Dealer dealer)
        {
            InitializeComponent();
            this.form = form;
            this.dealer = dealer;
            lbl_dealer_value.Text = dealer.Name;
            txt_invoiceAddress.Text = dealer.Address;
            txt_invoiceName.Text = dealer.Name;
            _orderHeaderRepository = new OrderHeaderRepository();
            _binLocationSpareRepository = new BinLocationSpareRepository();
            _orderLineRepository = new OrderLineRepository();
            _reservedSpareRepository = new ReservedSpareRepository();
            _invoiceRepository = new InvoiceRepository();
            _purchasingOrderRepository = new PurchasingOrderRepository();
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
        }

        private void GetItems()
        {
            List<CartItem> items = CartManager.Instance.GetItems();
            for (int i = 0; i < items.Count; i++)
            {
                dataGridView1.Rows.Add(items[i].Name, items[i].Location, items[i].Price, items[i].Quantity, items[i].TotalPrice);
            }
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

            DataGridViewTextBoxColumn locationColumn = new DataGridViewTextBoxColumn();
            locationColumn.Name = "Location";
            locationColumn.DataPropertyName = "Location";
            locationColumn.ReadOnly = true;
            locationColumn.HeaderText = "Location";
            locationColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            locationColumn.MinimumWidth = 200;

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
            dataGridView1.Columns.Add(locationColumn);
            dataGridView1.Columns.Add(priceColumn);
            dataGridView1.Columns.Add(quantityColumn);
            dataGridView1.Columns.Add(subTotalColumn);

            GetItems();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_delivery.Enabled = !checkBox1.Checked;
            if (checkBox1.Checked)
            {
                txt_delivery.Text = txt_invoiceAddress.Text;
            }
            else
            {
                txt_delivery.Text = "";
            }
        }

        private void CheckoutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }

        private void txt_invoiceAddress_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_delivery.Text = txt_invoiceAddress.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_invoiceName.Text == "")
            {
                MessageBox.Show("Please fill the invoice name");
                return;
            }
            if (txt_invoiceAddress.Text == "")
            {
                MessageBox.Show("Please fill the invoice address");
                return;
            }
            if (txt_delivery.Text == "")
            {
                MessageBox.Show("Please fill the delivery address");
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a contact type");
                return;
            }
                string query = "INSERT INTO OrderHeader (OrderHeaderId, CreatedAt, UpdatedAt) VALUES (@OrderHeaderId, @CreatedAt, @UpdatedAt)";
                OrderHeader header = new OrderHeader();
                header.OrderHeaderId = Guid.NewGuid().ToString();
                header.CreatedAt = header.UpdatedAt = DateTime.Now;
                
                try
                {
                    _orderHeaderRepository.AddOrderHeader(header);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to create order");
                    return;
                }

                List<RequireOrderItem> items = new List<RequireOrderItem>();
                bool needWaitingPurhcingOrder = false;
                foreach (CartItem item in CartManager.Instance.GetItems())
                {
                    BinLocationSpare binLocationSpare = _binLocationSpareRepository.GetBinLocationSpareById(item.SparePartId);
                    bool needWaitingPurhcingOrderLine = false;
                            if (binLocationSpare != null)
                            {
                                int reorderLevel = binLocationSpare.ROL;
                                int curStock = binLocationSpare.Stock;
                                int newStock = curStock - item.Quantity > 0 ? curStock - item.Quantity : 0;
                                if (newStock == 0)
                                {
                                    needWaitingPurhcingOrderLine = true;
                                    needWaitingPurhcingOrder = true;
                                }
                                if (newStock <= reorderLevel)
                                {
                                    RequireOrderItem requireOrderItem = new RequireOrderItem();
                                    requireOrderItem.SparePartId = item.SparePartId;
                                    requireOrderItem.Quantity = item.Quantity + reorderLevel * 2 - curStock;
                                    requireOrderItem.Price = item.Price;
                                    items.Add(requireOrderItem);
                                    if (newStock >= 0)
                                    {
                                        BinLocationSpare bls = _binLocationSpareRepository.GetBinLocationSpareById(item.SparePartId);
                                        bls.Stock = newStock;
                                        bls.BinLocationCode = binLocationSpare.BinLocationCode;
                                        _binLocationSpareRepository.UpdateBinLocationSpare(bls);
                                    }
                                } else
                                {
                                    BinLocationSpare bls = _binLocationSpareRepository
                                                    .GetBinLocationSpareByBinLocationCodeAndId
                                                    (
                                                        binLocationSpare.BinLocationCode,
                                                        item.SparePartId
                                                    );
                                    bls.Stock = newStock;
                                    _binLocationSpareRepository .UpdateBinLocationSpare(bls);
                                }

                    query = "INSERT INTO OrderLine (LineId, OrderHeaderId, SparePartId, Quantity, Status) VALUES (@LineId, @OrderHeaderId, @SparePartId, @Quantity, @Status)";
                    OrderLine line = new OrderLine();
                    line.LineId = Guid.NewGuid().ToString();
                    line.OrderHeaderId = header.OrderHeaderId;
                    line.SparePartId = item.SparePartId;
                    line.Quantity = item.Quantity;
                    line.Status = needWaitingPurhcingOrderLine ? "Pending" : "Available";
                    _orderLineRepository.AddOrderLine(line);

                    if (item.ReservedItemId != "")
                    {
                        query = "DELETE FROM ReservedSpare WHERE ReservedSpareId = @ReservedSpareId";
                        _reservedSpareRepository.RemoveReservedItemById(item.ReservedItemId);

                        query = "UPDATE BinLocation_Spare SET Reserved = Reserved - @ReservedQuantity WHERE Id = @SparePartId";
                        BinLocationSpare bls = _binLocationSpareRepository.GetBinLocationSpareById(item.SparePartId);
                        bls.Reserved = item.Quantity;
                        _binLocationSpareRepository.UpdateBinLocationSpare(bls);
                    }
                }
                

                query = "INSERT INTO Invoice (InvoiceId, InvoiceDate, InvoiceAmount) VALUES (@InvoiceId, @InvoiceDate, @InvoiceAmount)";
                Invoice invoice = new Invoice();
                invoice.InvoiceId = Guid.NewGuid().ToString();
                invoice.InvoiceDate = DateTime.Now;
                invoice.InvoiceAmount = CartManager.Instance.GetTotalPrice();
                _invoiceRepository.AddInvoice(invoice);



                query = "INSERT INTO IncomingOrder (OrderId, InvoiceName, InvoiceAddress, DeliveryAddress, DealerCode, Type, Remark, Status, StaffId, OrderHeaderId, InvoiceId) VALUES (@OrderId, @InvoiceName, @InvoiceAddress, @DeliveryAddress, @DealerCode, @Type, @Remark, @Status, @StaffId, @OrderHeaderId, @InvoiceId)";
                IncomingOrder incomingOrder = new IncomingOrder();
                incomingOrder.OrderId = Guid.NewGuid().ToString();
                incomingOrder.InvoiceName = txt_invoiceName.Text;
                incomingOrder.InvoiceAddress = txt_invoiceAddress.Text;
                incomingOrder.DeliveryAddress = txt_delivery.Text;
                incomingOrder.DealerCode = dealer.DealerCode;
                incomingOrder.Type = comboBox1.SelectedItem.ToString();
                incomingOrder.Remark = richTextBox1.Text;
                incomingOrder.Status = needWaitingPurhcingOrder ? "Pending" : "Available";
                incomingOrder.staffId = StaffManager.Instance.GetStaffId();
                incomingOrder.OrderHeaderId = header.OrderHeaderId;
                incomingOrder.InvoiceId = invoice.InvoiceId;

                if (items.Count > 0)
                {
                    query = "INSERT INTO OrderHeader (OrderHeaderId, CreatedAt, UpdatedAt) VALUES (@OrderHeaderId, @CreatedAt, @UpdatedAt)";
                    string purchasingOrderHeaderId = Guid.NewGuid().ToString();
                    OrderHeader orderHeader = new OrderHeader();
                    orderHeader.OrderHeaderId = purchasingOrderHeaderId;
                    orderHeader.CreatedAt = DateTime.Now;
                    orderHeader.UpdatedAt = DateTime.Now;
                    _orderHeaderRepository.AddOrderHeader(orderHeader);

                    query = "INSERT INTO OrderLine (LineId, OrderHeaderId, SparePartId, Quantity) VALUES (@LineId, @OrderHeaderId, @SparePartId, @Quantity)";

                    foreach (RequireOrderItem requireOrderItem in items)
                    {
                        OrderLine line = new OrderLine();
                        line.LineId = Guid.NewGuid().ToString();
                        line.OrderHeaderId = purchasingOrderHeaderId;
                        line.SparePartId = requireOrderItem.SparePartId;
                        line.Quantity = requireOrderItem.Quantity;
                        _orderLineRepository.AddOrderLine(line);
                    }

                    query = "INSERT INTO PurchasingOrder (OrderId, Status, IncomingOrderId, OrderHeaderId) VALUES (@OrderId, @Status, @IncomingOrderId, @OrderHeaderId)";
                    PurchasingOrder purchasingOrder = new PurchasingOrder();
                    purchasingOrder.OrderId = Guid.NewGuid().ToString();
                    purchasingOrder.Status = "Pending";
                    purchasingOrder.IncomingOrderId = incomingOrder.OrderId;
                    purchasingOrder.OrderHeaderId = purchasingOrderHeaderId;
                    _purchasingOrderRepository.AddPurchaseOrder(purchasingOrder);
                }

                CartManager.Instance.Clear();
                MessageBox.Show("Order created successfully");
                this.Close();
            }
        }
    }
}
