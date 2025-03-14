using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BookHaven.DAL;
using BookHaven.Models;

namespace BookHaven.BLL
{
    class CustomerService
    {
        private readonly CustomerRepository _customerRepo = new CustomerRepository();

        public List<Customer> GetAllCustomers() => _customerRepo.GetAllCustomers();

        public Customer? GetCustomerById(int id) => _customerRepo.GetCustomerById(id);

        public bool CreateCustomer(Customer customer, SqlTransaction transaction = null)
            => _customerRepo.CreateCustomer(customer, transaction);

        public bool UpdateCustomer(Customer customer, SqlTransaction transaction = null)
            => _customerRepo.UpdateCustomer(customer, transaction);

        public bool DeleteCustomer(int id, SqlTransaction transaction = null) => _customerRepo.DeleteCustomer(id, transaction);
    }
}
