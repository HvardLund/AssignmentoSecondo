using AssignmentoSecondo.Models;
using AssignmentoSecondo.Modules;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentoSecondo.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {

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
                                customers.Add(new Customer(
                                
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetString(5),
                                    reader.GetString(6)

                                ));
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
            Customer customer;
            using SqlConnection connection = new SqlConnection((ConnectionStringHelper.GetConnectionString()));
            connection.Open();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = @CustomerId";
            using SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@CustomerId", id);
            using SqlDataReader reader = cmd.ExecuteReader();
            
            if(reader.NextResult())
            {
                customer = new Customer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6)
                    );
            } else
            {
                throw new Exception("Fant ingenting!");
            }
            return customer;
        }

        public List<Customer> GetCustomerByName(string firstName, string lastName)
        {
            List<Customer> customers = new List<Customer>();
            using SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString());
            conn.Open();
            string sql = "SELECT CustomerId,FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE @FirstName AND LastName LIKE @LastName ";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@FirstName", firstName + "%");
            command.Parameters.AddWithValue("@LastName", lastName +"%");
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                customers.Add(new Customer(

                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6)
                ));
            }

            return customers;
        }

        public List<CustomerGenre> GetCustomerFavoriteGenre(int id)
        {
            List<CustomerGenre> favoriteGenres = new List<CustomerGenre>();
            using SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString());
            connection.Open();
            string sql = "SELECT Genre.Name,  COUNT(Genre.GenreId) PopularGenre FROM Invoice " +
                    "INNER JOIN InvoiceLine on Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                    "INNER JOIN Track on InvoiceLine.TrackId = Track.TrackId " +
                    "INNER JOIN Genre on Track.GenreId = Genre.GenreId " +
                    "WHERE CustomerId = @CustomerId " +
                    "GROUP BY Genre.Name " +
                    "ORDER BY PopularGenre DESC";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CustomerId", id);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                favoriteGenres.Add(new CustomerGenre(
                
                    reader.GetString(0),
                    reader.GetInt32(1)
                ));
            }
            
            
            return favoriteGenres;
        }

        public List<CustomerSpender> GetCustomersByBiggestSpender()
        {
            List<CustomerSpender> whales = new List<CustomerSpender>();
            using SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString());
            connection.Open();
            string sql = "SELECT CustomerId, SUM(Total) TotalAmount FROM Invoice GROUP BY CustomerId ORDER BY TotalAmount DESC";
            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                whales.Add(new CustomerSpender(
                    reader.GetInt32(0),
                    reader.GetDecimal(1)
                    ));
            }
            return whales;
        }

        public List<CustomerCountry> GetCustomersByCountry()
        {
            List<CustomerCountry> customersByCountry = new List<CustomerCountry>();
            using SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString());
            connection.Open();
            string sql = "SELECT Country, COUNT(CustomerId) NumberOfCustomers FROM dbo.Customer GROUP BY Country ORDER BY NumberOfCustomers";
            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                customersByCountry.Add(new CustomerCountry(
                    reader.GetString(0),
                    reader.GetInt32(1)
                    ));
            }
            return customersByCountry;
        }

        public bool AddNewCustomer(Customer customer)
        {
            bool sucsess = false;
            string sql = "INSERT INTO Customers(FirstName,LastName,Country,PostalCode,Phone,Email) " +
                "VALUES(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        sucsess = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logging all the errors
            }
            return sucsess;
        }
        public bool UpdateNewCustomer(Customer customer)
        {
            
            throw new NotImplementedException();
        }
    }
}
