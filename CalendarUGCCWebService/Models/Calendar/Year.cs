using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarUGCCWebService.Models
{
    public class Year
    {
        public int YearId { get; set; }
        public List<Day> Holidays = new List<Day>();
        public List<Month> Months = new List<Month>();

        public Year()
        { 
        }


        public Year(int id)
        {
            YearId = id;

            Holidays.Add(new Day(new DateTime(), "Easter"));
            Holidays.Add(new Day(new DateTime(YearId, 1, 7), "Rizdvo"));
            Holidays.Add(new Day(new DateTime(YearId, 1, 19), "Jordan"));
            Holidays.Add(new Day(new DateTime(YearId, 2, 15), "Stritennja"));
            Holidays.Add(new Day(new DateTime(YearId, 4, 7), "Blagovishhennja"));
            Holidays.Add(new Day(new DateTime(), "VerbnaNedilja"));
            Holidays.Add(new Day(new DateTime(), "Voznesinnja"));
            Holidays.Add(new Day(new DateTime(), "ZeleniSvjata"));
            Holidays.Add(new Day(new DateTime(YearId, 8, 19), "Preobrazhennja"));
            Holidays.Add(new Day(new DateTime(YearId, 8, 28), "UspinnjaBogorodyci"));
            Holidays.Add(new Day(new DateTime(YearId, 9, 21), "RizdvoBogorodyci"));
            Holidays.Add(new Day(new DateTime(YearId, 9, 27), "Vozdvyzhennja"));
            Holidays.Add(new Day(new DateTime(YearId, 12, 4), "VvedennjaBogorodyciVHram"));

            try
            { SetHolidays(); }
            catch (Exception ex)
            {
                throw new Exception("Error during defining holidays", ex);
            }
               

            for (int month = 1; month <= 12;  month++)
            {
                var MonthHolidays = Holidays.FindAll(x => x.DayId.Month == month);
                Months.Add(new Month(YearId, month, MonthHolidays));
            }

        }

        private bool SetHolidays()
        {
            var Easter = Holidays.FirstOrDefault(a => a.Holiday == "Easter");
            if (Easter != null) Easter.DayId = GetEasterDate();
            
            var obj = Holidays.FirstOrDefault(a => a.Holiday == "VerbnaNedilja");
            if (obj != null) obj.DayId = Easter.DayId.AddDays(-7);

            obj = Holidays.FirstOrDefault(a => a.Holiday == "Voznesinnja");
            if (obj != null) obj.DayId = Easter.DayId.AddDays(39);

            obj = Holidays.FirstOrDefault(a => a.Holiday == "ZeleniSvjata");
            if (obj != null) obj.DayId = Easter.DayId.AddDays(49);
            
            return true;
        }

        private DateTime GetEasterDate()
        {
            var a = (19 * (YearId % 19) + 15) % 30;
            var b = (2 * (YearId % 4) + 4 * (YearId % 7) + 6 * a + 6) % 7;
            if ((a+b)<10)
            {
                var day = 22 + a + b;
                var EasterDate = new DateTime(YearId, 3, day);
                EasterDate = EasterDate.AddDays(13);
                return EasterDate;
            }
            else
            {
                var day = a + b - 9;
                var EasterDate = new DateTime(YearId, 4, day);
                EasterDate = EasterDate.AddDays(13);
                return EasterDate;
            }
        }
    }
}