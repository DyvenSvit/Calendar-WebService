using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarUGCCWebService.Models.Calendar
{
    public class Month
    {
        public int MonthId;
        public int YearId;
        public List<Day> Days = new List<Day>();

        public Month()
        {

        }
        public Month(int yearId, int monthId, List<Day> monthHolidays)
        {
            MonthId = monthId;
            YearId = yearId;
            var days = DateTime.DaysInMonth(yearId, monthId);
            for (int day = 1; day <= days; day++ )
            {
                if (monthHolidays.Any<Day>(x => x.DayId.Day == day))
                {
                    var DayDate = new DateTime(yearId, monthId, day);
                    Days.Add(new Day(DayDate, monthHolidays.Find(x => x.DayId == DayDate).Holiday));
                }
                else
                {
                    Days.Add(new Day(new DateTime(yearId, monthId, day), false));
                }
            }
        }
    }
}