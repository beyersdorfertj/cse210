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
        if (!IsCompleted()) {
            SetCompleted(true);
            Console.WriteLine($"Congratulations! You've completed the goal: {GetName()} and earned {GetPoints()} points.");
            return GetPoints();
        } else {
            Console.WriteLine($"Goal '{GetName()}' is already completed. No points awarded.");
            return 0;
        }
    }
}