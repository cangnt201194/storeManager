using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Repositories
{
    public interface IMenuRepository:IRepository<Menu>
    {//can phai viet them cac phuowng thuc can thiet

    }
    public class MenuRepository:RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory) {
        }
    }
}
