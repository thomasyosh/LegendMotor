using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyControl.Model
{
    public class IncomingOrderDetails
    {
        public Guid OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
        public Guid OrderHeaderId { get; set; }
        public Dealer Dealer { get; set; }
        public string InvoiceName { get; set; }
        public string InvoiceAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public string Remark { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
