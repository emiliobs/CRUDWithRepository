namespace CRUDWithRepository.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

        Task<int> SaveAsync();
    }
}