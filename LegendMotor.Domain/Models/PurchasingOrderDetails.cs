using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class PurchasingOrderDetails
    {
        public string OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
        public int GRN { get; set; }
        public string OrderHeaderId { get; set; }
        public string IncomingOrderId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
