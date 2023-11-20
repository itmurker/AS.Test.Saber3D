namespace AS.Books
{
    public interface IBook
    {
        public string Title { get; }
        public string Author { get; }
        public string Genre { get; }
        public int PublicationYear { get; }
        public ISBN ISBN { get; }
        public string Text { get; }
    }



    //International Standard Book Number (ISBN)
    public struct ISBN
    {
        //fields...
    }
}