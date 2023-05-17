using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio1ClientManagementSystem.Models
{
    public class Client
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required(ErrorMessage = "A first name is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "A first name must contain only letters.")]
        public string fName { get; set; }

        [Required(ErrorMessage = "A last name is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "A last name must contain only letters.")]
        public string lName { get; set; }

        [Required(ErrorMessage = "An address is required.")]
        public string address  { get; set; }

        [Required(ErrorMessage = "A city is required.")]
        public string city { get; set; }

        [Required(ErrorMessage = "A postal code is required.")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Please enter a valid postal code in the format 'A1A 1A1'.")]
        public string postalCode { get; set; }

        [Required(ErrorMessage = "A telephone is required.")]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Please enter a valid telephone number in the format '(111) 111-1111'.")]
        public string telephoneNumber { get; set; }

        [Required(ErrorMessage = "A date of birth is required.")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "Please enter a valid date of birth in the format 'dd/mm/yyyy'.")]
        public DateTime dateOfBirth { get; set; }

        [Required(ErrorMessage = "An expiration date is required.")]
        [RegularExpression(@"^\d{2}:\d{2}:\d{4}$", ErrorMessage = "Please enter a valid expiration date in the format 'dd:mm:yyyy'")]
        public DateTime membershipExpirationDate { get; set; }
        public DateTime membershipCreationDate { get; set; } = DateTime.Now;

        [StringLength(300, ErrorMessage = "Fitness goals must be below 300 characters in length.")]
        public string fitnessGoals { get; set; }

        public string membershipStatus
        {
            get
            {
                var now = DateTime.Now.Date;
                var expiration = membershipExpirationDate.Date;

                if (now > expiration)
                {
                    return "Expired";
                }
                else if (expiration < now.AddDays(30))
                {
                    return "Soon to Expire";
                }
                else
                {
                    return "Valid";
                }

            }
        }
    }
}
