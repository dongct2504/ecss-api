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
}
