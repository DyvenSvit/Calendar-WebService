using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Entity = CalendarUGCCWebService.Models.MongoHelpers.Entity;

namespace CalendarUGCCWebService.Models.Pray
{
    public class PrayType : Entity
    {
        public string Name;
        public List<string> SubTypes;

        public PrayType()
        {
            
        }
    }
}