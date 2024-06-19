using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class ReservedItem
    {
        [Key]
        public string ReservedSpareId { get; set; }
        public string DealerCode { get; set; }
        public string SparePartId { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
