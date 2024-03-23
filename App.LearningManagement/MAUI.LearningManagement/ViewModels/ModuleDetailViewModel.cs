using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Android.Telecom;
using Library.LearningManagement.Models;
using Library.LearningManagement.Services;
using static Android.Provider.Contacts;

namespace MAUI.LearningManagement.ViewModels
{
    public class ModuleDetailViewModel : INotifyPropertyChanged
    {

        // DECLARATIONS
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Course Course { get; set; }

        public ObservableCollection<Course> Module
        {
            get;

            set;
            //get
            //{
            //   // return new ObservableCollection<Course>{CourseService.Current.Modules};
            //}
        }


        // EVENT HANDLER 
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public void AddModuleClick(Shell s)
        {
            s.GoToAsync("ModuleDetail");
        }


        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Module));

        }
    }
}
