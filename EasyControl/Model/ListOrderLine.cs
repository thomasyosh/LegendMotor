using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyControl.Model
{
    public class ListOrderLine
    {
        public Guid LineId { get; set; }
        public Guid OrderId { get; set; }
        public Guid OrderHeaderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string SpareId { get; set; }
        public Guid SparePartId { get; set; }
        public Guid IncomingOrderId { get; set; }
    }
}
