using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public sealed class StaffManager
    {
        private static StaffManager instance = null;
        private static readonly object padlock = new object();
        private Staff staff;
        private string binLocationCode;

        private StaffManager()
        {
        }

        public static StaffManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StaffManager();
                    }
                    return instance;
                }
            }
        }

        public void SetStaff(Staff staff)
        {
            this.staff = staff;
        }

        public void SetBinLocationCode(string binLocationCode)
        {
            this.binLocationCode = binLocationCode;
        }

        public string GetBinLocationCode()
        {
            return binLocationCode;
        }

        public string GetStaffPosition()
        {
            return staff.PositionCode;
        }

        public string GetStaffArea()
        {
            return staff.AreaCode;
        }

        public string GetStaffId()
        {
            return staff.StaffId;
        }

        public void Clear()
        {
            this.staff = null;
            this.binLocationCode = null;
        }
    }
}
