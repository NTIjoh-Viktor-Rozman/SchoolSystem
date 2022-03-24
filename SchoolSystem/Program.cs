using System;
using System.Linq;

namespace SchoolSystem
{
    class Program
    {
        //Main function

        static void Main(string[] args)
        {
            // Rules to Follow

            Console.WriteLine("Rules to follow: \n - If there is a list of obtions to choose from pick the option by typing the number that is stated infront of it. \n - If there is a \"Yes or No\" question then 1 == Yes and 2 == No");
            Console.WriteLine("\nPress Enter to Start");
            Console.ReadKey();

            // School System Main Function

            // Creating a Principal

            Console.WriteLine("\n--------------------------------------------------------\n");

            Console.WriteLine("Welcome To Your New School Principal!");

            Console.WriteLine("Enter your Name to register : ");
            string aName = Console.ReadLine();
            Console.WriteLine("Enter your Age and your registration will be complete : ");
            int aAge = int.Parse(Console.ReadLine());

            // Calls the create funcion in the class Principal to create a new Principal with the variable name PrincipalA
            Principal PrincipalA = new Principal(aName, aAge);

            Console.WriteLine("\n--------------------------------------------------------\n");

            // Creating the School 

            Console.WriteLine("What do you wish for your school to be called? ");
            aName = Console.ReadLine();
            Console.WriteLine("What type of School is it you are running? ");
            string aSchoolType = Console.ReadLine();

            // Calls the create function in the class School to create the new school with the variable name SchoolA
            School SchoolA = new School(aName, aSchoolType);
            SchoolA.Principals.Add(PrincipalA);
            
            // Main Code Loop 
            // Asking what you wish to do in the School
            // Everything will originate from here

            bool SchoolIsOpen = true;

            while (SchoolIsOpen == true)
            {
                // Shows all the options available for the user fomr 1 to 7
                Console.WriteLine("\n--------------------------------------------------------\n");
                Console.WriteLine("What do you wish to do : \n 1. Student Interaction Menu \n 2. Teacher Interaction Menu \n 3. Course Interaction Menu \n 4. Building Interaction Menu (NOT DONE!) \n 5. Janitor Interaction Menu (NOT DONE!) \n 6. School Statistics \n 7. Close School ");
                int UserAnswer = int.Parse(Console.ReadLine());

                // Switch statement to go to the correct place selected by the user
                // Sending SchoolA as a class through for further use later
                switch (UserAnswer)
                {
                    case 1:
                        StudentIM(SchoolA);
                        break;
                    case 2:
                        TeacherIM(SchoolA);
                        break;
                    case 3:
                        CourseIM(SchoolA);
                        break;
                    case 4:
                        Console.WriteLine("Not Done (-.-)");
                        break;
                    case 5:
                        Console.WriteLine("Not Done \\ (>U<) /");
                        break;
                    case 6:
                        SSM(SchoolA);
                        break;
                    case 7:
                        Console.WriteLine("\nYou have closed the school forever. Hope you find a new Job :)");
                        SchoolIsOpen = false;
                        break;
                    default:
                        Console.WriteLine("\nThat is not an option, try again");
                        break;
                }
            }
        }

        // ---------------------------------------------
        // Student Interaction Menu
        // ---------------------------------------------

        public static void StudentIM(School SchoolA)
        {
            // Asking what the User wants to do with the student
            Console.WriteLine("\nWhat do you want to do with the Students? \n 1. Create New Student \n 2. Interact With Existing Student");
            int UserAnswer = int.Parse(Console.ReadLine());
            bool Continue = true;

            switch (UserAnswer)
            {
                // Case 1 Creating a New Student
                case 1:
                    while (Continue == true)
                    {
                        // Asking the User for all of the Data required to create a New Student
                        Console.WriteLine("\nYou are now Creating a New Student: \nWrite the following in the Specific order and press \"Enter\" inbetween every input. \n 1. Name (String)   2. Age (Int)   3. Grade (String A - F)");
                        string aName = Console.ReadLine();
                        int aAge = int.Parse(Console.ReadLine());
                        string aGrade = Console.ReadLine();
                        aGrade = aGrade.ToUpper();

                        // Checking if everything is correct and if not will redo
                        Console.WriteLine($"\nIs the following information correct? \n Name == {aName} \n Age = {aAge} \n Grade == {aGrade} \n -- Answer with 1 or 2 -- ");
                        UserAnswer = int.Parse(Console.ReadLine());
                        if (UserAnswer == 1) { CreateNewStudent(aName, aAge, aGrade, SchoolA); Continue = false; }
                    }
                    Console.WriteLine("\n--------------------------------------------------------\n");
                    break;

                // Case 2 Interacting with already existing Student
                case 2:
                    // Printing out a list of all the Students that are in the SchoolA.Students List so User can choose one
                    int TemporaryVar = 0;
                    Console.WriteLine("\nWhat Student would you like to access?");
                    foreach (var item in SchoolA.Students)
                    {
                        Console.WriteLine($" {TemporaryVar + 1}. {SchoolA.Students[TemporaryVar].Name}");
                        TemporaryVar++;
                    }

                    // Asking the User what Student they want to access
                    UserAnswer = int.Parse(Console.ReadLine());
                    StudentSecondIM(UserAnswer, SchoolA);
                    break;
                default:
                    Console.WriteLine("Not a possible option");
                    break;
            }
        }

