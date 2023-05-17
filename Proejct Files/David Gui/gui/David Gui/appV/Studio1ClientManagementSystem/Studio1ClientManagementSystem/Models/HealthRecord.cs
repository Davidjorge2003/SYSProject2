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
    public class HealthRecord
    {
        [PrimaryKey, AutoIncrement]
        public int healthId { get; set; }

        [Required(ErrorMessage = "A value is required.")]
        public bool hasHeartConditions { get; set; }

        [Required(ErrorMessage = "A value is required.")]
        public bool hasChestPain { get; set; }

        [Required(ErrorMessage = "A value is required.")]
        public bool hasDizzinessOrNausea { get; set; }

        [Required(ErrorMessage = "A value is required.")]
        public bool hasJointOrBonePain { get; set; }

        [StringLength(200, ErrorMessage = "Specifications must be below 200 characters in length.")]
        public string? specifications { get; set; }

        //Navigation property
        public Client Client { get; set; }

        //Foreign Key property
        [ForeignKey("Client")]
        public int Id { get; set; }

    }
}
