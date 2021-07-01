using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppPoNote.Models;

namespace WebAppPoNote.Data
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ImageURL { get; set; }
        public bool priority { get; set; }
        public bool isActive { get; set; }
    }

}
