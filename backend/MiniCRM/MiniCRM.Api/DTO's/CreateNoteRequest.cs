using System.ComponentModel.DataAnnotations;

namespace MiniCRM.Api.DTOs;

public class CreateNoteRequest
{
    [Required]
    [MaxLength(1000)]
    public string Text { get; set; } = string.Empty;
}