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
using LegendMotor.Dal.Repository;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;

namespace LegendMotor.WinForm;

public partial class SpareManagement : Form
{
    private List<ListSpare> spares = new List<ListSpare>();
    private readonly ISpareRepository _spareRepository;
    public SpareManagement()
    {
        InitializeComponent();
        this._spareRepository = new SpareRepository();
    }

    private void SpareManagement_Load(object sender, EventArgs e)
    {
        dataGridView1.AllowUserToResizeColumns = false;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        AddDataGridViewColumns();
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
        nameColumn.MinimumWidth = 100;

        DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
        descriptionColumn.Name = "Description";
        descriptionColumn.DataPropertyName = "Description";
        descriptionColumn.ReadOnly = true;
        descriptionColumn.HeaderText = "Description";
        descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        descriptionColumn.MinimumWidth = 200;

        DataGridViewTextBoxColumn supplierColumn = new DataGridViewTextBoxColumn();
        supplierColumn.Name = "Suppliers";
        supplierColumn.DataPropertyName = "Suppliers";
        supplierColumn.ReadOnly = true;
        supplierColumn.HeaderText = "Suppliers";
        supplierColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        DataGridViewButtonColumn button = new DataGridViewButtonColumn();
        button.Text = "Update";
        button.UseColumnTextForButtonValue = true;
        button.Width = 150;
        button.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        dataGridView1.Columns.Add(idColumn);
        dataGridView1.Columns.Add(nameColumn);
        dataGridView1.Columns.Add(descriptionColumn);
        dataGridView1.Columns.Add(supplierColumn);
        dataGridView1.Columns.Add(button);

        GetSpares();
    }

    private void GetSpares()
    {
        spares.Clear();
        dataGridView1.Rows.Clear();
        var items = _spareRepository.GetAllSpare();
            foreach (var item in items)
            {
                ListSpare spare = new ListSpare();
                spare.Name =item.Name;
            spare.Description = item.Description;
                spare.SpareId = item.SpareId.Trim();
                spare.Count = item.Count;
                spares.Add(spare);
                dataGridView1.Rows.Add(spare.SpareId, spare.Name, spare.Description, spare.Count.ToString());
            }
    }

    private void childForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.Show();
        this.GetSpares();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        AddSpareForm addSpareForm = new AddSpareForm(null);
        addSpareForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
        addSpareForm.Show();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string name = textBox1.Text;
        string category = comboBox1.Text;
        spares.Clear();
        dataGridView1.Rows.Clear();
       string query = "SELECT * FROM Spare WHERE Name LIKE '%" + name + "%' AND Category LIKE '%" + category + "%'";
        var items = _spareRepository.GetSparesByNameAndCategory(name, category);

            foreach (var item in items)
            {
                ListSpare spare = new ListSpare();
                spare.Name = item.Name;
                spare.Description = item.Description;
                spare.SpareId = item.SpareId;
                spare.Count = item.Quantity;

                spares.Add(spare);
                dataGridView1.Rows.Add(spare.SpareId, spare.Name, spare.Description, spare.Count.ToString());
            }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        textBox1.Text = "";
        comboBox1.SelectedIndex = -1;
        GetSpares();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 4)
        {
            ListSpare spare = spares[e.RowIndex];
            AddSpareForm addSpareForm = new AddSpareForm(spare.SpareId);
            addSpareForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
            addSpareForm.Show();
        }
    }
}
