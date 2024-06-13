using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Dal.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DataContext _ctx = new DataContext();
        public List<Staff> GetAllStaff()
        {
            return _ctx.Staff.ToList();
        }

        public Staff GetUserByName(string name)
        {
            var staffList = _ctx.Staff; //GetAllStaff()
            return staffList.FirstOrDefault(staff => staff.Name.Equals(name));
        }

        public Staff GetStaffById(string id)
        {
            return _ctx.Staff.FirstOrDefault(staff => staff.StaffId.Equals(id));
        }

        public StaffDetails GetStaffDetails(string id)
        {
            var appInformationToReturn = _ctx.Staff
                 .Join(
                      _ctx.Position,
                      ai => ai.PositionCode,
                      al => al.PositionCode,
                      (ai, al) => new StaffDetails()
                      {
                          Name = al.Name,
                          Email = ai.Email,
                          Phone = ai.Phone,
                          Description = al.Description,
                      })
                 .Where(x => x.StaffId.Equals(id))
                 .FirstOrDefault();
            return appInformationToReturn;
        }
    }
}
