namespace GettingStarted;

public partial class CusButtonImportFilePage : ContentPage
{
	public CusButtonImportFilePage()
	{
		InitializeComponent();
	}
    private async void BackImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FileCustomerPage());
    }
    private async void InfoImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FileCustomerPage());
    }
}