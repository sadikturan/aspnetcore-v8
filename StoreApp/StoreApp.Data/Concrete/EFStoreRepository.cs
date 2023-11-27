using StoreApp.Data.Abstract;

namespace StoreApp.Data.Concrete;

public class EFStoreRepository : IStoreRepository
{
    private StoreDbContext _context;
    public EFStoreRepository(StoreDbContext context)
    {
        _context = context;
    }
    public IQueryable<Product> Products => _context.Products;

    public void CreateProduct(Product entity)
    {
        throw new NotImplementedException();
    }

}