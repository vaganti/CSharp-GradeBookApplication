﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            
            List<Student> LocalStudents = new List<Student>(Students);
            LocalStudents.Sort();
            int index = LocalStudents.FindLastIndex(
                delegate(Student student)
                {
                    return student.AverageGrade > averageGrade;
                });
            int percent = (int) Math.Round( (decimal) (100 * (index + 2) / LocalStudents.Count));

            switch (percent)
            {
                case int i when i <= 20:
                    return 'A';
                case int i when i <= 40:
                    return 'B';
                case int i when i <= 60:
                    return 'C';
                case int i when i <= 80:
                    return 'D';
                default:
                    return 'F';
            }
        }

        public double ClassAverage()
        {
            double average = 0;
            foreach (Student student in this.Students)
                average += student.AverageGrade;
            return average / Students.Count;
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
    }
}
