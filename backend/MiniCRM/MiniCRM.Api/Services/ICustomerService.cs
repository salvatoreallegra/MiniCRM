using MiniCRM.Api.DTOs;
using MiniCRM.Api.Models;

namespace MiniCRM.Api.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomersAsync(int page,int pageSize);

    Task<Customer?> GetCustomerByIdAsync(int id);

    Task<List<Customer>> SearchCustomersAsync(string search);

    Task<Customer> CreateCustomerAsync(CreateCustomerRequest request);

    Task<CustomerDetailsResponse?> GetCustomerDetailsAsync(int id);

    Task<Note?> AddNoteAsync(int customerId, CreateNoteRequest request);

    Task<bool> UpdateCustomerAsync(int id,UpdateCustomerRequest request);

    Task<bool> DeleteCustomerAsync(int id);
}