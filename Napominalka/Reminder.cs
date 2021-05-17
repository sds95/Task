using System;
using System.Collections.Generic;
using System.Text;

namespace Napominalka
{
    class Reminder : IReminder
    {
        private readonly Guid id;
        private string data;

        public override string ToString()
        {
            return data;
        }

        public Guid Id => id;
        //public string Data => data;

        public Reminder(string data)
        {
            id = Guid.NewGuid();
            this.data = data;
        }
    }
}
