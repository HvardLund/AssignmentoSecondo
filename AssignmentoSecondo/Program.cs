// See https://aka.ms/new-console-template for more information
using AssignmentoSecondo;
using AssignmentoSecondo.Modules;
using AssignmentoSecondo.Repositories;
using Microsoft.Data.SqlClient;

ICustomerRepository repos = new CustomerRepository();

//test.TestSelectAll(repos);
//test.TestGetCustomersByCountry(repos);
//test.TestGetCustomersByTotalAmountBought(repos);
TestRepository.TestGetCustomerByName(repos);
//TestRepository.TestGetCustomerById(repos);
//TestRepository.TestGetFavoriteGenreById(repos);

