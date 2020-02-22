# Sqorm.Console
This is a console application to test **Sqorm** module. This application basically fetches a list of all users in the database mapped to a collection of **User** objects.<br/>
This document walks you through the step-by-step process to run **Sqorm.Console** application. Please go through the document thoroughly.

## .Net Version
netcore 3.1

## Database Setup
You can find Sql scripts each for Sql Server and Postgres in **SqlScripts** folder inside **src** directory. Run these queries against each database server respectively or a db server of your choice. Both of these scripts create a database called **SqormTestDb** where a table called **users** is created with 3 rows populated with mock data. 

## Program.Main method
By default Sqorm.Console application fetches user data from both data servers. There are two methods defined to test data fetch one for each database server type as,
```csharp
System.Console.WriteLine("From Sql Server...");
TestSqlServer();
System.Console.WriteLine("Postgres server...");
TestPostgres();
```
Call only the appropriate method depending on your database server commenting out the other in order to avoid db connection errors. If you setup both data servers previously, no change is needed.<br/>
Please also make sure that you modify the connection strings as per your database configuration.

## Output
To start the console application run the following commands from project directory
```console
Sqorm\src\Sqorm.Console> dotnet restore
Sqorm\src\Sqorm.Console> dotnet build
Sqorm\src\Sqorm.Console> dotnet run
```
If everything goes well, the output should look like the following
```console
From Sql Server...
Id: 1 Username: admin Password: adminpass IsDeleted: False CreatedAt: 2/21/2020 1:30:52 PM
Id: 2 Username: user Password: userpass IsDeleted: False CreatedAt: 2/21/2020 1:30:52 PM
Id: 3 Username: guest Password: guestpass IsDeleted: False CreatedAt: 2/21/2020 1:30:52 PM
From Postgres server...
Id: 1 Username: admin Password: adminpass IsDeleted: False CreatedAt: 2/21/2020 5:16:39 PM
Id: 2 Username: user Password: userpass IsDeleted: False CreatedAt: 2/21/2020 5:16:39 PM
Id: 3 Username: guest Password: guestpass IsDeleted: False CreatedAt: 2/21/2020 5:16:39 PM
```