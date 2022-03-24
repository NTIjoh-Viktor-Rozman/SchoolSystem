using System;
using System.Collections.Generic;

namespace SchoolSystem
{
    class Course
    {
        public static int Id { get; set; } = 0;

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int CoursePoints { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public Course(string aName, int aPoints)
        {
            Id++;
            this.CourseId = Id;
            this.CourseName = aName;
            this.CoursePoints = aPoints;
        }

        public void StudentStudyForExam(Student studentObj)
        {
            string OldStudentGrade = studentObj.StudentGrade;
            int TemporaryVar = 0;

            switch (studentObj.StudentGrade)
            {
                case "A":
                    TemporaryVar = 1;
                    break;
                case "B":
                    studentObj.StudentGrade = "A";
                    break;
                case "C":
                    studentObj.StudentGrade = "B";
                    break;
                case "D":
                    studentObj.StudentGrade = "C";
                    break;
                case "E":
                    studentObj.StudentGrade = "D";
                    break;
                case "F":
                    studentObj.StudentGrade = "E";
                    break;
                default:
                    Console.WriteLine("Something has gone wrong when trying to change the grade of a student, Check for big characters in the Grade");
                    break;
            }
            switch (TemporaryVar)
            {
                case 0:
                    Console.WriteLine($"The Student {studentObj.Name} has studied for the Exam in {CourseName} and has upped their grade from {OldStudentGrade} to {studentObj.StudentGrade}");
                    break;
                case 1:
                    Console.WriteLine($"{studentObj.Name} already has an A and will therefor keep this grade");
                    break;
            }
        }
    }
}
