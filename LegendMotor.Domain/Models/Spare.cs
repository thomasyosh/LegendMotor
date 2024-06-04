using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class Spare
    {
        public string SpareId { get; set; }
        public string Name { get; set;}
        public char Category { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public string Url { get; set; }
        public int Count { get; set; }

    }
}
