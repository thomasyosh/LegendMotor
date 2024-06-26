﻿using LegendMotor.Domain.Abstractions.Repositories;
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
            var fullEntries = _ctx.IncomingOrder.Where(incomingOrder => incomingOrder.staffId.Equals(staffId) && incomingOrder.Status.Equals(statusId))
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
    }
}
