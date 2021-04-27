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
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90.0);
                    break;
                case 'B':
                    AddGrade(80.0);
                    break;
                case 'C':
                    AddGrade(70.0);
                    break;
                case 'D':
                    AddGrade(60.0);
                    break;
                default:
                    AddGrade(0.0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade >= 0 
                && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
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

        public char FindLetterGrade()
        {
            var letterGrade = 'F';
            var gradeStats = new Statistics();
            gradeStats.Average = FindAverageGrade();

            switch(gradeStats.Average)
            {
                case var d when d >= 90.0:
                    letterGrade = 'A';
                    break;
                case var d when d >= 80.0:
                    letterGrade = 'B';
                    break;
                case var d when d >= 70.0:
                    letterGrade = 'C';
                    break;
                case var d when d >= 60.0:
                    letterGrade = 'D';
                    break;
                default:
                    letterGrade = 'F';
                    break;
            }

            return letterGrade;
        }

        public Statistics ComputeStatistics()
        {
            var Stats = new Statistics();
            Stats.HighGrade = double.MinValue;
            Stats.LowGrade = double.MaxValue;
            Stats.Average = 0.0;
            Stats.Letter = 'F';


            Stats.HighGrade = FindHighGrade();
            Stats.LowGrade = FindLowGrade();
            Stats.Average = FindAverageGrade();
            Stats.Letter = FindLetterGrade();

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
            // Write the average letter grade to the console
            System.Console.WriteLine($"The average letter grade is is: {result.Letter}");
        }

        private List<double> grades;
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }

            }
        }
        
            
        private string name;
    }
}