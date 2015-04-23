using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarUGCCWebService.Models.Pray
{
    public class PraySection
    {
        public string AheadText { get; set; }
        public string Name { get; set; }
        public string AfterText { get; set; }

        public List<PrayItem> PrayItems = new List<PrayItem>();

        public PraySection()
        {
            
        }
    }
}