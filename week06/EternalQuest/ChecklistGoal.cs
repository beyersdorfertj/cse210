using System.Text.Json;

class ChecklistGoal : Goal {
    public static ChecklistGoal Create(string name, string description, int points) {
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        int timesToComplete = -1;
        while (timesToComplete <= 0) {
            try {
                timesToComplete = int.Parse(Console.ReadLine());
            } catch (FormatException) {
                Console.WriteLine("Invalid input, please enter a positive integer for the number of times.");
            }
        }
        if (timesToComplete == 0) {
            return null;
        }
        Console.Write("What is the bonus for accomplishing it that many times? ");
        int bonusPoints = -1;
        while (bonusPoints < 0) {
            try {
                bonusPoints = int.Parse(Console.ReadLine());
            } catch (FormatException) {
                Console.WriteLine("Invalid input, please enter a non-negative integer for bonus points.");
            }
        }
        return new ChecklistGoal(name, description, points, timesToComplete, bonusPoints);
    }
    
    public ChecklistGoal(string name, string description, int points, int timesToComplete, int bonusPoints) 
        : base(name, description, points) {
        _timesToComplete = timesToComplete;
        _bonusPoints = bonusPoints;
    }
    
    public ChecklistGoal(JsonElement json) 
        : base(json) {
        _timesToComplete = json.GetProperty("timesToComplete").GetInt32();
        _timesCompleted = json.GetProperty("timesCompleted").GetInt32();
        _bonusPoints = json.GetProperty("bonusPoints").GetInt32();
    }

    protected override string GetGoalType() {
        return "CG";
    }

    private int _timesToComplete;
    private int _timesCompleted = 0;
    private int _bonusPoints;

    public override int RecordEvent() {
        if (_isCompleted) {
            Console.WriteLine($"Goal '{_name}' is already completed. No points awarded.");
            return 0;
        }
        
        _timesCompleted++;
        Console.WriteLine($"You accomplished the goal: {_name}. You have now completed it {_timesCompleted} times.");
        
        if (_timesCompleted >= _timesToComplete) {
            _isCompleted = true;
            Console.WriteLine($"Congratulations! You've completed the goal: {_name} and earned {_points + _bonusPoints} points (including bonus).");
            return _points + _bonusPoints;
        } else {
            Console.WriteLine($"You earned {_points} points for this accomplishment.");
            return _points;
        }
    }

    public override string List() {
        return $"{base.List()} -- Currently Completed: {_timesCompleted}/{_timesToComplete}";
    }

    protected override string GetSerialization() {
        return $"{base.GetSerialization()},\"timesToComplete\":{_timesToComplete},\"timesCompleted\":{_timesCompleted},\"bonusPoints\":{_bonusPoints}";
    }
}
