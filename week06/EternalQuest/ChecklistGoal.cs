using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
        }

        public override int RecordEvent()
        {
            if (!_completed)
            {
                _currentCount++;
                if (_currentCount >= _targetCount)
                {
                    _completed = true;
                    return _points + _bonusPoints;
                }
                return _points;
            }
            return 0;
        }

        public override string GetStatus() => _completed ? "[X]" : "[ ]";
        public override string GetDetails() =>
            $"{GetStatus()} {_name} ({_description}) -- Completed {_currentCount}/{_targetCount} times";
        public override string Serialize() =>
            $"ChecklistGoal|{_name}|{_description}|{_points}|{_completed}|{_targetCount}|{_currentCount}|{_bonusPoints}";

        public static ChecklistGoal Deserialize(string data)
        {
            var parts = data.Split('|');
            var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[7]));
            goal._completed = bool.Parse(parts[4]);
            goal._currentCount = int.Parse(parts[6]);
            return goal;
        }
    }
}