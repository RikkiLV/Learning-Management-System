using System.Collections.ObjectModel;
using Library.LearningManagement.Database;
using Library.LearningManagement.Models;
using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

[QueryProperty(nameof(CourseId), "courseId")]

public partial class CourseDetailView : ContentPage
{

    // DECLARATIONS
    public CourseDetailView()
	{
		InitializeComponent();
    }

    public int CourseId { set; get; }


    // ALLOWS SELECTED SEARCH to fill to edit
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (CourseId > 0)
        {
            BindingContext = new CourseDetailViewModel(CourseId);
            
        }
        else
        {
            BindingContext = new CourseDetailViewModel();
        }
    }

    // BUTTON FUNCTIONS

    private async void AddModule(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewModel).AddModules();

    }

    private async void AddAssignment(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewModel).AddAssignment();

    }

    private async void AddRoster(object sender, EventArgs e)
    {
    }
    private async void RemoveRoster(object sender, EventArgs e)
    {
    }


    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }


    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewModel).AddCourse();
    
    }

    // ROUTE NAVIGATION 
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDetailViewModel(CourseId);
    }
}