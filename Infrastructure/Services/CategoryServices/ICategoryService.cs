using Domain.DTOs.CategoryDTOs;
using Domain.DTOs.Wrappers;

namespace Infrastructure.Services.CategoryServices;

public interface ICategoryService
{
    Task<Response<List<GetCategoryDTO>>> GetCategories();
    Task<Response<GetCategoryWithTasksDTO>> GetCategoryById(int id);
    Task<Response<string>> AddCategory(AddCategoryDTO addCategoryDTO);
    Task<Response<string>> UpdateCategory(GetCategoryDTO getCategoryDTO);
    Task<Response<string>> DeleteCategory(int id); 

}
