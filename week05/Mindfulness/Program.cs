// no duplicate prompts in reflection activity
// slowing down breathing activity

using System;

class Program {
    static void Main(string[] args) {
        int inputId = 0;

        do {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");

            Console.Write("Select a choice from the menu: ");

            try {
                inputId = int.Parse(Console.ReadLine());
                Activity activity = null;
                switch (inputId) {
                    case 1:
                        activity = new BreathingActivity();
                        break;
                    case 2:
                        activity = new ReflectingActivity();
                        break;
                    case 3:
                        activity = new ListingActivity();
                        break;
                    case 4:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You selected an invalid option, please try again.");
                        break;
                }
                if (activity != null) {
                    activity.Start();
                }
            } catch (FormatException) {
                Console.WriteLine($"You didn't type a number. Please try again.");
                Thread.Sleep(1500);
                inputId = 0; // Reset inputId to allow retry
            }
        } while (inputId != 4);
        Console.WriteLine("Thank you for using the Mindfulness App. Have a great day!");
    }
}