using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyControl.Model
{
    public class PurchasingOrderDetails
    {
        public Guid OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
        public int GRN { get; set; }
        public Guid OrderHeaderId { get; set; }
        public Guid IncomingOrderId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
