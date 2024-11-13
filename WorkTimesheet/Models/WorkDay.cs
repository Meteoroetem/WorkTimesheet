using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTimesheet.Models
{
    public class WorkDay
    {
        public DateOnly Date {get; init;}
        public TimeSpan EnterTime {get; init;}
        public TimeSpan ExitTime {get; init;}
        public TimeSpan DayLength {
            get => ExitTime - EnterTime;
        }
        public WorkDay(DateOnly date, TimeSpan enterTime, TimeSpan exitTime){
            Date = date;
            EnterTime = enterTime;
            ExitTime = exitTime;
            
        }
    }
}