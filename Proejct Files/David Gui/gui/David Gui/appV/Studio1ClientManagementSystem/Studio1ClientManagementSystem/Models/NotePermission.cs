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
    public class NotePermission
    {
        [PrimaryKey, AutoIncrement]
        public int permissionId { get; set; }

        [Required(ErrorMessage = "A permission is required.")]
        public bool viewPermission { get; set; }

        //Navigation property
        public Note Note { get; set; }

        //Foreign Key property
        public int noteId { get; set; }

    }
}
