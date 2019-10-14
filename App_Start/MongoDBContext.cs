using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace CarRental_WP.App_Start
{
    public class MongoDBContext
    {
        MongoClient client;
        public IMongoDatabase databse;
        public MongoDBContext() {
            var mongoClient = new MongoClient(ConfigurationManager.AppSettings["MongoDBHost"]);
            databse = mongoClient.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
        }
    }
}