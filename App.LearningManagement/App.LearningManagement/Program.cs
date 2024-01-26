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

            bool cont = true;
            var input = "1";
            while (cont)
            {
                Console.WriteLine("Choose an Action:");
                Console.WriteLine("1. Add a student enrollment");
                Console.WriteLine("2. Search for a student");
                Console.WriteLine("3. List all enrolled students");
                Console.WriteLine("4. Exit");
                input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result == 1) studentHelper.CreateStudentRecord();
                    else if (result == 2) studentHelper.SearchStudent();
                    else if (result == 3) studentHelper.ListStudents();
                    else if (result == 4) cont = false;

                }
            }

        }

      
    }
}