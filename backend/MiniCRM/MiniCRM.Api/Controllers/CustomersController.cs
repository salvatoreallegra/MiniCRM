using Microsoft.AspNetCore.Mvc;
using MiniCRM.Api.DTOs;
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
    public async Task<ActionResult<List<Customer>>> GetCustomers(
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10)
    {
        if (page < 1)
        {
            return BadRequest("Page must be at least 1.");
        }

        if (pageSize < 1 || pageSize > 100)
        {
            return BadRequest(
                "Page size must be between 1 and 100.");
        }

        List<Customer> customers =
            await _customerService.GetCustomersAsync(
                page,
                pageSize);

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

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(
    CreateCustomerRequest request)
    {
        Customer customer =
            await _customerService.CreateCustomerAsync(request);

        return CreatedAtAction(
            nameof(GetCustomerById),
            new { id = customer.Id },
            customer);
    }

    [HttpPost("{customerId:int}/notes")]
    public async Task<ActionResult<Note>> AddNote(
    int customerId,
    CreateNoteRequest request)
    {
        Note? note =
            await _customerService.AddNoteAsync(customerId, request);

        if (note is null)
        {
            return NotFound();
        }

        return Ok(note);
    }
    [HttpGet("{id:int}/details")]
    public async Task<ActionResult<CustomerDetailsResponse>> GetCustomerDetails(
    int id)
    {
        CustomerDetailsResponse? customer =
            await _customerService.GetCustomerDetailsAsync(id);

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCustomer(
    int id,
    UpdateCustomerRequest request)
    {
        bool updated =
            await _customerService.UpdateCustomerAsync(id, request);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        bool deleted =
            await _customerService.DeleteCustomerAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}