using AutoMapper;
using SolidApiTemplate.Application.DTOs;
using SolidApiTemplate.Domain.Entities;

namespace SolidApiTemplate.Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForCtorParam(nameof(ProductDto.Status), opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
