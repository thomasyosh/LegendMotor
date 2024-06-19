using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.WinForm
{
    public interface IFormFactory
    {
        T? Create<T>() where T : Form;
    }
}
