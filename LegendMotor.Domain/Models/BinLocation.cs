using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class BinLocation
    {
        [Key]
        public string BinLocationCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool isActive { get; set; }
    }
}
