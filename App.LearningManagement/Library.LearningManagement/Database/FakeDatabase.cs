using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Models;

namespace Library.LearningManagement.Database
{
    public static class FakeDatabase
    {
        public static List<Person> People
        {
            get
            {
                return new List<Person>();
            }
   
        }

        public static List<Course> Courses
        {
            get
            {
                return new List<Course>();
            }
        }

    }
}
