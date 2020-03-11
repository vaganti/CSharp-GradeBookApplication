using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            return 'F';
        }

        public double ClassAverage()
        {
            double average = 0;
            foreach (Student student in this.Students)
                average += student.AverageGrade;
            return average / Students.Count;
        }
    }
}
