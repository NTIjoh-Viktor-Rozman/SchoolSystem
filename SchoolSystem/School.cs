using System;
using System.Collections.Generic;


namespace SchoolSystem
{
    class School
    {
        public string SchoolName { get; set; }

        public string SchoolType { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public List<Janitor> Janitors { get; set; } = new List<Janitor>();

        public List<Principal> Principals { get; set; } = new List<Principal>();

        public List<Course> Courses { get; set; } = new List<Course>();


        public School(string aName, string aSchoolType)
        {
            this.SchoolName = aName;
            this.SchoolType = aSchoolType;
        }
    }
}
