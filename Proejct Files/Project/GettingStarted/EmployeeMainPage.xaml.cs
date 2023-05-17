namespace GettingStarted;

public partial class EmployeeMainPage : ContentPage
{
    private Timer _timer;
    public EmployeeMainPage()
	{
		InitializeComponent();
        BindingContext = this;
        //timer values/ to inicialices it 
        _timer = new Timer(UpdateCurrentTime, null, TimeSpan.Zero, TimeSpan.FromSeconds(1)); ;
        SetMyLabelText();
    }
    private void UpdateCurrentTime(object state)
    {
        Device.BeginInvokeOnMainThread(() =>
        {
            MyLabel.Text = $"{DateTime.Now:T}";

        });
    }
    private async void OnBackToLoginButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void HomeImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    private async void CustomerImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FileCustomerPage());
    }
    private async void NoteImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    private async void TimerImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    private async void FolderLockImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void PeopleImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    public static readonly BindableProperty MyLabelTextProperty =
      BindableProperty.Create(nameof(MyLabelText), typeof(string), typeof(MainPage), string.Empty);

    public string MyLabelText
    {
        get { return (string)GetValue(MyLabelTextProperty); }
        set { SetValue(MyLabelTextProperty, value); }
    }
    private void SetMyLabelText()
    {
        MyLabelText = "Texto establecido desde la función";
    }
    private async void LogOutImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}