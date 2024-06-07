using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class IncomingOrder
    {
        [Key]
        public string OrderId { get; set; }
        public string InvoiceName { get; set; }
        public string InvoiceAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public string DealerCode { get; set; }
        public string Type { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }

        public string staffId { get; set; }
        public string OrderHeaderId { get; set; }
        public string InvoiceId { get; set; }

    }
}
