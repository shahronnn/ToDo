using Domain.DTOs.TaskDTOs;
using Domain.DTOs.Wrappers;
using Infrastructure.Services.TaskServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;


    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    [HttpGet("Get-tasks")]
    public async Task<Response<List<GetTaskDTO>>> GetTasks()
    {
        return await _taskService.GetTasks();
    }
    [HttpGet("Get-task")]
    public async Task<Response<GetTaskDTO>> GetTaskById(int id)
    {
        return await _taskService.GetTaskById(id);
    }
    [HttpPost("Add-task")]
    public async Task<Response<string>> AddTask(AddTaskDTO addTaskDTO)
    {
        return await _taskService.AddTask(addTaskDTO);
    }
    [HttpPut("Update-task")]
    public async Task<Response<string>> UpdateTask(GetTaskDTO getTaskDTO)
    {
        return await _taskService.UpdateTask(getTaskDTO);
    }
    [HttpDelete("Delete-task")]
    public async Task<Response<string>> DeleteTask(int id)
    {
        return await _taskService.DeleteTask(id);
    }
}
