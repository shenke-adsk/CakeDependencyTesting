   // Add necessary Cake modules and tools
   
   #module nuget:?package=Cake.DotNetTool.Module&version=0.4.0
   #tool nuget:?package=NuGet.CommandLine&version=5.11.0
   
   #load "builder/internals_recipes_myawesomecompany_extensions.cake"

   var target = Argument("target", "Default");

   Task("Clean")
       .Does(() =>
   {
       CleanDirectory("./artifacts");
   });

   Task("Restore")
       .IsDependentOn("Clean")
       .Does(() =>
   {
       // Restore NuGet packages
       DotNetCoreRestore("MyCliApp/MyCliApp.csproj");
   });

   Task("InstallPackages")
       .IsDependentOn("Restore")
       .Does(() =>
   {
       // Add Newtonsoft.Json package
       StartProcess("nuget", "install Newtonsoft.Json -OutputDirectory ./packages");
   });

   Task("Build")
       .IsDependentOn("InstallPackages")
       .Does(() =>
   {
       DotNetCoreBuild("MyCliApp/MyCliApp.csproj", new DotNetCoreBuildSettings
       {
           Configuration = "Release"
       });
   });
   
   // Define a task that depends on SubTask from subbuild.cake
   Task("RunSubTask")
       .IsDependentOn("Build");

   Task("Default")
       .IsDependentOn("Build");

   RunTarget(target);
   