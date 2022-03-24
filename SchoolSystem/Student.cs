using System;
using System.Collections.Generic;

namespace SchoolSystem
{
    class Student : Person 
    {
        public static int Id { get; set; } = 0;

        public int StudentId { get; set; }

        public string StudentGrade { get; set; }

        List<Course> StudentCourses { get; set; } = new List<Course>();

        public Student(string aName, int aAge, string aGrade)
        {
            Id++;
            this.StudentId = Id;
            this.Name = aName;
            this.Age = aAge;
            this.StudentGrade = aGrade;
        }

        public void StudyForExam(Course courseObj)
        {
            courseObj.StudentStudyForExam(this);
        }

        public void StudentGradingSystem(Teacher TeacherObj)
        {
            Random rng = new Random();
            int GradeDiff = rng.Next(-1,2);
            string OldStudentGrade = StudentGrade;

            switch (StudentGrade)
            {
                case "A":
                    StudentGrade = ChangeGradeCalculator(GradeDiff, 0);
                    break;
                case "B":
                    StudentGrade = ChangeGradeCalculator(GradeDiff, 1);
                    break;
                case "C":
                    StudentGrade = ChangeGradeCalculator(GradeDiff, 2);
                    break;
                case "D":
                    StudentGrade = ChangeGradeCalculator(GradeDiff, 3);
                    break;
                case "E":
                    StudentGrade = ChangeGradeCalculator(GradeDiff, 4);
                    break;
                case "F":
                    StudentGrade = ChangeGradeCalculator(GradeDiff, 5);
                    break;
                default:
                    Console.WriteLine("Something has gone wrong when trying to change the grade of a student, Check for big characters in the Grade or that the grade is from A to F");
                    break;
            }
            Console.WriteLine($"The Teacher {TeacherObj.Name} has changed Student {Name}'s grade from {OldStudentGrade} to {StudentGrade}.");
        }

        public string ChangeGradeCalculator(int GradeDiff, int CurrentGrade)
        {
            string[] Grades = { "A", "B", "C", "D", "E", "F" };
            string NewGrade = Grades[CurrentGrade + GradeDiff];
            return NewGrade;
        }
    }
}
