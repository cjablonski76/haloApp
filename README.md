# haloApp

**Sources**
Setting up Angular with .NetCore Web Api: https://medium.com/@levifuller/building-an-angular-application-with-asp-net-core-in-visual-studio-2017-visualized-f4b163830eaa
setting up EntityFrameworkCore.InMemory https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-vsc


To Run:
From halo.serverdirectory
    run: set ASPNETCORE_ENVIRONMENT=Development
    run: dotnet watch run
    Development environment is currently necessary in order to read in the secret halo api key. A production strategy for storing this key has not been written yet.
From halo.client directory run: ng serve
Go to **localhost:4000**


