using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendMotor.Dal;
using System.Xml.Linq;

namespace LegendMotor.Dal.Repository
{
    public class SpareRepository : ISpareRepository
    {
        private DataContext _ctx = new DataContext();

        public Spare CreateSpare(Spare spare)
        {
            _ctx.Spare.Add(spare);
            return spare;
        }

        public Spare DeleteSpareBySpareId(string spareId)
        {
            Spare spare = GetSpareBySpareId(spareId);
            _ctx.Spare.Remove(spare);
            return spare;
        }

        public List<Spare> GetAllSpare()
        {
            return _ctx.Spare.ToList();
        }
        
        public List<SearchSpareResultModel> GetAllSpareItem()
        {
            var fullEntries = _ctx.BinLocation
            .Join(
                _ctx.BinLocationSpare,
                entryPoint => entryPoint.BinLocationCode,
                entry => entry.BinLocationCode,
                (entryPoint, entry) => new { entryPoint, entry }
            )
            .Join(
                _ctx.Spare,
            combinedEntry => combinedEntry.entry.SpareId,
            title => title.SpareId,
                (combinedEntry, title) => new SearchSpareResultModel
                {
                    SpareId = combinedEntry.entry.SpareId,
                    Name = title.Name,
                    Description = title.Description,
                    Category = title.Category,
                    Weight = title.Weight,
                    Price = title.Price,
                    BinLocationCode = combinedEntry.entry.BinLocationCode,
                    Location = combinedEntry.entryPoint.Name,
                    Quantity = combinedEntry.entry.Stock,
                    SparePartId = combinedEntry.entry.SpareId,
                    Reserved = combinedEntry.entry.Reserved
                }
            )
            .ToList();

            return fullEntries;
        }

        public Spare GetSpareBySpareId(string spareId)
        {
            return _ctx.Spare.FirstOrDefault(spare => spare.SpareId.Equals(spareId));
        }

        public List<SearchSpareResultModel> GetSparesByNameAndCategory(string name, string category)
        {
            var fullEntries = _ctx.BinLocation
            .Join(
                _ctx.BinLocationSpare,
                entryPoint => entryPoint.BinLocationCode,
                entry => entry.BinLocationCode,
                (entryPoint, entry) => new { entryPoint, entry }
            )
            .Join(name.Length > 0 && category.Length > 0 ?
                _ctx.Spare.Where(spare => spare.Name.Equals(name) && spare.Category.Equals(category)) :
                name.Length > 0 ? _ctx.Spare.Where(spare => spare.Name.Equals(name)) : _ctx.Spare.Where(spare => spare.Category.Equals(category)),
                combinedEntry => combinedEntry.entry.SpareId,
                title => title.SpareId,
                (combinedEntry, title) => new SearchSpareResultModel
                {
                    SpareId = combinedEntry.entry.SpareId,
                    Name = title.Name,
                    Description = title.Description,
                    Category = title.Category,
                    Weight = title.Weight,
                    Price = title.Price,
                    BinLocationCode = combinedEntry.entry.BinLocationCode,
                    Location = combinedEntry.entryPoint.Name,
                    Quantity = combinedEntry.entry.Stock,
                    SparePartId = combinedEntry.entry.SpareId,
                    Reserved = combinedEntry.entry.Reserved
                }
            )
            .ToList();

            return fullEntries;
        }

        public Spare UpdateSpareBySpare(Spare spare)
        {
            _ctx.Spare.Update(spare);
            _ctx.SaveChanges();
            return spare;
        }
    }
}
