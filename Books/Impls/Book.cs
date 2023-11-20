namespace AS.Books
{
    public abstract partial class Book : IBook, ITableLeg, ISellable
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Genre { get; private set; }
        public int PublicationYear { get; private set; }
        public ISBN ISBN { get; private set; }
        public string Text { get; private set; }
        public float Height { get; private set; }
        public float Price { get; private set; }
    }



    public class SmallBook : Book
    {
    }



    public class BigBook : Book
    {
    }



    public class RecyclableBook : Book, IRecyclable
    {
    }
}