using Microsoft.AspNetCore.Mvc;
using MiniCRM.Api.Models;
using MiniCRM.Api.Services;

namespace MiniCRM.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetCustomers()
    {
        List<Customer> customers =
            await _customerService.GetCustomersAsync();

        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Customer>> GetCustomerById(int id)
    {
        Customer? customer =
            await _customerService.GetCustomerByIdAsync(id);

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<Customer>>> SearchCustomers(
    [FromQuery] string search)
    {
        List<Customer> customers =
            await _customerService.SearchCustomersAsync(search);

        return Ok(customers);
    }
}