using AutoMapper;
using SolidApiTemplate.Application.DTOs;
using SolidApiTemplate.Application.Interfaces;
using SolidApiTemplate.Common;
using SolidApiTemplate.Domain.Entities;
using SolidApiTemplate.Domain.Enums;

namespace SolidApiTemplate.Application.Services;

public class ProductService(IProductRepository repository, IMapper mapper) : IProductService
{
    public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await repository.GetAllAsync(cancellationToken);
        return mapper.Map<IReadOnlyList<ProductDto>>(products);
    }

    public async Task<ProductDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException($"Produto '{id}' não encontrado.");

        return mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto, CancellationToken cancellationToken = default)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            StockQuantity = dto.StockQuantity
        };

        await repository.AddAsync(product, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto dto, CancellationToken cancellationToken = default)
    {
        var product = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException($"Produto '{id}' não encontrado.");

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.StockQuantity = dto.StockQuantity;
        product.Status = dto.IsActive ? ProductStatus.Active : ProductStatus.Inactive;

        repository.Update(product);
        await repository.SaveChangesAsync(cancellationToken);

        return mapper.Map<ProductDto>(product);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException($"Produto '{id}' não encontrado.");

        repository.Remove(product);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
