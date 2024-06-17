using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;

namespace LegendMotor.Dal.Repository
{
    public class BinLocationSpareDetailsRepository : IBinLocationSpareDetailsRepository
    {
        private readonly DataContext _ctx = new DataContext();
        public List<BinLocationSpareDetails> GetBinLocationSpareDetailsByBinLocationCode(string binLocationCode)
        {
            var fullEntries = _ctx.BinLocationSpare.Where(i=>i.BinLocationCode.Equals(binLocationCode))
            .Join(
                _ctx.Spare,
            combinedEntry => combinedEntry.SpareId,
            title => title.SpareId,
                (combinedEntry, title) => new BinLocationSpareDetails
                {
                    Id = combinedEntry.Id,
                    SpareId = title.SpareId,
                    Stock     = combinedEntry.Stock,
                    ROL = combinedEntry.ROL,
                    DL = combinedEntry.DL,
                    Name = title.Name,
                }
            )
            .ToList();
            return fullEntries;
        }


    }
}
