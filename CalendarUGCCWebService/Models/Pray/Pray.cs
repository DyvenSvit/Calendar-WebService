using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarUGCCWebService.Models
{
    public class Pray
    {
        public List<PrayItem> PrayList = new List<PrayItem>();        

        public Pray()
        {
            var comment = "Коментар";
            var header = "Вечірня";
            //testing of prayItem
            PrayList.Add(new PrayItem(comment, header));
            for (var i = 1; i <= 10; i++)
            {
                var text = GenerateText(i);
                PrayList.Add(new PrayItem(text));
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