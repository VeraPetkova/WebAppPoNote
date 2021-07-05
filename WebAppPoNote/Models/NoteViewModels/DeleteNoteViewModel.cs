using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPoNote.Models.NoteViewModels
{
    public class DeleteNoteViewModel
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
