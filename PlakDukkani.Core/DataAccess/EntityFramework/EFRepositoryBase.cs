using Microsoft.EntityFrameworkCore;
using PlakDukkani.Core.DataAccess;
using PlakDukkani.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace PlakDukkani.Core.DataAccess.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        TContext context;
        public EFRepositoryBase(TContext context)
        {
            this.context = context;
        }

        public TEntity Add(TEntity entity)
        {
            //context.Albums.Add(album);
            //context.SaveChanges()
            context.Entry(entity).State = EntityState.Added;
            if (context.SaveChanges() > 0)
            {
                return entity;
            }
            return null;
        }
        public TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            if (context.SaveChanges() > 0)
            {
                return entity;
            }
            return null;
        }
        public int Remove(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            //context.Albums.Where(a=>a.IsActive).Include(a=>a.Artist).SingleOrDefault();
            return context.Set<TEntity>().Where(filter).MyInclude(includes).SingleOrDefault();
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            if (filter == null)
            {
                return context.Set<TEntity>().MyInclude(includes).ToList();
            }
            else
            {
                return context.Set<TEntity>().Where(filter).MyInclude(includes).ToList();
            }
        }
    }
}
