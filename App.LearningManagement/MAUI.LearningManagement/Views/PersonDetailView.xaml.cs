using Library.LearningManagement.Models;
using Library.LearningManagement.Services;
using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
		BindingContext = new PersonDetailViewModel();
	}

	private void OkClick(object sender, EventArgs e)
	{
		//To do: Migrate this to ViewModel
		(BindingContext as PersonDetailViewModel).AddPerson();
	}

	private void OnLeaving (object sender, NavigatedToEventArgs e)
	{
		BindingContext = null;
	}

    private void OnArriving(object sender, NavigatedFromEventArgs e)
    {
		BindingContext = new PersonDetailViewModel();
    }
}