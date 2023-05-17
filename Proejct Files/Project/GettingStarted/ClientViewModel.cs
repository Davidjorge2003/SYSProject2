using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GettingStarted
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Client> Clients { get; set; }

        private readonly ClientService _clientService;

        public ClientViewModel()
        {            
            _clientService = new ClientService();
            Clients = _clientService.Clients;

        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        public void AddClient(Client client)
        {
            _clientService.AddClient(client);
            OnPropertyChanged(nameof(Clients));
        }

        public void RemoveClient(Client client)
        {
            _clientService.RemoveClient(client);
            OnPropertyChanged(nameof(Clients));
        }

        public async Task SaveClientAsync(Client client)
        {
           await _clientService.SaveClientAsync(client);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
