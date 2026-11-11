using System.ComponentModel.DataAnnotations;

namespace MiniCRM.Api.DTOs;

public class UpdateCustomerRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
}