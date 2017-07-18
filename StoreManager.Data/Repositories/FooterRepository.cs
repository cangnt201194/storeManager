using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Repositories
{
    public interface IFooterRepository
    {//can phai viet them cac phuowng thuc can thiet
       
    }
    public class FooterRepository:RepositoryBase<Footer>
    {
        public FooterRepository(DbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
