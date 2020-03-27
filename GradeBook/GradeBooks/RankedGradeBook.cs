using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var grades = new List<double>();
            grades.Add(averageGrade);

            foreach (var student in Students)
            {
                grades.Add(student.AverageGrade);
            }

            grades.Sort();
            int position = grades.IndexOf(averageGrade) % 5;

            switch (position)
            {
                case 4:
                    return 'A';
                case 3:
                    return 'B';
                case 2:
                    return 'C';
                case 1:
                    return 'D';
                default:
                    return 'F';
            }
        }
    }
}
