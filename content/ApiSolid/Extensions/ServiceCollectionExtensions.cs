using FluentValidation;
using SolidApiTemplate.Application.Interfaces;
using SolidApiTemplate.Application.Mappings;
using SolidApiTemplate.Application.Services;
using SolidApiTemplate.Application.Validators;
using SolidApiTemplate.Infrastructure.Auth;
using SolidApiTemplate.Infrastructure.Repositories;

namespace SolidApiTemplate.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<ProductMappingProfile>());
        services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidator>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
