using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;

namespace StoreManager.Data.Repositories
{
    public interface IProductRepository : IRepository<Product> { }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}