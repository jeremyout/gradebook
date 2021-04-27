using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Jeremy's Grade Book");
            var grade = 0.0;
            var done = false;
            while (!done)
            {
                Console.WriteLine("Enter a grade or enter 'q' to quit:");
                var input = Console.ReadLine();
                if (input.Equals("q") || input.Equals("Q"))
                {
                    done = true;
                }
                else
                {
                    grade = double.Parse(input);
                    book.AddGrade(grade);
                }

            }
            book.ShowStatistics();
        }
    }
}
