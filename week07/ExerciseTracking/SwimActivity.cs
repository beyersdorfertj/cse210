class SwimActivity : Activity {
    public SwimActivity(string date, double duration, int laps) : base(date, duration, laps / 20.0) {
        // Assuming each lap is 50 meters, so laps / 20.0 converts to kilometers
        // Distance is set in kilometers for consistency with other activities
    }

    protected override string GetName() {
        return "Swimming";
    }
    
    protected override string GetDistanceString() {
        return $"{GetDistance()*20} laps ({GetDistance()} km)";
    }
    protected override string GetSpeedString() {
        return (GetDuration() == 0) ? "---" : $"{GetDistance() / GetDuration() * 20 * 60} laps/h";
    }
    protected override string GetPaceString() {
        return $"{GetDuration() / GetDistance() / 20:N1} min/lap";
    }
}
