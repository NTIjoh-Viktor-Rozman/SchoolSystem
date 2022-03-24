using System;
using System.Collections.Generic;

namespace SchoolSystem
{
    class Teacher : Person
    {
        public static int Id { get; set; } = 0;

        public int TeacherId { get; set; }

        public List<Course> TeacherCourses { get; set; } = new List<Course>();

        public Teacher(string aName, int aAge)
        {
            Id++;
            this.TeacherId = Id;
            this.Name = aName;
            this.Age = aAge;   
        }

        public void GradeStudent(Student StudentObj)
        {
            StudentObj.StudentGradingSystem(this);

        }
    }
}
