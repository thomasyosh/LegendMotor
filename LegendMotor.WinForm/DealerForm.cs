using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LegendMotor.Dal;
using LegendMotor.Domain.Models;

namespace LegendMotor.WinForm
{
    public partial class DealerForm : Form
    {
        private readonly DataContext _ctx;
        private Form form;
        private int count = 0;
        private List<Dealer> dealers = new List<Dealer>();
        public DealerForm(Form form)
        {
            InitializeComponent();
            this.form = form;
            this._ctx = new DataContext();
        }

        private void Dealer_Load(object sender, EventArgs e)
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

            DataGridViewTextBoxColumn codeColumn = new DataGridViewTextBoxColumn();
            codeColumn.Name = "Code";
            codeColumn.DataPropertyName = "Code";
            codeColumn.ReadOnly = true;
            codeColumn.HeaderText = "Code";
            codeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            codeColumn.Width = 100;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.HeaderText = "Name";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.MinimumWidth = 300;

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.Text = "Details";
            button.UseColumnTextForButtonValue = true;
            button.Width = 150;
            button.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewButtonColumn btn_orders = new DataGridViewButtonColumn();
            btn_orders.Text = "Orders";
            btn_orders.UseColumnTextForButtonValue = true;
            btn_orders.Width = 150;
            btn_orders.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewButtonColumn btn_reserved = new DataGridViewButtonColumn();
            btn_reserved.Text = "Reserved";
            btn_reserved.UseColumnTextForButtonValue = true;
            btn_reserved.Width = 150;
            btn_reserved.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns.Add(codeColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(button);
            dataGridView1.Columns.Add(btn_orders);
            dataGridView1.Columns.Add(btn_reserved);

            getDealers(null);
        }

        private void getDealers(string name)
        {
            dealers.Clear();
            dataGridView1.Rows.Clear();
            var queryDealer = _ctx.Dealer;

                    foreach (Dealer dealer in queryDealer)
                    {
                        dealers.Add(dealer);
                        dataGridView1.Rows.Add(dealer.DealerCode, dealer.Name);
                    }
                }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                this.Hide();
                AddDealerForm form = new AddDealerForm(dealers[e.RowIndex]);
                form.FormClosed += childForm_FormClosed;
                form.Show();
            }
            else if (e.ColumnIndex == 3)
            {
                this.Hide();
                DealerOrderForm form = new DealerOrderForm(this, dealers[e.RowIndex].DealerCode);
                form.FormClosed += childForm_FormClosed;
                form.Show();
            } else if (e.ColumnIndex == 4)
            {
                /*
                this.Hide();
                ReservedForm form = new ReservedForm(this, dealers[e.RowIndex].DealerCode);
                form.FormClosed += childFormWithoutFetch_FormClosed;
                form.Show();*/
            }
        }

        private void DealerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddDealerForm form = new AddDealerForm(null);
            form.FormClosed += childForm_FormClosed;
            form.Show();
        }

        private async void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            await Task.Delay(1000);
            if (txt_dealer.Text != "")
            {
                getDealers(txt_dealer.Text);
            } else
            {
                getDealers(null);
            }
        }

        private void childFormWithoutFetch_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_dealer.Text != "")
            {
                getDealers(txt_dealer.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getDealers(null);
        }
    }
}
