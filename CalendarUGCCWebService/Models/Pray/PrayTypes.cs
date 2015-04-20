using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalendarUGCCWebService.Models.MongoHelpers;


namespace CalendarUGCCWebService.Models.Pray
{
    public static class PrayTypes
    {
        public static List<PrayType> List = MongoDb.GetEntityList<PrayType>();
    }
}