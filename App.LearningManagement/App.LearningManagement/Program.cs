using System;
using App.LearningManagement.Helpers;
using Library.LearningManagement.Models;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentHelper = new StudentHelper();
            var courseHelper = new CourseHelper();

            bool cont = true;
            var input = "1";
            while (cont)
            {
                Console.WriteLine("Choose an Action:");
                Console.WriteLine("1. Add a student enrollment");
                Console.WriteLine("2. Update a student enrollment");
                Console.WriteLine("3. Search for a student");
                Console.WriteLine("4. List all enrolled students");
                Console.WriteLine("5. Add a new course");
                Console.WriteLine("6. List all course");
                Console.WriteLine("7. Exit");
                input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result == 1) studentHelper.AddOrUpdateStudent();
                    else if (result == 2) studentHelper.UpdateStudentRecord();
                    else if (result == 3) studentHelper.SearchStudent();
                    else if (result == 4) studentHelper.ListStudents();
                    else if (result == 5) courseHelper.CreateCourseRecord();
                    else if (result == 6) courseHelper.ListCourse();
                    else if (result == 7) cont = false;

                }
            }

        }

      
    }
}