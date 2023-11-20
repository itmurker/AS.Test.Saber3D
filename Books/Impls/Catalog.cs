using System.Collections.Generic;
using System.Linq;

namespace AS.Books
{
    public class Catalog<T> : ICatalog<T>
    {
        public List<T> Items { get; }


        public Catalog(params T[] items) {
            Items = items.ToList();
        }
    }
}