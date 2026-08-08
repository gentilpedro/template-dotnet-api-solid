using SolidApiTemplate.Domain.Entities;

namespace SolidApiTemplate.Application.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
    void Update(Product product);
    void Remove(Product product);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
