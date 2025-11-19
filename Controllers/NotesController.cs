using Microsoft.AspNetCore.Mvc;
using CSCNotes.Models;
using CSCNotes.Repo;

namespace CSCNotes.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteRepo repo;

        public NotesController(INoteRepo _repo)
        {
            repo = _repo;
        }

        public async Task<IActionResult> Index()
        {
            var note = await repo.GetAll_Async();
            return View(note);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Notes_Title, Notes_Content")] NotesModel notesModel)
        {
            if (ModelState.IsValid)
            {
                await repo.Add_Async(notesModel);
                return RedirectToAction(nameof(Index));
            }

            return View(notesModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var note = await repo.GetID_Async(id);
            if (note == null) return NotFound();
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UID, Notes_Title, Notes_Content, Notes_Create_Time")] NotesModel notesModel)
        {
            if (id != notesModel.UID)
                return BadRequest();

            if (ModelState.IsValid)
            {
                notesModel.UpdateTime = DateTime.UtcNow;
                await repo.Update_Async(notesModel);
                return RedirectToAction(nameof(Index));
            }

            return View(notesModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var note = await repo.GetID_Async(id);
            if (note == null) return NotFound();
            return View(note);
        }

        [HttpPost, ActionName("ConfirmDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Console.WriteLine("Deleting ID = " + id);

            await repo.Delete_Async(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
