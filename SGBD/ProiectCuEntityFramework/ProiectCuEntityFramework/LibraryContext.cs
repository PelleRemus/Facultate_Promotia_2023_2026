using ProiectCuEntityFramework.Entities;
using System.Data.Entity;

namespace ProiectCuEntityFramework
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
        }
    }
}