        // Creating New Student Method. Called to Everytime we create a New Student 
        public static void CreateNewStudent(string aName, int aAge, string aGrade, School SchoolA)
        {
            Student StudentA = new Student(aName, aAge, aGrade);
            SchoolA.Students.Add(StudentA);
            Console.WriteLine($"\nYour Student {StudentA.Name} has now been Created and added to the System!");
            
        }

        // Student Second Interactive Menu, Used when case 2 is choosen in StudentIM to interact with a Student
        public static void StudentSecondIM(int aId, School SchoolA)
        {
            var SelectedStudent = SchoolA.Students.FirstOrDefault(Student => Student.StudentId == aId);

            Console.WriteLine($"\nWhat do you wish to do with {SelectedStudent.Name}? \n 1. Study For Exam");
            int UserAnswer = int.Parse(Console.ReadLine());

            int TemporaryVar = 1;
            switch (UserAnswer)
            {
                // Student Study For Exam
                case 1:
                    Console.WriteLine($"\nWhat course do you want to Study for?");
                    foreach (Course course in SchoolA.Courses) { Console.WriteLine($"{TemporaryVar} {course.CourseName}"); TemporaryVar++; }
                    UserAnswer = int.Parse(Console.ReadLine());
                    var SelectedCourse = SchoolA.Courses.FirstOrDefault(Course => Course.CourseId == UserAnswer);
                    SelectedStudent.StudyForExam(SelectedCourse);
                    break;
                default:
                    Console.WriteLine("Error, no such option");
                    break;
            }
        }

        // ---------------------------------------------
        // Teacher Interaction Menu
        // ---------------------------------------------

        public static void TeacherIM(School SchoolA)
        {
            // Asking what the User wants to do with the teacher
            Console.WriteLine("\nWhat do you want to do with the Teachers? \n 1. Create New Teacher \n 2. Interact With Existing Teacher");
            int UserAnswer = int.Parse(Console.ReadLine());
            bool Continue = true;

            switch (UserAnswer)
            {
                // Case 1 creating a New Teacher
                case 1:
                    while (Continue == true)
                    {
                        // Asking the User for all of the Data required to create a New Teacher
                        Console.WriteLine("\nYou are now Creating a New Teacher: \nWrite the following in the Specific order and press \"Enter\" inbetween every input. \n 1. Name (String)   2. Age (Int)");
                        string aName = Console.ReadLine();
                        int aAge = int.Parse(Console.ReadLine());

                        // Checking if everything is correct and if not will redo
                        Console.WriteLine($"\nIs the following information correct? \n Name == {aName} \n Age = {aAge} \n -- Answer with 1 or 2 -- ");
                        UserAnswer = int.Parse(Console.ReadLine());
                        if (UserAnswer == 1) { CreateNewTeacher(aName, aAge, SchoolA); Continue = false; }
                    }
                    Console.WriteLine("\n--------------------------------------------------------\n");
                    break;

                // Case 2 Interacting with already existing Teacher
                case 2:
                    // Printing out a list of all the Teachers that are in the SchoolA.Teachers List so User can choose one
                    int TemporaryVar = 0;
                    Console.WriteLine("\nWhat Teacher would you like to access?");
                    foreach (var item in SchoolA.Teachers)
                    {
                        Console.WriteLine($" {TemporaryVar + 1} {SchoolA.Teachers[TemporaryVar].Name}");
                        TemporaryVar++;
                    }

                    // Asking the User what Teacher they want to access
                    UserAnswer = int.Parse(Console.ReadLine());
                    TeacherSecondIM(UserAnswer, SchoolA);
                    break;
                default:
                    Console.WriteLine("Not a possible option");
                    break;
            }
        }

        // Creating a New Teacher. Called everytime a New Teacher is created
        public static void CreateNewTeacher(string aName, int aAge, School SchoolA)
        {
            Teacher TeacherA = new Teacher(aName, aAge);
            SchoolA.Teachers.Add(TeacherA);
            Console.WriteLine($"\nYour Student {TeacherA.Name} has now been Created and added to the System!");
        }

