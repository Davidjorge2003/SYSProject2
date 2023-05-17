using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio1ClientManagementSystem.Models
{
    public class PaymentRecord
    {
        [PrimaryKey, AutoIncrement]
        public int paymentId { get; set; }

        [Required(ErrorMessage = "A payment method is required.")]
        [RegularExpression(@"^[A-Za-z]$", ErrorMessage = "A payment record must contain only letters.")]
        public string paymentMethod { get; set; }

        [Required(ErrorMessage = "A cardholder's name is required.")]
        [RegularExpression(@"^[A-Za-z]$", ErrorMessage = "A cardholder's name must contain only letters.")]
        public string cardholderName { get; set; }

        [Required(ErrorMessage = "A card number is required.")]
        [RegularExpression(@"^[0-9]$", ErrorMessage = "A card number name must contain only numbers.")]
        public string cardNumber { get; set; }

        [Required(ErrorMessage = "An expiry date is required.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])[/]\d{2}$", ErrorMessage = "Please enter a valid expiry date with the format 'MM/YY'.")]
        public DateOnly expirationDate { get; set; }

        [Required(ErrorMessage = "A cvc code is required.")]
        [Range(100, 9999, ErrorMessage = "A cvc code must be a value between a 3 or 4 digit number")]
        public string cvc { get; set; }

        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "A fee must be a valid monetary value with up to two decimal places.")]
        public decimal? membershipFee { get; set; }

        [Required(ErrorMessage = "A membership type is required.")]
        [RegularExpression(@"^[A-Za-z]$", ErrorMessage = "A membership type must contain only letters.")]
        public string membershipType { get; set; }

        [Required(ErrorMessage = "A membership amount is required.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "A membership amount must be a valid monetary value with up to two decimal places.")]
        public decimal membershipAmount { get; set; }

        //Navigation property
        public Client client { get; set; }

        //Foreign Key property
        [ForeignKey("Client")]
        public int Id { get; set; }

    }
}
