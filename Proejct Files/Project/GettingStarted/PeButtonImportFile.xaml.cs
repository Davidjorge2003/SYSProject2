namespace GettingStarted;

public partial class PeButtonImportFile : ContentPage
{
	public PeButtonImportFile()
	{
		InitializeComponent();
	}
    private async void BackImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClasesPage());
    }
    private async void InfoImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClasesPage());
    }
}