using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class Staff
    {
        public string StaffId { get; set; }

        public string Password { get; set; }
        public string Name { get; set; }
        public string Gemder { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AreaCode { get; set; }
        public string PositionCode { get; set; }
    }
}
