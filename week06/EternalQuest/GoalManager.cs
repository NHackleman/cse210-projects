using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public void AddGoal(Goal goal) => _goals.Add(goal);

        public void ListGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet!");
                return;
            }
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
            }
        }

        public void RecordEvent()
        {
            ListGoals();
            if (_goals.Count == 0) return;
            Console.Write("Which goal did you accomplish? (number): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= _goals.Count)
            {
                int points = _goals[choice - 1].RecordEvent();
                if (points > 0)
                {
                    _score += points;
                    Console.WriteLine($"Congratulations! You earned {points} points.");
                }
                else
                {
                    Console.WriteLine("This goal is already complete or cannot be recorded again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void ShowScore() => Console.WriteLine($"Your current score: {_score}");

        public void Save(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(_score);
                foreach (var goal in _goals)
                    sw.WriteLine(goal.Serialize());
            }
            Console.WriteLine("Progress saved!");
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Save file not found.");
                return;
            }
            _goals.Clear();
            using (StreamReader sr = new StreamReader(filename))
            {
                _score = int.Parse(sr.ReadLine());
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    _goals.Add(Goal.Deserialize(line));
                }
            }
            Console.WriteLine("Progress loaded!");
        }

        public void CreateGoal()
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string desc = Console.ReadLine();
            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    AddGoal(new SimpleGoal(name, desc, points));
                    break;
                case "2":
                    AddGoal(new EternalGoal(name, desc, points));
                    break;
                case "3":
                    Console.Write("How many times to complete? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Bonus points on completion: ");
                    int bonus = int.Parse(Console.ReadLine());
                    AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }
    }
}