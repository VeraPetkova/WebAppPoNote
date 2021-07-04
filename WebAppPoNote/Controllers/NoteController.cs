using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppPoNote.Data;
using WebAppPoNote.Models.NoteViewModels;
using Microsoft.AspNetCore.Hosting;

namespace WebAppPoNote.Controllers
{

    public class NoteController : Controller
    {

        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;

        public NoteController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Note> allNotes = _db.NoteList.Where(x => x.isActive == true).OrderByDescending(x => x.Id);
            List<ListNoteViewModel> notesList = new List<ListNoteViewModel>();
            foreach (Note note in allNotes)
            {
                ListNoteViewModel tempListViewModel = new ListNoteViewModel();
                tempListViewModel.Id = note.Id;
                tempListViewModel.Title = note.Title;
                tempListViewModel.Description = note.Description;
                tempListViewModel.StartDate = note.StartDate;
                tempListViewModel.EndDate = note.EndDate;
                notesList.Add(tempListViewModel);
            }
            return View(notesList);
        }

        [HttpGet]
        public IActionResult Archived()
        {
            IEnumerable<Note> allNotes = _db.NoteList.Where(x => x.isActive == false).OrderByDescending(x => x.Id);
            List<ListNoteViewModel> notesList = new List<ListNoteViewModel>();
            foreach (Note note in allNotes)
            {
                ListNoteViewModel tempListViewModel = new ListNoteViewModel();
                tempListViewModel.Id = note.Id;
                tempListViewModel.Title = note.Title;
                tempListViewModel.Description = note.Description;
                tempListViewModel.ImageURL = note.ImageURL;
                tempListViewModel.StartDate = note.StartDate;
                tempListViewModel.EndDate = note.EndDate;
                notesList.Add(tempListViewModel);
            }
            return View(notesList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateNoteViewModel viewModel)
        {
            string filename = Path.GetFileNameWithoutExtension(viewModel.ImageFile.FileName);
            string extension = Path.GetExtension(viewModel.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff")+ extension;
            viewModel.ImageURL = "~/pictures/" + filename;
            //move the file to the server
            filename = Path.Combine(_env.WebRootPath+"/pictures/", filename);
            using( var stream = System.IO.File.Create(filename)) 
            {
                viewModel.ImageFile.CopyTo(stream);
            }
            //create db model, fills up the information from viewmodel and save to the db
            Note newNote = new Note();
            newNote.Title = viewModel.Title;
            newNote.Description = viewModel.Description;
            newNote.StartDate = DateTime.Now;
            newNote.EndDate = viewModel.EndDate;
            newNote.ImageURL = viewModel.ImageURL;
            newNote.isActive = true;
            newNote.priority = viewModel.Priority;
            _db.Add(newNote);
            _db.SaveChanges();
            return Redirect("/Note/index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Note dbNote = _db.NoteList.Find(id);
            DeleteNoteViewModel deleteNote = new DeleteNoteViewModel();
            if (dbNote != null)
            {
                deleteNote.Id = dbNote.Id;
                deleteNote.Title = dbNote.Title;
                deleteNote.Description = dbNote.Description;
            }
            else
            {
                return Redirect("/Note/index/");
            }
            return View(deleteNote);
        }

        [HttpPost]
        public IActionResult Delete(DeleteNoteViewModel deleteModel)
        {
            var noteToBeDeleted = new Note();
            noteToBeDeleted.Id = deleteModel.Id;
            _db.NoteList.Remove(noteToBeDeleted);
            _db.SaveChanges();
            return Redirect("/Note/index");
        }

        [HttpGet]
        public IActionResult Archive(int id)
        {
            Note dbNote = _db.NoteList.Find(id);
            ArchiveNoteViewModel archiveNote = new ArchiveNoteViewModel();
            if (dbNote != null)
            {
                archiveNote.Id = dbNote.Id;
                archiveNote.Title = dbNote.Title;
                archiveNote.Description = dbNote.Description;
                archiveNote.ImageURL = dbNote.ImageURL;
            }
            else
            {
                return Redirect("/Note/index/");
            }
            return View(archiveNote);
        }

        [HttpPost]
        public IActionResult Archive(ArchiveNoteViewModel archiveModel)
        {
            var noteTobeArchived = _db.NoteList.Where(m => m.Id == archiveModel.Id).FirstOrDefault();
            if (noteTobeArchived != null)
            {
                noteTobeArchived.isActive = false;
                _db.NoteList.Update(noteTobeArchived);
                _db.SaveChanges();
            }
            
            return Redirect("/Note/index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            Note dbNote = _db.NoteList.Where(x => x.Id == id).FirstOrDefault();
            if (dbNote != null)
            {
                UpdateNoteViewModel updateNoteModel = new UpdateNoteViewModel();
                updateNoteModel.Id = dbNote.Id;
                updateNoteModel.Title = dbNote.Title;
                updateNoteModel.Description = dbNote.Description;
                updateNoteModel.StartDate = dbNote.StartDate;
                updateNoteModel.EndDate = dbNote.EndDate;
                updateNoteModel.priority = dbNote.priority;
                updateNoteModel.isActive = dbNote.isActive;

                return View(updateNoteModel);
            } 

                return Redirect("/Note/index");
        }
        
        [HttpPost]
        public IActionResult Update(UpdateNoteViewModel updateModel)
        {
            Note updateNote = new Note();
            updateNote.Id = updateModel.Id;
            updateNote.Title = updateModel.Title;
            updateNote.Description = updateModel.Description;
            updateNote.ImageURL = updateModel.ImageURL;
            updateNote.StartDate = DateTime.Now;
            updateNote.EndDate = updateModel.EndDate;
            updateNote.isActive = true;
            _db.Update(updateNote);
            _db.SaveChanges();
            return Redirect("/Note/index");
        }

        [HttpGet]
        public IActionResult FullView(int id)
        {
            IEnumerable<Note> cNote = _db.NoteList.Where(x => x.Id == id);
            return View(cNote);
        }

        //[HttpGet]
        //public ActionResult Add()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Add(Image)
    }
}
