using System.ComponentModel.DataAnnotations;

namespace WebApi.Data;

public class EventEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = null!;    
    public string? Description { get; set; }
    public DateTime? Date { get; set; } = null!;
    public int Price { get; set; }
    public string Location { get; set; } = null!;

    public string Category { get; set; } = null!;

}
