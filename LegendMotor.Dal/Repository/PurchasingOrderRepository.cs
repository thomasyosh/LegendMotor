using LegendMotor.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendMotor.Domain.Abstractions;
using LegendMotor.Domain.Models;
using Microsoft.VisualBasic;

namespace LegendMotor.Dal.Repository
{
    public class PurchasingOrderRepository : IPurchasingOrderRepository
    {
        public PurchasingOrder GetPurchasingOrderById(string Id)
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.PurchasingOrder.FirstOrDefault(po => po.OrderId.Equals(Id));

            }
        }

        public List<PurchasingOrderDetails> GetPurchasingOrderDetailByBinLocationCode(string BinLocationCode)
        {
            using (DataContext _ctx = new DataContext())
            {
                var record = _ctx.PurchasingOrder.Where(po => !po.Status.Equals("Completed"))
                    .Join(
                        _ctx.OrderHeader,
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
                        _ctx.BinLocationSpare.Where(bs=>bs.BinLocationCode.Equals(BinLocationCode)),
                        full => full.ol.SparePartId,
                        bs => bs.SpareId,
                        (full, bs) => new PurchasingOrderDetails { }
                    ).ToList();
                return record;
            }
        }
    }
}

