using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            book.AddGrade(89.1);

            var grades = new List<double>() {12.7, 34.7, 12.4, 6.5};
            grades.Add(56.1);

            // Calculate the sum of all elements in the grades list
            var result = 0.0;
            foreach(var number in grades)
            {
                result += number;
            }
            Console.WriteLine($"The sum of scores is: {result:N1}");

            // Compute the average
            var average = result/grades.Count;
            System.Console.WriteLine($"The average score is: {average:N1}");

        }
    }
}
