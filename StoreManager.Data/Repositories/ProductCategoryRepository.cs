using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoreManager.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {//can phai viet them cac phuowng thuc can thiet
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>
    {
        public ProductCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}