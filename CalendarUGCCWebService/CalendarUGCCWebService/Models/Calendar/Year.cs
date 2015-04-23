using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarUGCCWebService.Models.Calendar
{
    public class Year
    {
        public int YearId { get; set; }
        public List<Day> Holidays = new List<Day>();
        public List<Month> Months = new List<Month>();

        public Year()
        { 
        }


        public Year(int id, bool fullYear)
        {
            YearId = id;
            try
            { SetHolidays(); }
            catch (Exception ex)
            {
                throw new Exception("Error during defining holidays", ex);
            }

            if (!fullYear) return;
            for (var month = 1; month <= 12; month++)
            {
                var monthHolidays = Holidays.FindAll(x => x.DayId.Month == month);
                Months.Add(new Month(YearId, month, monthHolidays));
            }
        }

        public Year(DateTime date)
        {
            YearId = date.Year;

            SetHolidays();

        }

        private void SetHolidays()
        {
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

            var easter = Holidays.FirstOrDefault(a => a.Holiday == "Easter");
            if (easter == null) return;
            easter.DayId = GetEasterDate();
            
            var obj = Holidays.FirstOrDefault(a => a.Holiday == "VerbnaNedilja");
            if (obj != null) obj.DayId = easter.DayId.AddDays(-7);

            obj = Holidays.FirstOrDefault(a => a.Holiday == "Voznesinnja");
            if (obj != null) obj.DayId = easter.DayId.AddDays(39);

            obj = Holidays.FirstOrDefault(a => a.Holiday == "ZeleniSvjata");
            if (obj != null) obj.DayId = easter.DayId.AddDays(49);
        }

        private DateTime GetEasterDate()
        {
            var a = (19 * (YearId % 19) + 15) % 30;
            var b = (2 * (YearId % 4) + 4 * (YearId % 7) + 6 * a + 6) % 7;
            if ((a+b)<10)
            {
                var day = 22 + a + b;
                var easterDate = new DateTime(YearId, 3, day);
                easterDate = easterDate.AddDays(13);
                return easterDate;
            }
            else
            {
                var day = a + b - 9;
                var easterDate = new DateTime(YearId, 4, day);
                easterDate = easterDate.AddDays(13);
                return easterDate;
            }
        }

        public Year GetPreviousYear(int currentYear)
        {
            return new Year(currentYear - 1, false);
        }
    }
}