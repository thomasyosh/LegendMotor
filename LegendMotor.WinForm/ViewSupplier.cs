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
using LegendMotor.Domain;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Dal.Repository;

namespace LegendMotor.WinForm
{
    public partial class ViewSupplier : Form
    {
     private List<Supplier> suppliers = new List<Supplier>();
        private readonly ISupplierRepository _supplierRepository;
        public ViewSupplier()
        {
            InitializeComponent();
            this._supplierRepository = new SupplierRepository();
        }

        private void ViewSupplier_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddDataGridViewColumns();
        }

        private void AddDataGridViewColumns()
        {
            DataGridViewTextBoxColumn supplierColumn = new DataGridViewTextBoxColumn();
            supplierColumn.Name = "Name";
            supplierColumn.DataPropertyName = "Name";
            supplierColumn.ReadOnly = true;
            supplierColumn.HeaderText = "Name";
            supplierColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            supplierColumn.MinimumWidth = 100;

            DataGridViewTextBoxColumn contactColumn = new DataGridViewTextBoxColumn();
            contactColumn.Name = "Email";
            contactColumn.DataPropertyName = "Email";
            contactColumn.ReadOnly = true;
            contactColumn.HeaderText = "Email";
            contactColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            contactColumn.MinimumWidth = 100;

            DataGridViewTextBoxColumn addressColumn = new DataGridViewTextBoxColumn();
            addressColumn.Name = "Address";
            addressColumn.DataPropertyName = "Address";
            addressColumn.ReadOnly = true;
            addressColumn.HeaderText = "Address";
            addressColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            addressColumn.MinimumWidth = 200;

            DataGridViewButtonColumn updateButton = new DataGridViewButtonColumn();
            updateButton.Text = "Update";
            updateButton.UseColumnTextForButtonValue = true;
            updateButton.MinimumWidth = 100;
            updateButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dataGridView1.Columns.Add(supplierColumn);
            dataGridView1.Columns.Add(contactColumn);
            dataGridView1.Columns.Add(addressColumn);
            dataGridView1.Columns.Add(updateButton);

            GetSupplier();
        }   

        private void GetSupplier()
        {
            suppliers.Clear();
            dataGridView1.Rows.Clear();
            List<Supplier> supplierItem = _supplierRepository.GetAllSupplier();

                foreach (Supplier item in supplierItem)
                {

                    suppliers.Add(item);

                    dataGridView1.Rows.Add(item.Name, item.Email, item.Address);
                }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                Supplier supplier = suppliers[e.RowIndex];
                AddSupplierForm addSupplierForm = new AddSupplierForm(supplier.SupplierCode);
                addSupplierForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                addSupplierForm.Show();
                this.Hide();
            }
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            this.GetSupplier();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddSupplierForm addSupplierForm = new AddSupplierForm(null);
            addSupplierForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
            addSupplierForm.Show(); 
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            if (name == "" && email == "")
            {
                GetSupplier();
            }
            else
            {
                dataGridView1.Rows.Clear();
                if (name != "" && email != "")
                {
                    foreach (Supplier supplier in suppliers)
                    {
                        if (supplier.Name.Contains(name) && supplier.Email.Contains(email))
                        {
                            dataGridView1.Rows.Add(supplier.Name, supplier.Email, supplier.Address);
                        }
                    }
                }
                else if (name != "")
                {
                    foreach (Supplier supplier in suppliers)
                    {
                        if (supplier.Name.Contains(name))
                        {
                            dataGridView1.Rows.Add(supplier.Name, supplier.Email, supplier.Address);
                        }
                    }
                }
                else if (email != "")
                {
                    foreach (Supplier supplier in suppliers)
                    {
                        if (supplier.Email.Contains(email))
                        {
                            dataGridView1.Rows.Add(supplier.Name, supplier.Email, supplier.Address);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            GetSupplier();
        }
    }
}
