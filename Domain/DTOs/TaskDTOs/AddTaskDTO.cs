namespace Domain.DTOs.TaskDTOs;

public class AddTaskDTO
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CategoryId { get; set; }
}
