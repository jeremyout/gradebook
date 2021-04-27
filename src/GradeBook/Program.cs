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
                    try
                    {
                        grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("**");
                    }
                }

            }
            book.ShowStatistics();
            Console.WriteLine(Book.CATEGORY);
        }
    }
}
