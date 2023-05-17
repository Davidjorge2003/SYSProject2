namespace GettingStarted;

public partial class FileCustomerPage : ContentPage
{
    private ClientViewModel _clientViewModel;
    public FileCustomerPage()
	{
		InitializeComponent();
        _clientViewModel = (ClientViewModel)BindingContext;
    }

    private async void HomeImageButtonClick(object sender, EventArgs e)//Image button that when cliked brings u to the main page of teh admin 
    {
        await Navigation.PushAsync(new AdminMainPage());
    }
    private async void CustomerImageButtonClick(object sender, EventArgs e)//Image button that when cliked brings u to the Customer page 
    {
        await Navigation.PushAsync(new FileCustomerPage());
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
    private  void ButtonAddUserCliked(object sender, EventArgs e)//Image button that when cliked brings u to the people page
    {
        var newClient = new Client
        {
            clientId = 1,
            firstName = "First Name",
            lastName = "Last Name",
            address = "Address",
            city = "City",
            postalCode = "Postal Code",
            telephoneNumber = "Phone Number",
            dateOfBirth = DateTime.Now,
            membershipCreationDate = DateTime.Now,
            membershipExpirationDate = DateTime.Now.AddDays(30),
            fitnessGoals = "Fitness Goals"
        };
        _clientViewModel.AddClient(newClient);
    }
    private void ButtonDeleteCliked(object sender, EventArgs e)
    {
        var selectedItems = dataGrid.SelectedRows.ToList();
        foreach (Client client in selectedItems)
        {
            _clientViewModel.RemoveClient(client);
        }
    }
    private async void ButtonSaveCliked(object sender, EventArgs e)
    {
        var selectedClients = dataGrid.SelectedRows;
        foreach (Client client in selectedClients)
        {
            await _clientViewModel.SaveClientAsync(client);
        }
    }
    private async void LogOutImageButtonClick(object sender, EventArgs e)//Image button that when cliked brings u to the people page
    {
        await Navigation.PushAsync(new MainPage());
    }
    private async void ButtonImportFileCliked(object sender, EventArgs e)//Image button that when cliked brings u to the people page
    {
        await Navigation.PushAsync(new PeButtonImportFile());
    }
    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string enteredFirstName = e.NewTextValue;

        //Search for the client with the entered first name
        Client client = _clientViewModel.Clients.FirstOrDefault(c => c.firstName == enteredFirstName);

        if (client != null)
        {
            //Highlight the row that corresponds to the found client
            dataGrid.SelectedRow = client;
        }
        else
        {
            //If there is no match, deselect any currently selected item
            dataGrid.SelectedRow = null;
        }

    }

}