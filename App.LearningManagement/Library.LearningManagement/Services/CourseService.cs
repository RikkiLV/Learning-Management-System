using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Models;

namespace Library.LearningManagement.Services
{
    public class CourseService
    {
        public List<Course> courseList = new List<Course>();

        // Function to add courses to our list
        public void Add(Course course)
        {
            courseList.Add(course);
        }
        // Function to list the courses in our list 
        public List<Course> Courses
        {
            get { return courseList; }
        }

    }
}
