using MiniCRM.Api.Models;

namespace MiniCRM.Api.Services;

public class CustomerService : ICustomerService
{
    private readonly List<Customer> _customers =
    [
        new Customer
        {
            Id = 1,
            Name = "John Smith",
            Email = "john@example.com"
        },

        new Customer
        {
            Id = 2,
            Name = "Sarah Jones",
            Email = "sarah@example.com"
        },

        new Customer
        {
            Id = 3,
            Name = "Mike Brown",
            Email = "mike@example.com"
        }
    ];

    public Task<List<Customer>> GetCustomersAsync()
    {
        return Task.FromResult(_customers);
    }

    public Task<Customer?> GetCustomerByIdAsync(int id)
    {
        Customer? customer = _customers
            .FirstOrDefault(c => c.Id == id);

        return Task.FromResult(customer);
    }

    public Task<List<Customer>> SearchCustomersAsync(string search)
    {
        List<Customer> customers = _customers
            .Where(c =>
                c.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                c.Email.Contains(search, StringComparison.OrdinalIgnoreCase))
            .OrderBy(c => c.Name)
            .ToList();

        return Task.FromResult(customers);
    }
}