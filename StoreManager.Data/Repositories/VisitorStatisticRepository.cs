using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Repositories
{
   public  class VisitorStatisticRepository:RepositoryBase<VisitorStatistic>
    {
        public VisitorStatisticRepository(DbFactory dbFactory):base(dbFactory)
        { }
    }
}
