﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using StoreManager.Data.Infrastructure;
using StoreManager.Data;
using StoreManager.Data.Repositories;
using StoreManager.Service;
using System.Web.Mvc;
using Autofac.Integration.WebApi;
using System.Web.Http;

[assembly: OwinStartup(typeof(StoreManager.Web.App_Start.Startup))]

namespace StoreManager.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            //cac đối tượng controller khi khởi tạo sẽ khởi tạo các type
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            //mỗi khi có class gọi đến class tương ứng sẽ tự động khởi tạo
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<StoreManagerDbContext>().AsSelf().InstancePerRequest();


            // Repositories
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces().InstancePerRequest();


            // Services
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}
