/*
 *  Alexey Shnigir's test job for Saber3d.
 *
 *  Project structure:
 *      - Interfaces:
 *          1. IBook
 *          2. ICatalog<TItem>
 *          3. IRecyclable
 *          4. ISellable
 *          5. ITable, ITableLeg
 *      - Abstracts:
 *          1. Book
 *      - Implementations"
 *          1. SmallBook
 *          2. BigBook
 *          3. RecyclableBook
 *          5. Table
 *          6. Catalog<TItem>
 *      - EntryPoint:
 *          1. Main.Init
 *
 * 
 *  Suggested Improvements:
 *      1. Remove code that trigger GC
 *      2. Add unique clearing and selling behaviors to IRecyclable, ISellable
 *      3. Maybe add new class-managers for clearing, selling and search
 *      4. Data storage and books creation from serialized data
 *      5. And more...
 */

using UnityEngine;

namespace AS.Books
{
    public class Main
    {
        private const float TABLE_HEIGHT = 0.15f;
        private const float CASH = 50f;
        
        private const float SMALL_BOOK_PRICE = 15f;
        private const float BIG_BOOK_PRICE = 15f;
        private const float RECYCLABLE_BOOK_PRICE = 45f;
        
        private const float SMALL_BOOK_HEIGHT = 0.03f;
        private const float BIG_BOOK_HEIGHT = TABLE_HEIGHT;
        private const float RECYCLABLE_BOOK_HEIGHT = 0.05f;
        
        


        public void Init() {
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            //Cataloging
            var catalog = new Catalog<Book>();

            var smallBooks = Book.NewBooks<SmallBook>("Small", SMALL_BOOK_HEIGHT, SMALL_BOOK_PRICE, 5);
            var bigBooks = Book.NewBooks<BigBook>("Big", BIG_BOOK_HEIGHT, BIG_BOOK_PRICE, 1);
            var recyclableBooks = Book.NewBooks<RecyclableBook>("Recyclable", RECYCLABLE_BOOK_HEIGHT, RECYCLABLE_BOOK_PRICE, 10);

            catalog.Add<Catalog<Book>, Book>(smallBooks);
            catalog.Add<Catalog<Book>, Book>(bigBooks);
            catalog.Add<Catalog<Book>, Book>(recyclableBooks);



            //------------------------------------------------------------------------------------------------------------------------------------------------------
            //Get some books for sale
            bool FindBookForSell(Book b) => b.Price <= CASH;
            if (catalog.TryGetFirst(FindBookForSell, out var bookForSell)) {
                //selling 'bookForSell'
            }



            //------------------------------------------------------------------------------------------------------------------------------------------------------
            //Table assembly
            var tableLeg1 = new TableLeg(TABLE_HEIGHT);
            var tableLeg2 = new TableLeg(TABLE_HEIGHT);

            //Stacking small books to make a leg
            var tableLeg3 = new CompositeTableLeg(smallBooks);

            //Using a big book as a table leg
            bool FindBookForLeg(Book b) => Mathf.Approximately(b.Height, TABLE_HEIGHT);
            var tableLeg4 = catalog.FirstOrDefault(FindBookForLeg); //Using a big book as a table leg

            //Make and check table
            var table = new Table(tableLeg1, tableLeg2, tableLeg3, tableLeg4);
            if (table.IsStable()) {
                //Cheers!
            }



            //------------------------------------------------------------------------------------------------------------------------------------------------------
            //Find in text
            var book = catalog.RandomItem();
            //Use 'book.Text' for search info



            //------------------------------------------------------------------------------------------------------------------------------------------------------
            //Recyclable book disposal
            foreach (var item in catalog.All(b => b is IRecyclable)) {
                //...
            }
        }
    }
}