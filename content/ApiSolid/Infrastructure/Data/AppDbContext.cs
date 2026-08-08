using Microsoft.EntityFrameworkCore;
using SolidApiTemplate.Domain.Entities;

namespace SolidApiTemplate.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(builder =>
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.Property(p => p.Status).HasConversion<string>().HasMaxLength(20);
        });

        base.OnModelCreating(modelBuilder);
    }
}
