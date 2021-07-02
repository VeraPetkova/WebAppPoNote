using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPoNote.Models.NoteViewModels
{
    public class UpdateNoteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageURL { get; set; }
        public bool priority { get; set; }
        public bool isActive { get; set; }
    }
}
