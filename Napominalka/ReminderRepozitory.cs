using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Napominalka
{
    class ReminderRepozitory : IReminderRepozitory
    {
        private List<IReminder> reminders = new List<IReminder>();
        private Database database;

        public ReminderRepozitory()
        {
            string connectionstring = "mongodb://localhost:27017";
            database = new Database(connectionstring);
        }
        public Task AddAsync(IReminder task)
        {
            return database.AddAsync(task);
        }
        public Task DeleteAsync(ObjectId id)
        {
            /* for (int i = 0; i < reminders.Count; i++)
               {
                   if (id == reminders[i].Id)
                   {
                       reminders.Remove(reminders[i]);
                   }
               }

               foreach (var reminder in reminders.ToArray())
               {
                   if (id == reminder.Id)
                       reminders.Remove(reminder);
               }

               reminders.RemoveAll(SameId);
               bool SameId(Reminder reminder)
               {
                   return id == reminder.Id;
               }

               bool SameId2(Reminder reminder) => id == reminder.Id;

               reminders.RemoveAll(reminder => 
               { 
                   return id == reminder.Id; 
               }); */

            //reminders.RemoveAll(reminder => id == reminder.Id);

            return database.DeleteDocumentAsync(id);
        }
        List<IReminder> IReminderRepozitory.Search()
        {
            Console.Write("Введите что найти - ");
            string finding = Console.ReadLine();
            return reminders.FindAll(reminder => reminder.ToString().Contains(finding));
        }

        /*List<Reminder> IReminderRepozitory.ToList()
        {
            return reminders;
        }*/
        public List<IReminder> All
        {
            get 
            {
                var task = this.database.GetAllAsync();
                reminders = task.Result;
                return reminders;    
            }
        }
    }
}

