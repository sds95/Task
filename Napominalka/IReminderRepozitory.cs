using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Napominalka
{
    interface IReminderRepozitory
    {
        Task AddAsync(IReminder task);
        Task DeleteAsync(ObjectId id); 
        List<IReminder> All { get; } 
        List<IReminder> Search();
    }
}
