using LegendMotor.Api.Dtos;
using LegendMotor.Dal;
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

namespace LegendMotor.WinForm;

public partial class StockList : Form
{
    private Form form;
    private List<BinLocationSpareDto> spares = new List<BinLocationSpareDto>();
    private readonly DataContext _ctx;
    public StockList(Form form)
    {
        InitializeComponent();
        this.form = form;
        this._ctx = new DataContext();
    }

    private void StockList_Load(object sender, EventArgs e)
    {
        dataGridView1.AllowUserToResizeColumns = true;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView1.RowHeadersVisible = false;
        AddDataGridView1Columns();
    }

    private async void GetStocks(string name, char category)
    {
        dataGridView1.Rows.Clear();
        spares.Clear();

        string binLocationCode = StaffManager.Instance.GetBinLocationCode();
        var items = _ctx.BinLocationSpare.Join(_ctx.Spare,
            spare => spare.SpareId,
            spare2 => spare2.SpareId,
            (spare, spare2) => new { BinLocationSpare = spare, Spare = spare2 })
                .Where(p => p.BinLocationSpare.BinLocationCode.Equals(binLocationCode))
                .Select(s => new BinLocationSpareDto
    {
        SpareId = s.BinLocationSpare.SpareId,
        Name = s.Spare.Name,
        Description = s.Spare.Description,
        Category = s.Spare.Category,
        Weight = s.Spare.Weight,
        Stock = s.BinLocationSpare.Stock,
        ROL = s.BinLocationSpare.ROL
    }
).Where(s => s.Category.Equals(category) && s.Name.Equals(name))
 .ToList();
        foreach (BinLocationSpareDto item in items)
        {
            BinLocationSpareDto spare = new BinLocationSpareDto();
            spare.SpareId = item.SpareId;
            spare.Name = item.Name;
            spare.Stock = item.Stock;
            spare.ROL = item.ROL;
            spare.DL = item.DL;
            spare.Category = item.Category;
            spare.Description = item.Description;
            spare.Weight = item.Weight;

            spares.Add(spare);
            dataGridView1.Rows.Add(spare.SpareId, spare.Name, spare.Description, spare.Category, spare.Weight, spare.Stock, spare.ROL);
        }
    }
    private void AddDataGridView1Columns()
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
        nameColumn.Width = 100;

        DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
        descriptionColumn.Name = "Description";
        descriptionColumn.DataPropertyName = "Description";
        descriptionColumn.ReadOnly = true;
        descriptionColumn.HeaderText = "Description";
        descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        descriptionColumn.MinimumWidth = 200;

        DataGridViewTextBoxColumn categoryColumn = new DataGridViewTextBoxColumn();
        categoryColumn.Name = "Category";
        categoryColumn.DataPropertyName = "Category";
        categoryColumn.ReadOnly = true;
        categoryColumn.HeaderText = "Category";
        categoryColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn weightColumn = new DataGridViewTextBoxColumn();
        weightColumn.Name = "Weight";
        weightColumn.DataPropertyName = "Weight";
        weightColumn.ReadOnly = true;
        weightColumn.HeaderText = "Weight (kg)";
        weightColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn stockColumn = new DataGridViewTextBoxColumn();
        stockColumn.Name = "Stock";
        stockColumn.DataPropertyName = "Stock";
        stockColumn.ReadOnly = true;
        stockColumn.HeaderText = "Stock";
        stockColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn rolColumn = new DataGridViewTextBoxColumn();
        rolColumn.Name = "Reorder level";
        rolColumn.DataPropertyName = "Reorder level";
        rolColumn.ReadOnly = true;
        rolColumn.HeaderText = "Reorder level";
        rolColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


        dataGridView1.Columns.Add(idColumn);
        dataGridView1.Columns.Add(nameColumn);
        dataGridView1.Columns.Add(descriptionColumn);
        dataGridView1.Columns.Add(categoryColumn);
        dataGridView1.Columns.Add(weightColumn);
        dataGridView1.Columns.Add(stockColumn);
        dataGridView1.Columns.Add(rolColumn);
    }

    private void StockList_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.form.Show();
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
        GetStocks(textBox1.Text, cbx_category.Text[0]);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        GetStocks(textBox1.Text, cbx_category.Text[0]);
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        GetStocks(textBox1.Text, cbx_category.Text[0]);
    }
}
/*
    private void AddDataGridView1Columns()
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
        nameColumn.Width = 100;

        DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
        descriptionColumn.Name = "Description";
        descriptionColumn.DataPropertyName = "Description";
        descriptionColumn.ReadOnly = true;
        descriptionColumn.HeaderText = "Description";
        descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        descriptionColumn.MinimumWidth = 200;

        DataGridViewTextBoxColumn categoryColumn = new DataGridViewTextBoxColumn();
        categoryColumn.Name = "Category";
        categoryColumn.DataPropertyName = "Category";
        categoryColumn.ReadOnly = true;
        categoryColumn.HeaderText = "Category";
        categoryColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn weightColumn = new DataGridViewTextBoxColumn();
        weightColumn.Name = "Weight";
        weightColumn.DataPropertyName = "Weight";
        weightColumn.ReadOnly = true;
        weightColumn.HeaderText = "Weight (kg)";
        weightColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn stockColumn = new DataGridViewTextBoxColumn();
        stockColumn.Name = "Stock";
        stockColumn.DataPropertyName = "Stock";
        stockColumn.ReadOnly = true;
        stockColumn.HeaderText = "Stock";
        stockColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn rolColumn = new DataGridViewTextBoxColumn();
        rolColumn.Name = "Reorder level";
        rolColumn.DataPropertyName = "Reorder level";
        rolColumn.ReadOnly = true;
        rolColumn.HeaderText = "Reorder level";
        rolColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

    
        dataGridView1.Columns.Add(idColumn);
        dataGridView1.Columns.Add(nameColumn);
        dataGridView1.Columns.Add(descriptionColumn);
        dataGridView1.Columns.Add(categoryColumn);
        dataGridView1.Columns.Add(weightColumn);
        dataGridView1.Columns.Add(stockColumn);
        dataGridView1.Columns.Add(rolColumn);
    */


/*
    private void StockList_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.form.Show();
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
        GetStocks(textBox1.Text, cbx_category.Text);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        GetStocks(textBox1.Text, cbx_category.Text);
    }
*/


