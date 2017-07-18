﻿using StoreManager.Data.Infrastructure;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Repositories
{
    public class PageRepository : RepositoryBase<Page> 
    { 
        public PageRepository(DbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
