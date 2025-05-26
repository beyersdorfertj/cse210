// implemented auto save/load functionality
// stored data as JSON files
// created a class Serialize to handle JSON serialization
// made functions to list/add/remove prompts

using System;

class Program {
    static void Main(string[] args) {
        string choice = "";
        Journal journal = Journal.GetJournal();
        do {
            Console.WriteLine("\nPlease select one of the following choisces:");
            Console.WriteLine("1. Write a new journal entry");
            if (journal.CountEntries() > 0) {
                Console.WriteLine($"2. Display all journal entries ({journal.CountEntries()})");
            }
            Console.WriteLine("3. Save journal entries");
            Console.WriteLine("4. Load journal entries");
            Console.WriteLine($"5. Display all prompts ({Prompt.CountEntries()})");
            Console.WriteLine("6. Add a new prompt");
            Console.WriteLine("7. Remove a prompt");
            Console.WriteLine("8. Quit");
            Console.Write("What would you like do? ");
            choice = Console.ReadLine();
            switch (choice) {
                case "1": {
                    string prompt = Prompt.GetRandom();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string entryText = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(entryText)) {
                        Console.WriteLine("Entry cannot be empty. Please try again.");
                        continue;
                    } else {
                        journal.AddEntry(prompt, entryText);
                    }
                }
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.Write("Please type your file name to save the journal entries (empty for cancel): ");
                    string fileName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(fileName)) {
                        Console.WriteLine("Save cancelled.");
                    } else {
                        Serialize.Write(journal._entries, fileName);
                        Console.WriteLine($"Journal entries saved to {fileName} successfully.");
                    }
                    break;
                case "4":
                    Console.Write("Please type your file name to load the journal entries (empty for cancel): ");
                    string loadFileName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(loadFileName)) {
                        Console.WriteLine("Load cancelled.");
                    } else {
                        if (File.Exists(loadFileName)) {
                            journal._entries = Serialize.Read<List<Entry>>(loadFileName);
                            Console.WriteLine($"Journal entries loaded from {loadFileName} successfully.");
                        } else {
                            Console.WriteLine($"File {loadFileName} does not exist.");
                        }
                    }
                    break;
                case "5":
                    Prompt.Display();
                    break;
                case "6":
                    Console.Write("Please enter a new prompt: ");
                    string newPrompt = Console.ReadLine();
                    Prompt.Add(newPrompt);
                    break;
                case "7":
                    Prompt.Display();
                    Console.Write("Please enter the ID of the prompt you want to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int promptId)) {
                        Prompt.Remove(promptId-1); // Adjust for zero-based index
                    } else {
                        Console.WriteLine("Invalid input. Please enter a valid ID.");
                    }
                    break;
                case "8":
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        } while (choice != "8");
        Console.Write("Thanks for working on your journal. ");
    }
}