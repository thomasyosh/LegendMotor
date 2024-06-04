using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class BinLocationSpare
    {
        public Guid Id { get; set; }

        public string BinLocationCode { get; set; }
        public string SpareId { get; set; }
        public int Stock { get; set; }
        public int ROL { get; set; }
        public int DL { get; set; }
        public int Reserved { get; set; }
    }
}
