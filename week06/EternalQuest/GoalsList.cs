using System.Text.Json;

public class GoalsList {

    public GoalsList() {
        LoadList(true);
    }
    private int _totalPoints = 0;

    public int GetTotalPoints() {
        return _totalPoints;
    }

    private List<Goal> _goals = new List<Goal>();
    public int GoalsCount() {
        return _goals.Count;
    }

    private string _filePath = "goals.txt";
    private bool _autoStore = true;
    public bool GetAutoStore() { return _autoStore; }
    public void ToggleAutoStore() {
        _autoStore = !_autoStore;
    }

    public void CreateGoal() {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  0. Cancel");
        int goalType = -1;
        while (goalType < 0 || goalType > 3) {
            Console.Write("Which type of goal would you like to create? ");
            try {
                goalType = int.Parse(Console.ReadLine());
                if (goalType < 0 || goalType > 3) {
                    Console.WriteLine("Invalid option, please try again.");
                }
            } catch (FormatException) {
                Console.WriteLine("Invalid input, please enter a number between 0 and 3.");
            }
        }
        if (goalType == 0) {
            return;
        }
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) {
            return;
        }
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(description)) {
            return;
        }
        Console.Write("What is the amount of points associated with this goal? ");
        int points = 0;
        while (points <= 0) {
            try {
                points = int.Parse(Console.ReadLine());
                if (points <= 0) {
                    Console.WriteLine("Points must be a positive integer. Please try again.");
                }
            } catch (FormatException) {
                Console.WriteLine("Invalid input, please enter a positive integer for points.");
            }
        }
        Goal newGoal = null;
        switch (goalType) {
            case 1:
                newGoal = SimpleGoal.Create(name, description, points);
                break;
            case 2:
                newGoal = EternalGoal.Create(name, description, points);
                break;
            case 3:
                newGoal = ChecklistGoal.Create(name, description, points);
                break;
        }
        if (newGoal != null) {
            _goals.Add(newGoal);
            if (_autoStore) {
                SaveList();
            }
        }
    }

    public void ListGoals() {
        if (_goals.Count == 0) {
            Console.WriteLine("No goals available.");
            return;
        }
        Console.WriteLine("\nThe Goals are:");
        for (int i = 0; i < _goals.Count; i++) {
            Console.WriteLine($"{i + 1}. {_goals[i].List()}");
        }
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }

    public void RecordEvent() {
        List<Goal> activeGoals = _goals.Where(g => !g.IsCompleted()).ToList();

        if (activeGoals.Count == 0) {
            Console.WriteLine("No uncompleted goals available to record an event.");
            return;
        }
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < activeGoals.Count; i++) {
            Console.WriteLine($"{i + 1}. {activeGoals[i].List()}");
        }
        int goalIndex = -1;
        while (goalIndex < 0 || goalIndex > activeGoals.Count) {
            try {
                Console.Write("Which goal did you accomplish? (Enter the number or 0 to cancel): ");
                goalIndex = int.Parse(Console.ReadLine());
                if (goalIndex < 1 || goalIndex > activeGoals.Count) {
                    Console.WriteLine("Invalid option, please try again.");
                }
            } catch (FormatException) {
                Console.WriteLine("Invalid input, please enter a number corresponding to the goal or 0 to cancel.");
            }
        }
        if (goalIndex == 0) {
            return;
        }
        _totalPoints += activeGoals[goalIndex - 1].RecordEvent();
        if (_autoStore) {
            SaveList();
        }
    }

    public void SaveList() {
        using (StreamWriter writer = new StreamWriter(_filePath)) {
            writer.WriteLine($"{_autoStore},{_totalPoints}");
            foreach (var goal in _goals) {
                writer.WriteLine(goal.Serialize());
            }
        }
    }

    public void LoadList(bool testAutoStore = false) {
        if (!File.Exists(_filePath)) {
            return;
        }
        using (StreamReader reader = new StreamReader(_filePath)) {
            string firstLine = reader.ReadLine();
            if (firstLine != null) {
                var parts = firstLine.Split(',');
                _autoStore = bool.Parse(parts[0]);
                if (testAutoStore && !_autoStore) {
                    return; // If auto store is false, skip loading goals
                }
                _totalPoints = int.Parse(parts[1]);
            }
            string line;
            while ((line = reader.ReadLine()) != null) {
                string type = line.Substring(0, 2);
                JsonDocument doc = JsonDocument.Parse(line.Substring(3));
                if (type == "SG") {
                    _goals.Add(new SimpleGoal(doc.RootElement));
                } else if (type == "EG") {
                    _goals.Add(new EternalGoal(doc.RootElement));
                } else if (type == "CG") {
                    _goals.Add(new ChecklistGoal(doc.RootElement));
                }
            }
        }
    }
}