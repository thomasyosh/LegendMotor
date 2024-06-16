using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class PurchasingOrder
    {
        [Key]
        public string OrderId { get; set; }
        public string Status { get; set; }
        public string IncomingOrderId { get; set; }
        public string OrderHeaderId { get; set; }

  




    }
}
