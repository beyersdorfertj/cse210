public abstract class Activity {

    protected abstract string GetActivityName();
    protected abstract string GetStartingMessage();
    protected abstract void StartActivity();

    private int _activityTime;

    protected void SetActivityTime(int seconds) {
        _activityTime = seconds;
    }
    protected int GetActivityTime() {
        return _activityTime;
    }

    public void Start() {
        Console.Clear();
        Console.WriteLine($"Welcome to the {GetActivityName()}.\n\n");
        Console.WriteLine($"{GetStartingMessage()}\n\n");
        int seconds = 0;
        do {
            Console.Write("How long, in seconds, would you like to do this activity? ");
            if (int.TryParse(Console.ReadLine(), out seconds) && seconds > 0) {
                SetActivityTime(seconds);
            } else {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        } while (seconds == 0);

        Console.Clear();
        Console.WriteLine("Get ready...");
        GetSpinner(5);
        StartActivity();
        Console.WriteLine("\n\nWell done!!");
        Console.WriteLine($"\nYou have completed another {GetActivityTime()} seconds of the {GetActivityName()}.");
        GetSpinner(5);
    }

    protected void GetSpinner(int seconds) {
        Console.CursorVisible = false;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        char[] spinnerChars = { '|', '/', '—', '\\' };
        int index = 0;

        Console.Write(spinnerChars[index]);
        while (DateTime.Now < endTime) {
            Thread.Sleep(500);
            Console.Write($"\b{spinnerChars[index]}");
            index = (index + 1) % spinnerChars.Length;
        }
        Console.Write("\b \b");
        Console.CursorVisible = true;
    }

    protected void GetCountdown(int seconds) {
        Console.CursorVisible = false;
        int digits = (int)Math.Log10(seconds) + 1;
        Console.Write(seconds);
        do {
            Thread.Sleep(1000);
            Console.Write($"{new string('\b', digits)}{--seconds}");
            if (digits > (int)Math.Log10(seconds) + 1) {
                Console.Write(" \b");
                digits = (int)Math.Log10(seconds) + 1;
            }
        } while (seconds > 0);
        Console.Write("\b \b");
        Console.CursorVisible = true;
    }
}