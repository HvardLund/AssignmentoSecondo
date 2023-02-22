# AssignmentoSecondo
AssignmentoSecondo consists of two parts. The first part of the project is a set of sql queries that create and populate a database of superheroes. The second part includes a C# console application that accesses a customer database for a music store using SQL Client. 

## Installation
For the C# application to work, Microsoft.Data.SqlClient should be installed using NuGet package manager:
https://www.nuget.org/packages/Microsoft.Data.SqlClient

## Usage
Database transactions supported by the console application:

Return a single instance from the database by id: GetCustomerById
Return a single instance from the database by name: GetCustomerByName
Return a single instance from the database by name: GetCustomersByCountry
Return the customer in the database that has spent the highest amount: GetCustomersByBiggestSpender
Return the favourite genre of a customer by amount of tracks bought that belongs to that genre:  GetCustomerFavoriteGenre
Return all customers: GetAllCustomers
Add a new customer to the database: AddNewCustomer
Change the values of fields in a single Customer instance: UpdateCustomer

## Authors
The authors of this project are Håvard Lund and Erik Skryseth
