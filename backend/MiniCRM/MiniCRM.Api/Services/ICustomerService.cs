using MiniCRM.Api.DTOs;
using MiniCRM.Api.Models;

namespace MiniCRM.Api.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomersAsync();

    Task<Customer?> GetCustomerByIdAsync(int id);

    Task<List<Customer>> SearchCustomersAsync(string search);

    Task<Customer> CreateCustomerAsync(CreateCustomerRequest request);
}