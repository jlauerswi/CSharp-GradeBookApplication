using System;
using System.Collections.Generic;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted) {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            if (this.Students.Count < 5) {
                throw new InvalidOperationException();
            }

            List<Student> allStudents = this.Students;
            List<double> studentsGrades = new List<double>();
            foreach(var student in allStudents) {
                studentsGrades.Add(student.AverageGrade);
            }
            // Sorts descending
            studentsGrades.Sort((a, b) => -1*a.CompareTo(b));

            int threshold = (int) Math.Ceiling(allStudents.Count * 0.2);
            if (averageGrade >= studentsGrades[threshold - 1]) {
                return 'A';
            } else if (averageGrade >= studentsGrades[(threshold*2) - 1]) {
                return 'B';
            } else if (averageGrade >= studentsGrades[(threshold*3) - 1]) {
                return 'C';
            } else if (averageGrade >= studentsGrades[(threshold*4) - 1]) {
                return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics() {
            if (this.Students.Count < 5) {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name) {
            if (this.Students.Count < 5) {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}