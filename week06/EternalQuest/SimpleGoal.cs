using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            if (!_completed)
            {
                _completed = true;
                return _points;
            }
            return 0;
        }

        public override string GetStatus() => _completed ? "[X]" : "[ ]";
        public override string GetDetails() => $"{GetStatus()} {_name} ({_description})";
        public override string Serialize() => $"SimpleGoal|{_name}|{_description}|{_points}|{_completed}";

        public static SimpleGoal Deserialize(string data)
        {
            var parts = data.Split('|');
            var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
            goal._completed = bool.Parse(parts[4]);
            return goal;
        }
    }
}