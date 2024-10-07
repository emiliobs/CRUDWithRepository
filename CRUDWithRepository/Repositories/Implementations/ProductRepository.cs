using CRUDWithRepository.DAL;
using CRUDWithRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithRepository.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly MyDbContext _myDbContext;

    public ProductRepository(MyDbContext myDbContext)
    {
        this._myDbContext = myDbContext;
    }

    public async Task Add(Product product)
    {
        _myDbContext.Products.Add(product);
        await _myDbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var product = await _myDbContext.Products.FindAsync(id);
        if (product is not null)
        {
            _myDbContext.Remove(product);
            await _myDbContext.SaveChangesAsync();
        }
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _myDbContext.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _myDbContext.Products.ToListAsync();
    }

    public async Task Update(Product product)
    {
        _myDbContext.Entry(product).State = EntityState.Modified;
        //_myDbContext.Update(product);
        await _myDbContext.SaveChangesAsync();
    }
}