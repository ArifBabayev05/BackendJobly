using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter,params string[] includes);
        IList<T> GetList(Expression<Func<T, bool>> filter = null, params string[] includes);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}

