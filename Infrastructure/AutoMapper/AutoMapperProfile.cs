using AutoMapper;
using Domain.DTOs.CategoryDTOs;
using Domain.DTOs.TaskDTOs;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Category, AddCategoryDTO>();
        CreateMap<AddCategoryDTO, Category>();
        CreateMap<GetCategoryDTO, Category>();
        CreateMap<Category, GetCategoryDTO>();
        CreateMap<GetCategoryWithTasksDTO, Category>();
        CreateMap<Category, GetCategoryWithTasksDTO>();

        CreateMap<TodoTask, GetTaskDTO>();
        CreateMap<TodoTask, AddTaskDTO>();
        CreateMap<GetTaskDTO, TodoTask>();
        CreateMap<AddTaskDTO, TodoTask>();
    }
}
