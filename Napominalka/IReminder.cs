using System;
using System.Collections.Generic;
using System.Text;

namespace Napominalka
{
    interface IReminder
    {
        public string ToString();
        public Guid Id { get; }
    }
}
