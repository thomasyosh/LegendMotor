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
    public partial class UpdateStockForm : Form
    {
        private LoginForm loginForm;
        private List<string> orders = new List<string>();
        private List<PurchasingOrderDetails> purchasingOrders = new List<PurchasingOrderDetails>();
        private readonly IPurchasingOrderRepository _purchasingOrderRepository;
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IOrderHeaderRepository _orderHeaderRepository;
        private readonly IBinLocationSpareRepository _binLocationSpareRepository;
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        public UpdateStockForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            _purchasingOrderRepository = new PurchasingOrderRepository();
            _orderLineRepository = new OrderLineRepository();
            _orderHeaderRepository = new OrderHeaderRepository();
            _binLocationSpareRepository = new BinLocationSpareRepository();
            _incomingOrderRepository = new IncomingOrderRepository();
            }

        private void UpdateStockForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
            GetBinLocationOrders();
        }

        private void GetBinLocationOrders()
        {
           comboBox1.Items.Clear();
            orders.Clear();
                string query = "SELECT PurchasingOrder.OrderId FROM PurchasingOrder JOIN OrderHeader ON OrderHeader.OrderHeaderId = PurchasingOrder.OrderHeaderId JOIN OrderLine ON OrderLine.OrderHeaderId = OrderHeader.OrderHeaderId JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId WHERE BinLocation_Spare.BinLocationCode = @BinLocationCode AND PurchasingOrder.Status != 'Completed'";
            List<PurchasingOrderDetails> purchasingOrderDetails = _purchasingOrderRepository
                                .GetPurchasingOrderDetailByBinLocationCode(StaffManager.Instance.GetBinLocationCode());
                    foreach (PurchasingOrderDetails details in purchasingOrderDetails)
                    {
                        orders.Add(details.OrderId);
                    }

            comboBox1.Items.AddRange(orders.ToArray());
        }

        private void GetBinLocationOrders(string orderId)
        {
            purchasingOrders.Clear();
            dataGridView1.Rows.Clear();

                List<PurchasingOrderDetails> purchasingOrder = _purchasingOrderRepository.GetPurchasingOrderDetailWithOrderHeader(orderId);

                string query = "SELECT * FROM PurchasingOrder WHERE OrderId = @OrderId AND Status != 'Completed'";
                query = "SELECT OrderLine.LineId AS LineId, OrderLine.Quantity AS Quantity, OrderLine.Status AS Status, OrderLine.SparePartId AS SparePartId, BinLocation_Spare.BinLocationCode AS BinLocationCode, Spare.Price AS Price, Spare.Name AS Name, Spare.SpareId AS SpareId FROM OrderLine JOIN BinLocation_Spare ON BinLocation_Spare.Id = OrderLine.SparePartId JOIN Spare ON Spare.SpareId = BinLocation_Spare.SpareId WHERE OrderLine.OrderHeaderId = @OrderHeaderId";

                    foreach (PurchasingOrderDetails item in purchasingOrder)
                    {
                        purchasingOrders.Add(item);
                        foreach (var line in item.OrderLines)
                        {
                                if (line.Status.Equals("Completed") 
                                    && line.BinLocationCode
                                       .Equals(StaffManager.Instance.GetBinLocationCode()))
                                {
                                    dataGridView1.Rows.Add(line.SpareId, line.Name, line.Quantity, 0, 0);
                                }
                            

                        }

                    }
        }
        private void AddDataGridViewColumns()
        {
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Spare ID";
            idColumn.DataPropertyName = "Spare ID";
            idColumn.ReadOnly = true;
            idColumn.HeaderText = "Spare ID";
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            idColumn.MinimumWidth = 100;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.HeaderText = "Name";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.MinimumWidth = 200;

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.Name = "Quantity";
            quantityColumn.DataPropertyName = "Quantity";
            quantityColumn.ReadOnly = true;
            quantityColumn.HeaderText = "Quantity";
            quantityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn discrepancyColumn = new DataGridViewTextBoxColumn();
            discrepancyColumn.Name = "Discrepancy";
            discrepancyColumn.DataPropertyName = "Discrepancy";
            discrepancyColumn.ReadOnly = false;
            discrepancyColumn.HeaderText = "Discrepancy";
            discrepancyColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn scrapColumn = new DataGridViewTextBoxColumn();
            scrapColumn.Name = "Scarp";
            scrapColumn.DataPropertyName = "Scarp";
            scrapColumn.ReadOnly = false;
            scrapColumn.HeaderText = "Scarp";
            scrapColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridView1.Columns.Add(idColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(quantityColumn);
            dataGridView1.Columns.Add(discrepancyColumn);
            dataGridView1.Columns.Add(scrapColumn);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 3 || dataGridView1.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex <= -1 || comboBox1.SelectedIndex >= orders.Count)
            {
                return;
            }
            GetBinLocationOrders(orders[comboBox1.SelectedIndex]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PurchasingOrderDetails purchasingOrder = purchasingOrders[comboBox1.SelectedIndex];
            foreach (OrderLineDetail orderLine in purchasingOrder.OrderLines)
            {
                int index = dataGridView1.Rows.IndexOf(dataGridView1.Rows.Cast<DataGridViewRow>()
                            .Where(r => r.Cells["Spare ID"].Value.ToString()
                            .Equals(orderLine.SpareId))
                            .FirstOrDefault());
                if (index == -1)
                {
                    continue;
                }
                int discrepancy = int.Parse(dataGridView1.Rows[index].Cells["Discrepancy"].Value.ToString());
                int scrap = int.Parse(dataGridView1.Rows[index].Cells["Scarp"].Value.ToString());
                int grn = orderLine.Quantity + discrepancy - scrap;
                Console.WriteLine("Discrepancy: " + discrepancy + " Scrap: " + scrap + " GRN: " + grn);
                string query = "UPDATE OrderLine SET Status = @Status, GRN = @GRN WHERE LineId = @LineId";
                OrderLine ol = _orderLineRepository.GetOrderLineById(orderLine.LineId);
                ol.Status = "Completed";
                ol.GRN = grn;
                _orderLineRepository.UpdateOrderLine(ol);

                query = "SELECT COUNT(*) FROM OrderLine WHERE OrderHeaderId = @OrderHeaderId AND Status != 'Completed'";
                List<OrderLine> orderLines = _orderLineRepository.GetOrderLineByOrderHeaderId(purchasingOrder.OrderHeaderId);
                int count = orderLines.Count;
                if (count == 0)
                {
                    query = "UPDATE PurchasingOrder SET Status = @Status WHERE OrderId = @OrderId";
                    PurchasingOrder po = _purchasingOrderRepository.GetPurchasingOrderById(purchasingOrder.OrderId);
                    po.Status = "Completed";
                    _purchasingOrderRepository.UpdatePurchaseOrder(po);

                }

                query = "UPDATE OrderHeader SET UpdatedAt = @UpdatedAt WHERE OrderHeaderId = @OrderHeaderId";
                OrderHeader orderHeader = _orderHeaderRepository.GetOrderHeaderById(purchasingOrder.OrderHeaderId);
                orderHeader.UpdatedAt = DateTime.Now;
                _orderHeaderRepository.UpdateOrderHeader(orderHeader);


                query = "UPDATE BinLocation_Spare SET Stock = Stock + @Stock WHERE Id = @Id";
                BinLocationSpare bs = _binLocationSpareRepository.GetBinLocationSpareBySpareId(orderLine.SparePartId);
                bs.Stock = grn;
                _binLocationSpareRepository.UpdateBinLocationSpare(bs);
                if (purchasingOrder.IncomingOrderId != null)
                {
                    IncomingOrder io = _incomingOrderRepository
                                        .GetIncomingOrderByOrderId(purchasingOrder.IncomingOrderId);




                    IncomingOrderDetails incomingOrderDetails = new IncomingOrderDetails();
                    if (io != null)
                    {
                        incomingOrderDetails.OrderId = io.OrderId;
                        incomingOrderDetails.OrderHeaderId = io.OrderHeaderId;


                        OrderHeader queryOrderHeader = _orderHeaderRepository
                                                       .GetOrderHeaderById(incomingOrderDetails.OrderHeaderId);

                        List<OrderLineDetail> lineDetail = _orderLineRepository.GetOrderLineWithSpare(
                        incomingOrderDetails.OrderHeaderId,
                        orderLine.SpareId,
                        StaffManager.Instance.GetBinLocationCode()
                        );

                        string LineId;

                        if (queryOrderHeader != null)
                        {
                            incomingOrderDetails.CreatedAt = queryOrderHeader.CreatedAt;
                            incomingOrderDetails.UpdatedAt = queryOrderHeader.UpdatedAt;
                        }

                        foreach (OrderLineDetail line in lineDetail)
                        {
                            LineId = line.LineId;
                            OrderLine item = _orderLineRepository.GetOrderLineById(LineId);
                            item.Status = "Available";
                            _orderLineRepository.UpdateOrderLine(item);
                            OrderHeader header = _orderHeaderRepository.GetOrderHeaderById(incomingOrderDetails.OrderHeaderId);
                            _orderHeaderRepository.UpdateOrderHeader(header);
                        }

                    }
                }
            }
        }
            


        private void logout()
        {
            StaffManager.Instance.Clear();
            loginForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fetchData()
        {
            dataGridView1.Rows.Clear();
            comboBox1.SelectedIndex = -1;
            GetBinLocationOrders();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.fetchData();
        }

        private void UpdateStockForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.logout();
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            //ResetPassword resetPassword = new ResetPassword();
            //resetPassword.FormClosed += childForm_FormClosed;
            //resetPassword.Show();
        }
    }
}
