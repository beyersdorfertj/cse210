using System;

class Program {
    static void Main(string[] args) {
        List<int> list = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int input;
        do {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0) {
                list.Add(input);
            }
        } while (input != 0);

        int sum = 0;
        int? max = null;
        int smallestPositive = -1;

        foreach (int i in list) {
            sum += i;
            if (max == null || i>max) {
                max=i;
            }
            if (i>0 && (i<smallestPositive || smallestPositive<0)) {
                smallestPositive = i;
            }
            Console.WriteLine($"{i}, {sum}, {max}, {smallestPositive}");
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {(float)sum/list.Count}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        list.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int i in list) {
            Console.WriteLine(i);
        }
    }
}