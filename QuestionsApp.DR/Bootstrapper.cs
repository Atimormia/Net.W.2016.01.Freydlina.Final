using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QuestionsApp.BLL.Services;
using QuestionsApp.ORM.Model;
using QuestionsApp.DAL.Concrete;
using QuestionsApp.DAL.Infrastructure;
using QuestionsApp.DAL.Interface.Infrastructure;
using QuestionsApp.DR.Authentication;
using QuestionsApp.DR.Mapping;
using QuestionsApp.ORM.EF;

namespace QuestionsApp.DR
{
    public static class Bootstrapper
    {
        public static void Run(Type mvcType)
        {
            System.Data.Entity.Database.SetInitializer(new QuestionsAppSampleData());
            SetAutofacContainer(mvcType);
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();

        }
        private static void SetAutofacContainer(Type mvcType)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(mvcType.Assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof (AppUserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof (LectionHeaderService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof (DefaultFormsAuthentication).Assembly)
                .Where(t => t.Name.EndsWith("Authentication"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>( new ApplicationDbContext())))
                .As<UserManager<ApplicationUser>>().InstancePerRequest();
            builder.Register(c => new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new ApplicationDbContext())))
                .As<RoleManager<ApplicationRole>>().InstancePerRequest();

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}