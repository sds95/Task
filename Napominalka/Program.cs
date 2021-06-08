using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Napominalka
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IReminderRepozitory reminderRepozitory = new ReminderRepozitory();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Введите команду: "); 
                string command = Console.ReadLine()
                    .ToLowerInvariant();

                switch (command)
                {
                    case "create":
                    case "add":
                        Console.WriteLine("Введите текст заметки: ");
                        string data = Console.ReadLine();
                        IReminder task = new Reminder(data);
                        await reminderRepozitory.AddAsync(task);
                        break;
                    case "list":
                        {
                            List<IReminder> result = reminderRepozitory.All;
                            Show(result);
                            break;
                        }
                    case "find":
                    case "search":
                        {
                            List<IReminder> result = reminderRepozitory.Search();
                            Show(result);
                            break;
                        }
                    case "del":
                        {
                            List<IReminder> result = reminderRepozitory.All;
                            Console.WriteLine("Введите номер заметки, которую хотите удалить: ");
                            int x = Convert.ToInt32(Console.ReadLine());
                            await reminderRepozitory.DeleteAsync(result[x-1].Id);
                        }
                        break;
                    case "help":
                        Console.WriteLine("ХУЙ ТЕБЕ А НЕ ПОМОЩЬ!");
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Error command");
                        break;
                }         
            }
        }
        public static void Show(List<IReminder> result)
        {
            int i = 1;
            foreach (IReminder reminder in result)
            {
                Console.WriteLine($"{i} {reminder.ToString()}");
                i++;
            }
        }
    }
}
