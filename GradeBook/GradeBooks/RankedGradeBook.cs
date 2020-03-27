using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var grades = new List<double>();

            foreach (var student in Students)
            {
                grades.Add(student.AverageGrade);
            }

            grades.Add(averageGrade);
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
