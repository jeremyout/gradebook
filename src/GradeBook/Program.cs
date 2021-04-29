using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Jeremy's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);
            // Run the calculations
            var result = book.GetStatistics();
            // Console.WriteLine(Book.CATEGORY);

            // Write the highest grade to the console
            System.Console.WriteLine($"The highest score is: {result.HighGrade:N1}");
            // Write the lowest grade to the console
            System.Console.WriteLine($"The lowest score is: {result.LowGrade:N1}");
            // Write the average to the console
            System.Console.WriteLine($"The average score is: {result.Average:N1}");
            // Write the average letter grade to the console
            System.Console.WriteLine($"The average letter grade is is: {result.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
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
                    try
                    {
                        grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("**");
                    }
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
