#addin nuget:?package=MyAwesomeCompany.Extensions&version=10.0.0&loaddependencies=true

using MyAwesomeCompany.Extensions;

Task("SubTask")
 .Does(() =>
{
 Information("Running SubTask from subbuild.cake");
});
 