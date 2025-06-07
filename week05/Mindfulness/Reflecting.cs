class ReflectingActivity : Activity {

    protected override string GetActivityName() {
        return "Reflecting Activity";
    }

    protected override string GetStartingMessage() {
        return "This activity will help you reflect on times in your life when you have shown strength and resilience." +
               "This will help you recognize the power you have and how you can use it in another aspects of your life.";
    }

    protected override void StartActivity() {
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        GetCountdown(5);
        DateTime endTime = DateTime.Now.AddSeconds(GetActivityTime());
        List<string> questions = GetQuestions();
        Console.Clear();
        do {
            if (questions.Count == 0) {
                Console.WriteLine("You have answered all the questions. Let's reset them for you.");
                questions = GetQuestions(); // Reset questions if all have been used
            }
            int randomIndex = new Random().Next(questions.Count);
            Console.Write($"> {questions[randomIndex]} ");
            questions.RemoveAt(randomIndex);
            GetSpinner(5); // Simulate thinking time
            Console.WriteLine();
        } while (DateTime.Now < endTime);
    }

    private string GetRandomPrompt() {
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a challenge.",
            "Reflect on a moment when you felt proud of yourself.",
            "Consider a difficult decision you had to make."
        };
        return prompts[new Random().Next(prompts.Length)];
    }

    private List<string> GetQuestions() {
        return new List<string> {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "What did you learn about yourself during this experience?",
            "How did this experience change your perspective on challenges?",
            "What strengths did you discover in yourself?",
            "How can you apply what you learned to future situations?",
            "What would you do differently if faced with a similar situation again?"
        };
    }   
}