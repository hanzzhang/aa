using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NeefunApi.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.Configuration;
using System.Threading.Tasks;

namespace NeefunApi
{
    public static class Mongo
    {
        private static string connectionString = "mongodb://hanzvm2.cloudapp.net";
        private static string dbName = "Person";
        private static string collectionName = "PersonCollection";
        private static IMongoDatabase db = null;
        static Mongo()
        {
            IMongoClient mongoClient = new MongoClient(connectionString);
            db = mongoClient.GetDatabase(dbName);
        }
        public static async Task<List<Person>> GetAllPersonAsync()
        {
            IMongoCollection<Person> collection = db.GetCollection<Person>(collectionName);
            return await collection.Find<Person>(x => x.Name != null).ToListAsync();
        }

        public static async Task<List<Person>> GetPersonAsync(System.Web.OData.Query.ODataQueryOptions<Person> queryOptions)
        {
            IMongoCollection<Person> collection = db.GetCollection<Person>(collectionName);
            return await collection.Find<Person>(x => x.Name =="hanz").ToListAsync();
        }

        // Creates a Person and inserts it into the collection in MongoDB.
        public static async Task CreatePersonAsync(Person Person)
        {
            IMongoCollection<Person> collection = db.GetCollection<Person>(collectionName);
            await collection.InsertOneAsync(Person);
        }
    }
}