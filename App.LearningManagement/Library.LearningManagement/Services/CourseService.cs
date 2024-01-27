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
        // Function allows for user to search a course in read-only
        public IEnumerable<Course> Search(string query)
        {
            return Courses.Where(s => s.Name.ToUpper().Contains(query.ToUpper()) 
            || s.Description.ToUpper().Contains(query.ToUpper())
            || s.Code.ToUpper().Contains(query.ToUpper()));
        }

    }
}
