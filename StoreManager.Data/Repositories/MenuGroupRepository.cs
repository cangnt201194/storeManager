using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Repositories
{
    public interface IMenuGroupRepository
    {//can phai viet them cac phuowng thuc can thiet

    }
    public class MenuGroupRepository:RepositoryBase<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
