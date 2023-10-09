using AutoMapper;
using Domain.DTOs.TaskDTOs;
using Domain.DTOs.Wrappers;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.TaskServices;

public class TaskService : ITaskService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public TaskService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<Response<string>> AddTask(AddTaskDTO addTaskDTO)
    {
        var mapped = _mapper.Map<TodoTask>(addTaskDTO);
        await _dataContext.Tasks.AddAsync(mapped);
         await _dataContext.SaveChangesAsync();
        return new Response<string>("TodoTask added!");  
    }

    public async Task<Response<string>> DeleteTask(int id)
    {
        var task = await _dataContext.Tasks.FindAsync(id);
        if(task == null) return new Response<string>("Data not found!");
        _dataContext.Tasks.Remove(task);
        await _dataContext.SaveChangesAsync();
        return new Response<string>("Task added!");
    }

    public async Task<Response<GetTaskDTO>> GetTaskById(int id)
    {
        var task = await _dataContext.Tasks.FindAsync(id);
        if(task == null) return new Response<GetTaskDTO>("Data not found!");
        var mapped = _mapper.Map<GetTaskDTO>(task);
        return new Response<GetTaskDTO>(mapped);
    }

    public async Task<Response<List<GetTaskDTO>>> GetTasks()
    {
        var tasks = await _dataContext.Tasks.ToListAsync();
        var mapped = _mapper.Map<List<GetTaskDTO>>(tasks);
        return new Response<List<GetTaskDTO>>(mapped);
    }

    public async Task<Response<string>> UpdateTask(GetTaskDTO getTaskDTO)
    {
        var task = _dataContext.Tasks.Find(getTaskDTO.Id);
        if(task==null)return new Response<string>("Data not found!");
        var mapped = _mapper.Map(getTaskDTO,task);
        await _dataContext.SaveChangesAsync();
        return new Response<string>("Task updated!");
    }

}
