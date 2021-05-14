using System;
using System.Collections.Generic;
using System.Text;

namespace Napominalka
{
    interface IReminderRepozitory
    {

        void Add(Reminder task);
        void Delete(Guid id); 
        List<Reminder> All { get; } 
        List<Reminder> Search();
    }
}
