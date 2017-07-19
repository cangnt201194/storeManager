using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Repositories
{
    public interface IPageRepository : IRepository<Page>
    {//can phai viet them cac phuowng thuc can thiet

    }
    public class PageRepository : RepositoryBase<Page> , IPageRepository
    { 
        public PageRepository(DbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
