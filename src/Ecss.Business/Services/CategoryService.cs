using AutoMapper;
using Ecss.Business.Dtos;
using Ecss.Business.Dtos.CategoryDtos;
using Ecss.Business.Interfaces;
using Ecss.Common.Constants;
using Ecss.Common.Exceptions;
using Ecss.Domain.Entities;
using Ecss.Domain.Interfaces.ExternalServices;
using Ecss.Domain.Interfaces.UnitOfWorks;
using Ecss.Domain.Specifications;

namespace Ecss.Business.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILocalizationService _localization;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localization)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _localization = localization;
    }

    public async Task<PagedList<CategoryDto>> GetCategoriesAsync(GetCategoriesInput input)
    {
        var spec = new Specification<Category>(c =>
            (string.IsNullOrEmpty(input.Name) || c.Name.Contains(input.Name)) &&
            (string.IsNullOrEmpty(input.Slug) || (c.Slug != null && c.Slug.Contains(input.Slug)))
        );

        int skip = (input.PageNumber - 1) * input.PageSize;
        int take = input.PageSize;
        IEnumerable<Category> categories = await _unitOfWork.Repository<Category>().GetAllWithSpecAsync(spec, true, skip, take, input.SortBy, input.OrderBy);
        int count = await _unitOfWork.Repository<Category>().GetCountAsync();

        List<CategoryDto> categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

        return new PagedList<CategoryDto>
        {
            Items = categoryDtos,
            TotalRecords = count,
            PageNumber = input.PageNumber,
            PageSize = input.PageSize
        };
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var spec = new Specification<Category>(c => c.Id == id);
        Category? category = await _unitOfWork.Repository<Category>().GetWithSpecAsync(spec, true);
        if (category == null)
        {
            throw new NotFoundException(_localization.Get(Messages.CategoryNotFound));
        }
        return _mapper.Map<CategoryDto>(category);
    }

    public Task<CategoryDto> GetCategoryByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> CreateCategoryAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> UpdateCategoryAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCategoryAsync()
    {
        throw new NotImplementedException();
    }
}
