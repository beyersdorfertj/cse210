using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        ActivityList activityList = new ActivityList();
        activityList.AddActivity(new RunActivity("03 Nov 2022", 30, 4.8));
        activityList.AddActivity(new CycleActivity("04 Nov 2022", 45, 20.0));
        activityList.AddActivity(new SwimActivity("05 Nov 2022", 60, 40)); // 40 laps
        activityList.ListActivities();
    }
}