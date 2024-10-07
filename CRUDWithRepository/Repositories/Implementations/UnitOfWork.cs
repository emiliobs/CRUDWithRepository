using CRUDWithRepository.DAL;

namespace CRUDWithRepository.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _myDbContext;

        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
            ProductRepository = new ProductRepository(_myDbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await _myDbContext.SaveChangesAsync();
        }
    }
}