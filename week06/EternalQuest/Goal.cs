using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _completed;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _completed = false;
        }

        public abstract int RecordEvent();
        public abstract string GetStatus();
        public abstract string GetDetails();
        public abstract string Serialize();

        public virtual bool IsComplete() => _completed;

        public static Goal Deserialize(string data)
        {
            var parts = data.Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    return SimpleGoal.Deserialize(data);
                case "EternalGoal":
                    return EternalGoal.Deserialize(data);
                case "ChecklistGoal":
                    return ChecklistGoal.Deserialize(data);
                default:
                    throw new Exception("Unknown goal type");
            }
        }
    }
}