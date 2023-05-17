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
    public class _Class
    {
        [PrimaryKey, AutoIncrement]
        public int classId { get; set; }

        [Required(ErrorMessage = "A title is required.")]
        [StringLength(50, ErrorMessage ="Title must be below 50 characters in length.")]
        public string title { get; set; }

        [StringLength(200, ErrorMessage = "Description must be below 200 characters in length.")]
        public string? description { get; set; }

        [Required(ErrorMessage = "A start time is required.")]
        [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$",ErrorMessage = "Please enter a valid time in the format hh:mm:ss.")]
        public TimeOnly startTime { get; set; }

        [Required(ErrorMessage = "An end time is required.")]
        [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$", ErrorMessage = "Please enter a valid time in the format hh:mm:ss.")]
        public TimeOnly endTime { get; set; }

        //Navigation property
        public Client Client { get; set; }

        //Foreign Key property
        [ForeignKey("Client")]
        public int Id { get; set; }


    }
}
