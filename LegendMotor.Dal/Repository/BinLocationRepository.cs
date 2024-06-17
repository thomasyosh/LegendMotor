using LegendMotor.Domain.Models;
using LegendMotor.Domain.Abstractions.Repositories;


namespace LegendMotor.Dal.Repository
{
    public class BinLocationRepository : IBinLocationRepository
    {
        private readonly DataContext _ctx = new DataContext();

        public BinLocation GetBinLocationById(string id)
        {
            return _ctx.BinLocation.FirstOrDefault(s => s.BinLocationCode.Equals(id));
        }

        public BinLocationStaff GetBinLocationByStaffId(string staffId)
        {
            return _ctx.BinLocationStaff.FirstOrDefault(s=>s.StaffId.Equals(staffId));
        }

        public List<BinLocation> GetBinLocations()
        {
            return _ctx.BinLocation.ToList();
        }
    }
}