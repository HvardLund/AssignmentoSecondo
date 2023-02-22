// See https://aka.ms/new-console-template for more information
using AssignmentoSecondo;
using AssignmentoSecondo.Modules;
using AssignmentoSecondo.Repositories;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

ICustomerRepository repos = new CustomerRepository();


//test.TestGetCustomersByCountry(repos);
//test.TestGetCustomersByTotalAmountBought(repos);
//TestRepository.TestAddNewCustomer(repos);
//TestRepository.TestUpdateCustomer(repos);
//TestRepository.TestGetCustomerById(repos);
//TestRepository.TestGetFavoriteGenreById(repos);
//TestRepository.TestSelectAll(repos);
//TestRepository.TestGetCustomerByName(repos);
//TestRepository.TestDelete(repos);
TestRepository.TestPagination(repos);
