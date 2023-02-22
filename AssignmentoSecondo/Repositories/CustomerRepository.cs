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
        /// <summary>
        /// Return all customers from the database
        /// </summary>
        /// <returns>List of customer records</returns>
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

        /// <summary>
        /// Takes in a customer Id, and returns the customer with the corresponding customerId from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single customer record</returns>
        public Customer GetCustomerById(int id)
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = @CustomerId";
            Customer customer = new Customer();
            try
            {
                using SqlConnection connection = new SqlConnection((ConnectionStringHelper.GetConnectionString()));
                connection.Open();
                using SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@CustomerId", id);
                using SqlDataReader reader = cmd.ExecuteReader();

                //Any other method for reading the result ends up with false, so that's why reader.Read() was chosen. 
                if (reader.Read())
                {
                    customer = (new Customer(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6)
                        ));
                }
                else
                {
                    throw new Exception("Fant ingenting!");
                }
            }catch(Exception ex)
            {
                //log ex
            }
            return customer;
        }

        /// <summary>
        /// Takes in a first and last name, and returns the customer with the corresponding values from the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>A list of one or more customer records</returns>
        public List<Customer> GetCustomerByName(string firstName, string lastName)
        {

            string sql = "SELECT CustomerId,FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE @FirstName AND LastName LIKE @LastName ";
            List<Customer> customers = new List<Customer>();
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString());
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@FirstName", firstName + "%");
                command.Parameters.AddWithValue("@LastName", lastName + "%");
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
            }
            catch (Exception ex)
            {
                //log ex
            }

            return customers;
        }

        /// <summary>
        /// Takes in a customer Id, and returns their most popular genre based on amount of tracks bought that belongs to that genre. Can be more than one genre when values are equal.
        /// <returns>List of customerGenre records</returns>
        public List<CustomerGenre> GetCustomerFavoriteGenre(int id)
        {
            string sql = "SELECT Genre.Name,  COUNT(Genre.GenreId) PopularGenre FROM Invoice " +
                    "INNER JOIN InvoiceLine on Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                    "INNER JOIN Track on InvoiceLine.TrackId = Track.TrackId " +
                    "INNER JOIN Genre on Track.GenreId = Genre.GenreId " +
                    "WHERE CustomerId = @CustomerId " +
                    "GROUP BY Genre.Name " +
                    "ORDER BY PopularGenre DESC";
            List<CustomerGenre> favoriteGenres = new List<CustomerGenre>();
            try
            {
                using SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString());
                connection.Open();

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
            } catch (Exception ex)
            {
                //log ex
            }
            
            
            return favoriteGenres;
        }
        
        /// <summary>
        /// Returns a list of customers from the database sorted by amount spent
        /// </summary>
        /// <returns>List of customerSpender records</returns>
        public List<CustomerSpender> GetCustomersByBiggestSpender()
        {
            List<CustomerSpender> whales = new List<CustomerSpender>();
            string sql = "SELECT CustomerId, SUM(Total) TotalAmount FROM Invoice GROUP BY CustomerId ORDER BY TotalAmount DESC";
            try
            {
                using SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString());
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    whales.Add(new CustomerSpender(
                        reader.GetInt32(0),
                        reader.GetDecimal(1)
                        ));
                }
            } catch(Exception ex)
            {
                //log ex
            }
            return whales;
        }

        /// <summary>
        /// Returns amount of customers from each country. Sorted from highest to lowest.
        /// </summary>
        /// <returns>List of CustomerCountry records</returns>
        public List<CustomerCountry> GetCustomersByCountry()
        {
            List<CustomerCountry> customersByCountry = new List<CustomerCountry>();
            using SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString());
            connection.Open();
            string sql = "SELECT Country, COUNT(CustomerId) NumberOfCustomers FROM dbo.Customer GROUP BY Country ORDER BY NumberOfCustomers DESC";
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

        /// <summary>
        /// Adds a new customer to the database. Takes in a customer object.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Success, boolean</returns>
        public bool AddCustomer(Customer customer)
        {
            bool sucsess = false;
            string sql = "INSERT INTO Customer(FirstName,LastName,Country,PostalCode,Phone,Email) " +
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

        /// <summary>
        /// Updates an existing customer in the database. All values but Id can be changes-
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Success, boolean</returns>
        public bool UpdateCustomer(Customer customer)
        {
            bool sucsess = false;
            try
            {
                using SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString());
                connection.Open();
                string sql = "UPDATE Customer SET FirstName = @FirstName, " +
                    "LastName = @LastName, " +
                    "Country = @Country, " +
                    "PostalCode = @PostalCode, " +
                    "Phone = @Phone, " +
                    "Email = @Email " +
                    "WHERE CustomerId = @CustomerId";
                using SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                sucsess = cmd.ExecuteNonQuery() > 0 ? true : false;
            } catch (Exception ex)
            {
                //log ex
            }

            return sucsess;
        }

        /// <summary>
        /// Deletes a customer from the database based on customerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Success, boolean</returns>
        public bool DeleteCustomer(int id)
        {
            bool success = false;
            try
            {
                using SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString());
                connection.Open();
                string sql = "DELETE Customer WHERE CustomerId = @CustomerId";
                using SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@CustomerId", id);
                success = cmd.ExecuteNonQuery() > 0 ? true : false;
            } catch(Exception ex)
            {
                //log ex
            }

            return success;
        }

        /// <summary>
        /// Returns a page of users. Limit determines page size, while offset sets starting point.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns>List of Customer objects with size equal to limit</returns>
        public List<Customer> GetPageOfCustomers(int offset, int limit)
        {
            List<Customer> customerPage = new List<Customer>();
            try
            {
                using SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString());
                connection.Open();
                string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";
                using SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Offset", offset);
                cmd.Parameters.AddWithValue("@Limit", limit);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customerPage.Add(new Customer(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6)
                        ));
                }
            } catch(Exception ex)
            {
                //log ex
            }
            return customerPage;

        }
    }
}
