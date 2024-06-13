using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendMotor.Domain.Models;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface IStaffRepository
    {
        public List<Staff> GetAllStaff();
        public StaffDetails GetStaffDetails(string id);
        public Staff GetStaffById(string id);
        public Staff GetUserByName(string name);
    }
}
