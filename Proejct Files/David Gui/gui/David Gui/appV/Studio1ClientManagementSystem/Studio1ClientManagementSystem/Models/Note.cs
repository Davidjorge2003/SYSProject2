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
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int noteId { get; set; }

        [Required(ErrorMessage = "A deadline is required.")]
        [RegularExpression(@"^\d{2}:\d{2}:\d{4}$", ErrorMessage = "Please enter a valid deadline in the format dd:mm:yyyy")]
        public DateOnly noteDeadline { get; set; }
        public DateTime timeOfCreation { get; set; } = DateTime.Now;

        //Navigation properties
        public Admin Admin { get; set; }
        public Employee Employee { get; set; }

        //Foreign Key properties
        [ForeignKey("Admin")]
        public int adminId { get; set; }

        [ForeignKey("Employee")]
        public int employeeId { get; set; }
    }
}
