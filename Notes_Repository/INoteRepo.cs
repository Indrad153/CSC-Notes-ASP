using CSCNotes.Models;

namespace CSCNotes.Repo
{
    public interface INoteRepo
    {
        Task<IEnumerable<NotesModel>> GetAll_Async();
        Task<NotesModel> GetID_Async(int uid);
        Task Add_Async(NotesModel notes_Model);
        Task Update_Async(NotesModel notes_Model);
        Task Delete_Async(int uid);
    }
}