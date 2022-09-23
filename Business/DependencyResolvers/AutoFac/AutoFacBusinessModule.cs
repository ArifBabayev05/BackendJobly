using System;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Entities.Data;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<VacancyManager>().As<IVacancyService>();
            builder.RegisterType<EfVacancyDal>().As<IVacancyDal>();

            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<EfCityDal>().As<ICityDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<EntityRepository>().As<IRepository>().InstancePerLifetimeScope();
        }
    }
}

