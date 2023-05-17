namespace Studio1ClientManagementSystem;

public partial class LockBuImportFile : ContentPage
{
	public LockBuImportFile()
	{
		InitializeComponent();
	}
    private async void BackImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LockFIleMainPage());
    }
    private async void InfoImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LockFIleMainPage());
    }
}