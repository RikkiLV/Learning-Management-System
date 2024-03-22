using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class InstructorView : ContentPage
{
    public InstructorView()
    {
        InitializeComponent();
        BindingContext = new InstructorViewViewModel();
    }

    // CANCEL BUTTONS
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void CourseCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }


    // ENROLLMENT BUTTONS
    private void AddEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).AddEnrollmentClick(Shell.Current);

    }

    private void EditEnrollmentClick(object sender, EventArgs e)
    {

        (BindingContext as InstructorViewViewModel).EditEnrollmentClick(Shell.Current);
    }

    private void RemoveEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).RemoveEnrollmentClick();
    }

    // COURSE BUTTONS
    private void AddCourseClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).AddCourseClick(Shell.Current);

    }
    private void EditCourseClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).AddCourseClick(Shell.Current);
    }

    private void RemoveCourseClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).RemoveCourseClick();
    }

    // NAVIGATION 
    public void ContentPage_NavigateTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InstructorViewViewModel).ResetView();
        (BindingContext as InstructorViewViewModel).RefreshView();
    }

    // LIST DISPLAY 
    private void Toolbar_EnrollmentsClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).ShowEnrollments();
    }

    private void Toolbar_CoursesClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).ShowCourses();
    }

}