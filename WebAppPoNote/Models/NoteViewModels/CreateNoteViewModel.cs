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

        //[Required]
        //[DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public DateTime StartDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string ImageURL { get; set; }
        public bool priority { get; set; }
    }
}
