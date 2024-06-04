using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class Position
    {
        [Key]
        public string PositionCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
