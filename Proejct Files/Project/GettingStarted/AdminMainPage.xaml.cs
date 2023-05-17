namespace GettingStarted;

public partial class AdminMainPage : ContentPage
{
    private Timer _timer;
    public AdminMainPage()
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
    private async void HomeImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminMainPage());
    }
    private async void CustomerImageButtonClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FileCustomerPage());
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