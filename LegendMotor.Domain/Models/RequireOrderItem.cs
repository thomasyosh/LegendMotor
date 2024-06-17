using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class RequireOrderItem
    {
        public string SparePartId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
