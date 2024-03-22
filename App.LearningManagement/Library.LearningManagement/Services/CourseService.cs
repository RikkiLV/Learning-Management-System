using System;
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

        public IEnumerable<Course?> Courses
        {
            get
            {
                return FakeDatabase.Courses.Where(c => c is Course).Select(c => c as Course);
            }
        }

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

        public Course? GetById(int id)
        {
            return FakeDatabase.Courses.FirstOrDefault(c => c.Id == id);
        }


        // Function allows for user to search a course in read-only
        public IEnumerable<Course> Search(string query)
        {
            return Courses.Where(a => (a != null) && a.Name.ToUpper().Contains(query.ToUpper()));

        }
    }
}
