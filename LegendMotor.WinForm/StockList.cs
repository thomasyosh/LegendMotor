using LegendMotor.Dal;
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

        private void GetStocks()
        {
            var item = _ctx.BinLocationSpare.Join(_ctx.Spare,
                    spare => spare.SpareId,
                    spare2 => spare2.SpareId,
                    (spare, spare2) => new { BinLocationSpare = spare, Spare = spare2 }).Select(s => new {s.BinLocationSpare.SpareId,s.Spare.Price, s.BinLocationSpare.Stock}).ToList();


                
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            GetStocks();
        }
    }
}
