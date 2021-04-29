using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics ComputeStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual Statistics ComputeStatistics()
        {
            throw new NotImplementedException();
        }
    }

    public class InMemoryBook : Book
    {
        // Constructor
        public InMemoryBook(string name) : base(name)
        {
            // category = "";
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

        public override void AddGrade(double grade)
        {
            if (grade >= 0 
                && grade <= 100)
            {
                grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

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

        public override Statistics ComputeStatistics()
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

        private List<double> grades;

        // readonly string category = "Science";
        // public const string CATEGORY = "Math";
    }
}