using System;

namespace SentryApi.Client
{
    public class EventRequest : SentryRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventRequest" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="organizationSlug">The organization slug.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <exception cref="ArgumentException">Value cannot be null or empty. - id</exception>
        public EventRequest(string id, string organizationSlug, string projectSlug)
            : base(organizationSlug, projectSlug)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Gets the identifier of the requested event.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; }
    }
}
