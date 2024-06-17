using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface IOrderLineRepository
    {
        public OrderLine GetOrderLineById(string lineId);
        public List<OrderLineDetail> GetOrderLineDetailByOrderHeaderId(string orderHeaderId);
        public List<OrderLineDetail> GetOrderLineDetailByBinLocationCode(string binLocationCode);
        public OrderLine UpdateOrderLine(OrderLine orderline);
        public List<OrderLine> GetOrderLineByOrderHeaderId(string orderHeaderId);
        public List<OrderLine> GetOrderLineByIncomingOrderId(string incomingOrderId);
        public List<OrderLineDetail> GetOrderLineWithSpare(string orderHeaderId, string spareId, string binLocationCode);
    }
}
