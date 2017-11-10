using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreManager.Web.Models
{
    public class ApplicationGroupViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public IEnumerable<ApplicationRoleViewModel> Roles { set; get; }

    }
}