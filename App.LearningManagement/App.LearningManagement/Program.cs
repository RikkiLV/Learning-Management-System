using System;
using App.LearningManagement.Helpers;
using Library.LearningManagement.Models;
using Library.LearningManagement.Services;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentSrvc = new StudentService();
            var studentHelper = new StudentHelper(studentSrvc);
            var courseHelper = new CourseHelper(studentSrvc);

            bool cont = true;
            var input = "1";
            while (cont)
            {
                Console.WriteLine("Choose an Action:");
                Console.WriteLine("1. Add a student enrollment");
                Console.WriteLine("2. Update a student enrollment");
                Console.WriteLine("3. List all enrolled students");
                Console.WriteLine("4. Search for a student");
                Console.WriteLine("5. Add a new course");
                Console.WriteLine("6. Update a course");
                Console.WriteLine("7. List all course");
                Console.WriteLine("8. Search course");
                Console.WriteLine("9. Exit");
                input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result == 1) studentHelper.AddOrUpdateStudent();
                    else if (result == 2) studentHelper.UpdateStudentRecord();
                    else if (result == 3) studentHelper.ListStudents();
                    else if (result == 4) studentHelper.SearchStudent();
                    else if (result == 5) courseHelper.AddOrUpdateCourse();
                    else if (result == 6) courseHelper.UpdateCourseRecord();
                    else if (result == 7) courseHelper.ListCourse();
                    else if (result == 8) courseHelper.SearchCourse();
                    else if (result == 9) cont = false;

                }
            }

        }

      
    }
}