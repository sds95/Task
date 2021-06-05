using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Napominalka
{
    class ReminderDocument
    {
        public ObjectId Id { get; set; }
        public string Data { get; set; }

        public ReminderDocument(IReminder reminder)
        {
            this.Id = reminder.Id;
            this.Data = reminder.ToString();
        }
        public static IReminder ConverToIReminder(ReminderDocument document)
        {
            IReminder reminder = new Reminder(document.Data, document.Id);
            return reminder;
        }
    }
}
