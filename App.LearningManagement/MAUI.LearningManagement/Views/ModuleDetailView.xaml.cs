using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class ModuleDetailView : ContentPage
{
	public ModuleDetailView()
	{
		InitializeComponent();
		BindingContext = new ModuleDetailViewModel();
	}

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDetail");
    }

    private void AddModuleClick(object sender, EventArgs e)
    {
        (BindingContext as ModuleDetailViewModel).AddModuleClick(Shell.Current);
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ModuleDetailViewModel).RefreshView();
    }


}