using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Napominalka
{
    class Database
    {
        private string dbname = "Reminders";
        private MongoClient dbClient;
        private IMongoDatabase database;
        private IMongoCollection<ReminderDocument> collection;

        public Database(string connectionstring)
        {
            dbClient = new MongoClient(connectionstring);
            database = dbClient.GetDatabase(dbname);
            collection = database.GetCollection<ReminderDocument>("Reminder");
        } 

        public async Task AddAsync(IReminder reminder)
        {
            var document = new ReminderDocument(reminder);
            await collection.InsertOneAsync(document);
        }
        public async Task<List<IReminder>> GetAllAsync()
        {
            var filter = new BsonDocument();
            var documents = await collection.Find(filter).ToListAsync();
            List<IReminder> reminders = new List<IReminder>();
            foreach (var document in documents)
            {
                reminders.Add(ReminderDocument.ConverToIReminder(document));
            }
            return reminders;
        }
        public async Task DeleteDocumentAsync (ObjectId id)
        {
            var filter = new BsonDocument("_id", id);
            await collection.DeleteOneAsync(filter);
        }
    }
}
