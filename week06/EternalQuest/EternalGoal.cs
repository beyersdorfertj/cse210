using System.Text.Json;

class EternalGoal : Goal {
    public static EternalGoal Create(string name, string description, int points) {
        return new EternalGoal(name, description, points);
    }

    EternalGoal(string name, string description, int points) : base(name, description, points) {}

    protected override string GetGoalType() {
        return "EG";
    }

    public EternalGoal(JsonElement json) : base(json) {}

    public override int RecordEvent() {
        Console.WriteLine($"Congratulations! You did {_name} and earned {_points} points.");
        return _points;
    }
}