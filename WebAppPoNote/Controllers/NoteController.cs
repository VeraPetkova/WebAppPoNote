using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPoNote.Data;
using WebAppPoNote.Models.NoteViewModels;

namespace WebAppPoNote.Controllers
{
    public class NoteController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateNoteViewModel viewModel)
        {
            Note newNote = new Note();
            newNote.Title = viewModel.Title;
            newNote.Description = viewModel.Description;
            //AppDbContext.notes.add(newNote);
            return Redirect("/Note/index");
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var a = id;
            return View();
        }
    }
}
