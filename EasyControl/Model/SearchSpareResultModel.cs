using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyControl.Model
{
    public class SearchSpareResultModel
    {
        public string SpareId { get; set; }
        public Guid SparePartId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string BinLocationCode { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public int Reserved { get; set; }

        public int Available
        {
            get
            {
                return Quantity - Reserved;
            }
        }

    }
}
