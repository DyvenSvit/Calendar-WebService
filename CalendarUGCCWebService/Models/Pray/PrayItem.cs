using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarUGCCWebService.Models
{
    public class PrayItem
    {
        public string Comment { get; set; }

        public enum Actors
        {
            Prist,
            People
        };

        public string Actor { get; set; }     
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
        public PrayItem(Actors actor, string text)
        {
            Text = text;
            Actor = actor.ToString();
        }

        public PrayItem(string comment, string actor, string text)
        {
            Comment = comment;
            Text = text;
            Actor = actor;
        }


    }
}