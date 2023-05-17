using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio1ClientManagementSystem.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int employeeId { get; set; }

        [Required(ErrorMessage = "A username is required.")]
        [RegularExpression(@"^\w+$", ErrorMessage = "Username must contain only letters or numbers.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 20 characters long.")]
        public string employeeUsername { get; set; }

        public DateTime registrationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "A password is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_\-\!\#\$\%\&\*]", ErrorMessage = "Invalid character found in password.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 20 characters long.")]
        public string temporaryPasswordVariableE { get; set; }





    }
}
