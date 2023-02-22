using AssignmentoSecondo.Modules;
using AssignmentoSecondo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentoSecondo
{
    internal class TestRepository 
    {
        public static void TestSelectAll(ICustomerRepository repos)
        {
            repos.GetAllCustomers().ForEach(x => Console.WriteLine(x.ToString()));
        }

        public static void TestGetCustomerById(ICustomerRepository repos)
        {
            Customer customer = repos.GetCustomerById(9);
            Console.WriteLine(customer.ToString());

        }

        public static void TestGetCustomersByCountry(ICustomerRepository repos)
        {
            repos.GetCustomersByCountry().ForEach(x => Console.WriteLine(x.ToString()));
        }

        public static void TestGetCustomersByTotalAmountBought(ICustomerRepository repos)
        {
            repos.GetCustomersByBiggestSpender().ForEach(x => Console.WriteLine(x.ToString()));
        }

        public static void TestGetCustomerByName(ICustomerRepository repos)
        {
            string firstName = "Nil";
            string lastName = "";
            List<Customer> customers = repos.GetCustomerByName(firstName, lastName);
            customers.ForEach(x => Console.WriteLine(x.ToString()));
        }

        public static void TestGetFavoriteGenreById(ICustomerRepository repos)
        {
            repos.GetCustomerFavoriteGenre(12).ForEach(x => Console.WriteLine(x.ToString()));
        }

        public static void TestAddNewCustomer(ICustomerRepository repos)
        {
            Customer customer = new Customer() { 
                FirstName = "Nils",
                LastName = "Nilsen",
                Country = "Norway",
                PostalCode = "12345",
                Phone = "1234567890",
                Email = "nils_nilsen@hotmail.com"
            };
            bool success = repos.AddCustomer(customer);
            if(success)
                Console.WriteLine("OK");
        }

        public static void TestUpdateCustomer(ICustomerRepository repos)
        {
            Customer customer = repos.GetCustomerById(60);
            Customer updatedCustomer = new Customer()
            {
                CustomerId = customer.CustomerId,
                FirstName = "Nilsemann",
                LastName = customer.LastName,
                Country = "Sverige",
                PostalCode = "54321",
                Phone = customer.Phone,
                Email = customer.Email
            };
            repos.UpdateCustomer(updatedCustomer);
            
        }

        public static void TestDelete(ICustomerRepository repos)
        {
            bool sucess = repos.DeleteCustomer(60);
            if(sucess) Console.WriteLine("Gratulerer nå er Nilsemann fjernet fra denne databasen!!! HURRA!!!");

        }

        public static void TestPagination(ICustomerRepository repos)
        {
            repos.GetPageOfCustomers(20, 10).ForEach(x => Console.WriteLine(x.ToString()));
        }

        
    }
}