        // Teacher Second Interactive Menu, Used when case 2 is choosen in TeacherIM to interact with a Teacher
        public static void TeacherSecondIM(int aId, School SchoolA)
        {
            var SelectedTeacher = SchoolA.Teachers.FirstOrDefault(Teacher => Teacher.TeacherId == aId);

            Console.WriteLine($"\nWhat would you like to do with {SelectedTeacher.Name}? \n 1. Grade a Student ");
            int UserAnswer = int.Parse(Console.ReadLine());

            int TemporaryVar = 1;
            switch (UserAnswer)
            {
                case 1:
                    Console.WriteLine("\nWhat Student do you want to Grade?");
                    foreach(Student student in SchoolA.Students) { Console.WriteLine($"{TemporaryVar} {student.Name}"); TemporaryVar++; }
                    UserAnswer = int.Parse(Console.ReadLine());
                    var SelectedStudent = SchoolA.Students.FirstOrDefault(Student => Student.StudentId == UserAnswer);
                    SelectedTeacher.GradeStudent(SelectedStudent);
                    break;
                default:
                    Console.WriteLine("Error, no such option");
                    break;
            }
        }

        // ---------------------------------------------
        // Course Interaction Menu
        // ---------------------------------------------

        public static void CourseIM(School SchoolA)
        {
            // Asking what the User wants to do with the course
            Console.WriteLine("\nWhat do you want to do with the Crourses? \n 1. Create New Course \n 2. Interact With Existing Course ( Nothing to do )");
            int UserAnswer = int.Parse(Console.ReadLine());
            bool Continue = true;

            switch (UserAnswer)
            {
                // Case 1 creating a New Course
                case 1:
                    while (Continue == true)
                    {
                        // Asking the User for all of the Data required to create a New Course
                        Console.WriteLine("\nYou are now Creating a New Course: \nWrite the following in the Specific order and press \"Enter\" inbetween every input. \n 1. Name (String)   2. CoursePoints (Int)");
                        string aName = Console.ReadLine();
                        int aCoursePoints = int.Parse(Console.ReadLine());

                        // Checking if everything is correct and if not will redo
                        Console.WriteLine($"\nIs the following information correct? \n Name == {aName} \n CoursePoints = {aCoursePoints} \n -- Answer with 1 or 2 -- ");
                        UserAnswer = int.Parse(Console.ReadLine());
                        if (UserAnswer == 1) { CreateNewCourse(aName, aCoursePoints, SchoolA); Continue = false; }
                    }
                    Console.WriteLine("\n--------------------------------------------------------\n");
                    break;

                // Case 2 to interact with already excisting Course
                case 2:
                    int TemporaryVar = 0;
                    Console.WriteLine("\nWhat Course would you like to access?");
                    foreach (var item in SchoolA.Courses)
                    {
                        Console.WriteLine($" {TemporaryVar + 1} {SchoolA.Courses[TemporaryVar].CourseName}");
                        TemporaryVar++;
                    }

                    // Asking the User what Student they want to access
                    UserAnswer = int.Parse(Console.ReadLine());
                    CourseSecondIM(UserAnswer, SchoolA);
                    break;
                default:
                    Console.WriteLine("Not a possible option");
                    break;
            }
        }

        // Creating a New Course. Called everytime a New Course is created
        public static void CreateNewCourse(string aName, int aCP, School SchoolA)
        {
            Course CourseA = new Course(aName, aCP);
            SchoolA.Courses.Add(CourseA);
            Console.WriteLine($"\nYour Student {CourseA.CourseName} has now been Created and added to the System!");
        }

        // Course Second Interaction Menu. Used when interacting with a course.
        public static void CourseSecondIM(int aId, School SchoolA)
        {
            var SelectedCourse = SchoolA.Courses.FirstOrDefault(Course => Course.CourseId == aId);
            Console.WriteLine($"\nCourse Selected : {SelectedCourse.CourseName}");
        }

        // ---------------------------------------------
        // School Statistics Menu
        // ---------------------------------------------

        // SSM = School Statistics Menu. Shows Statistics of your school
        // Statistics = School Name, Principal Name, Number of Students, Number of Teachers, Number of Courses.

        public static void SSM(School SchoolA)
        {
            // Writing all the statistics to the Console by Counting the lenght of all the lists and by accessing the principal name using Linq
            Console.WriteLine("\nSchool Statistics:\n");
            var SelectedPrincipal = SchoolA.Principals.FirstOrDefault(Principal => Principal.PrincipalId == 1);
            Console.WriteLine($"Principal Name : {SelectedPrincipal.Name}");
            var SelectedSchoolName = SchoolA.SchoolName;
            Console.WriteLine($"School Name : {SelectedSchoolName}");
            var NumberOfStudents = SchoolA.Students.Count();
            Console.WriteLine($"Number of Students : {NumberOfStudents}");
            var NumberOfTeachers = SchoolA.Teachers.Count();
            Console.WriteLine($"Number of Teachers : {NumberOfTeachers}");
            var NumberOfCourses = SchoolA.Courses.Count();
            Console.WriteLine($"Number of Courses : {NumberOfCourses}");
        }
    }
}
