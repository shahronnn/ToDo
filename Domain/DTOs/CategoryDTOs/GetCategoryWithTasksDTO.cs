using Domain.DTOs.TaskDTOs;

namespace Domain.DTOs.CategoryDTOs;

public class GetCategoryWithTasksDTO
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public List<GetTaskDTO>? Tasks { get; set; } 
}
