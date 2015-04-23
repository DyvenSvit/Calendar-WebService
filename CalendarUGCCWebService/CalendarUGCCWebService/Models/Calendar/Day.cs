using System;
using System.Globalization;
using System.Linq;
using System.Web.Helpers;

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
            if (DayId < currentYear.Holidays.FirstOrDefault(a => a.Holiday == "Easter").DayId)
            {
                year = currentYear.GetPreviousYear(currentYear.YearId);
            }
            else
            {
                year = currentYear;
            }
            var easter = year.Holidays.FirstOrDefault(a => a.Holiday == "Easter");
            var zelSvyata = year.Holidays.FirstOrDefault(a => a.Holiday == "ZeleniSvjata");
            if (zelSvyata != null)
            {      
              if (day >= easter.DayId && day < zelSvyata.DayId.AddDays(7))
                {
                    var diff = day - easter.DayId;
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
                    var daysFromZelSvyata = day - zelSvyata.DayId;
                    var weekFromZelSvyata = daysFromZelSvyata.Days / 7;
                    Glas = weekFromZelSvyata % 8;
                }
            }

           
        }

    }
}