using Dapper;
using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Services
{
    public class CustomerService : ICustomerService
    {//hello
        private readonly ICustomerRepository _customerRepository;
        public CustomerService (ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }
        public void CreateCustomer(Customer customer)
        {
            _customerRepository.CreateCustomer(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }
        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }
        public void UpdateLatLong(int id, decimal Latitude, decimal Longitude)
        {
           _customerRepository.UpdateLatLong(id, Latitude, Longitude);
        }


    }
}
