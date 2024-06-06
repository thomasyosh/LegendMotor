using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyControl.Model
{
    public class ReservedItem
    {
        public Guid ReservedSpareId { get; set; }
        public string DealerCode { get; set; }
        public Guid SparePartId { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
