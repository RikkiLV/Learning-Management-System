using Library.LearningManagement.Models;
using Library.LearningManagement.Services;
using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class ModuleDetailView : ContentPage
{
	public ModuleDetailView()
	{
		InitializeComponent();
		BindingContext = new ModuleDetailViewModel();
	}

  

 

    private void OkClick(object sender, EventArgs e)
    {
        (BindingContext as ModuleDetailViewModel).AddModules();

    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDetail");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ModuleDetailViewModel();
    }

    
}