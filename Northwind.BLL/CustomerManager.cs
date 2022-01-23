using Northwind.BLL.Base;
using Northwind.DAL.Abstract;
using Northwind.Entity.Dto;
using Northwind.Entity.IBase;
using Northwind.Entity.Base;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Northwind.BLL
{
    public class CustomerManager : BllBase<Customer, DtoCustomer>, ICustomerService
    {
        public readonly ICustomerRepository customerRepository;

        public CustomerManager(IServiceProvider service) : base(service)
        {
            customerRepository = service.GetService<ICustomerRepository>();
        }

        public IQueryable CustomerReport()
        {
            return customerRepository.CustomerReport();
        }

        public IResponse<DtoCustomer> GetCustomerByStringId(string id)
        {
            try
            {
                return new Response<DtoCustomer>
                {
                    Data = ObjectMapper.Mapper.Map<DtoCustomer>(customerRepository.GetCustomerByStringId(id)),
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception e)
            {
                return new Response<DtoCustomer>
                {
                    Data = null,
                    Message = $"Error: {e.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
        }
    }
}
