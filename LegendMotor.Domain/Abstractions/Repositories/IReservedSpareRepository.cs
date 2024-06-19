using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface IReservedSpareRepository
    {
        public ReservedItem GetReservedItemById (string id);
        public ReservedItem RemoveReservedItemById (string id);

    }
}
