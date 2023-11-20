namespace AS.Books
{
    public partial class Book
    {
        //Example. In reality, objects must be created from data
        public static TBook[] NewBooks<TBook>(string name, float height, float price, int count) where TBook : Book, new() {
            var books = new TBook[count];

            for (int i = 0; i < count; i++) {
                books[i] = new TBook {
                    Title = $"{name}Title_{i}",
                    Author = $"{name}Author_{i}",
                    Genre = $"{name}Author_{i}",
                    PublicationYear = 1980,
                    ISBN = new ISBN(),
                    Text = $"{name}Text_{i}",
                    Height = height,
                    Price = price
                };
            }

            return books;
        }
    }
}