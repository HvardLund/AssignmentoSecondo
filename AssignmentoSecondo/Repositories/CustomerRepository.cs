using AssignmentoSecondo.Models;
using AssignmentoSecondo.Modules;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentoSecondo.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        public bool AddNewCustomer(Customer customer)
        {
            string sql = "";
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string sql = "SELECT CustomerId,FirstName, LastName , Country, PostalCode,Phone, Email FROM dbo.Customer";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customers.Add(new Customer()
                                {
                                    CustomerId = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Country = reader.GetString(3),
                                    PostalCode = reader.GetString(4),
                                    Phone = reader.GetString(5),
                                    Email = reader.GetString(6)

                                });
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //log ex
            }

            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            string sql = "SELECT CustomerId,FirstName, LastName , Country, PostalCode,Phone, Email FROM Customer WHERE CustomerId = ";
            throw new NotImplementedException();
        }

        public Customer GetCustomerByName(string firstName, string lastName)
        {
            string sql = " SELECT CustomerId,FirstName, LastName , Country, PostalCode,Phone, Email FROM Customer WHERE FirstName LIKE '%' ";
            throw new NotImplementedException();
        }

        public CustomerGenre GetCustomerFavoriteGenre(int id)
        {
            string sql = "SELECT Genre.Name,  COUNT(Genre.GenreId) PopularGenre FROM Invoice " +
                    "INNER JOIN InvoiceLine on Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                    "INNER JOIN Track on InvoiceLine.TrackId = Track.TrackId " +
                    "INNER JOIN Genre on Track.GenreId = Genre.GenreId" +
                    "WHERE CustomerId = " +
                    "GROUP BY Genre.Name" +
                    "ORDER BY PopularGenre DESC";
            throw new NotImplementedException();
        }

        public CustomerSpender GetCustomersByBiggestSpender()
        {
            string sql = "SELECT CustomerId, SUM(Total) TotalAmount FROM Invoice GROUP BY CustomerId ORDER BY TotalAmount DESC";
            throw new NotImplementedException();
        }

        public CustomerCountry GetCustomersByCountry()
        {
            string sql = "SELECT Country, COUNT(CustomerId) NumberOfCustomers FROM dbo.Customer GROUP BY Country ORDER BY NumberOfCustomer";
            throw new NotImplementedException();
        }

        public bool UpdateNewCustomer(Customer customer)
        {
            string sql = "";
            throw new NotImplementedException();
        }
    }
}
