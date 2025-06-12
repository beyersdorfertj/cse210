// added auto save/load functionality
// suporting ',' and '\"' in goal names and descriptions
// counting points for uncompleted goals only

using System;

class Program {
    static void Main(string[] args) {
        int menuOption = 0;
        GoalsList goalsList = new GoalsList();
        
        while (menuOption != 7) {
            Console.Clear();
            Console.WriteLine($"You have {goalsList.GetTotalPoints()} points.");

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create a New Goal");
            if (goalsList.GoalsCount() > 0) Console.WriteLine($"  2. List Goals ({goalsList.GoalsCount()})");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine($"  4. Switch AutoStore {(goalsList.GetAutoStore() ? "OFF" : "ON")}");
            if (!goalsList.GetAutoStore()) {
                Console.WriteLine("  5. Load Goals");
                Console.WriteLine("  6. Save Goals");
            }
            Console.WriteLine("  7. Exit");
            Console.Write("Select a choice from the menu: ");

            menuOption = 0;
            while (menuOption < 1 || menuOption > 7) {
                try {
                    menuOption = int.Parse(Console.ReadLine());
                    if (menuOption < 1 || menuOption > 7) {
                        Console.WriteLine("Invalid option, please try again.");
                    }
                } catch (FormatException) {
                    Console.WriteLine("Invalid input, please enter a number between 1 and 7.");
                }
            }
            switch (menuOption) {
                case 1:
                    goalsList.CreateGoal();
                    break;
                case 2:
                    goalsList.ListGoals();
                    break;
                case 3:
                    goalsList.RecordEvent();
                    break;
                case 4:
                    goalsList.ToggleAutoStore();
                    break;
                case 5:
                    goalsList.LoadList();
                    break;
                case 6:
                    goalsList.SaveList();
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine("\nThanks for working on Your Goals! Goodbye!");
    }
}