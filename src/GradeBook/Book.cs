using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        // Constructor
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public double FindHighGrade()
        {
            var highGrade = double.MinValue;
            foreach(var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
            }
            return highGrade;
        }

        public double FindLowGrade()
        {
            var lowGrade = double.MaxValue;
            foreach(var number in grades)
            {
                lowGrade = Math.Min(number, lowGrade);
            }
            return lowGrade;
        }

        public double FindAverageGrade()
        {
            var average = 0.0;
            var result = 0.0;
            foreach(var number in grades)
            {
                result += number;
            }
            average = result/grades.Count;

            return average;
        }

        private Statistics ComputeStatistics()
        {
            var Stats = new Statistics();
            Stats.HighGrade = double.MinValue;
            Stats.LowGrade = double.MaxValue;
            Stats.Average = 0.0;


            Stats.HighGrade = FindHighGrade();
            Stats.LowGrade = FindLowGrade();
            Stats.Average = FindAverageGrade();

            return Stats;
        }

        public void ShowStatistics()
        {   
            // Run the calculations
            var result = ComputeStatistics();

            // Write the highest grade to the console
            System.Console.WriteLine($"The highest score is: {result.HighGrade:N1}");
            // Write the lowest grade to the console
            System.Console.WriteLine($"The lowest score is: {result.LowGrade:N1}");
            // Write the average to the console
            System.Console.WriteLine($"The average score is: {result.Average:N1}");
        }

        private List<double> grades;
        private string name;
    }
}