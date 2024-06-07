using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class SupplierPrice
    {
        [Key]
        public  string SupplierCode { get; set; }
        public double Price { get; set; }
    }
}
