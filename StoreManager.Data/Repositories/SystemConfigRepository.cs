using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Repositories
{
    public interface ISystemConfigRepository : IRepository<SystemConfig>
    {//can phai viet them cac phuowng thuc can thiet

    }
    public class SystemConfigRepository:RepositoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
