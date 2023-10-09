using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class TodoTask 
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    [ForeignKey("Category")] 
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
