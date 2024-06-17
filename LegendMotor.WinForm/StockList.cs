using LegendMotor.Api.Dtos;
using LegendMotor.Dal;
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

namespace LegendMotor.WinForm;

public partial class StockList : Form
{
    private Form form;
    private List<BinLocationSpareDetails> spares = new List<BinLocationSpareDetails>();
    private readonly IBinLocationSpareRepository _binLocationSpareRepository;
    public StockList(Form form)
    {
        InitializeComponent();
        this.form = form;
        _binLocationSpareRepository = new BinLocationSpareRepository();
    }

    private void StockList_Load(object sender, EventArgs e)
    {
        dataGridView1.AllowUserToResizeColumns = true;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView1.RowHeadersVisible = false;
        AddDataGridView1Columns();
    }

    private async void GetStocks(string name, string category)
    {
        dataGridView1.Rows.Clear();
        spares.Clear();
        List<BinLocationSpareDetails> bsd = _binLocationSpareRepository.GetBinLocationSpareByCategoryAndName(category, name, StaffManager.Instance.GetBinLocationCode());
        foreach(BinLocationSpareDetails item in bsd)
        {
            spares.Add(item);
            dataGridView1.Rows.Add(item.SpareId, item.Name, item.Description, item.Category, item.Weight, item.Stock, item.ROL);
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
        GetStocks(textBox1.Text, cbx_category.Text[0].ToString());
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (cbx_category.Text != "")
            GetStocks(textBox1.Text, cbx_category.Text[0].ToString());
        else
            MessageBox.Show("Please provide at least one search criteria");
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        GetStocks(textBox1.Text, cbx_category.Text[0].ToString());
    }
}