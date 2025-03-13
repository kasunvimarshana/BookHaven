using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.DAL;
using BookHaven.Models;

namespace BookHaven.BLL
{
    class CustomerService
    {
        private readonly CustomerRepository _customerRepo = new CustomerRepository();

        public List<Customer> GetAllCustomers() => _customerRepo.GetAllCustomers();

        public Customer? GetCustomerById(int id) => _customerRepo.GetCustomerById(id);

        public bool CreateCustomer(Customer customer)
            => _customerRepo.CreateCustomer(customer);

        public bool UpdateCustomer(Customer customer)
            => _customerRepo.UpdateCustomer(customer);

        public bool DeleteCustomer(int id) => _customerRepo.DeleteCustomer(id);
    }
}
