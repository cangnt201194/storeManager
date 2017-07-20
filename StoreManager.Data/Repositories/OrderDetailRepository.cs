using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;

namespace StoreManager.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {//can phai viet them cac phuowng thuc can thiet
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}