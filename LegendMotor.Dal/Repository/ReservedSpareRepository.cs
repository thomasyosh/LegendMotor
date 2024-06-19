using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Dal.Repository
{
    public class ReservedSpareRepository : IReservedSpareRepository
    {
        public ReservedItem GetReservedItemById(string id)
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.ReservedItem.FirstOrDefault(item => item.ReservedSpareId.Equals(id));
            }
        }

        public ReservedItem RemoveReservedItemById(string id)
        {
            using (DataContext _ctx = new DataContext())
            {
                ReservedItem item  = GetReservedItemById(id);
                _ctx.ReservedItem.Remove(item);
                _ctx.SaveChanges();
                return item;
            }
        }
    }
}
