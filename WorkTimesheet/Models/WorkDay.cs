using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTimesheet.Models
{
    public class WorkDay
    {
        public DateOnly Date {get; init;}
        public TimeOnly EnterTime {get; init;}
        public TimeOnly ExitTime {get; init;}
        public double DayLength {
            get => (ExitTime - EnterTime).TotalHours;
        }
        public WorkDay(DateOnly date, TimeOnly enterTime, TimeOnly exitTime){
            Date = date;
            EnterTime = enterTime;
            ExitTime = exitTime;
            
        }
    }
}