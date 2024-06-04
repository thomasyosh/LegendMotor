using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class BinLocationStaff
    {
        [Key]
        public string BinLocationCode { get; set; }
        [Key]
        public string StaffId { get; set; }
    }
}
