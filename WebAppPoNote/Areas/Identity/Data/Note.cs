using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPoNote.Areas.Identity.Data
{
    public class Note
    {

        [Key]
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageURL { get; set; }
        public bool priority { get; set; }
        public bool isActive { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual WebAppPoNote.Areas.Identity.Data.WebAppPoNoteUser CertainUser { get; set; }
    }
}
