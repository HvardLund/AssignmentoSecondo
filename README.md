# AssignmentoSecondo
AssignmentoSecondo consists of two parts. The first part of the project is a set of sql queries that create and populate a database of superheroes. The second part includes a C# console application that accesses a customer database for a music store using SQL Client. 

## Installation
For the C# application to work, Microsoft.Data.SqlClient should be installed using NuGet package manager:
https://www.nuget.org/packages/Microsoft.Data.SqlClient

## Usage
Database transactions supported by the console application: <br />

Return a single instance from the database by id: GetCustomerById <br />
Return a single instance from the database by name: GetCustomerByName <br />
Return a single instance from the database by name: GetCustomersByCountry <br />
Return the customer in the database that has spent the highest amount: GetCustomersByBiggestSpender <br />
Return the favourite genre of a customer by amount of tracks bought that belongs to that genre:  GetCustomerFavoriteGenre <br />
Return all customers: GetAllCustomers <br />
Add a new customer to the database: AddNewCustomer <br />
Change the values of fields in a single Customer instance: UpdateCustomer <br />
Return a page of customers, using parameters offset an limit: andGetPageOfCustomers

## Authors
The authors of this project are Håvard Lund and Erik Skryseth
