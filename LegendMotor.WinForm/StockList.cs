﻿using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LegendMotor.WinForm
{
    public partial class StockList : Form
    {
        private Form form;
        private DataContext _ctx;
        private List<BinLocationSpareDetails> spares = new List<BinLocationSpareDetails>();
        public StockList(Form form)
        {
            InitializeComponent();
            this.form = form;
            this._ctx = new DataContext();
        }

        private void GetStocks(string name, char category)
        {
            string binLocationCode = StaffManager.Instance.GetBinLocationCode();
            var item = _ctx.BinLocationSpare.Join(_ctx.Spare,
                    spare => spare.SpareId,
                    spare2 => spare2.SpareId,
                    (spare, spare2) => new { BinLocationSpare = spare, Spare = spare2 })
                        .Where(p => p.BinLocationSpare.BinLocationCode.Equals(binLocationCode))
                        .Select(s => new
                        {
                            s.BinLocationSpare.SpareId,
                            s.Spare.Name,
                            s.Spare.Description,
                            s.Spare.Category,
                            s.Spare.Weight,
                            s.BinLocationSpare.Stock,
                            s.BinLocationSpare.ROL
                        }
                    ).Where(s => s.Category.Equals(category) && s.Name.Equals(name))
                     .ToList();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            char category = textBox1.Text[0];
            string name = textBox2.Text.Trim();
            GetStocks(name, category);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}