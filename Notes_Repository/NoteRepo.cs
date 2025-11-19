using Microsoft.EntityFrameworkCore;
using CSCNotes.DAL;
using CSCNotes.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace CSCNotes.Repo
{
    public class NoteRepo : INoteRepo
    {
        private readonly NotesDbContext notesDbContext;

        public NoteRepo(NotesDbContext notesDb)
        {
            notesDbContext = notesDb;
        }

        public async Task<IEnumerable<NotesModel>> GetAll_Async()
        {
            return await notesDbContext.notes_Models.OrderByDescending(x => x.Notes_Create_Time).ToListAsync();
        }

        public async Task<NotesModel> GetID_Async(int id)
        {
            return await notesDbContext.notes_Models.FindAsync(id);
        }

        public async Task Add_Async(NotesModel notesModel)
        {
            notesDbContext.notes_Models.Add(notesModel);
            await notesDbContext.SaveChangesAsync();
        }

        public async Task Update_Async(NotesModel notesModel)
        {
            notesDbContext.notes_Models.Update(notesModel);
            await notesDbContext.SaveChangesAsync();
        }

        public async Task Delete_Async(int id)
        {
            var note = await notesDbContext.notes_Models.FindAsync(id);
            if (note != null)
            {
                notesDbContext.Remove(note);
                await notesDbContext.SaveChangesAsync();
            }
        }
    }
}