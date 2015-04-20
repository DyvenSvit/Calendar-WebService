using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace CalendarUGCCWebService.Models.MongoHelpers
{
    public abstract class Entity
    {
        public ObjectId Id { set; get; }
    }
}