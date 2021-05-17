using System;
using System.Collections.Generic;
using System.Text;

namespace Napominalka
{
    interface IReminderRepozitory
    {
        void Add(IReminder task);
        void Delete(Guid id); 
        List<IReminder> All { get; } 
        List<IReminder> Search();
    }
}
