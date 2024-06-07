using LegendMotor.Domain.Models;
using LegendMotor.Dal;
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
using LegendMotor.Api.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Dal.Repository;

namespace LegendMotor.WinForm;

public partial class SearchSpareForm : Form
{
    private readonly DataContext _ctx;
    private List<SearchSpareResultModel> spares = new List<SearchSpareResultModel>();
    private Form form;
    private readonly ISpareRepository _spareRepository;
    public SearchSpareForm(Form form)
    {
        InitializeComponent();
        this.form = form;
        this._ctx = new DataContext();
        this._spareRepository = new SpareRepository();
    }

    private void SearchSpareForm_Load(object sender, EventArgs e)
    {
        dataGridView1.AllowUserToResizeColumns = false;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        AddDataGridViewColumns();

        var sparesItem = _spareRepository.GetAllSpareItem();
        foreach (var entries in sparesItem)
        {
            dataGridView1.Rows.Add(entries.Name, entries.Description, entries.Location, entries.Category, entries.Weight, entries.Price, entries.Available);
        }
    }

    private void GetSpares(string name, string category)
    {
        spares.Clear();
        dataGridView1.Rows.Clear();
        var sparesItem = _spareRepository.GetSparesByNameAndCategory(name, category);

            foreach (var entries in sparesItem)
            {
                spares.Add(entries);
                dataGridView1.Rows.Add(entries.Name, entries.Description, entries.Location, entries.Category, entries.Weight, entries.Price, entries.Available);
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

        DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
        descriptionColumn.Name = "Description";
        descriptionColumn.DataPropertyName = "Description";
        descriptionColumn.ReadOnly = true;
        descriptionColumn.HeaderText = "Description";
        descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        descriptionColumn.MinimumWidth = 200;

        DataGridViewTextBoxColumn locationColumn = new DataGridViewTextBoxColumn();
        locationColumn.Name = "Location";
        locationColumn.DataPropertyName = "Location";
        locationColumn.ReadOnly = true;
        locationColumn.HeaderText = "Location";
        locationColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        locationColumn.MinimumWidth = 200;

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

        DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
        priceColumn.Name = "Price";
        priceColumn.DataPropertyName = "Price";
        priceColumn.ReadOnly = true;
        priceColumn.HeaderText = "Price";
        priceColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
        quantityColumn.Name = "Quantity";
        quantityColumn.DataPropertyName = "Quantity";
        quantityColumn.ReadOnly = true;
        quantityColumn.HeaderText = "Quantity";
        quantityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        DataGridViewButtonColumn button = new DataGridViewButtonColumn();
        button.Text = "Add to cart";
        button.UseColumnTextForButtonValue = true;
        button.Width = 150;
        button.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        dataGridView1.Columns.Add(nameColumn);
        dataGridView1.Columns.Add(descriptionColumn);
        dataGridView1.Columns.Add(locationColumn);
        dataGridView1.Columns.Add(categoryColumn);
        dataGridView1.Columns.Add(weightColumn);
        dataGridView1.Columns.Add(priceColumn);
        dataGridView1.Columns.Add(quantityColumn);
        dataGridView1.Columns.Add(button);
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        
        this.Hide();
        
        CartForm form = new CartForm(this);
        form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
        form.Show();
        
    }

    private void SearchSpareForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.form.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        spares.Clear();
        dataGridView1.Rows.Clear();
        textBox1.Text = comboBox1.Text = "";
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (comboBox1.Text.Length != 0)
            GetSpares(textBox1.Text, comboBox1.Text);
        else
            MessageBox.Show("Please enter at least one criteria of search");
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 7)
        {
            SearchSpareResultModel spare = spares[e.RowIndex];
            CartItem item = new CartItem();
            item.SpareId = spare.SpareId;
            item.SparePartId = spare.SparePartId;
            item.Name = spare.Name;
            item.Description = spare.Description;
            item.Location = spare.Location;
            item.BinLocationCode = spare.BinLocationCode;
            item.Category = spare.Category;
            item.Quantity = 1;
            item.Price = spare.Price;
            item.Weight = spare.Weight;
            item.Stock = spare.Available;
            CartManager.Instance.AddItem(item);
            MessageBox.Show("Item added to cart");
            
        }
    }

    private void childForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.Show();
        /*
        GetSpares(textBox1.Text, comboBox1.Text);
        */
    }
}
