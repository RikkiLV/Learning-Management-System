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
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Add a new person");
            Console.WriteLine("2. Update a person");
            Console.WriteLine("3. List all people");
            Console.WriteLine("4. Search for a person");
   

            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    studentHelper.CreateStudentRecord();
                }
                else if (result == 2)
                {
                    studentHelper.UpdateStudentRecord();
                }
                else if (result == 3)
                {
                    studentHelper.ListStudents();
                }
                else if (result == 4)
                {
                    studentHelper.SearchStudents();
                }
                
            }
        }

        static void ShowCourseMenu(CourseHelper courseHelper) 
        {
            Console.WriteLine("1. Add a new course");               
            Console.WriteLine("2. Update a course");                
            Console.WriteLine("3. Add a student to a course");
            Console.WriteLine("4. Remove a student from a course");
            Console.WriteLine("5. Add an assignment");
            Console.WriteLine("6. Update an assignment");
            Console.WriteLine("7. Remove an assignment");
            Console.WriteLine("8. Create a student submission");
            Console.WriteLine("9. List all submissions for a course");
            Console.WriteLine("10. Delete submission from a course");
            Console.WriteLine("11. Update submission in a course");
            Console.WriteLine("12. Grade submission in a course");
            Console.WriteLine("13. Add a module to a course");
            Console.WriteLine("14. Remove a module from a course");
            Console.WriteLine("15. Update a module in a course");
            Console.WriteLine("16. List all courses");            
            Console.WriteLine("17. Search for a course");           


            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    courseHelper.CreateCourseRecord();
                }
                else if (result == 2)
                {
                    courseHelper.UpdateCourseRecord();
                }
                else if (result == 3)
                {
                    courseHelper.AddStudent();
                }
                else if (result == 4)
                {
                    courseHelper.RemoveStudent();
                }
                else if (result == 6)
                {
                    courseHelper.AddAssignment();
                }
                else if (result == 7)
                {
                    courseHelper.UpdateAssignment();
                }
                else if (result == 8)
                {
                    courseHelper.RemoveAssignment();
                }
                else if (result == 9)
                {
                    courseHelper.AddSubmission();
                }
                else if (result == 10)
                {
                    courseHelper.ListSubmissions();
                }
                else if (result == 11)
                {
                    courseHelper.RemoveSubmission();
                }
                else if (result == 12)
                {
                    courseHelper.UpdateSubmission();
                }
                else if (result == 13)
                {
                    courseHelper.AddModule();
                }
                else if (result == 14)
                {
                    courseHelper.RemoveModule();
                }
                else if (result == 15)
                {
                    courseHelper.UpdateModule();
                }
                else if (result == 16)
                {
                    courseHelper.SearchCourses();
                }
                else if (result == 17)
                {
                    Console.WriteLine("Enter a query:");
                    var query = Console.ReadLine() ?? string.Empty;
                    courseHelper.SearchCourses(query);
                }
            }
        }
    }
}