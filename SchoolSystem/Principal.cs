using System;
using System.Collections.Generic;

namespace SchoolSystem
{
    class Principal : Person
    {
        public static int Id { get; set; } = 0;

        public int PrincipalId { get; set; }

        public Principal(string aName, int aAge)
        {
            Id++;
            this.PrincipalId = Id;
            this.Name = aName;
            this.Age = aAge;
        }

        //public void HireTeacher(string aName)
        //{
        //    Teacher Teacher1 = new Teacher(aName);
        //}
    }
}
