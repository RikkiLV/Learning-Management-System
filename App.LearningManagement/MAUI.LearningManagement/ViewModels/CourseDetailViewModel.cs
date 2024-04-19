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
using Microsoft.VisualBasic;

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
        public Course SelectedAssignment { get; set; }


        public string? ModuleName { get; set; }
        public string? ModuleDescription { get; set; }

        public string? AssignmentName { get; set; }
        public string? AssignmentDescription { get; set; }
        public decimal TotalAvailablePoints { get; set; }
        public DateTime AssignmentDueDate { get; set; }


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

        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                // Filter assignments based on the current course
                if (Id > 0)
                {
                    // Retrieve the current course
                    var currentCourse = CourseService.Current.GetById(Id) as Course;

                    // Return assignments associated with the current course
                    return new ObservableCollection<Assignment>(currentCourse.Assignments);
                }
                else
                {
                    // Return an empty collection if no course is selected
                    return new ObservableCollection<Assignment>();
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


            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Prefix));
            NotifyPropertyChanged(nameof(Description));


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
            if (Id <= 0)
            {

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

        // ADD FUNCTION for assignments
        public void AddAssignment()
        {
            // Use AssignmentName, AssignmentDescription, etc. properties
            Assignment newAssignment = new Assignment
            {
                Name = AssignmentName,
                Description = AssignmentDescription,
                TotalAvailablePoints = TotalAvailablePoints,
                DueDate = AssignmentDueDate
            };

            // Associate the assignment with the current course
            if (Id > 0)
            {
                var currentCourse = CourseService.Current.GetById(Id) as Course;
                if (currentCourse != null)
                {
                    // Add the assignment to a default assignment group for now
                    if (currentCourse.AssignmentGroups.Count == 0)
                    {
                        currentCourse.AssignmentGroups.Add(new AssignmentGroup());
                    }
                    currentCourse.AssignmentGroups[0].Assignments.Add(newAssignment);
                }
            }

            // Clear the inputs
            AssignmentName = "";
            AssignmentDescription = "";
            TotalAvailablePoints = 0;
            AssignmentDueDate = DateTime.Today;

            // Refresh the assignments collection
            NotifyPropertyChanged(nameof(Assignments));
        }

        public void AddRoster()
        {
           
        }
        public void RemoveRoster()
        {

        }

    }
}

