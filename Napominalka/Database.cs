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

        public async void Add(IReminder reminder)

        {
            var document = new ReminderDocument(reminder);
            await collection.InsertOneAsync(document);
        }
        public async Task<List<IReminder>> GetAll()
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
    }
}
