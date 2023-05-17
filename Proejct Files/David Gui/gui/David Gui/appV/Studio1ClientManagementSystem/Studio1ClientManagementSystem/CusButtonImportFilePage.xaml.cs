namespace Studio1ClientManagementSystem;

public partial class ImportFilePage : ContentPage
{
	public ImportFilePage()
	{
		InitializeComponent();
	}
    private async void BackImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomerPage());
    }
    private async void InfoImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomerPage());
    }
}