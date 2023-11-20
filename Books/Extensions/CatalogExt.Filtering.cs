using System.Collections.Generic;

namespace AS.Books
{
    //Extensions for filtering catalog data
    public static partial class CatalogExt
    {
        public delegate bool FilterDelegate<T>(T item);


        public static IEnumerable<T> All<T>(this ICatalog<T> catalog, FilterDelegate<T> filter) {
            for (int i = 0, iCount = catalog.Items.Count; i < iCount; i++) {
                var item = catalog.Items[i];
                if (filter(item)) {
                    yield return item;
                }
            }
        }


        public static T FirstOrDefault<T>(this ICatalog<T> catalog, FilterDelegate<T> filter) {
            for (int i = 0, iCount = catalog.Items.Count; i < iCount; i++) {
                var item = catalog.Items[i];
                if (filter(item)) {
                    return item;
                }
            }

            return default;
        }


        public static T RandomItem<T>(this ICatalog<T> catalog) {
            var rnd = UnityEngine.Random.Range(0, catalog.Items.Count);
            return catalog.Items[rnd];
        }


        public static bool TryGetFirst<T>(this ICatalog<T> catalog, FilterDelegate<T> filter, out T result) {
            for (int i = 0, iCount = catalog.Items.Count; i < iCount; i++) {
                var item = catalog.Items[i];
                if (filter(item)) {
                    result = item;
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}