using System;

namespace SentryApi.Client.IntegrationTests.Helpers
{
    internal static class SentryApiClientFactory
    {
        public static SentryApiClient Create()
        {
            var token = Environment.GetEnvironmentVariable("sentry-token");

            return new SentryApiClient(token);
        }
    }
}
