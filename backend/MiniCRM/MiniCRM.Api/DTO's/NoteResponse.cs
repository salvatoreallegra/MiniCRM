namespace MiniCRM.Api.DTOs;

public class NoteResponse
{
    public int Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public DateTime CreatedAtUtc { get; set; }
}