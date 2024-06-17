using LegendMotor.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using System.ComponentModel;

namespace LegendMotor.Dal.Repository
{
    public class IncomingOrderRepository : IIncomingOrderRepository
    {
        private readonly DataContext _ctx = new DataContext();
        
        public IncomingOrder GetIncomingOrderByOrderId (string orderId)
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.IncomingOrder.FirstOrDefault(io => io.Equals(orderId));
            }
        }
        
        public List<IncomingOrderDetails> GetIncomingOrderByOrderHeadId(string staffId)
        {
            var fullEntries = _ctx.IncomingOrder.Where(incomingOrder=>incomingOrder.staffId.Equals(staffId))
            .Join(
                _ctx.OrderHeader,
            combinedEntry => combinedEntry.OrderHeaderId,
            title => title.OrderHeaderId,
                (combinedEntry, title) => new IncomingOrderDetails
                {
                    Status = combinedEntry.Status,
                    CreatedAt = title.CreatedAt,
                    UpdatedAt = title.UpdatedAt,
                }
            )
            .ToList();
            return fullEntries;
        }

        public List<IncomingOrderDetails> GetIncomingOrderByStaffIdAndStatus(string staffId, string statusId)
        {
            var fullEntries = _ctx.IncomingOrder.Where(incomingOrder => incomingOrder.staffId.Equals(staffId) 
                                                    && incomingOrder.Status.Equals(statusId))
            .Join(
                _ctx.OrderHeader,
            combinedEntry => combinedEntry.OrderHeaderId,
            title => title.OrderHeaderId,
                (combinedEntry, title) => new IncomingOrderDetails
                {
                    Status = combinedEntry.Status,
                    CreatedAt = title.CreatedAt,
                    UpdatedAt = title.UpdatedAt,
                    InvoiceId = combinedEntry.InvoiceId
                }
            )
            .ToList();
            return fullEntries;
        }

        public List<IncomingOrderDetails> GetAllIncomingOrderWithOrderHeader()
        {
            using (DataContext _ctx = new DataContext())
            {
                var record = _ctx.IncomingOrder
                            .Join(
                                _ctx.OrderHeader,
                                io => io.OrderHeaderId,
                                oh => oh.OrderHeaderId,
                                (io, oh) => new IncomingOrderDetails
                                {
                                    OrderId = io.OrderHeaderId,
                                    CreatedAt = oh.CreatedAt,
                                    UpdatedAt = oh.UpdatedAt,
                                    Status = io.Status,
                                }
                            ).ToList();
                return record;
            }
        }

        public IncomingOrder UpdateIncomingOrder(IncomingOrder incomingOrder)
        {
           using (DataContext _ctx = new DataContext())
            {
                _ctx.IncomingOrder.Update( incomingOrder );
                _ctx.SaveChangesAsync();
                return incomingOrder;
            }
        }
    }
}
