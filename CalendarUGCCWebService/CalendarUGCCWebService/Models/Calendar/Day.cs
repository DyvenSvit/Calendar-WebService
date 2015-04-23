using System;
using System.Linq;

namespace CalendarUGCCWebService.Models.Calendar
{
    public class Day
    {
        public DateTime DayId { get; set; }

        public int Glas { get; set; }
        public string Holiday { get; set; }
        public bool IsHoliday { get; set; }

        public DayOfWeek DayType { get; set; }

        public Day()
        {

        }
        public Day(DateTime day)
        {
            DayId = day;
            DayType = day.DayOfWeek;
        }
        public Day(DateTime day, bool singleDay)
        {
            DayId = day;
            DayType = day.DayOfWeek;

            //if (singleDay)
            //{
                SetGlas(day);
            //}
        }

        public Day(DateTime day, string holiday)
        {
            DayId = day;
            Holiday = holiday;
            IsHoliday = true;
            DayType = day.DayOfWeek;

            SetGlas(day);
        }

        private void SetGlas(DateTime day)
        {
            var currentYear = new Year(day);
            Year year;
            if (DayId < currentYear.Holidays.List.FirstOrDefault(a => a.ShortName == "Easter").Date)
            {
                year = currentYear.GetPreviousYear(currentYear.YearId);
            }
            else
            {
                year = currentYear;
            }
            var easter = year.Holidays.List.FirstOrDefault(a => a.ShortName == "Easter");
            var zelSvyata = year.Holidays.List.FirstOrDefault(a => a.ShortName == "ZeleniSvjata");
            if (zelSvyata != null)
            {      
              if (day >= easter.Date && day < zelSvyata.Date.AddDays(7))
                {
                    var diff = day - easter.Date;
                    if (diff.Days <= new TimeSpan(7, 0, 0, 0).Days)
                    {
                        if (diff.Days == 6){Glas = diff.Days + 1;}
                        else{Glas = diff.Days + 1;}
                    }
                    else
                    {
                        if (diff.Days / 7 == 7){Glas = 8;}
                        else{Glas = (diff.Days / 7) % 8;}
                    }
                }
                else
                {
                    var daysFromZelSvyata = day - zelSvyata.Date;
                    var weekFromZelSvyata = daysFromZelSvyata.Days / 7;
                    Glas = weekFromZelSvyata % 8;
                }
            }

           
        }

    }
}