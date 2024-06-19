using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface IBinLocationSpareRepository
    {
        public BinLocationSpare GetBinLocationSpareBySpareId(string spareId);
        public BinLocationSpare GetBinLocationSpareById(string Id);
        public BinLocationSpare GetBinLocationSpareByBinLocationCodeAndId(string binLocationCode, string Id);
        public BinLocationSpare UpdateBinLocationSpare(BinLocationSpare binLocationSpare);
        public BinLocationSpare CreateBinLocationSpare(BinLocationSpare binLocationSpare);
        public List<BinLocationSpareDetails> GetBinLocationSpareByCategoryAndName (string category, string name, string binLocationSpare);
    }
}
