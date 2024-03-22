﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Database;
using Library.LearningManagement.Models;

namespace Library.LearningManagement.Services
{
    public class CourseService
    {
        private static CourseService? _instance;

        public static CourseService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseService();
                }
                return _instance;
            }
        }

        private CourseService()
        {
           
        }

        // Function to add courses to our list
        public void Add(Course course)
        {
            FakeDatabase.Courses.Add(course);
        }

        // Function to remove courses to our list
        public void Remove(Course course)
        {
            FakeDatabase.Courses.Remove(course);
        }

        // Function to list the courses in our list 
        public List<Course> Courses
        {
            get { return FakeDatabase.Courses; }
        }

        // Function allows for user to search a course in read-only
        public IEnumerable<Course> Search(string query)
        {
            return Courses.Where(s => s.Name.ToUpper().Contains(query.ToUpper()) 
            || s.Description.ToUpper().Contains(query.ToUpper())
            || s.Code.ToUpper().Contains(query.ToUpper()));
        }

    }
}
