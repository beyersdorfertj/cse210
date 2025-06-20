using System.Text.Json;

abstract class Goal {
    private string _name;
    private string _description;
    private int _points;
    private bool _isCompleted = false;

    public Goal(string name, string description, int points) {
        _name = name;
        _description = description;
        _points = points;
    }

    public Goal(JsonElement json) {
        _name = json.GetProperty("name").GetString();
        _description = json.GetProperty("description").GetString();
        _points = json.GetProperty("points").GetInt32();
        _isCompleted = json.GetProperty("isCompleted").GetBoolean();
    }

    protected string GetName() {
        return _name;
    }

    protected string GetDescription() {
        return _description;
    }

    protected int GetPoints() {
        return _points;
    }

    public virtual string List() {
        return $"[{(_isCompleted ? "X" : " ")}] {_name} ({_description})";
    }

    protected abstract string GetGoalType();

    protected virtual string GetSerialization() {
        return $"\"name\":\"{_name.Replace("\"", "\\\"")}\",\"description\":\"{_description.Replace("\"", "\\\"")}\",\"points\":{_points},\"isCompleted\":{_isCompleted.ToString().ToLower()}";
    }

    public string Serialize() {
        return $"{GetGoalType()},{{{GetSerialization()}}}";
    }

    public bool IsCompleted() {
        return _isCompleted;
    }

    protected void SetCompleted(bool isCompleted) {
        _isCompleted = isCompleted;
    }

    public abstract int RecordEvent();
}