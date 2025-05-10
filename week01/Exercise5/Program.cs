using System;

class Program {
    static void DisplayResult(string userName, int squaredNumber) {
        Console.WriteLine($"Brother {userName}, the square of your number is {squaredNumber}");
    }

    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName() {
        Console.Write("Please enter your name:");
        return Console.ReadLine();
    }

    static int PromptUserNumber() {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number) {
        return number*number;
    }

    static void Main(string[] args) {
        DisplayWelcome();
        string name = PromptUserName();
        int favoriteNumner = PromptUserNumber();
        DisplayResult(name, SquareNumber(favoriteNumner));
    }
}