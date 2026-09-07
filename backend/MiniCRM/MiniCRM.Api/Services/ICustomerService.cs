using MiniCRM.Api.DTOs;
using MiniCRM.Api.Models;

namespace MiniCRM.Api.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomersAsync();

    Task<Customer?> GetCustomerByIdAsync(int id);

    Task<List<Customer>> SearchCustomersAsync(string search);

    Task<Customer> CreateCustomerAsync(CreateCustomerRequest request);

    Task<CustomerDetailsResponse?> GetCustomerDetailsAsync(int id);

    Task<Note?> AddNoteAsync(int customerId, CreateNoteRequest request);

    Task<bool> UpdateCustomerAsync(int id, CreateCustomerRequest request);

    Task<bool> DeleteCustomerAsync(int id);
}