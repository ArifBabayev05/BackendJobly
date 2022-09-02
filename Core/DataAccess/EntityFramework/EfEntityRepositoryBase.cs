using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using(var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public  TEntity Get(Expression<Func<TEntity, bool>> filter,params string[] includes)
        {
            using (var context = new TContext())
            {
                var query = filter == null
                   ? context.Set<TEntity>().AsNoTracking()
                   : context.Set<TEntity>().Where(filter).AsNoTracking();
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    };
                }
                var data = query.SingleOrDefault();
                return data;
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params string[] includes)
        {
            using (var context = new TContext())
            {
               var query = filter == null
                    ? context.Set<TEntity>().AsNoTracking()
                    : context.Set<TEntity>().Where(filter).AsNoTracking();
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    };
                }
                var data = query.ToList();
                return data;
                
            }
        }
        

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

