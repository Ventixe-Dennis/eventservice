
namespace Business.Models;

public class CreateEventDTO
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? Date { get; set; } = null!;
    public int Price { get; set; }
    public string Location { get; set; } = null!;

    public string Category { get; set; } = null!;
}
