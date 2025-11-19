using System.ComponentModel.DataAnnotations;

namespace CSCNotes.Models
{
    public class NotesModel
    {
        [Key]
        public int UID { get; set; }

        [StringLength(200)]
        public string Notes_Title { get; set; }

        public string Notes_Content { get; set; }

        public DateTime Notes_Create_Time { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateTime { get; set; }

        public enum Importance
        {
            low = 1,
            Med = 2,
            High = 3
        }

        public Importance _Importance { get; set; }

    }
}