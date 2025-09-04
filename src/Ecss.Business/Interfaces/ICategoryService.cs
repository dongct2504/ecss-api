using Ecss.Business.Dtos;
using Ecss.Business.Dtos.CategoryDtos;

namespace Ecss.Business.Interfaces;

public interface ICategoryService
{
    Task<PagedList<CategoryDto>> GetCategoriesAsync(GetCategoriesInput input);
    Task<CategoryDto> GetCategoryByIdAsync(int id);
    Task<CategoryDto> GetCategoryByNameAsync(string name);

    Task<CategoryDto> CreateCategoryAsync(CreateCategoryInput input);
    Task<CategoryDto> UpdateCategoryAsync();
    Task<bool> DeleteCategoryAsync();
}
