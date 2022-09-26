using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfImageDal : EfEntityRepositoryBase<Image, JoblyContext>, IImageDal
    {
        
    }
}

