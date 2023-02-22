using AssignmentoSecondo.Models;
using AssignmentoSecondo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentoSecondo.Repositories
{
    /// <summary>
    /// Interface used to implement the repository design pattern
    /// </summary>
    internal interface ICustomerRepository
    {
        public Customer GetCustomerById(int id);
        public List<Customer> GetCustomerByName(string firstName, string lastName);
        public List<CustomerCountry> GetCustomersByCountry();
        public List<CustomerSpender> GetCustomersByBiggestSpender();
        public List<CustomerGenre> GetCustomerFavoriteGenre(int id);
        public List<Customer> GetAllCustomers();
        public List<Customer> GetPageOfCustomers(int offset, int limit);
        public bool AddCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(int id);

    }
}
