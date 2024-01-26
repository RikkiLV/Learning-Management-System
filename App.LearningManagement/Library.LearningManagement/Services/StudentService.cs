using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Models;

namespace Library.LearningManagement.Services
{
    public class StudentService
    {
        public List<Person> studentList { get; set; } = new List<Person>();

        // Function to add each student to our list
        public void Add(Person student)
        {
            studentList.Add(student);
        }

        // Function to list the students in our list 
        public List<Person> Students
        {
            get { return studentList; }
        }

        // Function allows for user to search a student in read-only
       public IEnumerable<Person> Search(string query)
       {
            return studentList.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
       }
    }
}
