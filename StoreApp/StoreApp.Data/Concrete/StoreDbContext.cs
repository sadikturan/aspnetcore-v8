using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete;

public class StoreDbContext:DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new List<Product>() {
                new() { Id=1, Name="Samsung S24", Price=50000, Description="güzel telefon", Category="Telefon"},
                new() { Id=2, Name="Samsung S25", Price=60000, Description="güzel telefon", Category="Telefon"},
                new() { Id=3, Name="Samsung S26", Price=70000, Description="güzel telefon", Category="Telefon"},
                new() { Id=4, Name="Samsung S27", Price=80000, Description="güzel telefon", Category="Telefon"},
                new() { Id=5, Name="Samsung S28", Price=90000, Description="güzel telefon", Category="Telefon"},
                new() { Id=6, Name="Samsung S29", Price=100000, Description="güzel telefon", Category="Telefon"},
            }
        );
    }
}