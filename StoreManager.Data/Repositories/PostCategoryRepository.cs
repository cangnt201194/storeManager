using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {//can phai viet them cac phuowng thuc can thiet

    }
    public class PostCategoryRepository:RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(DbFactory dbFactory):base(dbFactory)
        { }

    }
}
