using System;
using System.Collections.Generic;

namespace Napominalka
{
    class Program
    {
        static void Main(string[] args)
        {
            IReminderRepozitory reminderRepozitory = new ReminderRepozitory();
            bool exit = false;
            int i = 1;
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
                        Reminder task = new Reminder(data);
                        reminderRepozitory.Add(task);
                   //     tasks[i] =  task;
                   //     i++;
                        break;
                    case "list -all":
                        {
                            List<Reminder> result = reminderRepozitory.All;
                            Show(result);
                            break;
                        }
                    case "find":
                    case "search":
                        {
                            List<Reminder> result = reminderRepozitory.Search();
                            Show(result);
                            break;
                        }
                    case "del":
                        {
                            List<Reminder> result = reminderRepozitory.All;
                            Console.WriteLine("Введите номер заметки, которую хотите удалить: ");
                            int x = Convert.ToInt32(Console.ReadLine());
                            reminderRepozitory.Delete(result[x].Id);
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
        public static void Show(List<Reminder> result)
        {
            Console.WriteLine(result);
        }
    }
}
