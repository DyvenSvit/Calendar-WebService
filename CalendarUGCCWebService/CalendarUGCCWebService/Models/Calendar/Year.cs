using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarUGCCWebService.Models.Calendar
{
    public class Year
    {
        public int YearId { get; set; }
        public Holidays Holidays { get; set; }
        public List<Month> Months = new List<Month>();

        public Year()
        { 
        }


        public Year(int id, bool fullYear)
        {
            YearId = id;
            try
            {
                Holidays = new Holidays(YearId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error during defining holidays", ex);
            }
            if (fullYear)
            {
                for (var month = 1; month <= 12; month++)
                {
                    var monthHolidays = Holidays.List.FindAll(x => x.Date.Month == month);
                    Months.Add(new Month(YearId, month, monthHolidays));
                }    
            }
            
        }

        public Year(DateTime date)
        {
            YearId = date.Year;
            Holidays = new Holidays(YearId);
        }

        public Year GetPreviousYear(int currentYear)
        {
            return new Year(currentYear - 1, false);
        }
    }
}