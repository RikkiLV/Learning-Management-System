using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Library.LearningManagement.Models;
using Library.LearningManagement.Services;

namespace MAUI.LearningManagement.ViewModels
{
    public class PersonDetailViewModel
    {

        public string Name { get; set; }
        public string ClassificationString { get; set; } 

        public void AddPerson()
        {
            var person = new Person();
            PersonClassification classification;
            switch (ClassificationString)
            {
                case "S":
                    classification = PersonClassification.Senior; break;
                case "J":
                    classification = PersonClassification.Junior; break;
                case "O":
                    classification = PersonClassification.Sophomore; break;
                case "F":
                default:
                    // Handle unexpected values
                    classification = PersonClassification.Freshman;
                    break;
            }
            StudentService.Current.Add(new Student { Name = Name, Classification = classification });
            Shell.Current.GoToAsync("//Instructor");
        }
    }
}
