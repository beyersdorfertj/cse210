class ListingActivity : Activity {

    protected override string GetActivityName() {
        return "Listing Activity";
    }

    protected override string GetStartingMessage() {
        return "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void StartActivity() {
        Console.WriteLine("List as many responses you can to the following prompt:");	
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine("You may begin in: ");
        GetCountdown(5);
        DateTime endTime = DateTime.Now.AddSeconds(GetActivityTime());
        Console.WriteLine();

        int listedItemsInTime = 0;
        while (DateTime.Now < endTime) {
            Console.Write($"{Math.Ceiling((endTime - DateTime.Now).TotalSeconds)} > ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item) && DateTime.Now <= endTime) {
                listedItemsInTime++;
            }
        }
        Console.WriteLine($"You listed {listedItemsInTime} items in time.\n\nWell done!");
    }

    private string GetRandomPrompt() {
        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        return prompts[new Random().Next(prompts.Length)];
    }
}