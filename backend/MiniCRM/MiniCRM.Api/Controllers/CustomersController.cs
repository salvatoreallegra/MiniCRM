using Microsoft.AspNetCore.Mvc;
using MiniCRM.Api.Models;

namespace MiniCRM.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    [HttpGet]
    public ActionResult<Customer> GetCustomer()
    {
        var customer = new Customer
        {
            Id = 1,
            Name = "John Smith",
            Email = "john@example.com"
        };

        return Ok(customer);
    }
}