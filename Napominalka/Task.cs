using System;
using System.Collections.Generic;
using System.Text;

namespace Napominalka
{
    class Task
    {
        private Guid id;
        private string data;

        public override string ToString()
        {
            return data;
        }

        public Task( Guid id, string data)
        {
            this.id = id;
            this.data = data;
        }
    }
}
