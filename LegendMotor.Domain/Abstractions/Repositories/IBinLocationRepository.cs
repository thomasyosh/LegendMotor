using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface IBinLocationRepository
    {
        public List<BinLocation> GetBinLocations();

        public BinLocation GetBinLocationById(string id);

        public BinLocationStaff GetBinLocationByStaffId(string staffId);
    }
}
