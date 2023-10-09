using AutoMapper;
using Domain.DTOs.CategoryDTOs;
using Domain.DTOs.TaskDTOs;
using Domain.DTOs.Wrappers;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public CategoryService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<Response<string>> AddCategory(AddCategoryDTO addCategoryDTO)
    {
        var mapped = _mapper.Map<Category>(addCategoryDTO);
        await _dataContext.Categories.AddAsync(mapped);
        _dataContext.SaveChanges();
        return new Response<string>("Category added!");
    }

    public async Task<Response<string>> DeleteCategory(int id)
    {
        var category = await _dataContext.Categories.FindAsync(id);
        if(category == null) new Response<string>("Data not found");
        _dataContext.Categories.Remove(category);
        int v = await _dataContext.SaveChangesAsync();
        return new Response<string>("Category Deleted");
    }

    public async Task<Response<List<GetCategoryDTO>>> GetCategories()
    {
        var categories = await _dataContext.Categories.AsQueryable().ToListAsync();
        var mapped = _mapper.Map<List<GetCategoryDTO>>(categories);

        return new Response<List<GetCategoryDTO>>(mapped);
    }

    public async Task<Response<GetCategoryWithTasksDTO>> GetCategoryById(int id) 
    {
        var category = await _dataContext.Categories.FindAsync(id);
        if(category == null) return new Response<GetCategoryWithTasksDTO>("Data not found!");

        // var joined = from c in _dataContext.Categories
        //              join t in _dataContext.Tasks on c.Id equals t.CategoryId
        //              select new GetCategoryWithTasksDTO() 
        //              {
        //                 Id = category.Id,
        //                 CategoryName = category.CategoryName,
        //                 Tasks = _dataContext.Tasks.Select(e=>new GetTaskDTO()
        //                 {
        //                     Id = e.Id,
        //                     Title =e.Title
        //                 }).ToList()
        //              };
        
        var mapped = new GetCategoryWithTasksDTO()
        {
            Id = category.Id,
            CategoryName = category.CategoryName,
            Tasks =  _dataContext.Tasks.Where(e=>e.CategoryId==category.Id)
            .Select(x=>new GetTaskDTO()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId
            }).ToList() 
        };

        return new Response<GetCategoryWithTasksDTO>(mapped);
    }

    public async Task<Response<string>> UpdateCategory(GetCategoryDTO getCategoryDTO)
    {
        var category = await _dataContext.Categories.FindAsync(getCategoryDTO.Id);
        if(category == null) return new Response<string>("Data not found");
        var mapped = _mapper.Map<Category>(getCategoryDTO);
        _dataContext.Categories.Update(mapped);
        await _dataContext.SaveChangesAsync();
        
        return new Response<string>("Category updated!");
    }

}
