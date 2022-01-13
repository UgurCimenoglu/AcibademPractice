using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Northwind.DAL.Abstract;
using Northwind.DAL.Concrete.EntityFramework.Repository;
using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Concrete.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Variables

        DbContext context;
        IDbContextTransaction transaction;
        bool _dispose;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public bool BeginTransaction()
        {
            try
            {
                transaction = context.Database.BeginTransaction();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._dispose)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this._dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> GetGenericRepository<T>() where T : EntityBase
        {
            return new GenericRepository<T>(context);
        }

        public bool RollBackTransaction()
        {
            try
            {
                transaction.Rollback();
                transaction = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            var _transaction = transaction != null ? transaction : context.Database.BeginTransaction();

            using (_transaction)
            {
                try
                {
                    if (context == null)
                        throw new ArgumentException("Context is null.");

                    int result = context.SaveChanges();
                    _transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();
                    throw new Exception("Error on save changes", ex);
                }
            }
        }


        #endregion
    }
}
