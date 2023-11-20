using System.Collections.Generic;

namespace AS.Books
{
    public interface ICatalog<T>
    {
        public List<T> Items { get; }
    }
}