using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendMotor.Domain.Models;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface IPurchasingOrderRepository
    {
        public PurchasingOrder GetPurchasingOrderById(string Id );
        public List<PurchasingOrderDetails> GetPurchasingOrderDetailByBinLocationCode(string BinLocationCode);
        public List<PurchasingOrderDetails> GetPurchasingOrderDetailWithOrderHeader(string orderId);
        public PurchasingOrder UpdatePurchaseOrder(PurchasingOrder purchasingOrder);




    }


}
