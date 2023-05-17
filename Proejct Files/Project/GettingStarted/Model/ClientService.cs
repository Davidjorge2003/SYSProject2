using System.Collections.ObjectModel;

namespace GettingStarted
{
    public class ClientService
    {
        private ObservableCollection<Client> _clients;
        private DatabaseHelper _databaseHelper;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { _clients = value; }
        }

        public ClientService()
        {
            _databaseHelper = new DatabaseHelper();
            Clients = new ObservableCollection<Client>(_databaseHelper.GetClientsAsync().Result);
        }

        public async void AddClient(Client client)
        {
            await _databaseHelper.SaveClientAsync(client);
            _clients.Add(client);
        }

        public async void RemoveClient(Client client)
        {
            await _databaseHelper.DeleteClientAsync(client);
            _clients.Remove(client);
        }

        public async Task SaveClientAsync(Client client)
        {
            await _databaseHelper.SaveClientAsync(client);
        }

    }


}
