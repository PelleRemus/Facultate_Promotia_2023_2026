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
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Books)          // relatie one-to-many, o persoana are multe carti
                .WithRequired(b => b.Author)    // relatie many-to-one, fiecare carte are un singur autor
                .HasForeignKey(b => b.AuthorId);// proprietatea prin care se face relatia
        }
    }
}
