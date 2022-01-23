using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Abstract;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.DAL.Concrete.EntityFramework.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }

        public IQueryable CustomerReport()
        {
            return dbSet.AsQueryable();
        }

        public Customer GetCustomerByStringId(string id)
        {
            return dbSet.Find(id);
        }
    }
}
