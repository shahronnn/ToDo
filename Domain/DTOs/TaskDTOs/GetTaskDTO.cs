namespace Domain.DTOs.TaskDTOs;

public class GetTaskDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CategoryId { get; set; }
}
