using System;
using System.Collections.Generic;

namespace SchoolSystem
{
    class Building
    {
        public string Location { get; set; }

        public int ClassroomCount { get; set; }

        public int FloorCount { get; set; }

        public Building(string aLocation, int aClassroomCount, int aFloorCount)
        {
            this.Location = aLocation;
            this.ClassroomCount = aClassroomCount;
            this.FloorCount = aFloorCount;
        }
    }
}
