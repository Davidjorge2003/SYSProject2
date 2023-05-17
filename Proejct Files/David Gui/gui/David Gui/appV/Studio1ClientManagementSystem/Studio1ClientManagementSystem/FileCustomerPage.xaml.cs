using Studio1ClientManagementSystem.ViewModels;

namespace Studio1ClientManagementSystem;

public partial class CustomerPage : ContentPage
{
	public CustomerPage()
	{
		InitializeComponent();
	}
    private async void HomeImageButtonClick(object sender, EventArgs e)//Image button that when cliked brings u to the main page of teh admin 
    {
        await Navigation.PushAsync(new AdminMainPage());
    }
    private async void CustomerImageButtonClick(object sender, EventArgs e)//Image button that when cliked brings u to the Customer page 
    {
        await Navigation.PushAsync(new CustomerPage());
    }
    private async void NoteImageButtonClick(object sender, EventArgs e)//Image button that when cliked brings u to the Notes page
    {
        await Navigation.PushAsync(new NoteMainPage());
    }
    private async void TimerImageButtonClick(object sender, EventArgs e)//Image button that when cliked brings u to the Time page
    {
        await Navigation.PushAsync(new TimeMainPage());
    }
    private async void FolderLockImageButtonClick(object sender, EventArgs e)//Image button that when cliked brings u to the FolderLock page
    {
        await Navigation.PushAsync(new LockFIleMainPage());
    }

    private async void PeopleImageButtonClick(object sender, EventArgs e)//Image button that when cliked brings u to the people page
    {
        await Navigation.PushAsync(new ClasesPage());
    }
    private async void ButtonAddUserCliked(object sender, EventArgs e)//Image button that when cliked brings u to the people page
    {
        await Navigation.PushAsync(new AddUserPage());
    }
        private async void ButtonImportFileCliked(object sender, EventArgs e)//Image button that when cliked brings u to the people page
    {
        await Navigation.PushAsync(new ImportFilePage());
    }
            private async void LogOutImageButtonClick(object sender, EventArgs e)//Image button that when cliked brings u to the people page
    {
        await Navigation.PushAsync(new MainPage());
    }
}