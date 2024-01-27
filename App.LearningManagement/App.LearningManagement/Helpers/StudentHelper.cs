using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Library.LearningManagement.Models;
using Library.LearningManagement.Services;

namespace App.LearningManagement.Helpers
{
    internal class StudentHelper
    {
        private StudentService studentService;

        public StudentHelper(StudentService ssrvc)
        {
            studentService = ssrvc;
        }

        // Function to create the student record by calling function Add() from StudentService.cs
        public void AddOrUpdateStudent(Person? selectedStudent = null)
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


            // User-inputs are assigned to a new Person objects if user is just created

            bool isCreate = false;
            if (selectedStudent == null)
            {
                isCreate = true;
                selectedStudent = new Person();
               
            }

            // User can change Student record

            selectedStudent.Id = int.Parse(id ?? "0");
            selectedStudent.Name = name ?? string.Empty;
            selectedStudent.Classification = classEnum;

            // Each student is added to studentList is just created
            if (isCreate)
            {
                studentService.Add(selectedStudent);
            }

        }

        // Function to update the student using Id and called the CreateStudentRecord() function in order to do so
        public void UpdateStudentRecord()
        {
            Console.WriteLine("Select a student to update:");
            ListStudents();
            var selectionStr = Console.ReadLine();

            if(int.TryParse(selectionStr, out int selectionInt))
            {
               var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectionInt);
                if (selectedStudent != null)
                {
                    AddOrUpdateStudent(selectedStudent);
                }
            }
        }

        // Function to list the students by calling function ListStudents() from StudentService.cs
        public void ListStudents()
        {
            studentService.Students.ForEach(Console.WriteLine);
        }

        // Function to search students by name by calling function Search() from StudentService.cs
        public void SearchStudent()
        {
            Console.WriteLine("Enter a query:");
            var query = Console.ReadLine() ?? string.Empty;

            studentService.Search(query).ToList().ForEach(Console.WriteLine);
        }
    }
}
