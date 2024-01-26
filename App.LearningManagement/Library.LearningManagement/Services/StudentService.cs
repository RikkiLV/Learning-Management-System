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

        public void Add(Person student)
        {
            studentList.Add(student);
        }
    }
}
