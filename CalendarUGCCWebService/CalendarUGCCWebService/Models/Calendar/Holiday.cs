using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarUGCCWebService.Models.Calendar
{
    public class Holiday
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public DateTime Date { get; set; }

        public Holiday(){}

        public Holiday(DateTime date, string shortname, string name)
        {
            Date = date;
            Name = name;
            ShortName = shortname;
        }
    }
}