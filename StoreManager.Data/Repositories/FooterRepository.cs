using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Repositories
{
    public interface IFooterRepository : IRepository<Footer>
    {//can phai viet them cac phuowng thuc can thiet
       
    }
    public class FooterRepository:RepositoryBase<Footer>,IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
