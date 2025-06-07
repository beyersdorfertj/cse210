class BreathingActivity : Activity {

    protected override string GetActivityName() {
        return "Breathing Activity";
    }

    protected override string GetStartingMessage() {
        return "This activity will help you relax by walking your breathing in and out slowly.\n" +
               "Clear your mind and focus on your breathing.";
    }

    protected override void StartActivity() {
        DateTime endTime = DateTime.Now.AddSeconds(GetActivityTime());
        int breathDuration = 3; // seconds for breathing in and out
        while (DateTime.Now < endTime) {
            Console.Write("\nBreathe in...");
            GetCountdown(breathDuration);
            Console.Write("\nNow breathe out...");
            GetCountdown(breathDuration);
            Console.WriteLine();
            if (breathDuration < 10) {
                breathDuration++; // Increase the duration for the next cycle
            }
        }

        Console.WriteLine("Well done! You have completed the Breathing Activity.");
    }
}