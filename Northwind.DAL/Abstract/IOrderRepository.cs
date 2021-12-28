using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.DAL.Abstract
{
    public interface IOrderRepository
    {
        IQueryable OrderReport(int orderId);
    }
}
