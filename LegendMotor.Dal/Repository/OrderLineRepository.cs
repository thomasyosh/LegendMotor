using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Dal.Repository
{
    public class OrderLineRepository : IOrderLineRepository
    {
        public OrderLine AddOrderLine(OrderLine orderLine)
        {
            using (DataContext _ctx = new DataContext())
            {
                _ctx.orderLine.Add(orderLine);
                _ctx.SaveChanges();
                return orderLine;
            }
        }

        public OrderLine GetOrderLineById(string lineId)
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.orderLine.FirstOrDefault(ol => ol.Equals(lineId));
            }
        }

        public List<OrderLine> GetOrderLineByIncomingOrderId(string incomingOrderId)
        {
            using (DataContext _ctx = new DataContext())
            {
                var record = _ctx.orderLine
                            .Join(
                                _ctx.OrderHeader,
                                ol => ol.OrderHeaderId,
                                oh => oh.OrderHeaderId,
                                (ol, oh) => new { ol, oh }
                            )
                            .Join(
                                _ctx.IncomingOrder.Where(io=>io.OrderId.Equals(incomingOrderId)),
                                olWithIo => olWithIo.oh.OrderHeaderId,
                                io => io.OrderHeaderId,
                                (olWithIo, io) => new OrderLine
                                {
                                    LineId = olWithIo.ol.LineId,
                                    OrderHeaderId = io.OrderHeaderId,
                                }
                                ).ToList();
                return record;
            }
        }

        public List<OrderLine> GetOrderLineByOrderHeaderId(string orderHeaderId)
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.orderLine.Where(ol=>ol.OrderHeaderId.Equals(orderHeaderId)).ToList();
            }
        }

        public List<OrderLineDetail> GetOrderLineDetailByBinLocationCode(string binLocationCode)
        {
            using (DataContext _ctx = new DataContext())
            {
                var record = _ctx.orderLine
                    .Join(
                        _ctx.OrderHeader,
                        ol => ol.OrderHeaderId,
                        oh => oh.OrderHeaderId,
                        (ol, oh) => new { ol, oh }
                    )
                    .Join(
                        _ctx.PurchasingOrder,
                        olWithPo => olWithPo.oh.OrderHeaderId,
                        po => po.OrderHeaderId,
                        (olWithPo, po) => new { olWithPo, po }
                    )
                    .Join(
                        _ctx.BinLocationSpare.Where(bls=>bls.BinLocationCode.Equals(binLocationCode)),
                        full => full.olWithPo.ol.SparePartId,
                        bs => bs.SpareId,
                        (full, bs) => new { full, bs }
                    )
                    .Join(
                        _ctx.Spare,
                        fullRecord => fullRecord.bs.SpareId,
                        spare => spare.SpareId,
                        (fullRecord, spare) => new OrderLineDetail
                        {
                            LineId = fullRecord.full.olWithPo.ol.LineId,
                            OrderId = fullRecord.full.po.OrderId,
                            OrderHeaderId = fullRecord.full.olWithPo.oh.OrderHeaderId,
                            IncomingOrderId = fullRecord.full.po.IncomingOrderId,
                            CreatedAt = fullRecord.full.olWithPo.oh.CreatedAt,
                            UpdatedAt = fullRecord.full.olWithPo.oh.UpdatedAt,
                        }
                        ).ToList();
                return record;
            }
        }

        public List<OrderLineDetail> GetOrderLineDetailByOrderHeaderId(string orderHeaderId)
        {
            using (DataContext _ctx = new DataContext())
            {
                var record = _ctx.PurchasingOrder
                    .Join(
                        _ctx.OrderHeader.Where(oh=>oh.OrderHeaderId.Equals(orderHeaderId)),
                        po => po.OrderHeaderId,
                        oh => oh.OrderHeaderId,
                        (po, oh) => new { po, oh }
                    )
                    .Join(
                        _ctx.orderLine,
                        poWithOl => poWithOl.oh.OrderHeaderId,
                        ol => ol.OrderHeaderId,
                        (poWithOl, ol) => new { poWithOl, ol }
                    )
                    .Join(
                        _ctx.BinLocationSpare,
                        full => full.ol.SparePartId,
                        bs => bs.SpareId,
                        (full, bs) => new { full, bs }
                    )
                    .Join(
                        _ctx.Spare,
                        fullRecord=>fullRecord.bs.SpareId,
                        spare => spare.SpareId,
                        (fullRecord, spare) => new OrderLineDetail { }
                        ).ToList();
                return record;
            }
        }

        public List<OrderLineDetail> GetOrderLineWithSpare(string orderHeaderId, string spareId, string binLocationCode)
        {
            using (DataContext _ctx = new DataContext())
            {
                var record = _ctx.orderLine.Where(ol=>ol.OrderHeaderId.Equals(orderHeaderId))
                    .Join(
                        _ctx.BinLocationSpare.Where(bls=>bls.SpareId.Equals(spareId) 
                                                && bls.BinLocationCode.Equals(binLocationCode)),
                        ol => ol.SparePartId,
                        bs => bs.SpareId,
                        (ol, bs) => new { ol, bs }
                    )
                    .Join(
                        _ctx.Spare,
                        olWithBs => olWithBs.bs.SpareId,
                        spare => spare.SpareId,
                        (olWithBs, spare) => new OrderLineDetail { }
                    )
                    .ToList();
                return record;
            }
        }

        public OrderLine UpdateOrderLine(OrderLine orderline)
        {
            using (DataContext _ctx = new DataContext())
            {
                _ctx.orderLine.Update(orderline);
                _ctx.SaveChangesAsync();
                return orderline;
            }
        }
    }
}
