using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPoNote.Models.NoteViewModels
{
    public class CreateNoteViewModel
    {
        [Required]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
