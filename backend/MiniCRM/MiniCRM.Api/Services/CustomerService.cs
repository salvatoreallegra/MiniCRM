using Microsoft.EntityFrameworkCore;
using MiniCRM.Api.Data;
using MiniCRM.Api.DTOs;
using MiniCRM.Api.Models;

namespace MiniCRM.Api.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<CustomerService> _logger;

    public CustomerService(
        AppDbContext dbContext,
        ILogger<CustomerService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
        return await _dbContext.Customers
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _dbContext.Customers
            .Include(c => c.Notes)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Customer>> SearchCustomersAsync(string search)
    {
        return await _dbContext.Customers
            .Where(c =>
                c.Name.Contains(search) ||
                c.Email.Contains(search))
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Customer> CreateCustomerAsync(
        CreateCustomerRequest request)
    {
        var customer = new Customer
        {
            Name = request.Name,
            Email = request.Email
        };

        _dbContext.Customers.Add(customer);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation(
            "Created customer {CustomerId}",
            customer.Id);

        return customer;
    }
}