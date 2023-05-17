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
    public class Instructor
    {
        [PrimaryKey, AutoIncrement]
        public int instructorPairId { get; set; }

        [Required(ErrorMessage = "An instructor is required.")]
        [RegularExpression(@"^[A-Za-z]$", ErrorMessage = "An instructor's name must contain only letters.")]
        public string instructorName { get; set; }

        //Navigation property
        public _Class Class { get; set; }

        //Foreign Key property
        [ForeignKey("Class")]
        public int classId { get; set; }


    }
}
