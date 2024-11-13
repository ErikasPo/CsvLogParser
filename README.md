# CsvLogParser Danske Bank Task

## Table of Contents
* [Introduction](#Introduction)
* [Getting Started](#Getting-Started)
* [Bonus points](##Bonus-points:)
* [About the Project](#about-the-project)
* [Prerequisites](#prerequisites)
* [How to Run](#how-to-run)
* [Suggestions for Improvement](#suggestions-for-improvement)
* [Author](author)


# Introduction 
Create a console application what would parse a log csv file and print out logs based on a custom query. Use the attached csv file to work with.

# Getting Started
TODO:
1. Build a solution that is able to search any column by full or partial text string. Example: "signatureId=’Microsoft-Windows-Security-Auditing:4608’“ or "signatureId=’*4608*’“  should return all the logs from the file. This functionality should work with all columns. if column is not found return "column not found.  Query should be provided by user input. Query syntax can be in free form. Example:  
[column_name = ‘search_string’] or [select FROM collum_name WHERE text=’search_string’]
2. Results from the query should be combined and returned in JSON format. Example see bellow.
3. Please provide some project structure. It is not necessary to split it into different *.csproj but different folders.

## Bonus points:
* Add Boolean logical operator support in the queries (and, or, not...);
* Add multiple file support;
* Add log count value in the resulting JSON output;


## More bonus points:
* Improvements are welcome 😊. For example: Deal with duplicates, combine results in a more readable format.
* Implement database layer. Save results in a database of your choice.
* Implement options to send alerts based on the severity of the log. No need to actually send the notification, you can use Console.WriteLine().
* Dynamic log parsing. Logs can have different columns, how would you attend to this?
  
## About the Project
- This project was built using .NET 8.0 Framework, it is a console application.
- This is application imports logs from CSV file into MS SQL Server database.
- You can search imported logs from the database by using query "ColumnName = SearchKeyWord", you can use asterisks (*) in the search term to perform wildcard searches, once search is inputed it returns results in JSON format.

## How to Run

- Download the solution from the repository to your local machine.
- Open the solution using Microsoft Visual Studio 2022.
- Firstly set the file path to the file you would like to parse by opening App.config file and changing key, 
- Then set the connection string for SQL server and database by opening App.config file and changing connectionString appropriately.
- Once you set connection string you would need to perform database migration, by opening Package Manager Console, in Visual Studio on the top menu click Tools -> Package Manager Console.
- Once you open the package manager console type in "Update-Database -Migration 20241112180639_InitialCreate" and click enter, database with the Logs table should be created.
- Click on the "Green play button" CsvParser to start or click F5.
- Once the file is imported, please type in the search query by following syntax "ColumnName = SearchKeyWord" and click enter to get the logs.

## Prerequisites
* Microsoft Visual Studio 2022
* .NET 8.0
* NuGet packages: Newtonsoft.Json 13.0.3
                  Microsoft.EntityFrameworkCore 9.0.0
                  Microsoft.EntityFrameworkCore.SqlServer 9.0.0
                  Microsoft.EntityFrameworkCore.Tools 9.0.0
                  System.Linq 4.3.0
                  System.Configuration.ConfigurationManager 9.0.0

## Author

<strong>Erikas Pomeliaika</strong>
