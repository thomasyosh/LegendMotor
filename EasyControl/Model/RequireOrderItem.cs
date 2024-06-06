using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyControl.Model
{
    public class RequireOrderItem
    {
        public Guid SparePartId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
