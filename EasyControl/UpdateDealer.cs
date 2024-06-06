using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyControl
{
    public partial class UpdateDealer : Form
    {
        private Dealer form;
        public UpdateDealer(Dealer form)
        {
            InitializeComponent();
            this.form = form;
        }


    }
}
