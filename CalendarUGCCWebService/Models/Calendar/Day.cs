using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarUGCCWebService.Models
{
    public class Day
    {
        public DateTime DayId { get; set; }

        public string Holiday { get; set; }
        public bool IsHoliday { get; set; }
        public enum DayTypes
        {
            Sunday,
            Monday,
            Tuesday,
            WedSat,
        }
        public DayTypes DayType { get; set; }

        public Day()
        {

        }

        public Day(DateTime day)
        {
            DayId = day;

            var dayOfWeek = day.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Wednesday ||
                dayOfWeek == DayOfWeek.Thursday ||
                dayOfWeek == DayOfWeek.Friday ||
                dayOfWeek == DayOfWeek.Saturday)
            {
                DayType = DayTypes.WedSat;
            }
            else
            {
                DayType = (DayTypes)day.DayOfWeek;
            }
        }
        public Day(DateTime day, string holiday)
        {
            DayId = day;
            Holiday = holiday;
            IsHoliday = true;

            var dayOfWeek = day.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Wednesday|| 
                dayOfWeek == DayOfWeek.Thursday|| 
                dayOfWeek == DayOfWeek.Friday || 
                dayOfWeek == DayOfWeek.Saturday)
            {
                DayType = DayTypes.WedSat;
            }
            else
            {
                DayType = (DayTypes)day.DayOfWeek;
            }
        }
    }
}