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

        private readonly AppDbContext _db;

        public NoteController(AppDbContext db)
        {
            _db = db;

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
            Note newNote = new Note();
            newNote.Title = viewModel.Title;
            newNote.Description = viewModel.Description;
            newNote.StartDate = DateTime.Now;
            newNote.EndDate = viewModel.EndDate;
            newNote.ImageURL = viewModel.ImageURL;
            newNote.isActive = true;
            newNote.priority = viewModel.priority;
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
            var noteTobeArchived = new Note();
            noteTobeArchived.Id = archiveModel.Id;
            noteTobeArchived.Title = archiveModel.Title;
            noteTobeArchived.Description = archiveModel.Description;
            noteTobeArchived.StartDate = archiveModel.StartDate;
            noteTobeArchived.EndDate = archiveModel.EndDate;
            noteTobeArchived.priority = archiveModel.priority;
            noteTobeArchived.isActive = false;
            _db.NoteList.Update(noteTobeArchived);
            _db.SaveChanges();
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
    }
}
