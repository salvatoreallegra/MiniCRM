namespace MiniCRM.Api.DTOs;

public class CustomerDetailsResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public List<NoteResponse> Notes { get; set; } = [];
}