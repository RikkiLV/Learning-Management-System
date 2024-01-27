﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Models;
using Library.LearningManagement.Services;

namespace App.LearningManagement.Helpers
{
    public class CourseHelper
    {
        private CourseService courseService = new CourseService();
        private StudentService studentService = new StudentService();

        public CourseHelper(StudentService ssrvc)
        {
            studentService = ssrvc;
        }

        public void AddOrUpdateCourse(Course? selectedCourse = null)
        {
            // Takes user-input for the course variables
            Console.WriteLine("What is the code of the course?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the name of the course?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the description of the course?");
            var description = Console.ReadLine() ?? string.Empty;

            // Add students to courses
            Console.WriteLine("Which students should be enrolled in this course? ('Q' to quit)");

            var roster = new List<Person>();
            bool continueAdding = true;
            while (continueAdding)
            {
                studentService.Students.Where(s => !roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                var selection = "Q";
                if (!studentService.Students.Any(s => !roster.Any(s2 => s2.Id == s.Id)))
                {
                    selection = Console.ReadLine() ?? string.Empty;
                }

                if (selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    continueAdding = false;
                }
                else
                {
                    var selectedId = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectedId);

                    if (selectedStudent != null)
                    {
                        roster.Add(selectedStudent);
                    }

                }
            }
  
            // User-inputs are assigned to a new Course objects if user is just created
            bool isNewCourse = false;
            if (selectedCourse == null)
            {
                isNewCourse = true;
                selectedCourse = new Course();

            }

            // User can change Course record
            // Course variables
            selectedCourse.Code = code;
            selectedCourse.Name = name;
            selectedCourse.Description = description;
            selectedCourse.Roster = new List<Person>();
            selectedCourse.Roster.AddRange(roster);

            if (isNewCourse)
            courseService.Add(selectedCourse);
        }

        // Function to list the students by calling function ListCourse() from CourseService.cs
        public void ListCourse()
        {
            courseService.Courses.ForEach(Console.WriteLine);
        }

        // Function to update the student using Id and called the AddOrUpdateCourse() function in order to do so
        public void UpdateCourseRecord()
        {
            Console.WriteLine("Enter the code for the course to update:");
            ListCourse();

            var selectionStr = Console.ReadLine();

            
            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selectionStr, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                AddOrUpdateCourse(selectedCourse);
            }
            
        }
        // Function to search courses by code by calling function Search() from CourseService.cs
        public void SearchCourse()
        {
            Console.WriteLine("Enter a query:");
            var query = Console.ReadLine() ?? string.Empty;

            courseService.Search(query).ToList().ForEach(Console.WriteLine);
        }
    }
}
