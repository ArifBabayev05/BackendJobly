using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Core.Entities.Concrete;
using Entities.Models;

namespace DataAccess.Concrete
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, JoblyContext>, ICompanyDal
    {
       
       
    }
}

