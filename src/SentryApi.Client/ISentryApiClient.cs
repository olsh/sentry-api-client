using System.Threading.Tasks;

namespace SentryApi.Client
{
    public interface ISentryApiClient
    {
        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        IEventService Events { get; }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <value>
        /// The projects.
        /// </value>
        IProjectService Projects { get; }

        /// <summary>
        /// Loads the next page asynchronous.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>The next page.</returns>
        Task<PagedCollection<T>> LoadNextPageAsync<T>(PagedCollection<T> collection);

        /// <summary>
        /// Loads the previous page asynchronous.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>The next page.</returns>
        Task<PagedCollection<T>> LoadPreviousPageAsync<T>(PagedCollection<T> collection);
    }
}
