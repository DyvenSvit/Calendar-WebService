using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace CalendarUGCCWebService.Models.MongoHelpers
{
    public static class MongoDb
    {
        private static readonly string ConnectionString = "mongodb://localhost";
            //System.Configuration.ConfigurationManager.ConnectionStrings.["MongoServerSettings"];
        public static string DatabaseName { get { return "calendar"; } }

        private static MongoServer _server;
        private static MongoDatabase _database;

        public static MongoServer Server
        {
            get
            {
                if (_server == null)
                {
                    var client = new MongoClient(ConnectionString);
                    _server = client.GetServer();
                }

                return _server;
            }
        }

        public static MongoDatabase Db
        {
            get
            {
                if (_database == null)
                    _database = Server.GetDatabase(MongoDb.DatabaseName);

                return _database;
            }
        }

        public static MongoCollection<T> GetCollection<T>() where T : Entity
        {
            return Db.GetCollection<T>(typeof(T).FullName);
        }

        public static List<T> GetEntityList<T>() where T : Entity
        {
            var collection = MongoDb.Db.GetCollection<T>(typeof(T).Name);
            return collection.FindAll().ToList<T>();
        }

        public static void InsertEntity<T>(T entity) where T : Entity
        {
            GetCollection<T>().Save(entity);
        }
    }
}