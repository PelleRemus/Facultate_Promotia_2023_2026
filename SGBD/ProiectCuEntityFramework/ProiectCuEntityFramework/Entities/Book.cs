namespace ProiectCuEntityFramework.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public Person Author { get; set; }
        public string Publisher { get; set; }

        public override string ToString()
        {
            return Id + ". " + Title + ".\n"
                + Author?.Name + "\n"
                + Description
                + ".\nPublisher: " + Publisher;
        }
    }
}
