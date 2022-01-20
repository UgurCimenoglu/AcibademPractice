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
    public class OrderManager : BllBase<Order, DtoOrder>, IOrderService
    {
        public readonly IOrderRepository orderRepository;
        public OrderManager(IServiceProvider service) : base(service)
        {
        }

        public IQueryable OrderReport(int orderId)
        {
            return orderRepository.OrderReport(orderId);
        }
    }
}
