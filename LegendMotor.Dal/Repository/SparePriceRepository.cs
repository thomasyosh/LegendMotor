using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Dal.Repository
{
    public class SparePriceRepository : ISparePriceRepository
    {
        private readonly DataContext _ctx;

        public SparePrice CreateSparePrice(SparePrice sparePrice)
        {
            _ctx.SparePrice.Add(sparePrice);
            return sparePrice;
        }

        public SparePrice GetSparePriceBySpareId(string spareId)
        {
            return _ctx.SparePrice.FirstOrDefault(sparePrice => sparePrice.SpareID.Equals(spareId)); 
        }


    }
}
