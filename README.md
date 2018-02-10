# ASP.NET Core 2.0 - `GetUserIdAsync()` returning `null` with `Guid` ids

This repo demonstrates an issue I am experiencing where `GetUserIdAsync()` returns null
when using `Guid` ids in ASP.NET Core 2.0 Identity.

To run this project and reproduce the error, you will need to first create a database
in SQL Server and modify the details in `appsettings.json` accordingly, then run the
following commands in `GetUserIdAsyncNullExample/`:

    dotnet restore
    dotnet build
    dotnet ef database update
    dotnet run

Now go to http://localhost:5001/register and fill out the form, after which you should see
this exception:

    System.ArgumentNullException: Value cannot be null.
    Parameter name: value
       at System.IO.BinaryWriter.Write(String value)
       at Microsoft.AspNetCore.Identity.DataProtectorTokenProvider`1.&lt;GenerateAsync&gt;d__11.MoveNext()

The StackOverflow post associated with this repo is available at
https://stackoverflow.com/questions/48722020/asp-net-core-2-getuseridasync-returning-null-result-with-guid-ids

