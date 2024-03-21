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
            var studentHelper = new StudentHelper();
            var courseHelper = new CourseHelper();

            bool cont = true;
            var input = "1";
            while (cont)
            {
                Console.WriteLine("1. Maintain Students");
                Console.WriteLine("2. Maintain Courses");
                Console.WriteLine("3. Exit");

                input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result == 1) ShowStudentMenu(studentHelper);
                    else if (result == 2) ShowCourseMenu(courseHelper);
                    else if (result == 3) cont = false;

                }
            }

        }

        static void ShowStudentMenu(StudentHelper studentHelper)
        {
            // Students
            Console.WriteLine("Choose an Action:");
            Console.WriteLine("1. Add a student enrollment");
            Console.WriteLine("2. Update a student enrollment");
            Console.WriteLine("3. List all enrolled students");
            Console.WriteLine("4. Search for a student");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {

                if (result == 1) studentHelper.AddOrUpdateStudent();
                else if (result == 2) studentHelper.UpdateStudentRecord();
                else if (result == 3) studentHelper.ListStudents();
                else if (result == 4) studentHelper.SearchStudent();
            }
        }

        static void ShowCourseMenu(CourseHelper courseHelper) 
        {
            // Courses
            Console.WriteLine("1. Add a new course");
            Console.WriteLine("2. Update a course");
            Console.WriteLine("3. List all course");
            Console.WriteLine("4. Search course");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {

                if (result == 1) courseHelper.AddOrUpdateCourse();
                else if (result == 2) courseHelper.UpdateCourseRecord();
                else if (result == 3)
                {
                    courseHelper.SearchCourse();
                }
                else if (result == 4)
                {
                    Console.WriteLine("Enter a query:");
                    var query = Console.ReadLine() ?? string.Empty;
                    courseHelper.SearchCourse(query);
                }
            }
      }
    }
}