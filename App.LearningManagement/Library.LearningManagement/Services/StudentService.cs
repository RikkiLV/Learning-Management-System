using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Database;
using Library.LearningManagement.Models;

namespace Library.LearningManagement.Services
{
    public class StudentService
    {
        
        private static StudentService? _instance;

        public IEnumerable<Student?> Students
        {
            get
            {
                return FakeDatabase.People.Where(p => p is Student).Select(p => p as Student);
            }
        }

        public StudentService()
        {
            
        }

        public static StudentService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentService();
                }
                return _instance;
            }
        }


    // Function to add each student to our list
    public void Add(Person student)
        {
            FakeDatabase.People.Add(student);
        }

        

    // Function allows for user to search a student in read-only
    public IEnumerable<Student?> Search(string query)
    {
        return Students.Where(a => (a != null) && a.Name.ToUpper().Contains(query.ToUpper()));
    }
    }
}
