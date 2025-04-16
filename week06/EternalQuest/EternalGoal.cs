using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int _timesCompleted;

        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _timesCompleted = 0;
        }

        public override int RecordEvent()
        {
            _timesCompleted++;
            return _points;
        }

        public override string GetStatus() => $"[∞] (Completed {_timesCompleted} times)";
        public override string GetDetails() => $"{GetStatus()} {_name} ({_description})";
        public override string Serialize() => $"EternalGoal|{_name}|{_description}|{_points}|{_timesCompleted}";

        public static EternalGoal Deserialize(string data)
        {
            var parts = data.Split('|');
            var goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            goal._timesCompleted = int.Parse(parts[4]);
            return goal;
        }
    }
}