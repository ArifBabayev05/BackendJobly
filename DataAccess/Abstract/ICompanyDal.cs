using System;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Models;

namespace DataAccess.Abstract
{
    public interface ICompanyDal : IEntityRepository<Company>
    {
    }
}

