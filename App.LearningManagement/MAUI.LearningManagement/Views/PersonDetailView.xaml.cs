using Library.LearningManagement.Models;
using Library.LearningManagement.Services;
using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

[QueryProperty(nameof(PersonId), "personId")]

public partial class PersonDetailView : ContentPage
{
    // DECLARATIONS
    public int PersonId { set; get; }

    public PersonDetailView()
	{
		InitializeComponent();
    }

    // ALLOWS SELECTED SEARCH to fill to edit
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (PersonId > 0)
        {
            BindingContext = new PersonDetailViewModel(PersonId);
        }
        else
        {
            BindingContext = new PersonDetailViewModel();
        }
    }


    // BUTTON FUNCTIONS
    private void OkClick(object sender, EventArgs e)
	{
		(BindingContext as PersonDetailViewModel).AddPerson(); 
	}

    private void CancelClick(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Instructor");
    }

    // ROUTE NAVIGATION 
    private void OnLeaving (object sender, NavigatedFromEventArgs e)
	{
		BindingContext = null;
	}

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new PersonDetailViewModel(PersonId);
    }
}