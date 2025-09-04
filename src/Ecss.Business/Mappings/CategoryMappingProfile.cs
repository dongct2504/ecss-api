using AutoMapper;
using Ecss.Business.Dtos.CategoryDtos;
using Ecss.Domain.Entities;

namespace Ecss.Business.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryInput, Category>();
    }
}
