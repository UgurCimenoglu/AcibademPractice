using Northwind.BLL.Base;
using Northwind.DAL.Abstract;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.BLL
{
    public class CustomerManager : BllBase<Customer, DtoCustomer>, ICustomerService
    {
        public readonly ICustomerRepository customerRepository;

        public CustomerManager(IServiceProvider service) : base(service)
        {
        }

        public IQueryable CustomerReport()
        {
            return customerRepository.CustomerReport();
        }
    }
}
