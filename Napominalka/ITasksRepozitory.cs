using System;
using System.Collections.Generic;
using System.Text;

namespace Napominalka
{
    interface ITaskRepozitory
    {
        void Add(Task task);
        void Delete(int x); 
        Task[] List(); 
        Task[] Searsh();
    }
}
