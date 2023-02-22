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
        public void TestSelectAll(ICustomerRepository repos)
        {
            repos.GetAllCustomers().ForEach(x => Console.WriteLine(x.ToString()));
        }

        public static void TestGetCustomerById(ICustomerRepository repos)
        {
            Customer customer = repos.GetCustomerById(1);
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
            string firstName = "Emm";
            string lastName = "";
            List<Customer> customers = repos.GetCustomerByName(firstName, lastName);
            customers.ForEach(x => Console.WriteLine(x.ToString()));
        }

        public static void TestGetFavoriteGenreById(ICustomerRepository repos)
        {
            repos.GetCustomerFavoriteGenre(12).ForEach(x => Console.WriteLine(x.ToString()));
        }

        
    }
}
