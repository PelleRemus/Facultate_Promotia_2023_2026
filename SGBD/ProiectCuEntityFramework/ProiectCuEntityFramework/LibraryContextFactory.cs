using System.Data.Entity.Infrastructure;

namespace ProiectCuEntityFramework
{
    public class LibraryContextFactory : IDbContextFactory<LibraryContext>
    {
        public LibraryContext Create()
        {
            return new LibraryContext("Server=localhost;Database=biblioteca;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
