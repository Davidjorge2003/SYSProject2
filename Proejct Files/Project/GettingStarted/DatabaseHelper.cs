using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingStarted;
using SQLite;


namespace GettingStarted
{
    public class DatabaseHelper
    {
        private static readonly Lazy<DatabaseHelper> _instance = new Lazy<DatabaseHelper>(() => new DatabaseHelper());
        public static DatabaseHelper Instance
        {
            get { return _instance.Value; }
        }

        static SQLiteAsyncConnection database;

        public DatabaseHelper()
        {
            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            database.CreateTableAsync<Client>().Wait();
        }

        public Task<List<Client>> GetClientsAsync()
        {
            return database.Table<Client>().ToListAsync();
        }

        public Task<int> SaveClientAsync(Client client)
        {
            if (client.clientId == 1)
            {
                return database.InsertAsync(client);
            }
            else
            {
                return database.UpdateAsync(client);
            }
        }

        public Task<int> DeleteClientAsync(Client client)
        {
            return database.DeleteAsync(client);
        }
    }
}

