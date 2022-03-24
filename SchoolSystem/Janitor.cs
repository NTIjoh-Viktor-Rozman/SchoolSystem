using System;
using System.Collections.Generic;

namespace SchoolSystem
{
    class Janitor : Person
    {
        public static int Id { get; set; } = 0;

        public int JanitorId { get; set; }

        public Janitor(string aName, int aAge)
        {
            Id++;
            this.JanitorId = Id;
            this.Name = aName;
            this.Age = aAge;       
        }

        public void CleanClassroom(Classroom ClassroomObj)
        {
            ClassroomObj.JanitorCleanClassroom(this);
        }
    }
}
