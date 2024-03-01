namespace Platender.Front.Helpers
{
    public class PagedData<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItems { get; set; }

        public PagedData(
            IEnumerable<T> items,
            int totalItems)
        {
            Items = items;
            TotalItems = totalItems;
        }
    }
}
