# Sqorm.Console
This is a web api application to test **Sqorm** module. This api exposes two methods to save a user and fetch a list of all users in the database.<br/>
This document walks you through the step-by-step process to run **Sqorm.WebApi** project. Please go through the document thoroughly.

## .Net Version
netcore 3.1

## Dependencies
- Swashbuckle.AspNetCore v5.0.0

## Database Setup
You can find Sql scripts each for Sql Server and Postgres in **SqlScripts** folder inside **src** directory. Run these queries against each database server respectively or a db server of your choice. Both of these scripts create a database called **SqormTestDb** where a table called **users** is created with 3 rows populated with mock data. 

## Inject Database Client Dependencies
**Sqorm** provides following two db clients for SqlServer and Postgres databases respectively,
- **SqlSerConnection : IDatabaseConnection**
- **PostgresConnection : IDatabaseConnection**
<br/>
Both of these db clients implement a common interface **IDatabaseConnection**. Following sub-sections talk about injecting dependencies in the web api project for each of the clients.

### SqlServerConnection
To inject dependency for **SqlServerConnection** add following line inside **ConfigureServices** method of **Startup.cs** class.<br/>
```csharp
public void ConfigureServices(IServiceCollection services)
{
    // additional service config here

    // inject sql server connection dependency
    services.AddTransient<IDatabaseConnection>(c => new SqlServerConnection("Sql Server Connection String"));
}
```

### PostgresConnection
To inject dependency for **PostgresConnection** add following line inside **ConfigureServices** method of **Startup.cs** class.<br/>
```csharp
public void ConfigureServices(IServiceCollection services)
{
    // additional service config here

    // inject sql server connection dependency
    services.AddTransient<IDatabaseConnection>(c => new PostgresConnection("Postgres Connection String"));
}
```

## Output
To start the web api, run the following commands from project directory
```console
Sqorm\src\Sqorm.WebApi> dotnet restore
Sqorm\src\Sqorm.WebApi> dotnet build
Sqorm\src\Sqorm.WebApi> dotnet run
```
If everything goes well, the output should look like the following
```console
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: \Sqorm\src\Sqorm.WebApi
```
On the browser of your choice, enter "https://localhost:5001". You should see a swagger page, listing available endpoints for you to test.