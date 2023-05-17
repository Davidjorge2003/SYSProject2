using Studio1ClientManagementSystem.ViewModels;

namespace Studio1ClientManagementSystem;

public partial class TimeMainPage : ContentPage
{
	public TimeMainPage()
	{
		InitializeComponent();
	}
    private async void HomeImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminMainPage());
    }
    private async void CustomerImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomerPage());
    }
    private async void NoteImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NoteMainPage());
    }
    private async void TimerImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TimeMainPage());
    }
    private async void FolderLockImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LockFIleMainPage());
    }

    private async void PeopleImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClasesPage());
    }
    private async void LogOutImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}