using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Napominalka
{
    class Reminder : IReminder
    {
        private ObjectId id;
        private string data;
        
        public override string ToString()
        {
            return data;
        }

        public ObjectId Id => id;
              
        public Reminder(string data)
        {
            this.data = data;
            id = ObjectId.GenerateNewId();
        }
        public Reminder(string data, ObjectId id)
        { 
            this.data = data;
            this.id = id;
        }
    }
}
