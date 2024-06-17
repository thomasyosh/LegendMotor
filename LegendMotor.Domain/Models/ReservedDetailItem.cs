using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class ReservedDetailItem
    {
        public string SpareId { get; set; }
        public string ReservedSpareId { get; set; }
        public string SparePartId { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string BinLocationCode { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public int ReservedQuantity { get; set; }
    }
}
