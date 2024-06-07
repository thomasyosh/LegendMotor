using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface ISparePriceRepository
    {
        public SparePrice GetSparePriceBySpareId(string spareId);

        public SparePrice CreateSparePrice(SparePrice sparePrice);
    }
}
