using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;

namespace StoreManager.Data.Repositories
{
    public interface IOrderDetailRepository
    {//can phai viet them cac phuowng thuc can thiet
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}