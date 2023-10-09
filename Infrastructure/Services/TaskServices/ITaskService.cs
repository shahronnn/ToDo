using Domain.DTOs.TaskDTOs;
using Domain.DTOs.Wrappers;

namespace Infrastructure.Services.TaskServices;

public interface ITaskService
{
    Task<Response<List<GetTaskDTO>>> GetTasks();
    Task<Response<GetTaskDTO>> GetTaskById(int id);
    Task<Response<string>> AddTask(AddTaskDTO addTaskDTO);
    Task<Response<string>> UpdateTask(GetTaskDTO getTaskDTO);
    Task<Response<string>> DeleteTask(int id); 
}
