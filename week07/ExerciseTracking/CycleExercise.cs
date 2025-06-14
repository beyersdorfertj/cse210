class CycleActivity : Activity {
    public CycleActivity(string date, double duration, double distance) : base(date, duration, distance) {
    }

    protected override string GetName() {
        return "Cycling";
    }

}