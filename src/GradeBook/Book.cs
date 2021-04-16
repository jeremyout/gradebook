using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
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

        public void FindHighGrade()
        {
            foreach(var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
            }
        }

        public void FindLowGrade()
        {
            foreach(var number in grades)
            {
                lowGrade = Math.Min(number, lowGrade);
            }
        }

        public void FindAverageGrade()
        {
            var result = 0.0;
            foreach(var number in grades)
            {
                result += number;
            }
            average = result/grades.Count;
        }

        private void ComputeStatistics()
        {
            FindHighGrade();
            FindLowGrade();
            FindAverageGrade();
        }

        public void ShowStatistics()
        {   
            // Run the calculations
            ComputeStatistics();

            // Write the highest grade to the console
            System.Console.WriteLine($"The highest score is: {highGrade:N1}");
            // Write the lowest grade to the console
            System.Console.WriteLine($"The lowest score is: {lowGrade:N1}");
            // Write the average to the console
            System.Console.WriteLine($"The average score is: {average:N1}");
        }

        private List<double> grades;
        private string name;
        private double average = 0.0;
        private double highGrade = double.MinValue;
        private double lowGrade = double.MaxValue;
    }
}