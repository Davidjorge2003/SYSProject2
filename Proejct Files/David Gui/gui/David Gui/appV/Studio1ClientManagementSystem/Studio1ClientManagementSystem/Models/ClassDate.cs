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
    public class ClassDate
    {
        [PrimaryKey, AutoIncrement]
        public int datePairId { get; set; }

        [Required(ErrorMessage = "A date is required.")]
        [RegularExpression(@"^\d{2}:\d{2}:\d{4}$", ErrorMessage = "Please enter a valid class date in the format dd:mm:yyyy")]
        public DateOnly classDate { get; set; }

        //Navigation property
        public _Class Class { get; set; }

        //Foreign Key property
        [ForeignKey("Class")]
        public string classId { get; set; }
    }
}
