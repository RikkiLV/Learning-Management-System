using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class ModuleDetailView : ContentPage
{
	public ModuleDetailView()
	{
		InitializeComponent();
		BindingContext = new ModuleDetailViewModel();
	}


}