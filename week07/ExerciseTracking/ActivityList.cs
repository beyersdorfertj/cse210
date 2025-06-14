class ActivityList {
    private List<Activity> _activities;

    public ActivityList() {
        _activities = new List<Activity>();
    }

    public void AddActivity(Activity activity) {
        _activities.Add(activity);
    }

    public void ListActivities() {
        foreach (var activity in _activities) {
            Console.WriteLine(activity.GetSummary());
        }
    }
}