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
        public Month(int yearId, int monthId, List<Holiday> monthHolidays)
        {
            MonthId = monthId;
            YearId = yearId;
            var days = DateTime.DaysInMonth(yearId, monthId);
            for (int day = 1; day <= days; day++ )
            {
                if (monthHolidays.Any<Holiday>(x => x.Date.Day == day))
                {
                    var dayDate = new DateTime(yearId, monthId, day);
                    Days.Add(new Day(dayDate, monthHolidays.Find(x => x.Date == dayDate).ShortName));
                }
                else
                {
                    Days.Add(new Day(new DateTime(yearId, monthId, day), false));
                }
            }
        }
    }
}