using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        
        int grade = int.Parse(Console.ReadLine());

        string letterGrade = "";
        string sign = "";

        if (grade >= 90)
        {
            letterGrade = "A";
            sign = grade >= 97 ? "+" : "-";
        } 
        else if (grade >= 80)
        {
            letterGrade = "B";
            sign = grade >= 87 ? "+" : (grade < 83 ? "-" : "");
        } 
        else if (grade >= 70)
        {
            letterGrade = "C";
            sign = grade >= 77 ? "+" : (grade < 73 ? "-" : "");
        } 
        else if (grade >= 60)
        {
            letterGrade = "D";
            sign = grade >= 67 ? "+" : (grade < 63 ? "-" : "");
        } 
        else
        {
            letterGrade = "F";
            sign = "";
        } 
        Console.WriteLine($"Your letter grade is: {letterGrade}{sign}");

        if (grade >= 70)
        {
        Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
        Console.WriteLine("Better luck next time. Keep studying!");
        }
    }
}