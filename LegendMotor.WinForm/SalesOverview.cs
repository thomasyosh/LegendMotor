using LegendMotor.Dal;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LegendMotor.Dal.Repository;

namespace LegendMotor.WinForm
{
    public partial class SalesOverview : Form
    {
        private List<ListSalesOverview> salesOverviewList = new List<ListSalesOverview>();
        private readonly DataContext _ctx;
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        public SalesOverview()
        {
            InitializeComponent();
            // set start of month to date picker 1
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            // set end of month to date picker 2
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            this._ctx = new DataContext();
            this._incomingOrderRepository = new IncomingOrderRepository();
        }

        private void AreaReport_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            AddDataGridView1Columns();
            GetSalesOverview();
        }

        private void GetSalesOverview()
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            salesOverviewList.Clear();
            dataGridView1.Rows.Clear();

            string query = "SELECT * FROM Staff WHERE AreaCode = @AreaCode AND (PositionCode = 'smanager' OR PositionCode = 'amanager' OR PositionCode = 'sales')";
            List<Staff> queryStaff = _ctx.Staff.Where(staff => 
                                   staff.AreaCode.Equals(StaffManager.Instance.GetStaffArea()) &&
                                   staff.PositionCode.Equals("smanager") ||
                                   staff.PositionCode.Equals("amanager") ||
                                   staff.PositionCode.Equals("sales")
                                   ).ToList();

                        foreach (Staff staff in queryStaff)
                        {
                            ListSalesOverview salesOverview = new ListSalesOverview();
                            salesOverview.StaffId = staff.StaffId;
                            salesOverview.Name = staff.Name;
                            salesOverviewList.Add(salesOverview);
                        }


                query = "SELECT IncomingOrder.Status AS Status, OrderHeader.CreatedAt, OrderHeader.UpdatedAt " +
                "FROM IncomingOrder " +
                "JOIN OrderHeader ON OrderHeader.OrderHeaderId = IncomingOrder.OrderHeaderId " +
                "WHERE OrderHeader.CreatedAt >= @startDate AND OrderHeader.CreatedAt <= @endDate AND IncomingOrder.StaffId = @StaffId ";
                

                for (int i = 0; i < salesOverviewList.Count; i ++)
                {
                        var result = _incomingOrderRepository.GetIncomingOrderByOrderHeadId(salesOverviewList[i].StaffId);
                        var filterResult = result.Where(result => result.CreatedAt >= startDate && result.CreatedAt <= endDate);

                    foreach (var item in filterResult)
                    {
                        if (item.Status == "Pending")
                        {
                            salesOverviewList[i].PendingOrders++;
                        }
                        else if (item.Status == "Processing" || item.Status == "Available" || item.Status == "Ready")
                        {
                            salesOverviewList[i].ProcessingOrders++;
                        }
                        else if (item.Status == "Completed")
                        {
                            salesOverviewList[i].CompletedOrders++;
                            DateTime createdAt = Convert.ToDateTime(item.CreatedAt);
                            DateTime updatedAt = Convert.ToDateTime(item.UpdatedAt);
                            salesOverviewList[i].CompletedUsageTime += updatedAt - createdAt;
                        }
                    }

            }

            foreach (ListSalesOverview salesOverview in salesOverviewList)
            {
                dataGridView1.Rows.Add(salesOverview.StaffId, salesOverview.Name, salesOverview.PendingOrders, salesOverview.ProcessingOrders, salesOverview.CompletedOrders, salesOverview.AvgCompletionTimeString);
            }
        }

        private void AddDataGridView1Columns()
        {
               DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID";
            idColumn.DataPropertyName = "ID";
            idColumn.ReadOnly = true;
            idColumn.HeaderText = "ID";
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            idColumn.MinimumWidth = 100;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.HeaderText = "Name";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.Width = 100;

            DataGridViewTextBoxColumn pendingColumn = new DataGridViewTextBoxColumn();
            pendingColumn.Name = "Pending";
            pendingColumn.DataPropertyName = "Pending";
            pendingColumn.ReadOnly = true;
            pendingColumn.HeaderText = "Pending";

            DataGridViewTextBoxColumn inProgressColumn = new DataGridViewTextBoxColumn();
            inProgressColumn.Name = "In-progress";
            inProgressColumn.DataPropertyName = "In-progress";
            inProgressColumn.ReadOnly = true;
            inProgressColumn.HeaderText = "In-progress";

            DataGridViewTextBoxColumn completedColumn = new DataGridViewTextBoxColumn();
            completedColumn.Name = "Completed";
            completedColumn.DataPropertyName = "Completed";
            completedColumn.ReadOnly = true;
            completedColumn.HeaderText = "Completed";

            DataGridViewTextBoxColumn avgColumn = new DataGridViewTextBoxColumn();
            avgColumn.Name = "Avg Complete Time";
            avgColumn.DataPropertyName = "Avg Complete Time";
            avgColumn.ReadOnly = true;
            avgColumn.HeaderText = "Avg Complete Time";

            DataGridViewButtonColumn detailsButton = new DataGridViewButtonColumn();
            detailsButton.Text = "Details";
            detailsButton.UseColumnTextForButtonValue = true;
            detailsButton.MinimumWidth = 100;
            detailsButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dataGridView1.Columns.Add(idColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(pendingColumn);
            dataGridView1.Columns.Add(inProgressColumn);
            dataGridView1.Columns.Add(completedColumn);
            dataGridView1.Columns.Add(avgColumn);
            dataGridView1.Columns.Add(detailsButton);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetSalesOverview();
        }

        private void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
/*                this.Hide();
                SalesOrderDetails form = new SalesOrderDetails(salesOverviewList[e.RowIndex].StaffId);
                form.FormClosed += child_FormClosed;
                form.Show();*/
            }
        }
    }
}
