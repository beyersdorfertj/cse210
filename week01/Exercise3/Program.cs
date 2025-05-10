using System;

class Program {
    static void Main(string[] args) {
        do {
            Random randomGenerator = new Random();
            int magic = randomGenerator.Next(1, 100);
            int guess;
            int count = 0;
            do {
                count++;
                Console.WriteLine("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                if (guess < magic) {
                    Console.WriteLine("Higher");
                }
                if (guess > magic) {
                    Console.WriteLine("Lower");
                }
            } while (magic != guess);
            Console.WriteLine($"You guessed it in {count} tries!");
            Console.Write("Do you want play again? ");
        } while ("yes" == Console.ReadLine().ToLower());
    }
}