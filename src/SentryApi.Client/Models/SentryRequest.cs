using System;

namespace SentryApi.Client
{
    public class SentryRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SentryRequest"/> class.
        /// </summary>
        /// <param name="organizationSlug">The organization slug.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <exception cref="ArgumentException">
        /// Value cannot be null or empty. - organizationSlug
        /// or
        /// Value cannot be null or empty. - projectSlug
        /// </exception>
        public SentryRequest(string organizationSlug, string projectSlug)
        {
            if (string.IsNullOrEmpty(organizationSlug))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(organizationSlug));
            }

            if (string.IsNullOrEmpty(projectSlug))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(projectSlug));
            }

            OrganizationSlug = organizationSlug;
            ProjectSlug = projectSlug;
        }

        /// <summary>
        /// Gets the organization slug.
        /// </summary>
        /// <value>
        /// The organization slug.
        /// </value>
        public string OrganizationSlug { get; }

        /// <summary>
        /// Gets the project slug.
        /// </summary>
        /// <value>
        /// The project slug.
        /// </value>
        public string ProjectSlug { get; }
    }
}
