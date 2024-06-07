using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Dal;
using Microsoft.EntityFrameworkCore;

namespace LegendMotor.Dal.Repository
{
    public class BinLocationRepository : IBinLocationRepository
    {
        private readonly DataContext _ctx = new DataContext();

        public BinLocation GetBinLocationById(string id)
        {
            return _ctx.BinLocation.FirstOrDefault(s => s.BinLocationCode.Equals(id));
        }

        public List<BinLocation> GetBinLocations()
        {
            return _ctx.BinLocation.ToList();
        }
    }

}
