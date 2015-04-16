using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace CalendarUGCCWebService.Models.Pray
{
    public class PrayType
    {
        [BsonId]
        public String Id { get; set; }
        
        public string Name;
        public List<string> SubTypeList= new List<string>();

        public PrayType()
        {
            
            var tmp = ReadCollection();
            
        }

        private static long ReadCollection()
        {   
            var client = new MongoClient();
            var server = client.GetServer();
            var db = server.GetDatabase("calendar");
            var collection = db.GetCollection<PrayType>("pray_type");

            var count = 1;
            var query =
                    from e in collection.AsQueryable<PrayType>()
                    where e.Name == "Вечірня"
                    select e;
            foreach (var name in query)
            {
                var tmp = name.Name;
            }
            //var tmp = collection.Find();

            return count;
        }

    }
}