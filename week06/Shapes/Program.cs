using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Circle("Blue", 10));
        shapes.Add(new Rectangle("Green", 4, 6));
        shapes.Add(new Square("Red", 5));
        foreach (var shape in shapes) {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
        }
    }
}