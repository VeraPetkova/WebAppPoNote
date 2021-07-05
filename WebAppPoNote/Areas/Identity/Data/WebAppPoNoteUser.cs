using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebAppPoNote.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the WebAppPoNoteUser class
    public class WebAppPoNoteUser : IdentityUser
    {
        public virtual ICollection<Note> Notes { get; set; }
    }
}
