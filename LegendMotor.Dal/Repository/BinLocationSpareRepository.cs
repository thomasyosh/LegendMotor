using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Dal.Repository
{
    public class BinLocationSpareRepository : IBinLocationSpareRepository
    {
        private readonly DataContext _ctx = new DataContext();

        public BinLocationSpare CreateBinLocationSpare(BinLocationSpare binLocationSpare)
        {
            _ctx.BinLocationSpare.Add(binLocationSpare);
            return binLocationSpare;
        }

        public BinLocationSpare GetBinLocationSpareBySpareId(string spareId)
        {
            return _ctx.BinLocationSpare.FirstOrDefault(binLocationSpare=>binLocationSpare.SpareId.Equals(spareId));
        }

        public BinLocationSpare UpdateBinLocationSpare(BinLocationSpare binLocationSpare)
        {
            _ctx.BinLocationSpare.Update(binLocationSpare);
            _ctx.SaveChanges();
            return binLocationSpare;
        }
    }
}
