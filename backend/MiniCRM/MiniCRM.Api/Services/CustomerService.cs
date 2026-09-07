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

    public async Task<List<Customer>> GetCustomersAsync(
    int page,
    int pageSize)
    {
        return await _dbContext.Customers
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
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
    public async Task<CustomerDetailsResponse?> GetCustomerDetailsAsync(int id)
    {
        return await _dbContext.Customers
            .Where(c => c.Id == id)
            .Select(c => new CustomerDetailsResponse
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Notes = c.Notes
                    .OrderByDescending(n => n.CreatedAtUtc)
                    .Select(n => new NoteResponse
                    {
                        Id = n.Id,
                        Text = n.Text,
                        CreatedAtUtc = n.CreatedAtUtc
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();
    }
    public async Task<Note?> AddNoteAsync(
    int customerId,
    CreateNoteRequest request)
    {
        bool customerExists = await _dbContext.Customers
            .AnyAsync(c => c.Id == customerId);

        if (!customerExists)
        {
            return null;
        }

        var note = new Note
        {
            CustomerId = customerId,
            Text = request.Text,
            CreatedAtUtc = DateTime.UtcNow
        };

        _dbContext.Notes.Add(note);

        await _dbContext.SaveChangesAsync();

        return note;
    }
    public async Task<bool> UpdateCustomerAsync(
    int id,
    UpdateCustomerRequest request)
    {
        Customer? customer = await _dbContext.Customers
            .FirstOrDefaultAsync(c => c.Id == id);

        if (customer is null)
        {
            return false;
        }

        customer.Name = request.Name;
        customer.Email = request.Email;

        await _dbContext.SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        Customer? customer = await _dbContext.Customers
            .FirstOrDefaultAsync(c => c.Id == id);

        if (customer is null)
        {
            return false;
        }

        _dbContext.Customers.Remove(customer);

        await _dbContext.SaveChangesAsync();

        return true;
    }
}