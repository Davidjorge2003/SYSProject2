using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio1ClientManagementSystem.Models
{


    //!This class's features are still under developement
    public class UserLog
    {
        [PrimaryKey, AutoIncrement]
        public int loginId { get; set; }


        public DateTime timeOfLogin { get; set; }
        public string activity { get; set; }

        //Navigation properties
        public Admin Admin { get; set; }
        public Employee Employee { get; set; }

        //Foreign Key properties
        [ForeignKey("Employee")]
        public int employeeId { get; set; }

        [ForeignKey("Admin")]
        public string adminId { get; set; }
    }
}
