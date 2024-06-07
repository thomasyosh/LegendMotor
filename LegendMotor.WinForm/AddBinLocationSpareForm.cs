using LegendMotor.Api.Dtos;
using LegendMotor.Dal.Repository;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LegendMotor.WinForm
{
    public partial class AddBinLocationSpareForm : Form
    {
        private readonly ISpareRepository _spareRepository;
        private readonly IBinLocationSpareRepository _binLocationSpareRepository;
        private string binLocationCode;
        private List<BinLocationSpareDetails> curSpares = new List<BinLocationSpareDetails>();
        private List<ListSpare> spares = new List<ListSpare>();
        private List<BinLocationSpare> binLocationSpares = new List<BinLocationSpare>();
        DataGridViewComboBoxColumn spareColumn = new DataGridViewComboBoxColumn();
        public AddBinLocationSpareForm(string binLocationCode, List<BinLocationSpareDetails> curSpares)
        {
            InitializeComponent();
            this.binLocationCode = binLocationCode;
            this.curSpares = curSpares;
            this._spareRepository = new SpareRepository();
            this._binLocationSpareRepository = new BinLocationSpareRepository();
        }

        private void AddBinLocationSpareForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            AddDataGridViewColumns();
            getSpares();
        }

        private void getSpares()
        {
            var items = _spareRepository.GetAllSpare();
                        foreach (var item in items)
                        {
                            if (curSpares.Exists(x => x.SpareId == item.SpareId.Trim()))
                            {
                                continue;
                            }
                            ListSpare spare = new ListSpare();
                            spare.SpareId = item.SpareId;
                            spare.Name = item.Name;
                            spares.Add(spare);
                            spareColumn.Items.Add(spare.Name);
                    }
        }
        private void AddDataGridViewColumns()
        {
            spareColumn.Name = "Spare";
            spareColumn.DataPropertyName = "Spare";
            spareColumn.HeaderText = "Spare";
            spareColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            spareColumn.MinimumWidth = 200;

            DataGridViewTextBoxColumn rolColumn = new DataGridViewTextBoxColumn();
            rolColumn.Name = "Re-order level";
            rolColumn.DataPropertyName = "Re-oreder level";
            rolColumn.ReadOnly = false;
            rolColumn.HeaderText = "Re-oreder level";
            rolColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn dlColumn = new DataGridViewTextBoxColumn();
            dlColumn.Name = "Danger level";
            dlColumn.DataPropertyName = "Danger level";
            dlColumn.ReadOnly = false;
            dlColumn.HeaderText = "Danger level";
            dlColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn stockColumn = new DataGridViewTextBoxColumn();
            stockColumn.Name = "Stock";
            stockColumn.DataPropertyName = "Stock";
            stockColumn.ReadOnly = false;
            stockColumn.HeaderText = "Stock";
            stockColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.MinimumWidth = 100;
            deleteButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dataGridView1.Columns.Add(spareColumn);
            dataGridView1.Columns.Add(rolColumn);
            dataGridView1.Columns.Add(dlColumn);
            dataGridView1.Columns.Add(stockColumn);
            dataGridView1.Columns.Add(deleteButton);
        }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                // My combobox column is the second one so I hard coded a 1, flavor to taste
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
                if (cb.Value != null)
                {
                    binLocationSpares[e.RowIndex].SpareId = spares[cb.Items.IndexOf(cb.Value)].SpareId;
                    // do stuff
                    dataGridView1.Invalidate();
                }
            }
            else if (e.ColumnIndex == 1)
            {
                DataGridViewTextBoxCell tb = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[1];
                if (tb.Value != null)
                {
                    // do stuff
                    binLocationSpares[e.RowIndex].ROL = Convert.ToInt32(tb.Value.ToString());
                    dataGridView1.Invalidate();
                }
            } else if (e.ColumnIndex == 2)
            {
                DataGridViewTextBoxCell tb = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[2];
                if (tb.Value != null)
                {
                    // do stuff
                    binLocationSpares[e.RowIndex].DL = Convert.ToInt32(tb.Value.ToString());
                    dataGridView1.Invalidate();
                }
            } else if (e.ColumnIndex == 3)
            {
                DataGridViewTextBoxCell tb = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[3];
                if (tb.Value != null)
                {
                    // do stuff
                    binLocationSpares[e.RowIndex].Stock = Convert.ToInt32(tb.Value.ToString());
                    dataGridView1.Invalidate();
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (dataGridView1.Rows.Count > 1)
                {

                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    binLocationSpares.RemoveAt(e.RowIndex);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BinLocationSpare binLocationSpare = new BinLocationSpare();
            binLocationSpare.ROL = 0;
            binLocationSpare.DL = 0;
            binLocationSpare.Stock = 0;
            binLocationSpares.Add(binLocationSpare);
            dataGridView1.Rows.Add();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check binLocationSpares has duplicated spareId or not
            List<string> spareIds = new List<string>();
            foreach (BinLocationSpare binLocationSpare in binLocationSpares)
            {
                if (spareIds.Contains(binLocationSpare.SpareId))
                {
                    MessageBox.Show("Spares are dupliated.");
                    return;
                }
                spareIds.Add(binLocationSpare.SpareId);
            }

            try
            {

                foreach (BinLocationSpare binLocationSpare in binLocationSpares)
                {
                    string query = "INSERT INTO BinLocation_Spare (Id, BinLocationCode, SpareId, Stock, ROL, DL) VALUES (@Id, @BinLocationCode, @SpareId, @Stock, @ROL, @DL)";
                    binLocationSpare.Id = Guid.NewGuid();
                    _binLocationSpareRepository.CreateBinLocationSpare(binLocationSpare);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
