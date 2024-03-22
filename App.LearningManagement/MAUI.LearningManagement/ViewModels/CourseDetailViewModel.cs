using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Models;
using Library.LearningManagement.Services;

namespace MAUI.LearningManagement.ViewModels
{
    class CourseDetailViewModel : INotifyPropertyChanged
    {

        public int Id { get; set; }

        public string CourseCode
        {
            get => course?.Code ?? string.Empty;
        }

        private Course course;


        public CourseDetailViewModel(int id = 0)
        {
            if (id > 0) { LoadById(id); };
        }

        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var course = CourseService.Current.GetById(id) as Course;
            if (course != null)
            {
                Prefix = course.Prefix;
                Name = course.Name;
                Id = course.Id;
         

            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Prefix));

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            //get => course?.Name ?? string.Empty;
            //set { if (course != null) course.Name = value; }
            get; set;
        }
        public string Description
        {
            //get => course?.Description ?? string.Empty;
            //set { if (course != null) course.Description = value; }
            get; set;
        }
        public string Prefix
        {
            //get => course?.Prefix ?? string.Empty;
            //set { if (course != null) course.Prefix = value; }
            get; set;
        }
        
        public void AddCourse()
        {
            if (Id <= 0) {
                CourseService.Current.Add(new Course { Prefix = Prefix, Name = Name, Description = Description });
            }
            else
            {
                var refToUpdate = CourseService.Current.GetById(Id) as Course;
                refToUpdate.Prefix = Prefix;
                refToUpdate.Name = Name;
                refToUpdate.Description = Description;

            }
            Shell.Current.GoToAsync("//Instructor");
        }

    }
}

