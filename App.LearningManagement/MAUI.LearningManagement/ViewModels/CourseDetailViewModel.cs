using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
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
        public Course SelectedModules { get; set; }


        // DECLARATIONS
        public string? ModuleName { get; set; }
        public string? ModuleDescription { get; set; }


        public ObservableCollection<Module> Modules
        {
            get
            {
                // Filter modules based on the current course
                if (Id > 0)
                {
                    // Retrieve the current course
                    var currentCourse = CourseService.Current.GetById(Id) as Course;

                    // Return modules associated with the current course
                    return new ObservableCollection<Module>(currentCourse.Modules);
                }
                else
                {
                    // Return an empty collection if no course is selected
                    return new ObservableCollection<Module>();
                }
            }
        }

      

        // COURSE ID handler to load existing course from the DB
        public CourseDetailViewModel(int id = 0)
        {
            if (id > 0) 
            { 
                LoadById(id); 

            };
        }

        public void LoadById(int id)
        {
            if (id == 0) 
            {
                return; 
            }
            var course = CourseService.Current.GetById(id) as Course;
            if (course != null)
            {
                Prefix = course.Prefix;
                Name = course.Name;
                Id = course.Id;
                Description = course.Description;
                ModuleName = course.Modules?.FirstOrDefault()?.Name;
                ModuleDescription = course.Modules?.FirstOrDefault()?.Description ?? string.Empty;



            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Prefix));
            NotifyPropertyChanged(nameof(Description));
            NotifyPropertyChanged(nameof(ModuleName));
            NotifyPropertyChanged(nameof(ModuleDescription));


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



        // ADD FUNCTION for modules
        public void AddModules()
        {
            // Use ModuleName and ModuleDescription properties
            Module newModule = new Module { Name = ModuleName, Description = ModuleDescription };

            // Associate the module with the current course
            if (Id > 0)
            {
                var currentCourse = CourseService.Current.GetById(Id) as Course;
                if (currentCourse != null)
                {
                    currentCourse.Modules.Add(newModule);
                }
            }

            // Clear the inputs
            ModuleName = "";
            ModuleDescription = "";

            // Refresh the Modules collection
            NotifyPropertyChanged(nameof(Modules));
        }
        

    }
}

