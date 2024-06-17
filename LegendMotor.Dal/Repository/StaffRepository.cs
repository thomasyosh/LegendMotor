using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;


namespace LegendMotor.Dal.Repository
{
    public class StaffRepository : IStaffRepository
    {
        public List<Staff> GetAllStaff()
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.Staff.ToList();
            }
        }

        public Staff GetUserByName(string name)
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.Staff.FirstOrDefault(s => s.Name.Equals(name));
            }
        }

        public Staff GetStaffById(string id)
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.Staff.FirstOrDefault(s => s.Name.Equals(id));
            }
        }

        public Staff UpdateUser(Staff user)
        {
            using (DataContext _ctx = new DataContext())
            {
                try
                {
                    _ctx.Staff.Update(user);
                    
                }catch (Exception ex)
                {
                }
                finally
                {
                    _ctx.SaveChanges();
                }

                return user;
            }
        }

        public StaffDetails GetStaffDetails(string id)
        {
            using (DataContext _ctx = new DataContext())
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
}
