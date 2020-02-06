using CarRental.Domain.ExtensionMethods;
using CarRental.Domain.Models;
using CarRental.Domain.Requests;
using CarRental.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ObjectResult> GetAllCustomersAsync()
        {
            List<Customer> result = await _customerServices.CustomerRepository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("GetCustomer/{id}")]
        public async Task<ObjectResult> GetCustomerAsync([FromRoute] int id)
        {
            Customer result = await _customerServices.CustomerRepository.GetByIdAsync(id);

            return Ok(result);
        }


        [HttpPost("CreateCustomer")]
        public async Task<ObjectResult> CreateCustomerAsync([FromBody] GeneralCustomerRequest request)
        {
            Customer result = await _customerServices.CustomerRepository.CreateAsync(request.ToDTO());
            await _customerServices.CommitChanges();

            return Ok(result);
        }


    }
}