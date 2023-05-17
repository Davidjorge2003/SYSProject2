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
    public class Prescription
    {
        [PrimaryKey, AutoIncrement]
        public int prescriptionId { get; set; }

        [Required(ErrorMessage = "A prescription is required.")]
        [RegularExpression(@"^\w+$", ErrorMessage = "A prescription must contain only letters and numbers.")]
        public string prescriptionName { get; set; }

        //Navigation property
        public Client Client { get; set; }

        //Foreign Key property
        public int Id { get; set; }
    }
}
