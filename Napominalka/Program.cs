using System;

namespace Napominalka
{
    class Program
    {
        static void Main(string[] args)
        {
            ITaskRepozitory taskRepozitory = null;
            bool exit = false;
            Task[] tasks = new Task[50000];
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
                        Guid guid = Guid.NewGuid();
                        Console.WriteLine("Введите текст заметки: ");
                        string data = Console.ReadLine();
                        Task task = new Task(guid, data);
                        taskRepozitory.Add(task);
                   //     tasks[i] =  task;
                   //     i++;
                        break;
                    case "list -all":
                        tasks = taskRepozitory.List(); 
                        Console.WriteLine("Ваши заметки: ");
                        for (int j = 1; j < i; j++)
                        {
                            Console.WriteLine(j + " " + tasks[j]);
                        }
                        break;
                    case "find":
                    case "search":
                        tasks = taskRepozitory.Searsh();
                        string find = Console.ReadLine();
                        switch (find)
                        {
                            case "-st":
                                break;
                            case "-end":
                                break;
                            case "-cont":
                                break;
                            case "-ind":
                                break;
                        }
                        break;                          
                    case "del":
                        Console.WriteLine("Введите номер заметки, которую хотите удалить: ");
                        int x = Convert.ToInt32(Console.ReadLine());
                        taskRepozitory.Delete(x); 
                    //    tasks[x] = null;
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
    }
}
