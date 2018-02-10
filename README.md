# ASP.NET Core 2.0 - GetUserIdAsync() returning null with Guid Ids

This repo demonstrates an issue I am experiencing where GetUserIdAsync() returns null
when using Guid Ids in ASP.NET Core 2.0 Identity.

You can reproduce this error by running the code in this repo as follows:

    dotnet restore
    dotnet build
    dotnet run

Now go to http://localhost:5001/register and fill out the form, after which you should see
this exception:

    System.ArgumentNullException: Value cannot be null.
    Parameter name: value
       at System.IO.BinaryWriter.Write(String value)
       at Microsoft.AspNetCore.Identity.DataProtectorTokenProvider`1.&lt;GenerateAsync&gt;d__11.MoveNext()

The StackOverflow post associated with this repo is available at
https://stackoverflow.com/questions/48722020/asp-net-core-2-getuseridasync-returning-null-result-with-guid-ids

