using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.DAL.Abstract
{
    public interface ICustomerRepository
    {
        IQueryable CustomerReport();
        Customer GetCustomerByStringId(string id); 
    }
}
