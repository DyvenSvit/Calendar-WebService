using System;
using System.Collections.Generic;
using System.Linq;
using CalendarUGCCWebService.Models.Calendar;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace CalendarUGCCWebService.Models.Pray
{
    public class Pray
    {
        public PrayType Type;
        public List<PraySection> PraySections = new List<PraySection>();
        public string Name;

        public Pray()
        {
            const string comment = "Коментар";
            const string header = "Вечірня";
            //testing of prayItem
            PraySections.Add(new PraySection());
            for (var i = 1; i <= 10; i++)
            {
                var text = GenerateText(i);
                if (i % 2 == 0)
                {
                    PraySections.Add(new PraySection());
                }
                else
                {
                    PraySections.Add(new PraySection());
                }
            }
        }

        public Pray(Day day)
        {
            ReadCollection();
        }

        private static void ReadCollection()
        {
            var client = new MongoClient();
            var db = client.GetServer().GetDatabase("calendar");
            var collection = db.GetCollection<PrayType>("pray_type");

            var query = Query<PrayType>.EQ(e => e.Name, "Вечірня");
            var result = collection.FindOne(query);//.Limit(1);
            var json = result.ToJson();
            return;
        }

        //just for testing
        private static string GenerateText(int i)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, i+8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}