using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarUGCCWebService.Models
{
    public class PrayItem
    {
        public string Comment { get; set; }
        //public List<string> Actor = new List<string>()
        //{
        //    "Prist",
        //    "People"
        //};
        public string Header { get; set; }
        public string Text { get; set; }

        public PrayItem()
        {

        }
        public PrayItem(string comment, string header)
        {
            Comment = comment;
            Header = header;
        }
        public PrayItem(string text)
        {
            Text = text;
        }


    }
}