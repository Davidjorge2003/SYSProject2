using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio1ClientManagementSystem.Models
{


    //!This class's features are currently under developement.

    public class ClientDailyLog
    {
        [PrimaryKey, AutoIncrement]
        public string entryId { get; set; }

        public DateTime entryTime { get; set; } = DateTime.Now;

        //Navigation property
        public Client Client { get; set; }

        //Foreign Key property
        [ForeignKey("Client")]
        public string Id { get; set; }
    }
}
