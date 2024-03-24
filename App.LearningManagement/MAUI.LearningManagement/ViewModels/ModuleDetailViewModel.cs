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
    public class ModuleDetailViewModel : INotifyPropertyChanged
    {

        // DECLARATIONS
        public string? Name { get; set; }
        public string? Description { get; set; }


        public ObservableCollection<Module> Modules
        {
            get
            {
                return new ObservableCollection<Module>(CourseService.Current.Modules);
            }
        }

        // EVENT HANDLER 
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public void AddModules()
        {

            CourseService.Current.AddModules(new Module { Name = Name, Description = Description });
            Shell.Current.GoToAsync("//CourseDetail");

        }


    }
}
