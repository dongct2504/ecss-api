using Asp.Versioning;
using Ecss.Business.Dtos.CategoryDtos;
using Ecss.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecss.Api.Controllers.V1;

[ApiVersion("1.0")]
public class CategoriesController : ApiController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesInput input)
    {
        return Ok(await _categoryService.GetCategoriesAsync(input));
    }

    [HttpGet("{id:int}", Name = "GetCategoryById")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        return Ok(await _categoryService.GetCategoryByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryInput input)
    {
        CategoryDto categoryDto = await _categoryService.CreateCategoryAsync(input);
        return CreatedAtRoute(nameof(GetCategoryById), new { id = categoryDto.Id }, categoryDto);
    }
}
