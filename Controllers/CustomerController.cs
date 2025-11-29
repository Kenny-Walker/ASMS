using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Smart_Metering_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromForm] CreateCustomerDto createCustomerDto)
        {
            var customer = await _customerService.CreateCustomer(createCustomerDto);
            if (customer.Success == true)
            {
                return Ok(customer);
            }
            return Ok(customer);
        }

        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromForm] UpdateCustomerDto updateCustomerDto)
        {
            var customer = await _customerService.UpdateCustomer(updateCustomerDto);
            if (customer.Success == true)
            {
                return Ok(customer);
            }
            return Ok(customer);
        }
        // GET : GetAllCustomers
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customer = await _customerService.GetAllCustomers();
            if (customer.Success == true)
            {
                return Ok(customer);
            }
            return Ok(customer);
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomerByUserId(int userId)
        {
            var customer = await _customerService.GetCustomer(userId);
            if (customer.Success == true)
            {
                return Ok(customer);
            }
            return Ok(customer);
        }
        // GET : DeleteCustomer
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            var customer = await _customerService.DeleteCustomer(Id);
            if (customer.Success == true)
            {
                return Ok(customer);
            }
            return Ok(customer);
        }
        //GET : GetCustomerByName
        [HttpGet("GetCustomerByName")]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            var customer = await _customerService.GetCustomersByName(name);
            if (customer.Success == true)
            {
                return Ok(customer);
            }
            return Ok(customer);
        }
    }
}
