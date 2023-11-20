using System.Collections.Generic;

namespace AS.Books
{
    //Extensions for filling catalog data
    public static partial class CatalogExt
    {
        public static void Add<TCatalog, TItem>(this TCatalog catalog, TItem item) where TCatalog : ICatalog<TItem> {
            catalog.Items.Add(item);
        }


        public static void Add<TCatalog, TItem>(this TCatalog catalog, IReadOnlyList<TItem> items) where TCatalog : ICatalog<TItem> {
            catalog.Items.AddRange(items);
        }
    }
}