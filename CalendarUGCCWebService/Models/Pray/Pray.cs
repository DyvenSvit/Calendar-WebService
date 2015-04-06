using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarUGCCWebService.Models
{
    public class Pray
    {
        public List<PrayItem> PrayItems = new List<PrayItem>();        

        public Pray()
        {
            var comment = "Коментар";
            var header = "Вечірня";
            //testing of prayItem
            PrayItems.Add(new PrayItem(comment, header));
            for (var i = 1; i <= 10; i++)
            {
                var text = GenerateText(i);
                if (i % 2 == 0)
                {
                    PrayItems.Add(new PrayItem(PrayItem.Actors.People, text));
                }
                else
                {
                    PrayItems.Add(new PrayItem(PrayItem.Actors.Prist, text));
                }
            }
        }

        //just for testing
        private string GenerateText(int i)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, i+8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}