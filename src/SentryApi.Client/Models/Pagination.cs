using System;
using System.Text.RegularExpressions;

namespace SentryApi.Client
{
    public class Pagination
    {
        private static readonly Regex LinkRegex = new Regex(
            "<(?<url>[^>]+)>;\\s*rel=\"(?<rel>[^\"]+)\";\\s*results=\"(?<results>[^\"]+)\"",
            RegexOptions.Compiled);

        internal Pagination()
        {
        }

        internal bool HasNext { get; private set; }

        internal bool HasPrevious { get; private set; }

        internal Uri NextLink { get; private set; }

        internal Uri PreviousLink { get; private set; }

        internal static bool TryParse(string input, out Pagination pagination)
        {
            pagination = new Pagination();

            var parts = input.Split(',');
            if (parts.Length != 2)
            {
                return false;
            }

            foreach (var part in parts)
            {
                var match = LinkRegex.Match(part);
                if (!match.Success)
                {
                    return false;
                }

                if (!bool.TryParse(
                        match.Groups["results"]
                            .ToString(),
                        out var hasResults))
                {
                    return false;
                }

                if (!Uri.TryCreate(
                        match.Groups["url"]
                            .ToString(),
                        UriKind.Absolute,
                        out var link))
                {
                    return false;
                }

                var direction = match.Groups["rel"]
                    .ToString();
                if (direction == "next")
                {
                    pagination.HasNext = hasResults;
                    pagination.NextLink = link;
                }
                else if (direction == "previous")
                {
                    pagination.HasPrevious = hasResults;
                    pagination.PreviousLink = link;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
