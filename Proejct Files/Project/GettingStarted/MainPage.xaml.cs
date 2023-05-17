namespace GettingStarted;

public partial class MainPage : ContentPage
{



	public MainPage()
	{
		InitializeComponent();
  
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        // TODO: Validate username and password and handle login logic

        // Navigate to the next page
        if (username == "Admin" && password == "admin123")
        {
            await Navigation.PushAsync(new AdminMainPage());
        }
        else if (username == "Employee" && password == "employee123")
        {
            await Navigation.PushAsync(new EmployeeMainPage());
        }
        else
        {
            await DisplayAlert("Error", "Please enter a valid username and password.", "OK");
        }

    }
}

