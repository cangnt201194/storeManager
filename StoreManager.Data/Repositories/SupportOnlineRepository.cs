using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Repositories
{
    public interface ISupportOnlineRepository : IRepository<SupportOnline>
    {//can phai viet them cac phuowng thuc can thiet

    }
    public class SupportOnlineRepository:RepositoryBase<SupportOnline>, ISupportOnlineRepository
    {
        public SupportOnlineRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
