using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{ 
        public class BinLocationSpareDetails
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string SpareId { get; set; }
            public int Stock { get; set; }
            public int ROL { get; set; }
            public int DL { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public double Weight { get; set; }
            public double Price { get; set; }

        }
    }

