using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class Supplier
    {
        [Key]
        public string SupplierCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public  string Phone { get; set; }
        public string Email { get; set; }
    }
}
