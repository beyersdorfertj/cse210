using System.Text.Json;

class SimpleGoal : Goal {
    public static SimpleGoal Create(string name, string description, int points) {
        return new SimpleGoal(name, description, points);
    }

    public SimpleGoal(string name, string description, int points) : base(name, description, points) {}

    public SimpleGoal(JsonElement json) : base(json) {}

    protected override string GetGoalType() {
        return "SG";
    }

    public override int RecordEvent() {
        if (!_isCompleted) {
            _isCompleted = true;
            Console.WriteLine($"Congratulations! You've completed the goal: {_name} and earned {_points} points.");
            return _points;
        } else {
            Console.WriteLine($"Goal '{_name}' is already completed. No points awarded.");
            return 0;
        }
    }
}