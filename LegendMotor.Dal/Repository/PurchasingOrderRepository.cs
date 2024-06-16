using LegendMotor.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendMotor.Domain.Abstractions;
using LegendMotor.Domain.Models;

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
    }
}
