using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarUGCCWebService.Models.Calendar
{
    public class Holidays
    {
        public List<Holiday> List = new List<Holiday>();
        public int Year { get; set; }

        public Holidays(int year)
        {
            Year = year;

            List.Add(new Holiday(new DateTime(), "Easter", "Воскресіння Господнє"));
            List.Add(new Holiday(new DateTime(Year, 1, 7), "Rizdvo", "Різдво"));
            List.Add(new Holiday(new DateTime(Year, 1, 19), "Jordan", "Йордан"));
            List.Add(new Holiday(new DateTime(Year, 2, 15), "Stritennja", "Стрітення"));
            List.Add(new Holiday(new DateTime(Year, 4, 7), "Blagovishhennja", "Благовіщення"));
            List.Add(new Holiday(new DateTime(), "VerbnaNedilja", "Вербна Неділя"));
            List.Add(new Holiday(new DateTime(), "Voznesinnja", "Вознесіння"));
            List.Add(new Holiday(new DateTime(), "ZeleniSvjata", "Зіслання Св. Духа"));
            List.Add(new Holiday(new DateTime(Year, 8, 19), "Preobrazhennja", "Преображення"));
            List.Add(new Holiday(new DateTime(Year, 8, 28), "UspinnjaBogorodyci", "Успіння Богородиці"));
            List.Add(new Holiday(new DateTime(Year, 9, 21), "RizdvoBogorodyci", "Різдво Богородиці"));
            List.Add(new Holiday(new DateTime(Year, 9, 27), "Vozdvyzhennja", "Воздвиження"));
            List.Add(new Holiday(new DateTime(Year, 12, 4), "VvedennjaBogorodyciVHram", "Введення Богородиці у храм"));

            var easter = List.FirstOrDefault(a => a.ShortName == "Easter");
            if (easter == null) return;
            easter.Date = GetEasterDate();

            var obj = List.FirstOrDefault(a => a.ShortName == "VerbnaNedilja");
            if (obj != null) obj.Date = easter.Date.AddDays(-7);

            obj = List.FirstOrDefault(a => a.ShortName == "Voznesinnja");
            if (obj != null) obj.Date = easter.Date.AddDays(39);

            obj = List.FirstOrDefault(a => a.ShortName == "ZeleniSvjata");
            if (obj != null) obj.Date = easter.Date.AddDays(49);
        }

        private DateTime GetEasterDate()
        {
            var a = (19 * (Year % 19) + 15) % 30;
            var b = (2 * (Year % 4) + 4 * (Year % 7) + 6 * a + 6) % 7;
            if ((a + b) < 10)
            {
                var day = 22 + a + b;
                var easterDate = new DateTime(Year, 3, day);
                easterDate = easterDate.AddDays(13);
                return easterDate;
            }
            else
            {
                var day = a + b - 9;
                var easterDate = new DateTime(Year, 4, day);
                easterDate = easterDate.AddDays(13);
                return easterDate;
            }
        }
    }
}