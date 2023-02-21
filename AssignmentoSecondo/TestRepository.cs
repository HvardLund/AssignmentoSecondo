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
    }
}
