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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace LegendMotor.WinForm
{
    public partial class PurchasingOrderDetailsForm : Form
    {
        private PurchasingOrderDetails details = new PurchasingOrderDetails();
        public PurchasingOrderDetailsForm(string orderId)
        {
            InitializeComponent();
            details.OrderId = orderId;
        }

        private void PurchasingOrderDetails_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
            GetOrderDetails();
        }

        private void GetOrderDetails()
        {
            dataGridView1.Rows.Clear();
            /*using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                string query = "SELECT PurchasingOrder.OrderId AS OrderId, PurchasingOrder.Status AS Status, PurchasingOrder.IncomingOrderId AS IncomingOrderId, PurchasingOrder.OrderHeaderId AS OrderHeaderId" +
                    ", OrderHeader.CreatedAt AS CreatedAt, OrderHeader.UpdatedAt AS UpdatedAt" +
                    " FROM PurchasingOrder" +
                    " JOIN OrderHeader ON OrderHeader.OrderHeaderId = PurchasingOrder.OrderHeaderId" +
                    " WHERE PurchasingOrder.OrderId = '" + details.OrderId + "'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            details.Status = dr["Status"].ToString().Trim();
                            details.IncomingOrderId = Guid.Parse(dr["IncomingOrderId"].ToString().Trim());
                            details.OrderHeaderId = Guid.Parse(dr["OrderHeaderId"].ToString().Trim());
                            details.CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString().Trim());
                            details.UpdatedAt = DateTime.Parse(dr["UpdatedAt"].ToString().Trim());
                        }
                    }
                }

                lbl_orderId.Text = "Order ID: " + details.OrderId;
                lbl_orderDate.Text = "Order Date: " + details.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                label6.Text = "Last Update: " + details.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                details.OrderLines = new List<Model.OrderLine>();
                query = "SELECT OrderLine.LineId AS LineId, OrderLine.OrderHeaderId AS OrderHeaderId, OrderLine.SparePartId AS SparePartId, BinLocation_Spare.BinLocationCode AS BinLocationCode" +
                    ", OrderLine.Quantity AS Quantity" +
                    ", Spare.SpareId AS SpareId, Spare.Name AS Name, Spare.Weight AS Weight, Spare.Price AS Price" +
                    " FROM OrderLine" +
                    " JOIN BinLocation_Spare ON OrderLine.SparePartId = BinLocation_Spare.Id" +
                    " JOIN Spare ON BinLocation_Spare.SpareId = Spare.SpareId" +
                    " WHERE OrderLine.OrderHeaderId = '" + details.OrderHeaderId + "'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Model.OrderLine orderLine = new Model.OrderLine();
                            orderLine.LineId = Guid.Parse(dr["LineId"].ToString().Trim());
                            orderLine.OrderHeaderId = Guid.Parse(dr["OrderHeaderId"].ToString().Trim());
                            orderLine.SparePartId = Guid.Parse(dr["SparePartId"].ToString().Trim());
                            orderLine.BinLocationCode = dr["BinLocationCode"].ToString().Trim();
                            orderLine.Quantity = int.Parse(dr["Quantity"].ToString().Trim());
                            orderLine.SpareId = dr["SpareId"].ToString().Trim();
                            orderLine.Name = dr["Name"].ToString().Trim();
                            orderLine.Weight = double.Parse(dr["Weight"].ToString().Trim());
                            orderLine.Price = double.Parse(dr["Price"].ToString().Trim());
                            details.OrderLines.Add(orderLine);
                            dataGridView1.Rows.Add(orderLine.SpareId, orderLine.BinLocationCode, orderLine.Weight, orderLine.Quantity, orderLine.TotalWeight);
                        }
                    }
                }
                conn.Close();
            }*/
        }

        private void AddDataGridViewColumns()
        {
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Spare Id";
            idColumn.DataPropertyName = "Spare Id";
            idColumn.ReadOnly = true;
            idColumn.HeaderText = "Spare Id";
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Bin Location";
            nameColumn.DataPropertyName = "Bin Location";
            nameColumn.ReadOnly = true;
            nameColumn.HeaderText = "Bin Location";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataGridViewTextBoxColumn weightColumn = new DataGridViewTextBoxColumn();
            weightColumn.Name = "Weight";
            weightColumn.DataPropertyName = "Weight";
            weightColumn.ReadOnly = true;
            weightColumn.HeaderText = "Weight";
            weightColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.Name = "Quantity";
            quantityColumn.DataPropertyName = "Quantity";
            quantityColumn.ReadOnly = true;
            quantityColumn.HeaderText = "Quantity";
            quantityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();
            subTotalColumn.Name = "Total Weight";
            subTotalColumn.DataPropertyName = "Total Weight";
            subTotalColumn.ReadOnly = true;
            subTotalColumn.HeaderText = "Total Weight";
            subTotalColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridView1.Columns.Add(idColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(weightColumn);
            dataGridView1.Columns.Add(quantityColumn);
            dataGridView1.Columns.Add(subTotalColumn);
        }
    }
}
