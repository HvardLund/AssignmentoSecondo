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
        public List<Customer> GetCustomerByName(string firstName, string lastName);
        public List<CustomerCountry> GetCustomersByCountry();
        public List<CustomerSpender> GetCustomersByBiggestSpender();
        public List<CustomerGenre> GetCustomerFavoriteGenre(int id);
        public List<Customer> GetAllCustomers();
        public bool AddNewCustomer(Customer customer);
        public bool UpdateNewCustomer(Customer customer);
    }
}
