using CRUDWithRepository.Models;

namespace CRUDWithRepository.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProductById(int id);

        Task Add(Product product);

        Task Update(Product product);

        Task Delete(int id);
    }
}