using System;

class Program {
    static void Main(string[] args) {
        Console.Write("What is your grade percentage? ");
        int percentage = int.Parse(Console.ReadLine());

        string grade = "";
        if (percentage >= 90) {
            grade = "A";
        } else if (percentage >= 80) {
            grade = "B";
        } else if (percentage >= 70) {
            grade = "C";
        } else if (percentage >= 60) {
            grade = "D";
        } else {
            grade = "F";
        }

        if (percentage >= 60 && percentage <= 93) {
            int modula = percentage % 10;
            if (modula <=3) {
                grade += "-";
            }
            if (modula >=7) {
                grade += "+";
            }
        }

        Console.WriteLine($"\nYour grade is {grade}.");
        if (percentage < 70) {
            Console.WriteLine("You failed to pass as you need a grade of C- at least. Please continue to improve and try again.");
        } else {
            Console.WriteLine("Congratulations. You have passed!!!");
        }
    }
}