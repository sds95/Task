using System;
using System.Collections.Generic;
using System.Text;

namespace Napominalka
{
    class ReminderRepozitory : IReminderRepozitory
    {
        private List<IReminder> reminders = new List<IReminder>(); 
        public void Add(IReminder task)
        {
            reminders.Add(task);
        }
        public void Delete(Guid id)
        {
         /* for (int i = 0; i < reminders.Count; i++)
            {
                if (id == reminders[i].Id)
                {
                    reminders.Remove(reminders[i]);
                }
            }

            foreach (var reminder in reminders.ToArray())
            {
                if (id == reminder.Id)
                    reminders.Remove(reminder);
            }

            reminders.RemoveAll(SameId);
            bool SameId(Reminder reminder)
            {
                return id == reminder.Id;
            }

            bool SameId2(Reminder reminder) => id == reminder.Id;

            reminders.RemoveAll(reminder => 
            { 
                return id == reminder.Id; 
            }); */

            reminders.RemoveAll(reminder => id == reminder.Id);
        }

        /*List<Reminder> IReminderRepozitory.ToList()
        {
            return reminders;
        }*/
        public List<IReminder> All => reminders;

        List<IReminder> IReminderRepozitory.Search()
        {
            Console.Write("Введите что найти - ");
            string finding = Console.ReadLine();
            return reminders.FindAll(reminder => reminder.ToString().Contains(finding));
        }
    }
}

