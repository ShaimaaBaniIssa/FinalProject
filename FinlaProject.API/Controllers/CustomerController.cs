using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public List<Customer> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public Customer GetCustomerById(int id)
        {
            return _customerService.GetCustomerById(id);
        }
        [HttpPost]
        [Route("CreateCustomer")]
        public void CreateCustomer(Customer customer)
        {
            _customerService.CreateCustomer(customer);
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public void UpdateCustomer(Customer customer)
        {
            _customerService.UpdateCustomer(customer);
        }
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public void DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
        }


        [HttpPut]
        [Route("UpdateLatLong")]
        public void UpdateLatLong(int id, decimal Latitude, decimal Longitude)
        {
            _customerService.UpdateLatLong(id, Latitude, Longitude);
        }

    }
}
