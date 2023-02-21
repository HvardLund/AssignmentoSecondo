using AssignmentoSecondo.Models;
using AssignmentoSecondo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentoSecondo.Repositories
{
    internal interface ICustomerRepository
    {
        public Customer GetCustomerById(int id);
        public Customer GetCustomerByName(string firstName, string lastName);
        public CustomerCountry GetCustomersByCountry();
        public CustomerSpender GetCustomersByBiggestSpender();
        public CustomerGenre GetCustomerFavoriteGenre(int id);
        public List<Customer> GetAllCustomers();
        //Pagination here
        public bool AddNewCustomer(Customer customer);
        public bool UpdateNewCustomer(Customer customer);
    }
}
