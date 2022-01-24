using Northwind.BLL.Base;
using Northwind.DAL.Abstract;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Entity.IBase;
using Northwind.Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Northwind.BLL
{
    public class UserManager : BllBase<User, DtoUser>, IUserService
    {
        private readonly IUserRepository userRepository;
        IConfiguration configuration;
        public UserManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            userRepository = service.GetService<IUserRepository>();
            this.configuration = configuration;
        }

        public IResponse<DtoUserToken> Login(DtoLogin login)
        {
            var user = userRepository.Login(login);

            if (user != null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoLoginUser>(user);
                var token = new TokenManager(configuration).CreateAccessToken(dtoUser);
                var userTokenDto = new DtoUserToken
                {
                    AccessToken = token,
                    User = dtoUser
                };
                return new Response<DtoUserToken>
                {
                    Data = userTokenDto,
                    Message = "Token has been created",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new Response<DtoUserToken>
                {
                    Data = null,
                    Message = "UserCode or password was wrong!",
                    StatusCode = StatusCodes.Status406NotAcceptable
                };
            }
        }
    }
}
