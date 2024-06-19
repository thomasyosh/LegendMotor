using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface IOrderHeaderRepository
    {
        public OrderHeader GetOrderHeaderById (string id);
        public OrderHeader UpdateOrderHeader (OrderHeader orderHeader);
        public OrderHeader AddOrderHeader (OrderHeader orderHeader);

    }
}
