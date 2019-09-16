using System.Collections.Generic;

namespace SentryApi.Client
{
    public class PagedCollection<T>
    {
        public IReadOnlyCollection<T> Collection { get; internal set; }

        public Pagination Pagination { get; internal set; }
    }
}
