using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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
        public bool Priority { get; set; }

        public IFormFile ImageFile { get; set; }

        public string Id { get; set; }

        [ForeignKey("Id")]
        public virtual WebAppPoNote.Areas.Identity.Data.WebAppPoNoteUser CertainUser { get; set; }
    }
}
