﻿using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface IIncomingOrderRepository
    {
        public List<IncomingOrderDetails> GetIncomingOrderByOrderHeadId(string orderHeadId);
        public IncomingOrder GetIncomingOrderByOrderHeaderId(string orderHeadId);
        public List<IncomingOrderDetails> GetIncomingOrderByStaffIdAndStatus(string staffId, string statusId);
        public IncomingOrder GetIncomingOrderByOrderId(string orderId);
        public List<IncomingOrderDetails> GetAllIncomingOrderWithOrderHeader();
        public IncomingOrder UpdateIncomingOrder(IncomingOrder incomingOrder);
        public List<IncomingOrderDetails> GetIncompleteIncomingOrderWithOrderHeader();
    }
}
