using Domain.DTOs.CategoryDTOs;
using Domain.DTOs.Wrappers;
using Infrastructure.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;


    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet("Get-categories")]
    public async Task<Response<List<GetCategoryDTO>>> GetCategories()
    {
        return await _categoryService.GetCategories();
    }
    [HttpGet("GetCategoryById")]
    public async Task<Response<GetCategoryWithTasksDTO>> GetCategoryById(int id)
    {
        return await _categoryService.GetCategoryById(id);
    }
    [HttpPost("Add-category")]
    public async Task<Response<string>> AddCategory([FromForm]AddCategoryDTO addCategoryDTO)
    {
        return await _categoryService.AddCategory(addCategoryDTO);
    }
    [HttpPut("Update-category")]
    public async Task<Response<string>> UpdateCategory([FromForm]GetCategoryDTO getCategoryDTO)
    {
        return await _categoryService.UpdateCategory(getCategoryDTO);
    }
    [HttpDelete("Delete-category")]
    public async Task<Response<string>> DeleteCategory(int id)
    {
        return await _categoryService.DeleteCategory(id);
    }
}
