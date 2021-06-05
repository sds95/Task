using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Napominalka
{
    interface IReminder
    {
        public string ToString();
        public ObjectId Id { get; }
    }
}
