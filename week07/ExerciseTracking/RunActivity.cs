class RunActivity : Activity {
    public RunActivity(string date, double duration, double distance) : base(date, duration, distance) {
    }

    protected override string GetName() {
        return "Running";
    }

}