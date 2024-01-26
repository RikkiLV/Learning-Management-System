using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Models;
using Library.LearningManagement.Services;

namespace App.LearningManagement.Helpers
{
    internal class StudentHelper
    {
        private StudentService studentService = new StudentService();

        public void CreateStudentRecord()
        {
            // Takes user-input for the student variables
            Console.WriteLine("What is the id of the student?");
            var id = Console.ReadLine();
            Console.WriteLine("What is the name of the student?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the classification of the student? [(F)reshman, S(O)phomore, (J)unior, (S)enior");
            var classification = Console.ReadLine();

            // Conditional statement for student classification
            PersonClassification classEnum = PersonClassification.Freshman;

            if (classification.Equals("O", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Sophomore;
            }
            else if (classification.Equals("J", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Junior;
            }
            else if (classification.Equals("S", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Senior;
            }


            // User-inputs are assigned to Person objects
            var student = new Person
            {
                Id = int.Parse(id),
                Name = name ?? string.Empty,
                Classification = classEnum
            };

            // Each student is added to studentList 
            studentService.Add(student);
            studentService.studentList.ForEach(Console.WriteLine);
        }
    }
}
