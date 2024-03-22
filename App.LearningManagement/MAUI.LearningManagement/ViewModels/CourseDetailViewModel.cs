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
        // DECLARATIONS
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Prefix { get; set; }
        public string CourseCode
        {
            get => course?.Code ?? string.Empty;
        }

        private Course course;

        private bool isEditingCourse;

        // Property to track whether the user is editing a course
        public bool IsEditingCourse
        {
            get => isEditingCourse;
            set
            {
                if (isEditingCourse != value)
                {
                    isEditingCourse = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // Property to control the visibility of module-related UI elements
        public bool IsModulesVisible => IsEditingCourse;



        // COURSE ID handler to load existing course from the DB
        public CourseDetailViewModel(int id = 0)
        {
            if (id > 0) { LoadById(id); };
        }

        public void LoadById(int id)
        {
            if (id == 0) 
            {
                IsEditingCourse = false;
                return; 
            }
            var course = CourseService.Current.GetById(id) as Course;
            if (course != null)
            {
                Prefix = course.Prefix;
                Name = course.Name;
                Id = course.Id;
                IsEditingCourse = true;


            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Prefix));

        }


        // EVENT HANDLER
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // ADD FUNCTION for courses
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

