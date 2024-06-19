using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public class Invoice
    {
        [Key]
        public string InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double InvoiceAmount { get; set; }    
    }
}
