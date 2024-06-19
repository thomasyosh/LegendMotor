using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models;

public class ListIncomingOrder
{
    public string OrderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Status { get; set; }
    public string OrderHeaderId { get; set; }
    public string InvoiceId { get; set; }
    public List<OrderLineDetail> OrderLines { get; set; }

}
