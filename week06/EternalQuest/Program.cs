using System;

namespace EternalQuest
{
    class Program
    {
        static void Main()
        {
            GoalManager manager = new GoalManager();
            string filename = "goals.txt";
            while (true)
            {
                Console.WriteLine("\nEternal Quest Menu:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Show Score");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. Quit");
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        manager.CreateGoal();
                        break;
                    case "2":
                        manager.ListGoals();
                        break;
                    case "3":
                        manager.RecordEvent();
                        break;
                    case "4":
                        manager.ShowScore();
                        break;
                    case "5":
                        manager.Save(filename);
                        break;
                    case "6":
                        manager.Load(filename);
                        break;
                    case "7":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}