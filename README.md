# Sentry API client

![CI](https://github.com/olsh/sentry-api-client/workflows/CI/badge.svg)
![Nuget](https://img.shields.io/nuget/v/Io.Sentry.Client)


This is a library for [Sentry web API](https://docs.sentry.io/api/), 
if you are looking for reporting API(submitting events) take a look at the library https://github.com/getsentry/sentry-dotnet

# Getting started


```csharp
// Initialize client with token
var sentryClient = new SentryApiClient(token);

// Gets the first page of projects
var projects = sentryClient.Projects.GetAsync();

// Get all projects
var allProjects = new List<Project>(pagedCollection.Collection);
while (pagedCollection.Pagination.HasNext)
{
    pagedCollection = await client.LoadNextPageAsync(pagedCollection);
    allProjects.AddRange(pagedCollection.Collection);
}
```

# Known issues

Most of the API call is not implemented yet
