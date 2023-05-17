using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio1ClientManagementSystem.Models
{
    public class ClientClassPair
    {
        //Navigation properties
        public Client Client { get; set; }
        public _Class Class { get; set; }



        [ForeignKey("Client")]
        public int Id { get; set; }

        [ForeignKey("Class")]
        public int classId { get; set; }


    }
}
