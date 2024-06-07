using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class OrderLine
    {
        public Guid LineId { get; set; }
        public Guid OrderHeaderId {get; set; }
        public Guid SparePartId { get; set; }
        public string BinLocationCode { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public string SpareId { get; set; }
        public string Name { get; set; }
        public double TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }

        public double TotalWeight
        {
            get
            {
                return Weight * Quantity;
            }
        }
    }
}
