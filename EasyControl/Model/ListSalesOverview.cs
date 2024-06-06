using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyControl.Model
{
    public class ListSalesOverview
    {
        public string StaffId { get; set; }
        public string Name { get; set; }
        public int PendingOrders { get; set; }
        public int CompletedOrders { get; set; }
        public int ProcessingOrders { get; set; }
        public TimeSpan CompletedUsageTime { get; set; }
        //public int PendingOrders
        //{
        //    get
        //    {
        //        return IncomingOrders.FindAll(order => order.Status == "Pending").Count;
        //    }
        //}
        //public int CompletedOrders
        //{
        //    get
        //    {
        //        return IncomingOrders.FindAll(order => order.Status == "Completed").Count;
        //    }
        //}
        //public int ProcessingOrders
        //{
        //    get
        //    {
        //        return IncomingOrders.FindAll(order => order.Status == "Processing").Count;
        //    }
        //}

        public string AvgCompletionTimeString
        {
            get
            {
                if (CompletedUsageTime == TimeSpan.Zero)
                {
                    return "N/A";
                }
                else
                {
                    TimeSpan AvgCompleteTime = TimeSpan.FromTicks(CompletedUsageTime.Ticks / CompletedOrders);
                    int day = AvgCompleteTime.Days;
                    int hour = AvgCompleteTime.Hours;
                    int minute = AvgCompleteTime.Minutes;
                    return day + "d " + hour + "h " + minute + "m";
                }
            }
        }
    }
}
