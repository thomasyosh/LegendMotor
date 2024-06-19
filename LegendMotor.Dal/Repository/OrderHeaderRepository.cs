using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Dal.Repository
{
    public class OrderHeaderRepository : IOrderHeaderRepository
    {
        public OrderHeader AddOrderHeader(OrderHeader orderHeader)
        {
            using (DataContext _ctx = new DataContext())
            {
                _ctx.OrderHeader.Add(orderHeader);
                _ctx.SaveChanges();
                return orderHeader;
            }
        }

        public OrderHeader GetOrderHeaderById(string id)
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.OrderHeader.FirstOrDefault(oh => oh.OrderHeaderId.Equals(id));
            }
        }

        public OrderHeader UpdateOrderHeader(OrderHeader orderHeader)
        {
            using (DataContext _ctx = new DataContext())
            {
                _ctx.OrderHeader.Update(orderHeader);
                _ctx.SaveChangesAsync();
                return orderHeader;
            }
        }
    }
}