using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class Dealer
    {
        [Key]
        public string DealerCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Telex { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
    }
}
