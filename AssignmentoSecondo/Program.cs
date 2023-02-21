// See https://aka.ms/new-console-template for more information
using AssignmentoSecondo;
using AssignmentoSecondo.Modules;
using AssignmentoSecondo.Repositories;
using Microsoft.Data.SqlClient;

ICustomerRepository repos = new CustomerRepository();
TestRepository test = new TestRepository();
//test.TestSelectAll(repos);
test.TestGetCustomerById(repos);

