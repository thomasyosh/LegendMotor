using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendMotor.Domain.Models;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface ISpareRepository
    {
        public List<Spare> GetAllSpare();
        public Spare CreateSpare(Spare spare);
        public Spare UpdateSpareBySpare (Spare spare);
        public Spare GetSpareBySpareId(string spareId);
        public Spare DeleteSpareBySpareId(string spareId);
        public List<SearchSpareResultModel> GetSparesByNameAndCategory(string name, string category);

        public List<SearchSpareResultModel> GetAllSpareItem();
    }
}
