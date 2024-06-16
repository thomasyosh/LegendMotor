using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class OrderLine
    {
        [Key]
        public string LineId { get; set; }
        public string OrderHeaderId {get; set; }
        public string SparePartId { get; set; }
      
        public int Quantity { get; set; }
        public string Status { get; set; }
        public int? GRN { get; set; }


       
    }
}
