using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World! This is the Fractions Project.");
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(3);
        Fraction fraction3 = new Fraction(2, 5);
        Console.WriteLine($"Fraction 1: {fraction1._top}/{fraction1._bottom}");
        Console.WriteLine($"Fraction 2: {fraction2._top}/{fraction2._bottom}");
        Console.WriteLine($"Fraction 3: {fraction3._top}/{fraction3._bottom}");

        fraction1.SetTop(4);
        fraction1.SetBottom(8);
        Console.WriteLine($"Updated Fraction 1: {fraction1.GetTop()}/{fraction1.GetBottom()}");
        Console.WriteLine($"Fraction 1 as string: {fraction1.GetFrationString()}");
        Console.WriteLine($"Fraction 1 as decimal: {fraction1.GetDecimalValue()}");
    }
}