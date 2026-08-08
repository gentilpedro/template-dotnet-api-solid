namespace SolidApiTemplate.Application.DTOs;

public record ProductDto(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    int StockQuantity,
    string Status,
    DateTime CreatedAtUtc);

public record CreateProductDto(string Name, string? Description, decimal Price, int StockQuantity);

public record UpdateProductDto(string Name, string? Description, decimal Price, int StockQuantity, bool IsActive);
