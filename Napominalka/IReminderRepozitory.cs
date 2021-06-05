using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Napominalka
{
    interface IReminderRepozitory
    {
        void Add(IReminder task);
        void Delete(ObjectId id); 
        List<IReminder> All { get; } 
        List<IReminder> Search();
    }
}
