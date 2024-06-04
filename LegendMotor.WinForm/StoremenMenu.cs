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
    public partial class StoremenMenu : Form
    {
        private LoginForm loginForm;
        public StoremenMenu(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockList stockList = new StockList(this);
            stockList.Show();

        }
    }
}
