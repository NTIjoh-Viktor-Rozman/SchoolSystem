using System;

namespace SchoolSystem
{
    class Classroom
    {
        public string ClassroomNumber { get; set; }

        public int NumberOfChairs { get; set; }

        public bool HasProjector { get; set; }

        public bool ClassroomCleaned { get; set; }

        public Classroom(string aName, int aChairs, bool aProj, bool aClean)
        {
            this.ClassroomNumber = aName;
            this.NumberOfChairs = aChairs;
            this.HasProjector = aProj;
            this.ClassroomCleaned = aClean;
        }

        public void JanitorCleanClassroom(Janitor JanitorObj)
        {
            Console.WriteLine($"{JanitorObj.Name} has cleaned classroom {ClassroomNumber}");
            this.ClassroomCleaned = true;
        }
    }
}
