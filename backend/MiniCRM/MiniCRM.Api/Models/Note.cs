namespace MiniCRM.Api.Models;

public class Note
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Text { get; set; } = string.Empty;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public Customer Customer { get; set; } = null!;
}