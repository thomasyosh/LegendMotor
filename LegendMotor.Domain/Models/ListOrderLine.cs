using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class ListOrderLine
    {
        public string OrderId { get; set; }
        public string LineId { get; set; }
        public string OrderHeaderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string SpareId { get; set; }
        public string SparePartId { get; set; }
        public string IncomingOrderId { get; set; }
    }
}
