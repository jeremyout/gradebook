using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Jeremy's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var grades = new List<double>() {12.7, 34.7, 12.4, 6.5};
            grades.Add(56.1);

            // Calculate the sum of all elements in the grades list
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach(var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade); 
                result += number;
            }

            // Compute the average
            var average = result/grades.Count;
            // Write the average to the console
            System.Console.WriteLine($"The average score is: {average:N1}");
            // Write the highest grade to the console
            System.Console.WriteLine($"The highest score is: {highGrade:N1}");
            // Write the lowest grade to the console
            System.Console.WriteLine($"The lowest score is: {lowGrade:N1}");
        }
    }
}
