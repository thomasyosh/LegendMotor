using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class Spare
    {
        public string SpareId { get; set; }
        [DefaultValue("Metal sheet")]
        public string Name { get; set;}
        [MaxLength(1)]
        [DefaultValue("A")]
        public string Category { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public byte[] Url { get; set; }
        public int Count { get; set; }

    }
}
