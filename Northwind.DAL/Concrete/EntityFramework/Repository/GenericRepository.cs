using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Abstract;
using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.DAL.Concrete.EntityFramework.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        #region Variables
        protected DbContext context;
        protected DbSet<T> dbSet;
        #endregion

        #region Constructor
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
            //this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        #endregion

        #region Methods
        public T Add(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            dbSet.Add(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            return Delete(Find(id));
        }

        public bool Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Attach(entity);
            }
            return dbSet.Remove(entity) != null;
        }

        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public T Update(T entity)
        {
            dbSet.Update(entity);
            return entity;
        }
        #endregion

    }
}
