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
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Error less than 5 students");
            }

            int studentsPerGradeBucket = (int)Math.Floor(Students.Count * 0.2);
            int studentsThatPerformedBetter = 0;
            foreach(Student student in Students)
            {
                if(student.AverageGrade > averageGrade)
                {
                    studentsThatPerformedBetter += 1;
                }
            }
            
            if(studentsPerGradeBucket > studentsThatPerformedBetter)
            {
                return 'A';
            }
            else if (studentsPerGradeBucket * 2 > studentsThatPerformedBetter)
            {
                return 'B';
            }
            else if (studentsPerGradeBucket * 3 > studentsThatPerformedBetter)
            {
                return 'C';
            }
            else if (studentsPerGradeBucket * 4 > studentsThatPerformedBetter)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
