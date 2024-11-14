﻿using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [CheckClaims("roleid", "21")]
        public List<Customer> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        [CheckClaims("roleid", "1")]

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
        [CheckClaims("roleid", "1")]

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
        [CheckClaims("roleid", "1")]

        public void UpdateLatLong(int id, decimal Latitude, decimal Longitude)
        {
            _customerService.UpdateLatLong(id, Latitude, Longitude);
        }

    }
}
