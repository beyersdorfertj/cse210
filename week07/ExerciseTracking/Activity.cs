abstract class Activity {
    private string _date;
    private double _duration; // in minutes
    private double _distance; // in kilometers


    protected double GetDuration() {
        return _duration;
    }

    protected string GetDate() {
        return _date;
    }

    public Activity(string date, double duration, double distance) {
        _date = date;
        _duration = duration;
        _distance = distance;
    }

    protected double GetDistance() {
        return _distance;
    }

    protected virtual string GetDistanceString() {
        return $"{_distance:N2} km";
    }

    protected virtual string GetSpeedString() {
        return (_duration == 0) ? "---" : $"{_distance / _duration * 60:N1} km/h";
    }

    protected virtual string GetPaceString() {
        return (_distance == 0) ? "---" : $"{_duration / _distance:N1} min/km";
    }

    public string GetSummary() {
        return $"{_date} {GetName()}, Distance: {GetDistanceString()}, Speed: {GetSpeedString()}, Pace: {GetPaceString()}";
    }

    protected abstract string GetName();
}