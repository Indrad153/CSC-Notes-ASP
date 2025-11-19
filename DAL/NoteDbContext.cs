using Microsoft.EntityFrameworkCore;
using CSCNotes.Models;

namespace CSCNotes.DAL
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<NotesModel> notes_Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

