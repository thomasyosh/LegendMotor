using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace LegendMotor.WinForm;

public partial class DealerOrderForm : Form
{
    private readonly DataContext _ctx;
    private Form form;
    private List<Dealer> dealers = new List<Dealer>();
    private List<ListIncomingOrder> incomingOrders = new List<ListIncomingOrder>();
    private string dealerCode;
    private string status = "";
    public DealerOrderForm(Form form, string dealerCode)
    {
        InitializeComponent();
        this.form = form;
        this.dealerCode = dealerCode;
        this._ctx = new DataContext();
    }

    private void DealerOrder_Load(object sender, EventArgs e)
    {
        dataGridView1.AllowUserToResizeColumns = false;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        AddDataGridViewColumns();
        GetDealers();
    }

    private void GetDealers()
    {
        dealers.Clear();
        var queryDealer = _ctx.Dealer;

        foreach (Dealer dealer in queryDealer)
        {
            dealers.Add(dealer);
            comboBox1.Items.Add(dealer.Name);
        }

        if (dealerCode != null)
        {
            comboBox1.SelectedIndex = dealers.FindIndex(x => x.DealerCode == dealerCode);
        }
        else
        {
            GetOrders();
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

    private void GetOrders()
    {
        incomingOrders.Clear();
        dataGridView1.Rows.Clear();
        string id = StaffManager.Instance.GetStaffArea();
        var en = _ctx.IncomingOrder.Where(io => io.DealerCode.Equals(dealerCode) && io.Status.Equals(status))
        .Join(
          _ctx.OrderHeader,
          entryPoint => entryPoint.OrderHeaderId,
          entry => entry.OrderHeaderId,
          (entryPoint, entry) => new { entryPoint, entry }
      ).Join(
            _ctx.Staff,
            combinedEntry => combinedEntry.entryPoint.staffId,
            title => title.StaffId,
            (combinedEntry, title) => new {combinedEntry, title}).ToList();
        var fullEntries = _ctx.IncomingOrder.Where(io => io.DealerCode.Equals(dealerCode) && io.Status.Equals(status))
      .Join(
          _ctx.OrderHeader,
          entryPoint => entryPoint.OrderHeaderId,
          entry => entry.OrderHeaderId,
          (entryPoint, entry) => new { entryPoint, entry }
      ).Join(
            _ctx.Staff.Where(x => x.AreaCode.Equals(StaffManager.Instance.GetStaffArea())),
            combinedEntry => combinedEntry.entryPoint.staffId,
            title => title.StaffId,
            (combinedEntry, title) => new ListIncomingOrder
            {
                OrderId = combinedEntry.entryPoint.OrderId,
                CreatedAt = combinedEntry.entry.CreatedAt,
                UpdatedAt = combinedEntry.entry.UpdatedAt,
                Status = combinedEntry.entryPoint.Status,
                OrderHeaderId = combinedEntry.entryPoint.OrderHeaderId,
                InvoiceId = combinedEntry.entryPoint.InvoiceId,
            }
            ).ToList();

        foreach (var entries in fullEntries)
        {
            ListIncomingOrder incomingOrder = new ListIncomingOrder();
            /*                 incomingOrder.OrderId = entries.OrderId;
                               incomingOrder.CreatedAt = entries.CreatedAt;
                               incomingOrder.UpdatedAt = entries.UpdatedAt;
                               incomingOrder.Status = entries.Status;*/

            incomingOrders.Add(entries);
            dataGridView1.Rows.Add(entries.OrderId, entries.CreatedAt.ToString("yyyy-MM-dd HH:mm"), entries.UpdatedAt.ToString("yyyy-MM-dd HH:mm"), entries.Status);
        }


    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex != -1)
        {
            dealerCode = dealers[comboBox1.SelectedIndex].DealerCode;
        }
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 4)
        {
            this.Hide();
            Guid orderId = (Guid)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            IncomingOrderDetails form = new IncomingOrderDetails(orderId);
            form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
            form.Show();
        }
        else if (e.ColumnIndex == 5)
        {
            this.Hide();
            Guid orderId = (Guid)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            /*Invoice form = new Invoice(orderId);
            form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
            form.ShowDialog();*/
        }
    }

    private void childForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.Show();
        GetOrders();
    }

    private void btn_search_Click(object sender, EventArgs e)
    {
        GetOrders();
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        status = comboBox2.SelectedItem.ToString();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        GetOrders();
    }
}
