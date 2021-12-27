using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        bool BeginTransaction();
        bool RollBackTransaction();
        int SaveChanges();
    }
}
