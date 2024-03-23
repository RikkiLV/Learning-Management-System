using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.LearningManagement.Models;
using Library.LearningManagement.Services;


namespace MAUI.LearningManagement.ViewModels
{
    public class InstructorViewViewModel : INotifyPropertyChanged

    {

        // DECLARATIONS
        public bool IsEnrollmentsVisible  { get; set;}

        public bool IsCoursesVisible { get; set; }

        public string Title { get => "Instructor / Administrator Menu"; }

        public Person SelectedPerson { get; set; }
        public Course SelectedCourse { get; set; }


        // QUERY INITIALIZING for search functions
        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(People));
                NotifyPropertyChanged(nameof(Courses));
            }
        }

        // QUERY SEARCH FUNCTIONS for courses and students
        public ObservableCollection<Person> People
        {
            get
            {
                var filteredList = StudentService.Current.Students.Where(s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));
                return new ObservableCollection<Person>(filteredList);
            }
        }

        public ObservableCollection<Course> Courses
        {
            get
            {
                var filteredList = CourseService.Current.Courses
                    .Where(c => (c.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ||
                    (c.Prefix.ToUpper().Contains(Query?.ToUpper() ?? string.Empty))));
                return new ObservableCollection<Course>(filteredList);
            }
        }

        // EVENT HANDLER 
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        // LIST DISPLAY for courses and students
        public InstructorViewViewModel()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
        }

        public void ShowEnrollments()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }

        public void ShowCourses()
        {
            IsEnrollmentsVisible = false;
            IsCoursesVisible = true;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }


        // ENROLLMENTS functions
        public void AddEnrollmentClick(Shell s)
        {
            s.GoToAsync($"//PersonDetail?personId=0");
        }

        public void EditEnrollmentClick(Shell s)
        {
            var idParam = SelectedPerson?.Id ?? 0;
            s.GoToAsync($"//PersonDetail?personId={idParam}");
        }

        public void RemoveEnrollmentClick()
        {
            if(SelectedPerson==null) { return; }

            StudentService.Current.Remove(SelectedPerson);
            RefreshView();
        }

        // COURSES functions
        public void AddCourseClick(Shell s)
        {
            var idParam = SelectedCourse?.Id ?? 0;
            s.GoToAsync($"//CourseDetail?courseId={idParam}");
        }

        public void RemoveCourseClick()
        {
            if (SelectedCourse == null) { return; }

            CourseService.Current.Remove(SelectedCourse);
            RefreshView();
        }

        // NAVIGATION for routes
        public void ResetView()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
            NotifyPropertyChanged(nameof(Courses));
        }
    }
}
