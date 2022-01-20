using Northwind.BLL.Base;
using Northwind.DAL.Abstract;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Northwind.BLL
{
    public class UserManager : BllBase<User, DtoUser>, IUserService
    {
        private readonly IUserRepository userRepository;
        public UserManager(IServiceProvider service) : base(service)
        {
            userRepository = service.GetService<IUserRepository>();
        }

        public DtoUser Login(DtoLogin login)
        {
            return ObjectMapper.Mapper.Map<DtoUser>(userRepository.Login(login));
        }
    }
}
