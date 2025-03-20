using System.Collections.Generic;

namespace ProiectCuEntityFramework.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
