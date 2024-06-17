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
            _ctx.SaveChanges();
            return binLocationSpare;
        }

        public List<BinLocationSpareDetails> GetBinLocationSpareByCategoryAndName(string category, string name, string binLocationCode)
        {
            using (DataContext _ctx = new DataContext())
            {
                var record = _ctx.BinLocationSpare.Where(bs=>bs.BinLocationCode.Equals(binLocationCode))
                                .Join(
                                     _ctx.Spare,
                                     bs=>bs.SpareId,
                                     spare=>spare.SpareId,
                                     (bs, spare) => new BinLocationSpareDetails
                                     {
                                         SpareId = spare.SpareId,
                                         Name = spare.Name,
                                         Description = spare.Description,
                                         Category = spare.Category,
                                         Weight = spare.Weight,
                                         Stock = bs.Stock,
                                         ROL = bs.ROL,
                                     }
                                     )
                                .ToList();
                return record;  
            }
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
