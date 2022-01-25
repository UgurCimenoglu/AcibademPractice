using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entity.Base;
using Northwind.Entity.Dto;
using Northwind.Entity.IBase;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IResponse<DtoUserToken> Login(DtoLogin user)
        {
            try
            {
                return userService.Login(user);
            }
            catch (Exception e)
            {

                return new Response<DtoUserToken>
                {
                    Data = null,
                    Message = $"Error: {e.Message}",
                    StatusCode = StatusCodes.Status406NotAcceptable
                };
            }
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IResponse<DtoUserForRegister> Register(DtoUserForRegister user)
        {
            try
            {
                return userService.Register(user);
            }
            catch (Exception e)
            {
                return new Response<DtoUserForRegister>
                {
                    Data = null,
                    Message = $"Error: {e.Message}",
                    StatusCode = StatusCodes.Status406NotAcceptable
                };

            }

        }
    }
}
